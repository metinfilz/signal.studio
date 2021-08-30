using System.Diagnostics;
using System.Windows;
using Signal.Studio.Workspace.Context;

namespace Signal.Studio.Workspace {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var store = Store.Instance;
            Debug.WriteLine(store.ToolState.Tools.Count);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {

        }
    }
}
