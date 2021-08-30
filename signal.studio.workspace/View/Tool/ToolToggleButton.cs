using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using Signal.Studio.Workspace.Context;
using Signal.Studio.Workspace.Model;
using Signal.Studio.Workspace.Utils;

namespace Signal.Studio.Workspace.View {
    internal partial class ToolToggleButton : ToggleButton {
        private ToolState State => Store.Instance.ToolState;


        public IToolModel ToolModel { get; internal set; }
        internal ToolToggleButton() {
            Focusable = false;
            IsTabStop = false;
            FocusVisualStyle = null;

        }
        internal void Configure() {
            Content = ToolModel.Header;
            Click += (s, e) => {
                if ((bool)IsChecked) {
                    if (ToolModel.ViewMode == ToolViewMode.Dock) {
                        Store.Instance.ToolState.Buttons[ToolModel.Position].Where(i => i != this).Where(i => ((ToolToggleButton)i).ToolModel.ViewMode == ToolViewMode.Dock).ToList().ForEach(i => i.IsChecked = false);
                        Store.Instance.ToolState.ToolDocks[ToolModel.Position].Set((UserControl)Activator.CreateInstance(ToolModel.Type));
                        Store.Instance.ToolState.Visibles[ToolModel.Position].Set(true);
                    }
                    else if (ToolModel.ViewMode == ToolViewMode.Window) {
                        var view = new ToolWindow { ToolModel = ToolModel };
                        view.Configure();
                    }
                }
                else {
                    if (ToolModel.ViewMode == ToolViewMode.Dock) {
                        Store.Instance.ToolState.Buttons[ToolModel.Position].Where(i => ((ToolToggleButton)i).ToolModel.ViewMode == ToolViewMode.Dock).ToList().ForEach(i => i.IsChecked = false);
                        Store.Instance.ToolState.ToolDocks[ToolModel.Position].Set(null);
                        Store.Instance.ToolState.Visibles[ToolModel.Position].Set(false);
                    }
                    else if (ToolModel.ViewMode == ToolViewMode.Window) {
                        Store.Instance.ToolState.ToolWindows.FindAll(i => i.ToolModel == ToolModel).ForEach(i => {
                            i.Close();
                        });
                    }
                }
            };
            SetStyle();
        }
        private void SetStyle() {

            var resource = new ResourceDictionary();
            resource.Source = new Uri("pack://application:,,,/Signal.Studio.Workspace;component/Resource/Theme/IntellijLightResource.xaml", uriKind: UriKind.RelativeOrAbsolute);

            var style = new Style();
            var header = new FrameworkElementFactory(typeof(TextBlock));
            header.SetValue(TextBlock.TextProperty, ToolModel.Header);
            var stack = new FrameworkElementFactory(typeof(StackPanel));
            stack.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Center);
            stack.SetValue(VerticalAlignmentProperty, VerticalAlignment.Center);
            stack.SetValue(MarginProperty, new Thickness(8, 0, 8, 0));
            var border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(HeightProperty, 21.0);
            border.SetBinding(BackgroundProperty, new Binding { RelativeSource = RelativeSource.TemplatedParent, Path = new PropertyPath("Background") });
            stack.AppendChild(header);
            border.AppendChild(stack);
            var template = new ControlTemplate(typeof(ToolToggleButton)) { VisualTree = border };
            style.Setters.Add(new Setter { Property = TemplateProperty, Value = template });
            style.Setters.Add(new Setter { Property = BackgroundProperty, Value = Brushes.Transparent });
            var hoverTrigger = new Trigger { Property = IsMouseOverProperty, Value = true };
            hoverTrigger.Setters.Add(new Setter { Property = BackgroundProperty, Value = resource["colors.border"] as SolidColorBrush });
            var checkedTrigger = new Trigger { Property = IsCheckedProperty, Value = true };
            checkedTrigger.Setters.Add(new Setter { Property = BackgroundProperty, Value = resource["colors.border"] as SolidColorBrush });
            style.Triggers.Add(hoverTrigger);
            style.Triggers.Add(checkedTrigger);
            Style = style;
        }
    }
    internal partial class ToolToggleButton {









    }

}
