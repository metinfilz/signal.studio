namespace Signal.Studio.Workspace.Context {
    public sealed class Store {
        public ToolAction ToolAction { get; }
        public ToolState ToolState { get; }
        static Store() {
        }

        private Store() {
            ToolState = new ToolState();
            ToolAction = new ToolAction(ToolState);
        }
        public static Store Instance { get; } = new();
    }
}
