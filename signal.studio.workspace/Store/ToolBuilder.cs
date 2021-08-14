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

            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                var tools = doc.GetElementsByTagName("tools")[0];
                var sizes = doc.GetElementsByTagName("sizes")[0];
                foreach(XmlNode size in sizes.ChildNodes) {
                    if (size.Name.Equals("left"))
                        Tool.State.leftSizeCache = new System.Windows.GridLength(double.Parse(size.Attributes[0].Value), System.Windows.GridUnitType.Pixel);
                    else if (size.Name.Equals("right"))
                        Tool.State.rightSizeCache = new System.Windows.GridLength(double.Parse(size.Attributes[0].Value), System.Windows.GridUnitType.Pixel);
                    if (size.Name.Equals("top"))
                        Tool.State.topSizeCache = new System.Windows.GridLength(double.Parse(size.Attributes[0].Value), System.Windows.GridUnitType.Pixel);
                    if (size.Name.Equals("bottom"))
                        Tool.State.bottomSizeCache = new System.Windows.GridLength(double.Parse(size.Attributes[0].Value), System.Windows.GridUnitType.Pixel);
                }
                foreach(XmlNode tool in tools.ChildNodes) {
                    Tool.State.Tools.ForEach(i => {
                        var name = "T"+CreateMD5(i.Type.AssemblyQualifiedName);
                        if(name == tool.Name) {
                            i.Position = (Position)Enum.Parse(typeof(Position), tool.Attributes[0].Value);
                            i.Visibility = bool.Parse(tool.Attributes[1].Value);
                        }
                    });
                }

            } catch { }



            Tool.State.Tools.ForEach(tool => {
                var button = new ToggleButton { Content = tool.ButtonHeader, Tag = tool.Type };
                button.Click += (s, e) => {
                    var control = s as ToggleButton;
                    if ((bool)control.IsChecked) {
                        Tool.State.Visibilities[tool.Position].Set(true);
                        var view = (UserControl)Activator.CreateInstance(tool.Type);
                        var config = (IToolBase)view;
                        Tool.State.Panels[tool.Position].content.Children.Add(view);
                        Tool.State.Panels[tool.Position].header.Text = config.ToolPanelHeader;
                        Tool.State.Buttons[tool.Position].ToList().ForEach(i => i.IsChecked = false);
                        Tool.State.Tools.FindAll(i => i.Position == tool.Position).ForEach(i => i.Visibility = false);
                        Tool.State.Tools.FindAll(i => i.Type.Equals(tool.Type)).ForEach(i => i.Visibility = true);
                        control.IsChecked = true;
                    } else {
                        Tool.State.Visibilities[tool.Position].Set(false);
                        Tool.State.Panels[tool.Position].content.Children.Clear();
                        Tool.State.Buttons[tool.Position].ToList().ForEach(i => i.IsChecked = false);
                        Tool.State.Tools.FindAll(i => i.Position == tool.Position).ForEach(i => i.Visibility = false);
                    }
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

        public static string CreateMD5(string input) {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create()) {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++) {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
