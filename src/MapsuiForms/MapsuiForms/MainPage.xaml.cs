using Mapsui.Geometries;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.Utilities;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MapsuiForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
        {
            InitializeComponent();

            var mapControl = new MapsuiView();
            mapControl.NativeMap.Layers.Add(OpenStreetMap.CreateTileLayer());
            mapControl.NativeMap.CRS = "EPSG:3857";
            mapControl.NativeMap.Transformation = new MinimalTransformation();
            var polys = GetSamplePolygonsLatLon();
            mapControl.NativeMap.Layers.Add(CreateLayer(polys, Mapsui.Styles.Color.Red, Mapsui.Styles.Color.Black));
            ContentGrid.Children.Add(mapControl);
        }

        private static List<Polygon> GetSamplePolygonsLatLon()
        {
            var p = new Polygon();
            p.ExteriorRing.Vertices.Add(new Mapsui.Geometries.Point(4.9642583, 52.151205));
            p.ExteriorRing.Vertices.Add(new Mapsui.Geometries.Point(5.2154863, 52.193423));
            p.ExteriorRing.Vertices.Add(new Mapsui.Geometries.Point(5.2939013, 51.994378));
            p.ExteriorRing.Vertices.Add(new Mapsui.Geometries.Point(4.8729163, 51.970706));
            p.ExteriorRing.Vertices.Add(new Mapsui.Geometries.Point(4.9642583, 52.151205));

            var polys = new List<Polygon> { p };
            return polys;
        }

        public static ILayer CreateLayer(List<Polygon> polys, Mapsui.Styles.Color fillColor, Mapsui.Styles.Color outlineColor)
        {
            return new Layer("Polygons")
            {
                DataSource = new MemoryProvider(polys) { CRS = "EPSG:4326" },
                Style = new VectorStyle
                {
                    Fill = new Brush(fillColor),
                    Outline = new Pen
                    {
                        Color = outlineColor,
                        Width = 4,
                        PenStyle = PenStyle.Solid,
                        PenStrokeCap = PenStrokeCap.Round
                    }
                }
            };
        }
    }
}
