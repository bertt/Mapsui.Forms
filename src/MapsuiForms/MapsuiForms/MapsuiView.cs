namespace MapsuiForms
{
    public class MapsuiView : Xamarin.Forms.View
    {
        public Mapsui.Map NativeMap { get; }

        protected internal MapsuiView()
        {
            NativeMap = new Mapsui.Map();
        }
    }
}
