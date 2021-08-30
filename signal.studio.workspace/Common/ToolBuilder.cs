using System.Collections.Generic;
using Signal.Studio.Workspace.Context;
using Signal.Studio.Workspace.Model;
using Signal.Studio.Workspace.Utils;

namespace Signal.Studio.Workspace.Common {
    public class ToolBuilder {
        public IToolModel Construct<T>(ToolPosition position, string header = "Default", ToolViewMode viewMode = ToolViewMode.Dock, bool isOpen = false) where T : ITool {
            var tool = new ToolModel(typeof(T), this) {
                Position = position,
                Header = header,
                ViewMode = viewMode,
                isOpen = isOpen
            };
            return tool;
        }
        public List<IToolModel> Tools { get; } = new List<IToolModel>();
        internal void Add(ToolModel tool) {
            Tools.Add(tool);
        }
        public void AddDefaultTools() {
            Store.Instance.ToolAction.AddDefaultTools(Tools);
        }
    }
}
