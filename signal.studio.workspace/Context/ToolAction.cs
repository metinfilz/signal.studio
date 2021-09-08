using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Signal.Studio.Core;
using Signal.Studio.Workspace.Common;
using Signal.Studio.Workspace.Model;
using Signal.Studio.Workspace.Utils;
using Signal.Studio.Workspace.View;

namespace Signal.Studio.Workspace.Context {
    public partial class ToolAction {
        private ToolState State { get; }
        internal ToolAction(ToolState state) {
            State = state;
        }
        public void AddDefaultTools(List<IToolModel> list) {
            list.ForEach(i => {
                if (State.Tools.FirstOrDefault(j => j.Type == i.Type) == null) {
                    State.Tools.Add(i);
                }
            });
        }
        internal void CloseTool(ToolPosition position) {
            State.Visibles[position].Set(false);
            State.ToolDocks[position].Set(null);
            State.Buttons[position].Where(i => ((ToolToggleButton)i).ToolModel.ViewMode == ToolViewMode.Dock).ToList().ForEach(i => i.IsChecked = false);
        }
        internal void MoveTool(ToolPosition position) {
            switch (position) {
                case ToolPosition.LeftTop:
                    break;
                case ToolPosition.LeftBottom:
                    break;
                case ToolPosition.RightTop:
                    break;
                case ToolPosition.RightBottom:
                    break;
                case ToolPosition.TopLeft:
                    break;
                case ToolPosition.TopRight:
                    break;
                case ToolPosition.BottomLeft:
                    break;
                case ToolPosition.BottomRight:
                    break;
                default:
                    break;
            }
        }
    }

    public partial class ToolAction : IToolAction {
        public void ChangeToolButtonVisibility(bool visibility) {
            State.VisibilityToolButtons = visibility;
            Debug.WriteLine(Repository.Instance.General.State.GeneralPath);
        }
    }
}
