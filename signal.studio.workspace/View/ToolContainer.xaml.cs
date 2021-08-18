using Signal.Studio.Workspace.Common;
using Signal.Studio.Workspace.Service;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Position = Signal.Studio.Workspace.Common.ToolPosition;

namespace Signal.Studio.Workspace.View {
    public partial class ToolContainer : UserControl {
        public IStoreService Store { get; }
        public ToolStore ToolStore => Store.ToolStore;
        public ToolContainer() {
            Store = Resolver.Resolve<IStoreService>();
            InitializeComponent();
            ToolStore.State.Panels.Add(Position.TopLeft, TopLeftPanel);
            ToolStore.State.Panels.Add(Position.TopRight, TopRightPanel);
            ToolStore.State.Panels.Add(Position.BottomLeft, BottomLeftPanel);
            ToolStore.State.Panels.Add(Position.BottomRight, BottomRightPanel);
            ToolStore.State.Panels.Add(Position.LeftTop, LeftTopPanel);
            ToolStore.State.Panels.Add(Position.LeftBottom, LeftBottomPanel);
            ToolStore.State.Panels.Add(Position.RightTop, RightBottomPanel);
            ToolStore.State.Panels.Add(Position.RightBottom, RightBottomPanel);
        }

        protected override void OnVisualParentChanged(DependencyObject oldParent) {
            base.OnVisualParentChanged(oldParent);
            var view = Application.Current.MainWindow;
            view.Loaded += (s, e) => {
            };
        }
    }
}
