using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Shapes;
using Signal.Studio.Workspace.Common;
using Signal.Studio.Workspace.Utils;

namespace Signal.Studio.Workspace.Model {
    internal partial class ToolModel : IToolModel {
        private Type type;
        private ToolPosition position;
        private string header;
        private ToolViewMode viewMode;

        public Type Type { get => type; set => SetProperty(ref type, value); }
        public ToolPosition Position { get => position; set => SetProperty(ref position, value); }
        public string Header { get => header; set => SetProperty(ref header, value); }
        public ToolViewMode ViewMode { get => viewMode; set => SetProperty(ref viewMode, value); }










        private ToolBuilder builder;

#pragma warning disable CS0649 // Field 'ToolModel.icon' is never assigned to, and will always have its default value null
        public Path icon;
#pragma warning restore CS0649 // Field 'ToolModel.icon' is never assigned to, and will always have its default value null



        internal ToolModel(Type type, ToolBuilder builder) {
            this.Type = type;
            this.builder = builder;
        }
        public void Build() {
            builder.Add(this);
            builder = null;
        }




        public bool isOpen;




    }
    internal partial class ToolModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {
            if (Equals(storage, value) || string.IsNullOrEmpty(propertyName)) {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
