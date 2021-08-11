using System;
using System.Windows;
using System.Windows.Input;

namespace SignalStudio.Core {
    public partial class MainView : Window {
        public MainView() {
            InitializeComponent();
            StateChanged += MainViewStateChanged;
            tool.AddTool<bool>(ToolPosition.LeftTop, "Solution");
            tool.AddTool<bool>(ToolPosition.LeftBottom, "Settings");
            tool.AddTool<bool>(ToolPosition.RightTop, "RightTop");
            tool.AddTool<bool>(ToolPosition.RightBottom, "RightBottom");
            tool.AddTool<bool>(ToolPosition.BottomLeft, "Terminal");
            tool.AddTool<bool>(ToolPosition.BottomRight, "BottomRight");
            tool.AddTool<bool>(ToolPosition.TopLeft, "TopLeft");
            tool.AddTool<bool>(ToolPosition.TopRight, "TopRight");
        }

    }
    public partial class MainView {
        private void CommandCanExecute(object s, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void CommandMinimize(object s, ExecutedRoutedEventArgs e) => SystemCommands.MinimizeWindow(this);
        private void CommandMaximize(object s, ExecutedRoutedEventArgs e) => SystemCommands.MaximizeWindow(this);
        private void CommandRestore(object s, ExecutedRoutedEventArgs e) => SystemCommands.RestoreWindow(this);
        private void CommandClose(object s, ExecutedRoutedEventArgs e) => SystemCommands.CloseWindow(this);
        private void MainViewStateChanged(object s, EventArgs e) {
            if (WindowState == WindowState.Maximized) {
                border.BorderThickness = new Thickness(8);
                RestoreButton.Visibility = Visibility.Visible;
                MaximizeButton.Visibility = Visibility.Collapsed;
            } else {
                border.BorderThickness = new Thickness(0);
                RestoreButton.Visibility = Visibility.Collapsed;
                MaximizeButton.Visibility = Visibility.Visible;
            }
        }
    }
}
