using Signal.Studio.Workspace.Common;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Signal.Studio.Workspace {
    public class ToolAction {
        public ToolState State { get; }
        public ToolAction(ToolState state) {
            State = state;
        }
        internal void CloseTool(ToolPosition position) {
            State.Visibilities[position].Set(false);
            State.Panels[position].content.Children.Clear();
            State.Buttons[position].ToList().ForEach(i => i.IsChecked = false);
            State.Tools.FindAll(i => i.Position == position).ForEach(i => i.Visibility = false);
        }

        internal void OpenTool(ToolPosition position, ToggleButton button) {
            var type = (Type)button.Tag;
            var view = (UserControl)Activator.CreateInstance(type);
            State.Visibilities[position].Set(true);
            var config = (IToolBase)view;
            State.Panels[position].content.Children.Clear();
            State.Panels[position].content.Children.Add(view);
            State.Panels[position].header.Text = config.ToolPanelHeader;
            State.Buttons[position].ToList().ForEach(i => i.IsChecked = false);
            State.Tools.FindAll(i => i.Position == position).ForEach(i => i.Visibility = false);
            State.Tools.FindAll(i => i.Type.Equals(type)).ForEach(i => i.Visibility = true);
            button.IsChecked = true;
        }
    }
}
