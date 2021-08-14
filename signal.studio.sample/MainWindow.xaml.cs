using Signal.Studio.Sample.Tool;
using Signal.Studio.Workspace.Common;
using Signal.Studio.Workspace.Service;
using System;
using System.Collections.Generic;
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

namespace Signal.Studio.Sample {
    public partial class MainWindow : Window {
        private IStoreService Store { get; }
        public MainWindow() {
            InitializeComponent();
            Store = Resolver.Resolve<IStoreService>();

            Store.ToolStore.Action.AddTool(ToolPosition.LeftTop, typeof(BlankTool), "LeftTop");
            Store.ToolStore.Action.AddTool(ToolPosition.LeftBottom, typeof(BlankTool), "LeftBottom");
            Store.ToolStore.Action.AddTool(ToolPosition.RightTop, typeof(BlankTool), "RightTop");
            Store.ToolStore.Action.AddTool(ToolPosition.RightBottom, typeof(BlankTool), "RightBottom");
            Store.ToolStore.Action.AddTool(ToolPosition.TopLeft, typeof(BlankTool), "TopLeft");
            Store.ToolStore.Action.AddTool(ToolPosition.TopRight, typeof(BlankTool), "TopRight");
            Store.ToolStore.Action.AddTool(ToolPosition.BottomLeft, typeof(BlankTool), "BottomLeft");
            Store.ToolStore.Action.AddTool(ToolPosition.BottomRight, typeof(BlankTool), "BottomRight");
            Store.ToolStore.Action.AddTool(ToolPosition.LeftTop, typeof(BlankTool), "LeftTop");
            Store.ToolStore.Action.AddTool(ToolPosition.LeftBottom, typeof(BlankTool), "LeftBottom");
            Store.ToolStore.Action.AddTool(ToolPosition.RightTop, typeof(BlankTool), "RightTop");
            Store.ToolStore.Action.AddTool(ToolPosition.RightBottom, typeof(BlankTool), "RightBottom");
            Store.ToolStore.Action.AddTool(ToolPosition.TopLeft, typeof(BlankTool), "TopLeft");
            Store.ToolStore.Action.AddTool(ToolPosition.TopRight, typeof(BlankTool), "TopRight");
            Store.ToolStore.Action.AddTool(ToolPosition.BottomLeft, typeof(BlankTool), "BottomLeft");
            Store.ToolStore.Action.AddTool(ToolPosition.BottomRight, typeof(BlankTool), "BottomRight");
        }
    }
}
