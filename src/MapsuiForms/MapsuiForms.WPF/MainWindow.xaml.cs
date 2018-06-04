using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace MapsuiForms.WPF
{
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            Forms.Init();
            LoadApplication(new MapsuiForms.App());
        }
    }
}
