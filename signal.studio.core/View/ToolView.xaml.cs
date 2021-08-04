﻿using System;
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
    public partial class ToolView : UserControl {
        internal event EventHandler ToolCloseRequest;
        private void OnToolCloseRequest() {
            ToolCloseRequest?.Invoke(this, EventArgs.Empty);
        }
        public ToolView() {
            InitializeComponent();
        }
    }
}
