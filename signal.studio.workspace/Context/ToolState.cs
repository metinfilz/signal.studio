using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Signal.Studio.Workspace.Common;
using Signal.Studio.Workspace.Model;
using Signal.Studio.Workspace.Utils;
using Signal.Studio.Workspace.View;

namespace Signal.Studio.Workspace.Context {
    public partial class ToolState {
        public ObservableCollection<IToolModel> Tools { get; }
        internal List<ToolWindow> ToolWindows { get; }
        internal List<ToolFloat> ToolFloats { get; }
        internal Dictionary<ToolPosition, VariableReference> ToolDocks { get; }
        internal ToolState() {
            {
                Tools = new ObservableCollection<IToolModel>();
                ToolWindows = new List<ToolWindow>();
                ToolFloats = new List<ToolFloat>();
                ToolDocks = new Dictionary<ToolPosition, VariableReference> {
                    { ToolPosition.LeftTop, new VariableReference(() => PanelLeftTop, val => PanelLeftTop = (UserControl)val) },
                    { ToolPosition.LeftBottom, new VariableReference(() => PanelLeftBottom, val => PanelLeftBottom = (UserControl)val) },
                    { ToolPosition.RightTop, new VariableReference(() => PanelRightTop, val => PanelRightTop = (UserControl)val) },
                    { ToolPosition.RightBottom, new VariableReference(() => PanelRightBottom, val => PanelRightBottom = (UserControl)val) },
                    { ToolPosition.TopLeft, new VariableReference(() => PanelTopLeft, val => PanelTopLeft = (UserControl)val) },
                    { ToolPosition.TopRight, new VariableReference(() => PanelTopRight, val => PanelTopRight = (UserControl)val) },
                    { ToolPosition.BottomLeft, new VariableReference(() => PanelBottomLeft, val => PanelBottomLeft = (UserControl)val) },
                    { ToolPosition.BottomRight, new VariableReference(() => PanelBottomRight, val => PanelBottomRight = (UserControl)val) },
                };
            }



            {




                Buttons.Add(ToolPosition.LeftTop, ButtonsLeftTop);
                Buttons.Add(ToolPosition.LeftBottom, ButtonsLeftBottom);
                Buttons.Add(ToolPosition.RightTop, ButtonsRightTop);
                Buttons.Add(ToolPosition.RightBottom, ButtonsRightBottom);
                Buttons.Add(ToolPosition.TopLeft, ButtonsTopLeft);
                Buttons.Add(ToolPosition.TopRight, ButtonsTopRight);
                Buttons.Add(ToolPosition.BottomLeft, ButtonsBottomLeft);
                Buttons.Add(ToolPosition.BottomRight, ButtonsBottomRight);


                Visibles.Add(ToolPosition.LeftTop, new VariableReference(() => VisibilityLeftTop, val => VisibilityLeftTop = (bool)val));
                Visibles.Add(ToolPosition.LeftBottom, new VariableReference(() => VisibilityLeftBottom, val => VisibilityLeftBottom = (bool)val));
                Visibles.Add(ToolPosition.RightTop, new VariableReference(() => VisibilityRightTop, val => VisibilityRightTop = (bool)val));
                Visibles.Add(ToolPosition.RightBottom, new VariableReference(() => VisibilityRightBottom, val => VisibilityRightBottom = (bool)val));
                Visibles.Add(ToolPosition.TopLeft, new VariableReference(() => VisibilityTopLeft, val => VisibilityTopLeft = (bool)val));
                Visibles.Add(ToolPosition.TopRight, new VariableReference(() => VisibilityTopRight, val => VisibilityTopRight = (bool)val));
                Visibles.Add(ToolPosition.BottomLeft, new VariableReference(() => VisibilityBottomLeft, val => VisibilityBottomLeft = (bool)val));
                Visibles.Add(ToolPosition.BottomRight, new VariableReference(() => VisibilityBottomRight, val => VisibilityBottomRight = (bool)val));
            }
            Tools.CollectionChanged += (s, e) => {
                e.NewItems?.Cast<IToolModel>().ToList().ForEach(i => {
                    var button = new ToolToggleButton { ToolModel = i };
                    button.Configure();
                    Buttons[i.Position].Add(button);
                });
                e.OldItems?.Cast<IToolModel>().ToList().ForEach(i => {
                    Buttons[i.Position].ToList().FindAll(j => ((ToolToggleButton)j).ToolModel.Type == i.Type).ForEach(j => {
                        Buttons[i.Position].Remove(j);
                    });
                });
            };
        }
        private void ToolPropertyChanged(object sender, PropertyChangedEventArgs e) {
        }
    }
    public partial class ToolState {
        internal Dictionary<ToolPosition, ObservableCollection<ToggleButton>> Buttons { get; } = new Dictionary<ToolPosition, ObservableCollection<ToggleButton>>();
        internal Dictionary<ToolPosition, VariableReference> Visibles { get; } = new Dictionary<ToolPosition, VariableReference>();
        internal Dictionary<Type, (double width, double height, double top, double left)> ToolWindowsState { get; }
            = new Dictionary<Type, (double width, double height, double top, double left)>();



        public ObservableCollection<ToggleButton> ButtonsTopLeft { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> ButtonsTopRight { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> ButtonsBottomLeft { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> ButtonsBottomRight { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> ButtonsLeftTop { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> ButtonsLeftBottom { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> ButtonsRightTop { get; } = new ObservableCollection<ToggleButton>();
        public ObservableCollection<ToggleButton> ButtonsRightBottom { get; } = new ObservableCollection<ToggleButton>();
        public UserControl PanelTopLeft { get => panelTopLeft; set => SetProperty(ref panelTopLeft, value); }
        public UserControl PanelTopRight { get => panelTopRight; set => SetProperty(ref panelTopRight, value); }
        public UserControl PanelBottomLeft { get => panelBottomLeft; set => SetProperty(ref panelBottomLeft, value); }
        public UserControl PanelBottomRight { get => panelBottomRight; set => SetProperty(ref panelBottomRight, value); }
        public UserControl PanelLeftTop { get => panelLeftTop; set => SetProperty(ref panelLeftTop, value); }
        public UserControl PanelLeftBottom { get => panelLeftBottom; set => SetProperty(ref panelLeftBottom, value); }
        public UserControl PanelRightTop { get => panelRightTop; set => SetProperty(ref panelRightTop, value); }
        public UserControl PanelRightBottom { get => panelRightBottom; set => SetProperty(ref panelRightBottom, value); }


    }
    public partial class ToolState {
        public bool VisibilityLeftTop {
            get => visibilityLeftTop; set {
                SetProperty(ref visibilityLeftTop, value);
                if (value) {
                    SizeLeftTop = cacheSizeLeftTop;
                }
                else {
                    cacheSizeLeftTop = SizeLeftTop;
                    SizeLeftTop = 0;
                }
                if (value && VisibilityLeftBottom) {
                    cacheSizeLeft = SizeLeft;
                }
                else if (!value && VisibilityLeftBottom) {
                    cacheSizeLeft = SizeLeft;
                }
                else if (value && !VisibilityLeftBottom) {
                    SizeLeft = cacheSizeLeft;
                }
                else {
                    cacheSizeLeft = SizeLeft;
                    SizeLeft = 0;
                }
            }
        }
        public bool VisibilityLeftBottom {
            get => visibilityLeftBottom; set {
                SetProperty(ref visibilityLeftBottom, value);
                if (value) {
                    SizeLeftBottom = cacheSizeLeftBottom;
                } else {
                    cacheSizeLeftBottom = SizeLeftBottom;
                    SizeLeftBottom = 0;
                }
                if(value && VisibilityLeftTop) { 
                    cacheSizeLeft = SizeLeft;
                } else if(!value && VisibilityLeftTop) {
                    cacheSizeLeft = SizeLeft;
                } else if(value && !VisibilityLeftTop) {
                    SizeLeft = cacheSizeLeft;
                } else {
                    cacheSizeLeft = SizeLeft;
                    SizeLeft = 0;
                }
            }
        }
        public bool VisibilityRightTop {
            get => visibilityRightTop; set {
                SetProperty(ref visibilityRightTop, value);
                if (value) {
                    SizeRightTop = cacheSizeRightTop;
                }
                else {
                    cacheSizeRightTop = SizeRightTop;
                    SizeRightTop = 0;
                }
                if (value && VisibilityRightBottom) {
                    cacheSizeRight = SizeRight;
                }
                else if (!value && VisibilityRightBottom) {
                    cacheSizeRight = SizeRight;
                }
                else if (value && !VisibilityRightBottom) {
                    SizeRight = cacheSizeRight;
                }
                else {
                    cacheSizeRight = SizeRight;
                    SizeRight = 0;
                }
            }
        }
        public bool VisibilityRightBottom {
            get => visibilityRightBottom; set {
                SetProperty(ref visibilityRightBottom, value);
                if (value) {
                    SizeRightBottom = cacheSizeRightBottom;
                }
                else {
                    cacheSizeRightBottom = SizeRightBottom;
                    SizeRightBottom = 0;
                }
                if (value && VisibilityRightTop) {
                    cacheSizeRight = SizeRight;
                }
                else if (!value && VisibilityRightTop) {
                    cacheSizeRight = SizeRight;
                }
                else if (value && !VisibilityRightTop) {
                    SizeRight = cacheSizeRight;
                }
                else {
                    cacheSizeRight = SizeRight;
                    SizeRight = 0;
                }
            }
        }
        public bool VisibilityTopLeft {
            get => visibilityTopLeft; set {
                SetProperty(ref visibilityTopLeft, value);
                if (value) {
                    SizeTopLeft = cacheSizeTopLeft;
                }
                else {
                    cacheSizeTopLeft = SizeTopLeft;
                    SizeTopLeft = 0;
                }
                if (value && VisibilityTopRight) {
                    cacheSizeTop = SizeTop;
                }
                else if (!value && VisibilityTopRight) {
                    cacheSizeTop = SizeTop;
                }
                else if (value && !VisibilityTopRight) {
                    SizeTop = cacheSizeTop;
                }
                else {
                    cacheSizeTop = SizeTop;
                    SizeTop = 0;
                }
            }
        }
        public bool VisibilityTopRight {
            get => visibilityTopRight; set {
                SetProperty(ref visibilityTopRight, value);
                if (value) {
                    SizeTopRight = cacheSizeTopRight;
                }
                else {
                    cacheSizeTopRight = SizeTopRight;
                    SizeTopRight = 0;
                }
                if (value && VisibilityTopLeft) {
                    cacheSizeTop = SizeTop;
                }
                else if (!value && VisibilityTopLeft) {
                    cacheSizeTop = SizeTop;
                }
                else if (value && !VisibilityTopLeft) {
                    SizeTop = cacheSizeTop;
                }
                else {
                    cacheSizeTop = SizeTop;
                    SizeTop = 0;
                }
            }
        }
        public bool VisibilityBottomLeft {
            get => visibilityBottomLeft; set {
                SetProperty(ref visibilityBottomLeft, value);
                if (value) {
                    SizeBottomLeft = cacheSizeBottomLeft;
                }
                else {
                    cacheSizeBottomLeft = SizeBottomLeft;
                    SizeBottomLeft = 0;
                }
                if (value && VisibilityBottomRight) {
                    cacheSizeBottom = SizeBottom;
                }
                else if (!value && VisibilityBottomRight) {
                    cacheSizeBottom = SizeBottom;
                }
                else if (value && !VisibilityBottomRight) {
                    SizeBottom = cacheSizeBottom;
                }
                else {
                    cacheSizeBottom = SizeBottom;
                    SizeBottom = 0;
                }

            }
        }
        public bool VisibilityBottomRight {
            get => visibilityBottomRight; set {
                SetProperty(ref visibilityBottomRight, value);
                if (value) {
                    SizeBottomRight = cacheSizeBottomRight;
                }
                else {
                    cacheSizeBottomRight = SizeBottomRight;
                    SizeBottomRight = 0;
                }
                if (value && VisibilityBottomLeft) {
                    cacheSizeBottom = SizeBottom;
                }
                else if (!value && VisibilityBottomLeft) {
                    cacheSizeBottom = SizeBottom;
                }
                else if (value && !VisibilityBottomLeft) {
                    SizeBottom = cacheSizeBottom;
                }
                else {
                    cacheSizeBottom = SizeBottom;
                    SizeBottom = 0;
                }
            }
        }





        public double SizeLeftTop { get => sizelLeftTop; set => SetProperty(ref sizelLeftTop, value); }
        public double SizeLeftBottom { get => sizeLeftBottom; set => SetProperty(ref sizeLeftBottom, value); }
        public double SizeRightTop { get => sizeRightTop; set => SetProperty(ref sizeRightTop, value); }
        public double SizeRightBottom { get => sizeRightBottom; set => SetProperty(ref sizeRightBottom, value); }
        public double SizeTopLeft { get => sizeTopLeft; set => SetProperty(ref sizeTopLeft, value); }
        public double SizeTopRight { get => sizeTopRight; set => SetProperty(ref sizeTopRight, value); }
        public double SizeBottomLeft { get => sizeBottomLeft; set => SetProperty(ref sizeBottomLeft, value); }
        public double SizeBottomRight { get => sizeBottomRight; set => SetProperty(ref sizeBottomRight, value); }
        public double SizeLeft { get => sizeLeft; set => SetProperty(ref sizeLeft, value); }
        public double SizeRight { get => sizeRight; set => SetProperty(ref sizeRight, value); }
        public double SizeTop { get => sizeTop; set => SetProperty(ref sizeTop, value); }
        public double SizeBottom { get => sizeBottom; set => SetProperty(ref sizeBottom, value); }
        public double SizeMiddle { get => sizeMiddle; set => SetProperty(ref sizeMiddle, value); }
        public double SizeCenter { get => sizeCenter; set => SetProperty(ref sizeCenter, value); }
    }
    public partial class ToolState {
        private double cacheSizeLeftTop = 1;
        private double cacheSizeLeftBottom = 1;
        private double cacheSizeRightTop = 1;
        private double cacheSizeRightBottom = 1;
        private double cacheSizeTopLeft = 1;
        private double cacheSizeTopRight = 1;
        private double cacheSizeBottomLeft = 1;
        private double cacheSizeBottomRight = 1;
        private double sizelLeftTop = 0;
        private double sizeLeftBottom = 0;
        private double sizeRightTop = 0;
        private double sizeRightBottom = 0;
        private double sizeTopLeft = 0;
        private double sizeTopRight = 0;
        private double sizeBottomLeft = 0;
        private double sizeBottomRight = 0;

        private double cacheSizeLeft = 200;
        private double cacheSizeRight = 200;
        private double cacheSizeTop = 100;
        private double cacheSizeBottom = 100;
        private double sizeLeft = 0;
        private double sizeRight = 0;
        private double sizeTop = 0;
        private double sizeBottom = 0;
        
        private UserControl panelLeftTop;
        private UserControl panelLeftBottom;
        private UserControl panelRightTop;
        private UserControl panelRightBottom;
        private UserControl panelTopLeft;
        private UserControl panelTopRight;
        private UserControl panelBottomLeft;
        private UserControl panelBottomRight;

        private bool visibilityTopLeft = false;
        private bool visibilityTopRight = false;
        private bool visibilityBottomLeft = false;
        private bool visibilityBottomRight = false;
        private bool visibilityLeftTop = false;
        private bool visibilityLeftBottom = false;
        private bool visibilityRightTop = false;
        private bool visibilityRightBottom = false;



        private double sizeMiddle = 2;
        private double sizeCenter = 2;

    }
    public partial class ToolState : IToolState {
        private bool visibilityToolButtons = true;
        public bool VisibilityToolButtons { get => visibilityToolButtons; set => SetProperty(ref visibilityToolButtons, value); }
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
