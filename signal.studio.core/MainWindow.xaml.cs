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

namespace SignalStudio.Core {
    public partial class MainWindow : Window {
        public MainWindow() {
            this.InitializeComponent();
            tool.AddTool<bool>(ToolPosition.LeftTop, "Solution");
            tool.AddTool<bool>(ToolPosition.LeftBottom, "Settings");
            tool.AddTool<bool>(ToolPosition.RightTop, "RightTop");
            tool.AddTool<bool>(ToolPosition.RightBottom, "RightBottom");
            tool.AddTool<bool>(ToolPosition.BottomLeft, "Terminal");
            tool.AddTool<bool>(ToolPosition.BottomRight, "BottomRight");
            tool.AddTool<bool>(ToolPosition.TopLeft, "TopLeft");
            tool.AddTool<bool>(ToolPosition.TopRight, "TopRight");
        }
    }
}
