using CoreGraphics;
using Foundation;
using MapsuiForms;
using MapsuiForms.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MapsuiView), typeof(MapViewRenderer))]
namespace MapsuiForms.iOS
{
    [Preserve(AllMembers = true)]
    public class MapViewRenderer : ViewRenderer
    {
        Mapsui.UI.iOS.MapControl mapNativeControl;
        MapsuiView mapViewControl = null;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (mapViewControl == null && e.NewElement != null)
            {
                mapViewControl = (MapsuiView)e.NewElement;
            }

            if (mapNativeControl == null && mapViewControl != null)
            {
                var rectangle = mapViewControl.Bounds;
                var rect = new CGRect(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

                mapNativeControl = new Mapsui.UI.iOS.MapControl(rect);
                mapNativeControl.Map = mapViewControl.NativeMap;
                mapNativeControl.Frame = rect;

                SetNativeControl(mapNativeControl);
            }
        }
    }
}