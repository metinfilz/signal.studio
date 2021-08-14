using Signal.Studio.Workspace.Service;
using System.Windows.Controls;

namespace Signal.Studio.Workspace.View {
    public partial class ToolContainer : UserControl {
        public IStoreService Store { get; }


        public ToolStore ToolStore => Store.ToolStore;
        public ToolContainer() {
            Store = Resolver.Resolve<IStoreService>();
            InitializeComponent();
        }
    }
}
