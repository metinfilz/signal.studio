using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Signal.Studio.Workspace.Model;
using Signal.Studio.Workspace.Store;
using System.Security.Cryptography;
using System.Xml;
using System.Reflection;
using System.Windows;
using System.Xml.Schema;
using Signal.Studio.Workspace.Common;

namespace Signal.Studio.Workspace.Service {
    internal class StoreService : IStoreService {
        public ToolStore ToolStore { get; } = new ToolStore();
        public ToolBuilder Builder { get; }

        public StoreService() {
            Builder = new ToolBuilder(ToolStore);
        }
    
        public void ApplicationOnClosing(CancelEventArgs e) {
            var parser = new StateXmlParser();
            parser.SaveToFile(ToolStore, Builder.ToolPath);
        }
    }

    public interface IStoreService {
        ToolStore ToolStore { get; }
        ToolBuilder Builder { get; }
        void ApplicationOnClosing(CancelEventArgs e);
    }
}
