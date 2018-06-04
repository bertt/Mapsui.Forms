using MapsuiForms;
using Xamarin.Forms.Platform.WPF;
using MapsuiForms.WPF;

[assembly: ExportRenderer(typeof(MapsuiView), typeof(MapViewRenderer))]
namespace MapsuiForms.WPF
{
    public class MapViewRenderer: ViewRenderer<MapsuiView, Mapsui.UI.Wpf.MapControl>
    {
        Mapsui.UI.Wpf.MapControl mapNativeControl;
        MapsuiView mapViewControl;

        protected override void OnElementChanged(ElementChangedEventArgs<MapsuiView> e)
        {
            base.OnElementChanged(e);

            if (mapViewControl == null && e.NewElement != null)
                mapViewControl = e.NewElement;

            if (mapNativeControl == null && mapViewControl != null)
            {
                mapNativeControl = new Mapsui.UI.Wpf.MapControl();
                mapNativeControl.Map = mapViewControl.NativeMap;

                SetNativeControl(mapNativeControl);
            }
        }

    }
}
