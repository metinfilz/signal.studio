using System.Windows.Controls;
using Signal.Studio.Workspace.Context;

namespace Signal.Studio.Workspace.View {
    internal partial class ToolContainer : UserControl {
        public ToolContainer() {
            InitializeComponent();
            var store = Store.Instance;
            DataContext = store.ToolState;
            leftGrid.DragStarted += (s, e) => {
                var max = center.ActualWidth - right.Width.Value - 12;
                left.MaxWidth = max;
            };
            rightGrid.DragStarted += (s, e) => {
                var max = center.ActualWidth - left.Width.Value - 12;
                right.MaxWidth = max;
            };
            topSplitter.DragStarted += (s, e) => {
                var max = middlle.ActualHeight - bottom.Height.Value - 12;
                top.MaxHeight = max;
            };
            bottomSplitter.DragStarted += (s, e) => {
                var max = middlle.ActualHeight - top.Height.Value - 12;
                bottom.MaxHeight = max;
            };
        }
    }
}
