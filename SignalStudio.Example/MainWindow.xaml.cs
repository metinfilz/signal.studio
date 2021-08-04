using SignalStudio.Core;
using SignalStudio.Example.Tool;
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

namespace SignalStudio.Example {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();


            SignalStudio.AddTool<SolutionTool>(ToolPosition.LeftTop, "Solution");
            SignalStudio.AddTool<SolutionTool>(ToolPosition.LeftBottom, "Settings");
            SignalStudio.AddTool<SolutionTool>(ToolPosition.LeftBottom, "Device");
            SignalStudio.AddTab("Test");
        }
    }
}
