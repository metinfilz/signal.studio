using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal.Studio.Workspace {
    public interface IToolsVisibleState {
        public bool LeftTopVisible { get; set; }
        public bool LeftBottomVisible { get; set; }
        public bool RightTopVisible { get; set; }
        public bool RightBottomVisible { get; set; }
        public bool TopLeftVisible { get; set; }
        public bool TopRightVisible { get; set; }
        public bool BottomLeftVisible { get; set; }
        public bool BottomRightVisible { get; set; }
    }
}
