using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace SignalStudio.Core {
    public partial class WorkspaceView : UserControl {
        public RelayCommand ToolButtonCommand { get; }
        private void ToolButtonCommandAction(object param) {
            var pos = (ToolPosition)param;
            switch (pos) {
                case ToolPosition.LeftTop:
                    LeftTopVisibility = !LeftTopVisibility;
                    break;
                case ToolPosition.LeftBottom:
                    LeftBottomVisibility = !LeftBottomVisibility;
                    break;
                case ToolPosition.TopLeft:
                    TopLeftVisibility = !TopLeftVisibility;
                    break;
                case ToolPosition.TopRight:
                    TopRightVisibility = !TopRightVisibility;
                    break;
                case ToolPosition.RightTop:
                    RightTopVisibility = !RightTopVisibility;
                    break;
                case ToolPosition.RightBottom:
                    RightBottomVisibility = !RightBottomVisibility;
                    break;
                case ToolPosition.BottomLeft:
                    BottomLeftVisibility = !BottomLeftVisibility;
                    break;
                case ToolPosition.BottomRight:
                    BottomRightVisibility = !BottomRightVisibility;
                    break;
                default:
                    break;
            }

        }

        private bool _isMoving;
        private Point? _buttonPosition;
        private double deltaX;
        private double deltaY;
        private TranslateTransform _currentTT;

        public WorkspaceView() {
            InitializeComponent();

            ToolButtonCommand = new RelayCommand(ToolButtonCommandAction);

            var tl = new ToggleButton { Content = "Top Left", Command = ToolButtonCommand, CommandParameter = ToolPosition.TopLeft };
            TopLeftButtons.Add(tl);
            TopRightButtons.Add(new ToggleButton { Content = "Top Right", Command = ToolButtonCommand, CommandParameter = ToolPosition.TopRight });
            BottomLeftButtons.Add(new ToggleButton { Content = "Bottom Left", Command = ToolButtonCommand, CommandParameter = ToolPosition.BottomLeft });
            BottomRightButtons.Add(new ToggleButton { Content = "Bottom Right", Command = ToolButtonCommand, CommandParameter = ToolPosition.BottomRight });
            LeftTopButtons.Add(new ToggleButton { Content = "Left Top", Command = ToolButtonCommand, CommandParameter = ToolPosition.LeftTop });
            LeftBottomButtons.Add(new ToggleButton { Content = "Left Bottom", Command = ToolButtonCommand, CommandParameter = ToolPosition.LeftBottom });
            RightTopButtons.Add(new ToggleButton { Content = "Right Top", Command = ToolButtonCommand, CommandParameter = ToolPosition.RightTop });
            RightBottomButtons.Add(new ToggleButton { Content = "Right Bottom", Command = ToolButtonCommand, CommandParameter = ToolPosition.RightBottom });
        }
    }
    public partial class WorkspaceView {
        public ObservableCollection<ToggleButton> LeftTopButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> LeftBottomButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> RightTopButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> RightBottomButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> TopLeftButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> TopRightButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> BottomLeftButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> BottomRightButtons { get; } = new ObservableCollection<ToggleButton>();
    }
    public partial class WorkspaceView {
        private bool leftTopVisibility = false;
        private bool leftBottomVisibility = false;
        private bool rightTopVisibility = false;
        private bool rightBottomVisibility = false;
        private bool topLeftVisibility = false;
        private bool topRightVisibility = false;
        private bool bottomLeftVisibility = false;
        private bool bottomRightVisibility = false;

        public bool LeftAndVisibility => leftTopVisibility && leftBottomVisibility;
        public bool RightAndVisibility => rightTopVisibility && rightBottomVisibility;
        public bool TopAndVisibility => topLeftVisibility && topRightVisibility;
        public bool BottomAndVisibility => bottomLeftVisibility && bottomRightVisibility;

        public bool LeftOrVisibility => leftTopVisibility || leftBottomVisibility;
        public bool RightOrVisibility => rightTopVisibility || rightBottomVisibility;
        public bool TopOrVisibility => topLeftVisibility || topRightVisibility;
        public bool BottomOrVisibility => bottomLeftVisibility || bottomRightVisibility;


        public bool LeftTopVisibility {
            get => leftTopVisibility; set {
                SetProperty(ref leftTopVisibility, value);
                RaisePropertyChanged("LeftAndVisibility");
                RaisePropertyChanged("LeftOrVisibility");

                if (!value) {
                    leftTopSizeCache = leftTopSize;
                    SetProperty(ref leftTopSize, new GridLength(0, GridUnitType.Star), "LeftTopSize");
                } else {
                    SetProperty(ref leftTopSize, leftTopSizeCache, "LeftTopSize");
                }
                if (!value && !leftBottomVisibility) {
                    leftSizeCache = leftSize;
                    SetProperty(ref leftSize, new GridLength(0, GridUnitType.Star), "LeftSize");
                } else {
                    SetProperty(ref leftSize, leftSizeCache, "LeftSize");
                }
            }
        }
        public bool LeftBottomVisibility {
            get => leftBottomVisibility; set {
                SetProperty(ref leftBottomVisibility, value);
                RaisePropertyChanged("LeftAndVisibility");
                RaisePropertyChanged("LeftOrVisibility");

                if (!value) {
                    leftBottomSizeCache = leftBottomSize;
                    SetProperty(ref leftBottomSize, new GridLength(0, GridUnitType.Star), "LeftBottomSize");
                } else {
                    SetProperty(ref leftBottomSize, leftBottomSizeCache, "LeftBottomSize");
                }
                if (!value && !leftTopVisibility) {
                    leftSizeCache = leftSize;
                    SetProperty(ref leftSize, new GridLength(0, GridUnitType.Star), "LeftSize");
                } else {
                    SetProperty(ref leftSize, leftSizeCache, "LeftSize");
                }

            }
        }
        public bool RightTopVisibility {
            get => rightTopVisibility; set {
                SetProperty(ref rightTopVisibility, value);
                RaisePropertyChanged("RightAndVisibility");
                RaisePropertyChanged("RightOrVisibility");
                if (!value) {
                    rightTopSizeCache = rightTopSize;
                    SetProperty(ref rightTopSize, new GridLength(0, GridUnitType.Star), "RightTopSize");
                } else {
                    SetProperty(ref rightTopSize, rightTopSizeCache, "RightTopSize");
                }
                if (!value && !rightBottomVisibility) {
                    rightSizeCache = rightSize;
                    SetProperty(ref rightSize, new GridLength(0, GridUnitType.Star), "RightSize");
                } else {
                    SetProperty(ref rightSize, rightSizeCache, "RightSize");
                }

            }
        }
        public bool RightBottomVisibility {
            get => rightBottomVisibility; set {
                SetProperty(ref rightBottomVisibility, value);
                RaisePropertyChanged("RightAndVisibility");
                RaisePropertyChanged("RightOrVisibility");

                if (!value) {
                    rightBottomSizeCache = rightBottomSize;
                    SetProperty(ref rightBottomSize, new GridLength(0, GridUnitType.Star), "RightBottomSize");
                } else {
                    SetProperty(ref rightBottomSize, rightBottomSizeCache, "RightBottomSize");
                }
                if (!value && !rightTopVisibility) {
                    rightSizeCache = rightSize;
                    SetProperty(ref rightSize, new GridLength(0, GridUnitType.Star), "RightSize");
                } else {
                    SetProperty(ref rightSize, rightSizeCache, "RightSize");
                }

            }
        }
        public bool TopLeftVisibility {
            get => topLeftVisibility; set {
                SetProperty(ref topLeftVisibility, value);
                RaisePropertyChanged("TopAndVisibility");
                RaisePropertyChanged("TopOrVisibility");
                if (!value) {
                    topLeftSizeCache = topLeftSize;
                    SetProperty(ref topLeftSize, new GridLength(0, GridUnitType.Star), "TopLeftSize");
                } else {
                    SetProperty(ref topLeftSize, topLeftSizeCache, "TopLeftSize");
                }
                if(!value && !topRightVisibility) {
                    topSizeCache = topSize;
                    SetProperty(ref topSize, new GridLength(0, GridUnitType.Star), "TopSize");
                } else {
                    SetProperty(ref topSize, topSizeCache, "TopSize");
                }
            }
        }
        public bool TopRightVisibility {
            get => topRightVisibility; set {
                SetProperty(ref topRightVisibility, value);
                RaisePropertyChanged("TopAndVisibility");
                RaisePropertyChanged("TopOrVisibility");
                if (!value) {
                    topRightSizeCache = topRightSize;
                    SetProperty(ref topRightSize, new GridLength(0, GridUnitType.Star), "TopRightSize");
                } else {
                    SetProperty(ref topRightSize, topRightSizeCache, "TopRightSize");
                }
                if (!value && !topLeftVisibility) {
                    topSizeCache = topSize;
                    SetProperty(ref topSize, new GridLength(0, GridUnitType.Star), "TopSize");
                } else {
                    SetProperty(ref topSize, topSizeCache, "TopSize");
                }
            }
        }
        public bool BottomLeftVisibility {
            get => bottomLeftVisibility; set {
                SetProperty(ref bottomLeftVisibility, value);
                RaisePropertyChanged("BottomAndVisibility");
                RaisePropertyChanged("BottomOrVisibility");
                if (!value) {
                    bottomLeftSizeCache = bottomLeftSize;
                    SetProperty(ref bottomLeftSize, new GridLength(0, GridUnitType.Star), "BottomLeftSize");
                } else {
                    SetProperty(ref bottomLeftSize, bottomLeftSizeCache, "BottomLeftSize");
                }
                if (!value && !bottomRightVisibility) {
                    bottomSizeCache = bottomSize;
                    SetProperty(ref bottomSize, new GridLength(0, GridUnitType.Star), "BottomSize");
                } else {
                    SetProperty(ref bottomSize, bottomSizeCache, "BottomSize");
                }
            }
        }
        public bool BottomRightVisibility {
            get => bottomRightVisibility; set {
                SetProperty(ref bottomRightVisibility, value);
                RaisePropertyChanged("BottomAndVisibility");
                RaisePropertyChanged("BottomOrVisibility");
                if (!value) {
                    bottomRightSizeCache = bottomRightSize;
                    SetProperty(ref bottomRightSize, new GridLength(0, GridUnitType.Star), "BottomRightSize");
                } else {
                    SetProperty(ref bottomRightSize, bottomRightSizeCache, "BottomRightSize");
                }
                if (!value && !bottomLeftVisibility) {
                    bottomSizeCache = bottomSize;
                    SetProperty(ref bottomSize, new GridLength(0, GridUnitType.Star), "BottomSize");
                } else {
                    SetProperty(ref bottomSize, bottomSizeCache, "BottomSize");
                }
            }
        }
    }
    public partial class WorkspaceView {
        private GridLength topSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength topLeftSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength topRightSizeCache = new GridLength(1, GridUnitType.Star);

        private GridLength bottomSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength bottomLeftSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength bottomRightSizeCache = new GridLength(1, GridUnitType.Star);

        private GridLength leftSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength leftTopSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength leftBottomSizeCache = new GridLength(1, GridUnitType.Star);

        private GridLength rightSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength rightTopSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength rightBottomSizeCache = new GridLength(1, GridUnitType.Star);


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


        public GridLength TopSize { get => topSize; set => SetProperty(ref topSize, value); }
        public GridLength TopLeftSize { get => topLeftSize; set => SetProperty(ref topLeftSize, value); }
        public GridLength TopRightSize { get => topRightSize; set => SetProperty(ref topRightSize, value); }

        public GridLength BottomSize { get => bottomSize; set => SetProperty(ref bottomSize, value); }
        public GridLength BottomLeftSize { get => bottomLeftSize; set => SetProperty(ref bottomLeftSize, value); }
        public GridLength BottomRightSize { get => bottomRightSize; set => SetProperty(ref bottomRightSize, value); }


        public GridLength LeftSize { get => leftSize; set => SetProperty(ref leftSize, value); }
        public GridLength LeftTopSize { get => leftTopSize; set => SetProperty(ref leftTopSize, value); }
        public GridLength LeftBottomSize { get => leftBottomSize; set => SetProperty(ref leftBottomSize, value); }

        public GridLength RightSize { get => rightSize; set => SetProperty(ref rightSize, value); }
        public GridLength RightTopSize { get => rightTopSize; set => SetProperty(ref rightTopSize, value); }
        public GridLength RightBottomSize { get => rightBottomSize; set => SetProperty(ref rightBottomSize, value); }





    }
    public partial class WorkspaceView: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null) {
            if (!EqualityComparer<T>.Default.Equals(field, newValue)) {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
        protected void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
