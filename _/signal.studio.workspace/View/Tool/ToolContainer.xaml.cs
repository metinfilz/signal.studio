using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Signal.Studio.Workspace.Context;
using Signal.Studio.Workspace.Model;
using Signal.Studio.Workspace.Utils;

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

        private void ToggleButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            var control = sender as ToggleButton;
            var tool = (IToolModel)control.Tag;
            if ((bool)control.IsChecked) {
                if (tool.ViewMode == ToolViewMode.Dock) {
                    var view = (UserControl)Activator.CreateInstance(tool.Type);
                    if((double)Store.Instance.ToolState.SizesCache[tool.Position].Get() == 1) {
                        Store.Instance.ToolState.SizesCache[tool.Position].Set(view.MinWidth);
                    }
                    view.MinWidth = 0;
                    Store.Instance.ToolState.ToolDocks[tool.Position].Set(view);
                    Store.Instance.ToolState.Visibles[tool.Position].Set(true);
                }
                else if (tool.ViewMode == ToolViewMode.Window) {
                    var view = new ToolWindow { ToolModel = tool };
                    view.Configure();
                }
            }
            else {
                if (tool.ViewMode == ToolViewMode.Dock) {
                    Store.Instance.ToolState.ToolDocks[tool.Position].Set(null);
                    Store.Instance.ToolState.Visibles[tool.Position].Set(false);
                }
                else if (tool.ViewMode == ToolViewMode.Window) {
                    Store.Instance.ToolState.ToolWindows.FindAll(i => i.ToolModel == tool).ForEach(i => {
                        i.Close();
                    });
                }
            }
        }
    }
}
