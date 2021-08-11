using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SignalStudio.Core {
    public partial class ToolContainerView : UserControl {
        public ToolContainerView() {
            InitializeComponent();
            LeftTopToolPanel.ToolCloseRequest += (s, e) => {
                LeftTopButtons.ToList().ForEach(i => i.IsChecked = false);
                LeftTopVisibility = false;
            };
            LeftBottomToolPanel.ToolCloseRequest += (s, e) => {
                LeftBottomButtons.ToList().ForEach(i => i.IsChecked = false);
                LeftBottomVisibility = false;
            };
            RightTopToolPanel.ToolCloseRequest += (s, e) => {
                RightTopButtons.ToList().ForEach(i => i.IsChecked = false);
                RightTopVisibility = false;
            };
            RightBottomToolPanel.ToolCloseRequest += (s, e) => {
                RightBottomButtons.ToList().ForEach(i => i.IsChecked = false);
                RightBottomVisibility = false;
            };
            TopLeftToolPanel.ToolCloseRequest += (s, e) => {
                TopLeftButtons.ToList().ForEach(i => i.IsChecked = false);
                TopLeftVisibility = false;
            };
            TopRightToolPanel.ToolCloseRequest += (s, e) => {
                TopRightButtons.ToList().ForEach(i => i.IsChecked = false);
                TopRightVisibility = false;
            };
            BottomLeftToolPanel.ToolCloseRequest += (s, e) => {
                BottomLeftButtons.ToList().ForEach(i => i.IsChecked = false);
                BottomLeftVisibility = false;
            };
            BottomRightToolPanel.ToolCloseRequest += (s, e) => {
                BottomRightButtons.ToList().ForEach(i => i.IsChecked = false);
                BottomRightVisibility = false;
            };
            ToolButtonCommand = new RelayCommand(ToolButtonCommandAction);
        }
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
        public void AddTool<T>(ToolPosition position, string header) {
            switch (position) {
                case ToolPosition.LeftTop:
                    var lt = new ToggleButton { Content = header, CommandParameter = ToolPosition.LeftTop, Tag = typeof(T) };
                    lt.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            LeftTopButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            LeftTopButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                        LeftTopVisibility = (bool)control.IsChecked;
                    };
                    LeftTopButtons.Add(lt);
                    break;
                case ToolPosition.LeftBottom:
                    var lb = new ToggleButton { Content = header, CommandParameter = ToolPosition.LeftBottom, Tag = typeof(T) };
                    lb.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            LeftBottomButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            LeftBottomButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                        LeftBottomVisibility = (bool)control.IsChecked;
                    };
                    LeftBottomButtons.Add(lb);
                    break;
                case ToolPosition.TopLeft:
                    var tl = new ToggleButton { Content = header, CommandParameter = ToolPosition.TopLeft, Tag = typeof(T) };
                    tl.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            TopLeftButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            TopLeftButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                        TopLeftVisibility = (bool)control.IsChecked;
                    };
                    TopLeftButtons.Add(tl);
                    break;
                case ToolPosition.TopRight:
                    var tr = new ToggleButton { Content = header, CommandParameter = ToolPosition.TopRight, Tag = typeof(T) };
                    tr.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            TopRightButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            TopRightButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                        TopRightVisibility = (bool)control.IsChecked;
                    };
                    TopRightButtons.Add(tr);
                    break;
                case ToolPosition.RightTop:
                    var rt = new ToggleButton { Content = header, CommandParameter = ToolPosition.RightTop, Tag = typeof(T) };
                    rt.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            RightTopButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            RightTopButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                        RightTopVisibility = (bool)control.IsChecked;
                    };
                    RightTopButtons.Add(rt);
                    break;
                case ToolPosition.RightBottom:
                    var rb = new ToggleButton { Content = header, CommandParameter = ToolPosition.RightBottom, Tag = typeof(T) };
                    rb.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            RightBottomButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            RightBottomButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                        RightBottomVisibility = (bool)control.IsChecked;
                    };
                    RightBottomButtons.Add(rb);

                    break;
                case ToolPosition.BottomLeft:
                    var bl = new ToggleButton { Content = header, CommandParameter = ToolPosition.BottomLeft, Tag = typeof(T) };
                    bl.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            BottomLeftButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            BottomLeftButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                        BottomLeftVisibility = (bool)control.IsChecked;
                    };
                    BottomLeftButtons.Add(bl);
                    break;
                case ToolPosition.BottomRight:
                    var br = new ToggleButton { Content = header, CommandParameter = ToolPosition.BottomRight, Tag = typeof(T) };
                    br.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            BottomRightButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            BottomRightButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                        BottomRightVisibility = (bool)control.IsChecked;
                    };
                    BottomRightButtons.Add(br);
                    break;
                default:
                    break;
            }
        }
        private void Rectangle_PreviewDragEnter(object sender, DragEventArgs e) {
            var control = sender as Rectangle;
            var animation = new DoubleAnimation { To = 0.5F, Duration = TimeSpan.FromMilliseconds(100) };
            animation.Completed += (s, e) => control.Opacity = 0.5F;
            control.BeginAnimation(OpacityProperty, animation);
        }

        private void Rectangle_PreviewDragLeave(object sender, DragEventArgs e) {
            var control = sender as Rectangle;
            var animation = new DoubleAnimation { To = 0.0F, Duration = TimeSpan.FromMilliseconds(100) };
            animation.Completed += (s, e) => control.Opacity = 0.0F;
            control.BeginAnimation(OpacityProperty, animation);
        }

        private void Grid_GiveFeedback(object sender, GiveFeedbackEventArgs e) {
            Mouse.SetCursor(Cursors.Wait);
            e.Handled = true;
        }
    }
    public partial class ToolContainerView {
        public ObservableCollection<ToggleButton> LeftTopButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> LeftBottomButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> RightTopButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> RightBottomButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> TopLeftButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> TopRightButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> BottomLeftButtons { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> BottomRightButtons { get; } = new ObservableCollection<ToggleButton>();
    }
    public partial class ToolContainerView {
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
                if (value) {
                    LeftTopSize = leftTopSizeCache;
                } else {
                    leftTopSizeCache = leftTopSize;
                    LeftTopSize = new GridLength(0, GridUnitType.Star);
                }
                if (LeftOrVisibility) {
                    LeftSize = leftSizeCache;
                } else {
                    leftSizeCache = LeftSize;
                    LeftSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool LeftBottomVisibility {
            get => leftBottomVisibility; set {
                SetProperty(ref leftBottomVisibility, value);
                RaisePropertyChanged("LeftAndVisibility");
                RaisePropertyChanged("LeftOrVisibility");
                if (value) {
                    LeftBottomSize = leftBottomSizeCache;
                } else {
                    leftBottomSizeCache = leftBottomSize;
                    LeftBottomSize = new GridLength(0, GridUnitType.Star);
                }
                if (LeftOrVisibility) {
                    LeftSize = leftSizeCache;
                } else {
                    leftSizeCache = LeftSize;
                    LeftSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool RightTopVisibility {
            get => rightTopVisibility; set {
                SetProperty(ref rightTopVisibility, value);
                RaisePropertyChanged("RightAndVisibility");
                RaisePropertyChanged("RightOrVisibility");
                if (value) {
                    RightTopSize = rightTopSizeCache;
                } else {
                    rightTopSizeCache = rightTopSize;
                    RightTopSize = new GridLength(0, GridUnitType.Star);
                }
                if (RightOrVisibility) {
                    RightSize = rightSizeCache;
                } else {
                    rightSizeCache = RightSize;
                    RightSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool RightBottomVisibility {
            get => rightBottomVisibility; set {
                SetProperty(ref rightBottomVisibility, value);
                RaisePropertyChanged("RightAndVisibility");
                RaisePropertyChanged("RightOrVisibility");
                if (value) {
                    RightBottomSize = rightBottomSizeCache;
                } else {
                    rightBottomSizeCache = rightBottomSize;
                    RightBottomSize = new GridLength(0, GridUnitType.Star);
                }
                if (RightOrVisibility) {
                    RightSize = rightSizeCache;
                } else {
                    rightSizeCache = RightSize;
                    RightSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool TopLeftVisibility {
            get => topLeftVisibility; set {
                SetProperty(ref topLeftVisibility, value);
                RaisePropertyChanged("TopAndVisibility");
                RaisePropertyChanged("TopOrVisibility");
                if (value) {
                    TopLeftSize = topLeftSizeCache;
                } else {
                    topLeftSizeCache = topLeftSize;
                    TopLeftSize = new GridLength(0, GridUnitType.Star);
                }
                if (TopOrVisibility) {
                    TopSize = topSizeCache;
                } else {
                    topSizeCache = TopSize;
                    TopSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool TopRightVisibility {
            get => topRightVisibility; set {
                SetProperty(ref topRightVisibility, value);
                RaisePropertyChanged("TopAndVisibility");
                RaisePropertyChanged("TopOrVisibility");
                if (value) {
                    TopRightSize = topRightSizeCache;
                } else {
                    topRightSizeCache = topRightSize;
                    TopRightSize = new GridLength(0, GridUnitType.Star);
                }
                if (TopOrVisibility) {
                    TopSize = topSizeCache;
                } else {
                    topSizeCache = TopSize;
                    TopSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool BottomLeftVisibility {
            get => bottomLeftVisibility; set {
                SetProperty(ref bottomLeftVisibility, value);
                RaisePropertyChanged("BottomAndVisibility");
                RaisePropertyChanged("BottomOrVisibility");
                if (value) {
                    BottomLeftSize = bottomLeftSizeCache;
                } else {
                    bottomLeftSizeCache = bottomLeftSize;
                    BottomLeftSize = new GridLength(0, GridUnitType.Star);
                }
                if (BottomOrVisibility) {
                    BottomSize = bottomSizeCache;
                } else {
                    bottomSizeCache = BottomSize;
                    BottomSize = new GridLength(0, GridUnitType.Pixel);
                }
            }
        }
        public bool BottomRightVisibility {
            get => bottomRightVisibility; set {
                SetProperty(ref bottomRightVisibility, value);
                RaisePropertyChanged("BottomAndVisibility");
                RaisePropertyChanged("BottomOrVisibility");
                if (value) {
                    BottomRightSize = bottomRightSizeCache;
                } else {
                    bottomRightSizeCache = bottomRightSize;
                    BottomRightSize = new GridLength(0, GridUnitType.Star);
                }
                if (BottomOrVisibility) {
                    BottomSize = bottomSizeCache;
                } else {
                    bottomSizeCache = BottomSize;
                    BottomSize = new GridLength(0, GridUnitType.Auto);
                }
            }
        }
    }
    public partial class ToolContainerView {
        private GridLength topSizeCache = new GridLength(1, GridUnitType.Auto);
        private GridLength topLeftSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength topRightSizeCache = new GridLength(1, GridUnitType.Star);

        private GridLength bottomSizeCache = new GridLength(1, GridUnitType.Auto);
        private GridLength bottomLeftSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength bottomRightSizeCache = new GridLength(1, GridUnitType.Star);

        private GridLength leftSizeCache = new GridLength(1, GridUnitType.Auto);
        private GridLength leftTopSizeCache = new GridLength(1, GridUnitType.Star);
        private GridLength leftBottomSizeCache = new GridLength(1, GridUnitType.Star);

        private GridLength rightSizeCache = new GridLength(1, GridUnitType.Auto);
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

        private GridLength centerSize = new GridLength(1, GridUnitType.Star);

        public GridLength TopSize {
            get => topSize; set {
                SetProperty(ref topSize, value);
                if (value.Value != 0) {
                    topSizeCache = TopSize;
                }
            }
        }
        public GridLength TopLeftSize {
            get => topLeftSize; set {
                SetProperty(ref topLeftSize, value);
            }
        }
        public GridLength TopRightSize { get => topRightSize; set => SetProperty(ref topRightSize, value); }
        public GridLength BottomSize {
            get => bottomSize; set {
                SetProperty(ref bottomSize, value);
                if (value.Value != 0) {
                    bottomSizeCache = BottomSize;
                }
            }
        }
        public GridLength BottomLeftSize { get => bottomLeftSize; set => SetProperty(ref bottomLeftSize, value); }
        public GridLength BottomRightSize { get => bottomRightSize; set => SetProperty(ref bottomRightSize, value); }
        public GridLength LeftSize {
            get => leftSize; set {
                SetProperty(ref leftSize, value);
                if (value.Value != 0) {
                    leftSizeCache = LeftSize;
                }
            }
        }
        public GridLength LeftTopSize { get => leftTopSize; set => SetProperty(ref leftTopSize, value); }
        public GridLength LeftBottomSize { get => leftBottomSize; set => SetProperty(ref leftBottomSize, value); }
        public GridLength RightSize {
            get => rightSize; set {
                SetProperty(ref rightSize, value);
                if (value.Value != 0) {
                    rightSizeCache = RightSize;
                }
            }
        }
        public GridLength RightTopSize { get => rightTopSize; set => SetProperty(ref rightTopSize, value); }
        public GridLength RightBottomSize { get => rightBottomSize; set => SetProperty(ref rightBottomSize, value); }
        public GridLength CenterSize { get => centerSize; set => SetProperty(ref centerSize, value); }
    }
    public partial class ToolContainerView {
        public bool DragStatus { get; set; } = true;
    }
    public partial class ToolContainerView : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null) {
            if (!EqualityComparer<T>.Default.Equals(field, newValue)) {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
        protected void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
