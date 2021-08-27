using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using System.Xml;
using Signal.Studio.Workspace.Common;
using Signal.Studio.Workspace.Model;
using Position = Signal.Studio.Workspace.Common.ToolPosition;


namespace Signal.Studio.Workspace.Store {
    public class ToolBuilder {

        private ToolStore Tool;
        private bool BuildState = false;
        public ToolBuilder(ToolStore tool) {
            Tool = tool;
        }
        internal string ToolPath { get; set; }

        public IToolModel CreateTool<T>(Position leftTop, bool visibility) where T : IToolBase {
            return new ToolModel(leftTop, typeof(T), visibility);
        }
        public void AddTool(IToolModel value) {
            if (value == null) return;
            var tool = (ToolModel)value;
            Tool.State.Tools.Add(tool);
        }
        public void Build(string path) {
            if (BuildState) return;
            ToolPath = path;
            var parser = new StateXmlParser();
            parser.LoadFromFile(Tool, path);

            Tool.State.Tools.ForEach(tool => {
                var button = new ToggleButton { Content = tool.ButtonHeader, Tag = tool.Type };
                button.Click += (s, e) => {
                    var control = s as ToggleButton;
                    if ((bool)control.IsChecked) Tool.Action.OpenTool(tool.Position, control);
                    else Tool.Action.CloseTool(tool.Position);
                };
                Tool.State.Buttons[tool.Position].Add(button);

            });
            Tool.State.Tools.FindAll(i => i.Visibility == true).ForEach(i => {
                var button = Tool.State.Buttons[i.Position].ToList().Find(k => k.Content.Equals(i.ButtonHeader));
                Tool.State.Visibilities[i.Position].Set(true);
                var view = (UserControl)Activator.CreateInstance(i.Type);
                var config = (IToolBase)view;
                Tool.State.Panels[i.Position].content.Children.Add(view);
                Tool.State.Panels[i.Position].header.Text = config.ToolPanelHeader;
                Tool.State.Buttons[i.Position].ToList().ForEach(i => i.IsChecked = false);
                button.IsChecked = true;
            });
            BuildState = true;
        }
    }
}
