using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class ToolPanelView : UserControl {
        internal event EventHandler ToolCloseRequest;
        public RelayCommand CloseCommand { get; }
        private void OnToolCloseRequest() {
            ToolCloseRequest?.Invoke(this, EventArgs.Empty);
        }

        public ToolPanelView() {
            CloseCommand = new RelayCommand(t => OnToolCloseRequest());
            InitializeComponent();
        }
    }
    public partial class ToolPanelView {
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(ToolPosition), typeof(ToolPanelView), new PropertyMetadata(ToolPosition.LeftTop));
        public ToolPosition Position { get { return (ToolPosition)GetValue(PositionProperty); } set { SetValue(PositionProperty, value); } }
    }
}
