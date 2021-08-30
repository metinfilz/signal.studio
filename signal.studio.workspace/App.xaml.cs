using System.Windows;
using Signal.Studio.Workspace.Resource;

namespace Signal.Studio.Workspace {
    public partial class App : Application {
        public App() {
            //var toolBuilder = new ToolBuilder();
            //_ = toolBuilder.Construct<LeftTopTool>().
            //    Position(Position.LeftTop).
            //    Header("LeftTop").
            //    ViewMode(ToolViewMode.Window).
            //    IsOpen(true);
            //_ = toolBuilder.Construct<LeftBottomTool>().
            //    Position(Position.LeftBottom).
            //    ViewMode(ToolViewMode.Dock).
            //    Header("LeftBottom");
            //_ = toolBuilder.Construct<RightTopTool>().
            //    Position(Position.LeftBottom).
            //    ViewMode(ToolViewMode.Dock).
            //    Header("RightTop");
            //_ = toolBuilder.Construct<RightBottomTool>().
            //    Position(Position.LeftBottom).
            //    ViewMode(ToolViewMode.Dock).
            //    Header("RightBottom");
            //Store.Instance.ToolAction.AddDefaultTools(toolBuilder.tools);
        }



















        public static Skin Skin { get; set; } = Skin.Red;

        public void ChangeSkin(Skin newSkin) {
            Skin = newSkin;

            foreach (ResourceDictionary dict in Resources.MergedDictionaries) {

                if (dict is ThemeResource skinDict)
                    skinDict.UpdateSource();
                else
                    dict.Source = dict.Source;
            }
        }
    }

    public enum Skin {
        Red, Blue
    }

}
