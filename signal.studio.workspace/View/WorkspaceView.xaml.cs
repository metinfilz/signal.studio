using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Signal.Studio.Workspace.Context;

namespace Signal.Studio.Workspace.View {
    public partial class WorkspaceView : UserControl {
        public WorkspaceView() {
            InitializeComponent();
        }

        private void ToolVisible_Click(object sender, RoutedEventArgs e) {
            var control = sender as ToggleButton;
            Store.Instance.ToolAction.ChangeToolButtonVisibility((bool)control.IsChecked);
        }
    }
}
