using System.Windows;

namespace Duget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            System.Diagnostics.Debugger.Launch();
            InitializeComponent();
        }
    }
}
