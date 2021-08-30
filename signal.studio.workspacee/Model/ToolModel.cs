using System;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Position = Signal.Studio.Workspace.Common.ToolPosition;

namespace Signal.Studio.Workspace.Model {
    internal partial class ToolModel : IToolModel {
        public string ButtonHeader { get; set; }

    }
    internal partial class ToolModel {
        public Position Position { get; set; }
        public Type Type { get; set; }
        public bool Visibility { get; set; }
        public ToolModel(Position position, Type type, bool visibility) {
            Position = position;
            Type = type;
            Visibility = visibility;
        }
    }
}
