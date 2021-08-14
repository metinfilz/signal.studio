using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;
using Signal.Studio.Workspace.Common;

namespace Signal.Studio.Workspace {
    public partial class ToolState {
        public Type LeftTopPanelContent { get; set; }
        public Type LeftBottomPanelContent { get; set; }
        public Type RightTopPanelContent { get; set; }
        public Type RightBottomPanelContent { get; set; }
        public Type TopLeftPanelContent { get; set; }
        public Type TopRightPanelContent { get; set; }
        public Type BottomLeftPanelContent { get; set; }
        public Type BottomRightPanelContent { get; set; }

        public ObservableCollection<ToggleButton> LeftTopButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> LeftBottomButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> RightTopButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> RightBottomButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> TopLeftButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> TopRightButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> BottomLeftButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> BottomRightButtons { get; } = new ObservableCollection<ToggleButton>();





        private bool leftTopVisible;
        private bool leftBottomVisible;
        private bool rightTopVisible;
        private bool rightBottomVisible;
        private bool topLeftVisible;
        private bool topRightVisible;
        private bool bottomLeftVisible;
        private bool bottomRightVisible;
    }

    public partial class ToolState {
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
