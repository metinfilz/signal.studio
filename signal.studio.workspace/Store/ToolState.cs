using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using Signal.Studio.Workspace.Common;
using Signal.Studio.Workspace.Model;
using Signal.Studio.Workspace.View;

using Position = Signal.Studio.Workspace.Common.ToolPosition;

namespace Signal.Studio.Workspace {
    public partial class ToolState {
        internal Dictionary<Position, ToolPanel> Panels { get; } = new Dictionary<Position, ToolPanel>();
        internal Dictionary<Position, ObservableCollection<ToggleButton>> Buttons { get; } = new Dictionary<Position, ObservableCollection<ToggleButton>>();
        internal Dictionary<Position, VariableReference> Visibilities { get; } = new Dictionary<Position, VariableReference>();
        internal Dictionary<Position, GridLength> Sizes { get; } = new Dictionary<Position, GridLength>();
        
        
        internal List<ToolModel> Tools { get; } = new List<ToolModel>();
        public ToolState() {
            Buttons.Add(Position.LeftTop, LeftTopButtons);
            Buttons.Add(Position.LeftBottom, LeftBottomButtons);
            Buttons.Add(Position.RightTop, RightTopButtons);
            Buttons.Add(Position.RightBottom, RightBottomButtons);
            Buttons.Add(Position.TopLeft, TopLeftButtons);
            Buttons.Add(Position.TopRight, TopRightButtons);
            Buttons.Add(Position.BottomLeft, BottomLeftButtons);
            Buttons.Add(Position.BottomRight, BottomRightButtons);

            Visibilities.Add(Position.LeftTop, new VariableReference(() => LeftTopVisible, val => LeftTopVisible = (bool)val));
            Visibilities.Add(Position.LeftBottom, new VariableReference(() => LeftBottomVisible, val => LeftBottomVisible = (bool)val));
            Visibilities.Add(Position.RightTop, new VariableReference(() => RightTopVisible, val => RightTopVisible = (bool)val));
            Visibilities.Add(Position.RightBottom, new VariableReference(() => RightBottomVisible, val => RightBottomVisible = (bool)val));
            Visibilities.Add(Position.TopLeft, new VariableReference(() => TopLeftVisible, val => TopLeftVisible = (bool)val));
            Visibilities.Add(Position.TopRight, new VariableReference(() => TopRightVisible, val => TopRightVisible = (bool)val));
            Visibilities.Add(Position.BottomLeft, new VariableReference(() => BottomLeftVisible, val => BottomLeftVisible = (bool)val));
            Visibilities.Add(Position.BottomRight, new VariableReference(() => BottomRightVisible, val => BottomRightVisible = (bool)val));

            Sizes.Add(Position.LeftTop, leftTopSizeCache);
            Sizes.Add(Position.LeftBottom, leftBottomSizeCache);
            Sizes.Add(Position.RightTop, rightTopSizeCache);
            Sizes.Add(Position.RightBottom, rightBottomSizeCache);
            Sizes.Add(Position.TopLeft, topLeftSizeCache);
            Sizes.Add(Position.TopRight, topRightSizeCache);
            Sizes.Add(Position.BottomLeft, bottomLeftSizeCache);
            Sizes.Add(Position.BottomRight, bottomRightSizeCache);
        }
    }

    public partial class ToolState {
        public ObservableCollection<ToggleButton> LeftTopButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> LeftBottomButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> RightTopButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> RightBottomButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> TopLeftButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> TopRightButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> BottomLeftButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> BottomRightButtons { get; } = new ObservableCollection<ToggleButton>();
    }

    public partial class ToolState : IToolsVisibleState {
        public bool LeftTopVisible {
            get => leftTopVisible; set {
                SetProperty(ref leftTopVisible, value);
                LeftAndVisible = value && leftBottomVisible;
                LeftOrVisible = value || leftBottomVisible;
                if (value) {
                    LeftTopSize = leftTopSizeCache;
                } else {
                    leftTopSizeCache = leftTopSize;
                    LeftTopSize = new GridLength(0, GridUnitType.Star);
                }
                if (LeftOrVisible) {
                    LeftSize = leftSizeCache;
                } else {
                    leftSizeCache = LeftSize;
                    LeftSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool LeftBottomVisible {
            get => leftBottomVisible; set {
                SetProperty(ref leftBottomVisible, value);
                LeftAndVisible = leftTopVisible && value;
                LeftOrVisible = leftTopVisible || value;
                if (value) {
                    LeftBottomSize = leftBottomSizeCache;
                } else {
                    leftBottomSizeCache = leftBottomSize;
                    LeftBottomSize = new GridLength(0, GridUnitType.Star);
                }
                if (LeftOrVisible) {
                    LeftSize = leftSizeCache;
                } else {
                    leftSizeCache = LeftSize;
                    LeftSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool RightTopVisible {
            get => rightTopVisible; set {
                SetProperty(ref rightTopVisible, value);
                RightAndVisible = value && rightBottomVisible;
                RightOrVisible = value || rightBottomVisible;
                if (value) {
                    RightTopSize = rightTopSizeCache;
                } else {
                    rightTopSizeCache = rightTopSize;
                    RightTopSize = new GridLength(0, GridUnitType.Star);
                }
                if (RightOrVisible) {
                    RightSize = rightSizeCache;
                } else {
                    rightSizeCache = RightSize;
                    RightSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool RightBottomVisible {
            get => rightBottomVisible; set {
                SetProperty(ref rightBottomVisible, value);
                RightAndVisible = rightTopVisible && value;
                RightOrVisible = rightTopVisible || value;
                if (value) {
                    RightBottomSize = rightBottomSizeCache;
                } else {
                    rightBottomSizeCache = rightBottomSize;
                    RightBottomSize = new GridLength(0, GridUnitType.Star);
                }
                if (RightOrVisible) {
                    RightSize = rightSizeCache;
                } else {
                    rightSizeCache = RightSize;
                    RightSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool TopLeftVisible {
            get => topLeftVisible; set {
                SetProperty(ref topLeftVisible, value);
                TopAndVisible = value && topRightVisible;
                TopOrVisible = value || topRightVisible;
                if (value) {
                    TopLeftSize = topLeftSizeCache;
                } else {
                    topLeftSizeCache = topLeftSize;
                    TopLeftSize = new GridLength(0, GridUnitType.Star);
                }
                if (TopOrVisible) {
                    TopSize = topSizeCache;
                } else {
                    topSizeCache = TopSize;
                    TopSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool TopRightVisible {
            get => topRightVisible; set {
                SetProperty(ref topRightVisible, value);
                TopAndVisible = topLeftVisible && value;
                TopOrVisible = topLeftVisible || value;
                if (value) {
                    TopRightSize = topRightSizeCache;
                } else {
                    topRightSizeCache = topRightSize;
                    TopRightSize = new GridLength(0, GridUnitType.Star);
                }
                if (TopOrVisible) {
                    TopSize = topSizeCache;
                } else {
                    topSizeCache = TopSize;
                    TopSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool BottomLeftVisible {
            get => bottomLeftVisible; set {
                SetProperty(ref bottomLeftVisible, value);
                BottomAndVisible = value && bottomRightVisible;
                BottomOrVisible = value || bottomRightVisible;
                if (value) {
                    BottomLeftSize = bottomLeftSizeCache;
                } else {
                    bottomLeftSizeCache = bottomLeftSize;
                    BottomLeftSize = new GridLength(0, GridUnitType.Star);
                }
                if (BottomOrVisible) {
                    BottomSize = bottomSizeCache;
                } else {
                    bottomSizeCache = BottomSize;
                    BottomSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool BottomRightVisible {
            get => bottomRightVisible; set {
                SetProperty(ref bottomRightVisible, value);
                BottomAndVisible = bottomLeftVisible && value;
                BottomOrVisible = bottomLeftVisible || value;
                if (value) {
                    BottomRightSize = bottomRightSizeCache;
                } else {
                    bottomRightSizeCache = bottomRightSize;
                    BottomRightSize = new GridLength(0, GridUnitType.Star);
                }
                if (BottomOrVisible) {
                    BottomSize = bottomSizeCache;
                } else {
                    bottomSizeCache = BottomSize;
                    BottomSize = new GridLength(0, GridUnitType.Auto);
                }
            }
        }
        public bool LeftOrVisible { get => leftOrVisible; set => SetProperty(ref leftOrVisible, value); }
        public bool LeftAndVisible { get => leftAndVisible; set => SetProperty(ref leftAndVisible, value); }
        public bool RightOrVisible { get => rightOrVisible; set => SetProperty(ref rightOrVisible, value); }
        public bool RightAndVisible { get => rightAndVisible; set => SetProperty(ref rightAndVisible, value); }
        public bool TopOrVisible { get => topOrVisible; set => SetProperty(ref topOrVisible, value); }
        public bool TopAndVisible { get => topAndVisible; set => SetProperty(ref topAndVisible, value); }
        public bool BottomOrVisible { get => bottomOrVisible; set => SetProperty(ref bottomOrVisible, value); }
        public bool BottomAndVisible { get => bottomAndVisible; set => SetProperty(ref bottomAndVisible, value); }
    }
    public partial class ToolState : IToolSizeState {
        public GridLength TopLeftSize { get => topLeftSize; set => SetProperty(ref topLeftSize, value); }
        public GridLength TopRightSize { get => topRightSize; set => SetProperty(ref topRightSize, value); }
        public GridLength BottomLeftSize { get => bottomLeftSize; set => SetProperty(ref bottomLeftSize, value); }
        public GridLength BottomRightSize { get => bottomRightSize; set => SetProperty(ref bottomRightSize, value); }
        public GridLength LeftTopSize { get => leftTopSize; set => SetProperty(ref leftTopSize, value); }
        public GridLength LeftBottomSize { get => leftBottomSize; set => SetProperty(ref leftBottomSize, value); }
        public GridLength RightTopSize { get => rightTopSize; set => SetProperty(ref rightTopSize, value); }
        public GridLength RightBottomSize { get => rightBottomSize; set => SetProperty(ref rightBottomSize, value); }
        public GridLength TopSize {
            get => topSize; set {
                SetProperty(ref topSize, value);
                if (value.Value != 0) {
                    topSizeCache = TopSize;
                }
            }
        }
        public GridLength BottomSize {
            get => bottomSize; set {
                SetProperty(ref bottomSize, value);
                if (value.Value != 0) {
                    bottomSizeCache = BottomSize;
                }
            }
        }
        public GridLength LeftSize {
            get => leftSize; set {
                SetProperty(ref leftSize, value);
                if (value.Value != 0) {
                    leftSizeCache = LeftSize;
                }
            }
        }
        public GridLength RightSize {
            get => rightSize; set {
                SetProperty(ref rightSize, value);
                if (value.Value != 0) {
                    rightSizeCache = RightSize;
                }
            }
        }
    }
    public partial class ToolState {
        private bool leftOrVisible = false;
        private bool leftAndVisible = false;
        private bool rightOrVisible = false;
        private bool rightAndVisible = false;
        private bool topOrVisible = false;
        private bool topAndVisible = false;
        private bool bottomOrVisible = false;
        private bool bottomAndVisible = false;
        private bool leftTopVisible = false;
        private bool leftBottomVisible = false;
        private bool rightTopVisible = false;
        private bool rightBottomVisible = false;
        private bool topLeftVisible = false;
        private bool topRightVisible = false;
        private bool bottomLeftVisible = false;
        private bool bottomRightVisible = false;

        internal GridLength topSizeCache = new GridLength(1, GridUnitType.Auto);
        internal GridLength topLeftSizeCache = new GridLength(1, GridUnitType.Star);
        internal GridLength topRightSizeCache = new GridLength(1, GridUnitType.Star);
        internal GridLength bottomSizeCache = new GridLength(1, GridUnitType.Auto);
        internal GridLength bottomLeftSizeCache = new GridLength(1, GridUnitType.Star);
        internal GridLength bottomRightSizeCache = new GridLength(1, GridUnitType.Star);
        internal GridLength leftSizeCache = new GridLength(1, GridUnitType.Auto);
        internal GridLength leftTopSizeCache = new GridLength(1, GridUnitType.Star);
        internal GridLength leftBottomSizeCache = new GridLength(1, GridUnitType.Star);
        internal GridLength rightSizeCache = new GridLength(1, GridUnitType.Auto);
        internal GridLength rightTopSizeCache = new GridLength(1, GridUnitType.Star);
        internal GridLength rightBottomSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength topSize;
        private GridLength topLeftSize;
        private GridLength topRightSize;
        private GridLength bottomSize;
        private GridLength bottomLeftSize;
        private GridLength bottomRightSize;
        private GridLength leftSize;
        private GridLength leftTopSize;
        private GridLength leftBottomSize;
        private GridLength rightSize;
        private GridLength rightTopSize;
        private GridLength rightBottomSize;
    }
    public partial class ToolState : INotifyPropertyChanged {
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
