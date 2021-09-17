using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Signal.Studio.Workspace.Store;

namespace Signal.Studio.Workspace {
    public class ToolStore {
        public ToolState State { get; } = new ToolState();
        public ToolAction Action { get; }
        public string SaveFile { get; set; }
        public ToolStore() {
            Action = new ToolAction(State);
        }
    }
}
