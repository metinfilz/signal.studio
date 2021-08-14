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
using System.Text.Json;
using System.Security.Cryptography;
using System.Xml;

namespace Signal.Studio.Workspace.Service {
    internal class StoreService : IStoreService {
        public ToolStore ToolStore { get; } = new ToolStore();
        public ToolBuilder Builder { get; }

        public StoreService() {
            Builder = new ToolBuilder(ToolStore);
        }

            
        public void ApplicationCloseRequest(CancelEventArgs e) {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement container = doc.CreateElement(string.Empty, "container", string.Empty);
            doc.AppendChild(container);
            XmlElement tools = doc.CreateElement(string.Empty, "tools", string.Empty);
            container.AppendChild(tools);
            ToolStore.State.Tools.ForEach(i => {
                XmlElement tool = doc.CreateElement(string.Empty, "T"+CreateMD5(i.Type.AssemblyQualifiedName), string.Empty);
                tool.SetAttribute("Position", i.Position.ToString());
                tool.SetAttribute("Visibility", i.Visibility.ToString());
                tools.AppendChild(tool);
            });
            XmlElement sizes = doc.CreateElement(string.Empty, "sizes", string.Empty);
            container.AppendChild(sizes);
            if (ToolStore.State.leftSizeCache.IsAbsolute) {
                var size = doc.CreateElement(string.Empty, "left", string.Empty);
                size.SetAttribute("Value", ToolStore.State.leftSizeCache.ToString());
                sizes.AppendChild(size);
            }
            if (ToolStore.State.rightSizeCache.IsAbsolute) {
                var size = doc.CreateElement(string.Empty, "right", string.Empty);
                size.SetAttribute("Value", ToolStore.State.rightSizeCache.ToString());
                sizes.AppendChild(size);
            }
            if (ToolStore.State.topSizeCache.IsAbsolute) {
                var size = doc.CreateElement(string.Empty, "top", string.Empty);
                size.SetAttribute("Value", ToolStore.State.topSizeCache.ToString());
                sizes.AppendChild(size);
            }
            if (ToolStore.State.bottomSizeCache.IsAbsolute) {
                var size = doc.CreateElement(string.Empty, "top", string.Empty);
                size.SetAttribute("Value", ToolStore.State.bottomSizeCache.ToString());
                sizes.AppendChild(size);
            }
            doc.Save(Builder.ToolPath);
        }


        public static string CreateMD5(string input) {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create()) {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++) {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


        static void EncryptFile(string sInputFilename, string sKey) {
            FileStream fsInput = new FileStream(sInputFilename,
               FileMode.Open,
               FileAccess.ReadWrite);

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsInput,
               desencrypt,
               CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            fsInput.SetLength(0);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            fsInput.Close();
        }
        private static void DecryptFile(string sInputFilename, string sKey) {
            var DES = new DESCryptoServiceProvider();
            DES.Key = Encoding.ASCII.GetBytes(sKey);
            DES.IV = Encoding.ASCII.GetBytes(sKey);
            ICryptoTransform desdecrypt = DES.CreateDecryptor();

            using (var fsread = new FileStream(sInputFilename,
                FileMode.Open,
                FileAccess.ReadWrite)) {
                using (var cryptostreamDecr = new CryptoStream(fsread,
                    desdecrypt,
                    CryptoStreamMode.Read)) {
                    int data;

                    fsread.Flush();

                    using (var ms = new MemoryStream()) {
                        while ((data = cryptostreamDecr.ReadByte()) != -1) {
                            ms.WriteByte((byte)data);
                        }

                        cryptostreamDecr.Close();

                        using (var fsWrite = new FileStream(sInputFilename, FileMode.Truncate)) {
                            ms.WriteTo(fsWrite);
                            ms.Flush();
                        }
                    }
                }
            }
        }
    }



    public interface IStoreService {
        ToolStore ToolStore { get; }
        ToolBuilder Builder { get; }

        void ApplicationCloseRequest(CancelEventArgs e);
    }
}
