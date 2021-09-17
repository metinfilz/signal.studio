using Signal.Studio.Workspace.Common;
using Signal.Studio.Workspace.Repositories;

namespace Signal.Studio.Workspace.Context {
    public sealed class Store {
        public (IToolState State, IToolAction Action) Tools { get; }

        public ToolAction ToolAction { get; }
        public ToolState ToolState { get; }
        static Store() {
        }

        private Store() {
            ToolState = new ToolState();
            ToolAction = new ToolAction(ToolState);
            Tools = (ToolState, ToolAction);
        }
        public static Store Instance { get; } = new();
    }
}
