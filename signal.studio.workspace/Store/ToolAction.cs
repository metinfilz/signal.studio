using Signal.Studio.Workspace.Common;
using System;
using System.Linq;
using System.Windows.Controls.Primitives;

namespace Signal.Studio.Workspace {
    public class ToolAction {
        private readonly ToolState State;

        public ToolAction(ToolState state) {
            State = state;
        }

        public void AddTool(ToolPosition position, Type tool, string header) {
            var button = new ToggleButton { Content = header };
            switch (position) {
                case ToolPosition.LeftTop:
                    button.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            State.LeftTopVisible = false;

                            State.LeftTopButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            State.LeftTopVisible = true;
                            State.LeftTopPanelContent = tool;


                            State.LeftTopButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                    };
                    State.LeftTopButtons.Add(button);
                    break;
                case ToolPosition.LeftBottom:
                    button.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            State.LeftBottomVisible= false;
                            State.LeftBottomPanelContent = tool;

                            State.LeftBottomButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            State.LeftBottomVisible = true;
                            State.LeftBottomPanelContent = tool;

                            State.LeftBottomButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                    };
                    State.LeftBottomButtons.Add(button);
                    break;
                case ToolPosition.RightTop:
                    button.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            State.RightTopVisible = false;
                            State.RightTopPanelContent = tool;


                            State.RightTopButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            State.RightTopVisible = true;

                            State.RightTopButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                    };
                    State.RightTopButtons.Add(button);
                    break;
                case ToolPosition.RightBottom:
                    button.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            State.RightBottomVisible = false;
                            
                            State.RightBottomButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            State.RightBottomVisible = true;

                            State.RightBottomButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                    };
                    State.RightBottomButtons.Add(button);
                    break;
                case ToolPosition.TopLeft:
                    button.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            State.TopLeftVisible = false;

                            State.TopLeftButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            State.TopLeftVisible = true;

                            State.TopLeftButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                    };
                    State.TopLeftButtons.Add(button);
                    break;
                case ToolPosition.TopRight:
                    button.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            State.TopRightVisible = false;

                            State.TopRightButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            State.TopRightVisible = true;

                            State.TopRightButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                    };
                    State.TopRightButtons.Add(button);
                    break;
                case ToolPosition.BottomLeft:
                    button.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            State.BottomLeftVisible = false;

                            State.BottomLeftButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            State.BottomLeftVisible = true;

                            State.BottomLeftButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                    };
                    State.BottomLeftButtons.Add(button);
                    break;
                case ToolPosition.BottomRight:
                    button.Click += (s, e) => {
                        var control = s as ToggleButton;
                        if (!(bool)control.IsChecked) {
                            State.BottomRightVisible = false;

                            State.BottomRightButtons.ToList().ForEach(i => i.IsChecked = false);
                        } else {
                            State.BottomRightVisible = true;

                            State.BottomRightButtons.ToList().ForEach(i => i.IsChecked = false);
                            control.IsChecked = true;
                        }
                    };
                    State.BottomRightButtons.Add(button);
                    break;
                default:
                    break;
            }
        }
    }
}
