using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Signal.Studio.Workspace.Context;
using Signal.Studio.Workspace.Model;

namespace Signal.Studio.Workspace.View {
    internal partial class ToolWindow : Window {
        private ToolState State => Store.Instance.ToolState;
        public ToolWindow() {
            InitializeComponent();

        }
        public void Configure() {
            var status = State.ToolWindowsState.TryGetValue(ToolModel.Type, out var value);
            var content = (UserControl)Activator.CreateInstance(ToolModel.Type);
            if (status) {
                Width = value.width;
                Height = value.height;
                Top = value.top;
                Left = value.left;
                Title = ToolModel.Header;
            }
            else {
                Width = content.MinWidth > Width ? content.MinWidth : Width;
                Height = content.MinHeight > Height ? content.MinHeight : Height;
                Title = ToolModel.Header;
            }
            content.MinHeight = 0;
            content.MinWidth = 0;
            State.ToolWindows.Add(this);
            container.Content = content;
            Show();
        }

        public IToolModel ToolModel { get; internal set; }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            if (State.ToolWindowsState.ContainsKey(ToolModel.Type)) {
                State.ToolWindowsState[ToolModel.Type] = (Width, Height, Top, Left);
            }
            else {
                State.ToolWindowsState.Add(ToolModel.Type, (Width, Height, Top, Left));
            }
        }
        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            Store.Instance.ToolState.Buttons[ToolModel.Position].Where(i => ((ToolToggleButton)i).ToolModel.Type == ToolModel.Type).ToList().ForEach(i => i.IsChecked = false);
            _ = Store.Instance.ToolState.ToolWindows.Remove(this);
        }


        private void Dock_Click(object sender, RoutedEventArgs e) {

        }
        private void Close_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
