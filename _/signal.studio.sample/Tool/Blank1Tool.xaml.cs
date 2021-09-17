using System.Diagnostics;
using System.Windows.Controls;
using Signal.Studio.Workspace.Common;

namespace Signal.Studio.Sample.Tool {
    public partial class Blank1Tool : UserControl{
        public Blank1Tool() {
            Debug.WriteLine("Construct " + GetHashCode());
            InitializeComponent();
            Loaded += (s, e) => {
                Debug.WriteLine("Loaded " + GetHashCode());
            };
            Unloaded += (s, e) => {
                Debug.WriteLine("Unloaded " + GetHashCode());
            };
        }
        ~Blank1Tool() {
            Debug.WriteLine("Destruct " + GetHashCode());
        }
    }
    public partial class Blank1Tool : ITool {

    }
}
