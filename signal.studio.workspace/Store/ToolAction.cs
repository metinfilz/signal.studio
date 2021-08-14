using Signal.Studio.Workspace.Common;
using System;
using System.Linq;
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
        }
    }
}
