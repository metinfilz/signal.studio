using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
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

        private void Setting_Click(object sender, RoutedEventArgs e) {
            var button = sender as Button;
            var move = new MenuItem { Header = "Move to" };
            _ = move.Items.Add(new MenuItem { Header = "Left Top" });
            _ = move.Items.Add(new MenuItem { Header = "Left Bottom" });
            _ = move.Items.Add(new MenuItem { Header = "Bottom Left" });
            _ = move.Items.Add(new MenuItem { Header = "Bottom Right" });
            _ = move.Items.Add(new MenuItem { Header = "Right Top" });
            _ = move.Items.Add(new MenuItem { Header = "Right Bottom" });
            _ = move.Items.Add(new MenuItem { Header = "Top Left" });
            _ = move.Items.Add(new MenuItem { Header = "Top Right" });
            var context = new ContextMenu();
            _ = context.Items.Add(move);
            button.ContextMenu = context;
            button.ContextMenu.IsOpen = true;
            Debug.WriteLine(Position);
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
