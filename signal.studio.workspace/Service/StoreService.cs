using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal.Studio.Workspace.Service {
    internal class StoreService : IStoreService {
        public ToolStore ToolStore { get; } = new ToolStore();
    }
    public interface IStoreService {
        ToolStore ToolStore { get; }
    }
}
