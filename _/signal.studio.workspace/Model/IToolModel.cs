using System;
using System.ComponentModel;
using Signal.Studio.Workspace.Utils;

namespace Signal.Studio.Workspace.Model {
    public interface IToolModel {
        event PropertyChangedEventHandler PropertyChanged;

        Type Type { get; }
        ToolPosition Position { get; }
        string Header { get; set; }
        ToolViewMode ViewMode { get; }

        void Build();
    }
}
