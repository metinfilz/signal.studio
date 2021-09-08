using Signal.Studio.Core;
using Signal.Studio.Sample.Tool;
using Signal.Studio.Workspace.Common;
using Signal.Studio.Workspace.Utils;
using Signal.Studio.Workspace.View;
using System;
using System.IO;
using System.Windows;

namespace Signal.Studio.Sample {
    public partial class App : Application {
        public App() {
            var repository = Repository.Instance;
            repository.General.Action.SetPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".signalstudio"));
            repository.General.Action.SetTheme("ligth");














            var toolBuilder = new ToolBuilder();

            toolBuilder.Construct<Blank5Tool>(position: ToolPosition.TopLeft, header: "Blank5").Build();
            toolBuilder.Construct<Blank6Tool>(position: ToolPosition.TopRight, header: "Blank6").Build();
            toolBuilder.Construct<Blank13Tool>(position: ToolPosition.TopLeft, header: "Blank13").Build();
            toolBuilder.Construct<Blank14Tool>(position: ToolPosition.TopRight, header: "Blank14").Build();

            toolBuilder.Construct<Blank1Tool>(position: ToolPosition.LeftTop, header: "Blank1").Build();
            toolBuilder.Construct<Blank2Tool>(position: ToolPosition.LeftBottom, header: "Blank2").Build();
            toolBuilder.Construct<Blank9Tool>(position: ToolPosition.LeftTop, header: "Blank9").Build();
            toolBuilder.Construct<Blank10Tool>(position: ToolPosition.LeftBottom, header: "Blank10").Build();

            toolBuilder.Construct<Blank3Tool>(position: ToolPosition.RightTop, header: "Blank3").Build();
            toolBuilder.Construct<Blank4Tool>(position: ToolPosition.RightBottom, header: "Blank4").Build();
            toolBuilder.Construct<Blank11Tool>(position: ToolPosition.RightTop, header: "Blank11").Build();
            toolBuilder.Construct<Blank12Tool>(position: ToolPosition.RightBottom, header: "Blank12").Build();

            toolBuilder.Construct<Blank7Tool>(position: ToolPosition.BottomLeft, header: "Blank7").Build();
            toolBuilder.Construct<Blank8Tool>(position: ToolPosition.BottomRight, header: "Blank8").Build();
            toolBuilder.Construct<Blank15Tool>(position: ToolPosition.BottomLeft, header: "Blank15").Build();
            toolBuilder.Construct<Blank16Tool>(position: ToolPosition.BottomRight, header: "Blank16").Build();
            toolBuilder.AddDefaultTools();

        }
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            var view = new WindowBase();
            view.Content = new WorkspaceView();
            view.Show();


        }
    }
}
