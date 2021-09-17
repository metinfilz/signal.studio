using Signal.Studio.Core.Repositories;

namespace Signal.Studio.Core {
    public sealed partial class Repository {
        public (IGeneralState State, IGeneralAction Action) General {
            get;
        }
    }
    public sealed partial class Repository {
        public static Repository Instance { get; } = new();
        public Repository() {
            var generalState = new GeneralState();
            var generalAction = new GeneralAction(generalState);
            General = (generalState, generalAction);
        }
    }
}
