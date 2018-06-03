using Android.Content;
using MapsuiForms;
using MapsuiForms.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MapsuiView), typeof(MapViewRenderer))]
namespace MapsuiForms.Droid
{
    public class MapViewRenderer : ViewRenderer
    {
        Mapsui.UI.Android.MapControl mapNativeControl;
        MapsuiView mapViewControl;

        public MapViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (mapViewControl == null && e.NewElement != null)
                mapViewControl = (MapsuiView)e.NewElement;

            if (mapNativeControl == null && mapViewControl != null)
            {
                mapNativeControl = new Mapsui.UI.Android.MapControl(Context, null);
                mapNativeControl.Map = mapViewControl.NativeMap;

                SetNativeControl(mapNativeControl);
            }
        }
    }
}