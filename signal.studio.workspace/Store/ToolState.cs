using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Signal.Studio.Workspace {
    public partial class ToolState {
        private bool leftTopVisible = true;
        private bool leftBottomVisible = true;
        private bool rightTopVisible = true;
        private bool rightBottomVisible = true;
        private bool topLeftVisible = true;
        private bool topRightVisible;
        private bool bottomLeftVisible;
        private bool bottomRightVisible;
    }
    public partial class ToolState : IToolsVisibleState {
        public bool LeftTopVisible { get => leftTopVisible; set => SetProperty(ref leftTopVisible, value); }
        public bool LeftBottomVisible { get => leftBottomVisible; set => SetProperty(ref leftBottomVisible, value); }
        public bool RightTopVisible { get => rightTopVisible ; set => SetProperty(ref rightTopVisible, value); }
        public bool RightBottomVisible { get => rightBottomVisible; set => SetProperty(ref rightBottomVisible, value); }
        public bool TopLeftVisible { get => topLeftVisible; set => SetProperty(ref topLeftVisible, value); }
        public bool TopRightVisible { get => topRightVisible; set => SetProperty(ref topRightVisible, value); }
        public bool BottomLeftVisible { get => bottomLeftVisible; set => SetProperty(ref bottomLeftVisible, value); }
        public bool BottomRightVisible { get => bottomRightVisible; set => SetProperty(ref bottomRightVisible, value); }
    }
    partial class ToolState : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {
            if (Equals(storage, value) || string.IsNullOrEmpty(propertyName)) {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
