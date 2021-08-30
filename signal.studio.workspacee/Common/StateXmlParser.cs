using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;

using Position = Signal.Studio.Workspace.Common.ToolPosition;

namespace Signal.Studio.Workspace.Common {
    internal class StateXmlParser {
        public void SaveToFile(ToolStore store, string path) {
            var view = Application.Current.MainWindow;
            if (view == null) return;
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement container = doc.CreateElement(string.Empty, "Container", string.Empty);
            XmlElement window = doc.CreateElement(string.Empty, "Window", string.Empty);
            XmlElement tools = doc.CreateElement(string.Empty, "Tools", string.Empty);
            XmlElement toolList = doc.CreateElement(string.Empty, "List", string.Empty);
            XmlElement toolSizes = doc.CreateElement(string.Empty, "Sizes", string.Empty);
            doc.AppendChild(container);
            container.AppendChild(window);
            container.AppendChild(tools);
            tools.AppendChild(toolList);
            tools.AppendChild(toolSizes);
            window.SetAttribute("Top", view.Top.ToString());
            window.SetAttribute("Left", view.Left.ToString());
            window.SetAttribute("Width", view.Width.ToString());
            window.SetAttribute("Height", view.Height.ToString());
            window.SetAttribute("WindowState", view.WindowState.ToString());
            store.State.Tools.ForEach(i => {
                XmlElement tool = doc.CreateElement(string.Empty, "Tool", string.Empty);
                tool.SetAttribute("Value", "T" + CreateMD5(i.Type.AssemblyQualifiedName));
                tool.SetAttribute("Position", i.Position.ToString());
                tool.SetAttribute("Visibility", i.Visibility.ToString());
                toolList.AppendChild(tool);
            });
            store.State.Sizes.ToList().ForEach(i => {
            XmlElement size = doc.CreateElement(string.Empty, "Size", string.Empty);
            size.SetAttribute("Position", i.Key.ToString());
            size.SetAttribute("Value", ((GridLength)i.Value.Get()).Value.ToString());
            toolSizes.AppendChild(size);
            });
            if (store.State.leftSizeCache.IsAbsolute) {
                XmlElement size = doc.CreateElement(string.Empty, "Size", string.Empty);
                size.SetAttribute("Position", "Left");
                size.SetAttribute("Value", store.State.leftSizeCache.ToString());
                toolSizes.AppendChild(size);
            }
            if (store.State.rightSizeCache.IsAbsolute) {
                XmlElement size = doc.CreateElement(string.Empty, "Size", string.Empty);
                size.SetAttribute("Position", "Right");
                size.SetAttribute("Value", store.State.rightSizeCache.ToString());
                toolSizes.AppendChild(size);
            }
            if (store.State.topSizeCache.IsAbsolute) {
                XmlElement size = doc.CreateElement(string.Empty, "Size", string.Empty);
                size.SetAttribute("Position", "Top");
                size.SetAttribute("Value", store.State.topSizeCache.ToString());
                toolSizes.AppendChild(size);
            }
            if (store.State.bottomSizeCache.IsAbsolute) {
                XmlElement size = doc.CreateElement(string.Empty, "Size", string.Empty);
                size.SetAttribute("Position", "Bottom");
                size.SetAttribute("Value", store.State.bottomSizeCache.ToString());
                toolSizes.AppendChild(size);
            }
            doc.Save(path);
        }
        public void LoadFromFile(ToolStore store, string path) {
            try {
                var view = Application.Current.MainWindow;
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                var window = doc.GetElementsByTagName("Window")[0];
                view.Top = double.Parse(window.Attributes[0].Value);
                view.Left = double.Parse(window.Attributes[1].Value);
                view.Width = double.Parse(window.Attributes[2].Value);
                view.Height = double.Parse(window.Attributes[3].Value);
                view.WindowState = (WindowState)Enum.Parse(typeof(WindowState), window.Attributes[4].Value);
                var sizes = doc.GetElementsByTagName("Sizes")[0];
                var listSize = sizes.ChildNodes;
                for (int i = 0; i < listSize.Count; i++) {
                    var size = listSize[i];
                    if (size.Attributes[0].Value.Equals("Left"))
                    store.State.leftSizeCache = new GridLength(double.Parse(size.Attributes[1].Value), GridUnitType.Pixel);
                    else if (size.Attributes[0].Value.Equals("Right"))
                        store.State.rightSizeCache = new GridLength(double.Parse(size.Attributes[1].Value), GridUnitType.Pixel);
                    else if (size.Attributes[0].Value.Equals("Top"))
                        store.State.topSizeCache = new GridLength(double.Parse(size.Attributes[1].Value), GridUnitType.Pixel);
                    else if (size.Attributes[0].Value.Equals("Bottom"))
                        store.State.bottomSizeCache = new GridLength(double.Parse(size.Attributes[1].Value), GridUnitType.Pixel);
                    else {
                        store.State.Sizes[(Position)Enum.Parse(typeof(Position), size.Attributes[0].Value)].Set(new GridLength(double.Parse(size.Attributes[1].Value), GridUnitType.Star));
                    }
                }
                var tools = doc.GetElementsByTagName("List")[0];
                var listTool = tools.ChildNodes;
                for (int i = 0; i < listTool.Count; i++) {
                    var tool = listTool[i];
                    store.State.Tools.ForEach(i => {
                        var name = "T" + CreateMD5(i.Type.AssemblyQualifiedName);
                        if (tool.Attributes[0].Value.Equals(name)) {
                            i.Position = (Position)Enum.Parse(typeof(Position), tool.Attributes[1].Value);
                            i.Visibility = bool.Parse(tool.Attributes[2].Value);
                        }
                    });
                }



                //    foreach(XmlNode size in sizes.ChildNodes) {
                //    }





            } catch { }



            //try {
            //    XmlDocument doc = new XmlDocument();
            //    doc.Load(path);
            //    var tools = doc.GetElementsByTagName("tools")[0];
            //    var sizes = doc.GetElementsByTagName("sizes")[0];
            //    foreach(XmlNode size in sizes.ChildNodes) {
            //        if (size.Name.Equals("left"))
            //            Tool.State.leftSizeCache = new System.Windows.GridLength(double.Parse(size.Attributes[0].Value), System.Windows.GridUnitType.Pixel);
            //        else if (size.Name.Equals("right"))
            //            Tool.State.rightSizeCache = new System.Windows.GridLength(double.Parse(size.Attributes[0].Value), System.Windows.GridUnitType.Pixel);
            //        if (size.Name.Equals("top"))
            //            Tool.State.topSizeCache = new System.Windows.GridLength(double.Parse(size.Attributes[0].Value), System.Windows.GridUnitType.Pixel);
            //        if (size.Name.Equals("bottom"))
            //            Tool.State.bottomSizeCache = new System.Windows.GridLength(double.Parse(size.Attributes[0].Value), System.Windows.GridUnitType.Pixel);
            //    }
            //    foreach(XmlNode tool in tools.ChildNodes) {
            //        Tool.State.Tools.ForEach(i => {
            //            var name = "T"+CreateMD5(i.Type.AssemblyQualifiedName);
            //            if(name == tool.Name) {
            //                i.Position = (Position)Enum.Parse(typeof(Position), tool.Attributes[0].Value);
            //                i.Visibility = bool.Parse(tool.Attributes[1].Value);
            //            }
            //        });
            //    }

            //} catch { }
        }

        private static string CreateMD5(string input) {
            using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create(); byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++) {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
