using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal.Studio.Workspace {
    public class ToolStore {
        public ToolState State { get; } = new ToolState();
        public ToolAction Action { get; }

        public ToolStore() {
            Action = new ToolAction(State);
        }
    }
}
