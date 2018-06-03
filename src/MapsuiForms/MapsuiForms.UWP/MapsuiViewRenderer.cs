using MapsuiForms;
using MapsuiForms.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MapsuiView), typeof(MapViewRenderer))]
namespace MapsuiForms.UWP
{
    public class MapViewRenderer : ViewRenderer<MapsuiView, Mapsui.UI.Uwp.MapControl>
    {
        Mapsui.UI.Uwp.MapControl mapNativeControl;
        MapsuiView mapViewControl;

        protected override void OnElementChanged(ElementChangedEventArgs<MapsuiView> e)
        {
            base.OnElementChanged(e);

            if (mapViewControl == null && e.NewElement != null)
                mapViewControl = e.NewElement;

            if (mapNativeControl == null && mapViewControl != null)
            {
                mapNativeControl = new Mapsui.UI.Uwp.MapControl();
                mapNativeControl.Map = mapViewControl.NativeMap;

                SetNativeControl(mapNativeControl);
            }
        }
    }
}