using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Signal.Studio.Workspace.Common;
using Signal.Studio.Workspace.Service;

namespace Signal.Studio.Workspace.View {
    internal partial class ToolPanel : UserControl {
        public IStoreService Store { get; }
        public ToolPanel() {
            InitializeComponent();
            Store = Resolver.Resolve<IStoreService>();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) {
            Store.ToolStore.Action.CloseTool(Position);
        }
    }
    internal partial class ToolPanel {
        public static DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(ToolPosition), typeof(ToolPanel));
        public ToolPosition Position {
            get => (ToolPosition)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }
    }
}
