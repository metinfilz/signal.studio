using System.Windows;
using System.Windows.Controls;
using Signal.Studio.Workspace.Context;
using Signal.Studio.Workspace.Utils;

namespace Signal.Studio.Workspace.View {
    internal partial class ToolDock : UserControl {
        public ToolDock() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var store = Store.Instance;
            store.ToolAction.CloseTool(Position);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            var store = Store.Instance;
            store.ToolAction.MoveTool(ToolPosition.LeftBottom);
        }
    }
    internal partial class ToolDock {
        public static DependencyProperty ToolContentProperty = DependencyProperty.Register("ToolContent", typeof(UserControl), typeof(ToolDock));
        public UserControl ToolContent {
            get => (UserControl)GetValue(ToolContentProperty);
            set => SetValue(ToolContentProperty, value);
        }
        public static DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(ToolPosition), typeof(ToolDock));
        public ToolPosition Position {
            get => (ToolPosition)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }
    }
}
