using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace PhotoStore.UtilityServices
{
    public delegate List<T> Export<T>();
    public delegate string Import<T>(List<T> lists,string applicationPath);
    public class XMLSerializingService:IDisposable
    {
        FileStream _fs;
        XmlSerializer _xs;
        public XMLSerializingService(
            string path, FileMode fileMode)
        {
            _fs = new FileStream(path, fileMode);
            
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_fs != null)
            {
                _fs.Dispose();
                _fs = null;
            }
            _xs = null;
        }

        #endregion

        public void Export<T>(Export<T> exportDelegate)
        {
            List<T> lists = exportDelegate();
            _xs=new XmlSerializer(typeof(List<T>),new Type[]{typeof(T)});
            _xs.Serialize(_fs, lists);
        }

        public string Import<T>(Import<T> importDelegate,string applicationPath)
        {
            string response = "";
            _xs = new XmlSerializer(typeof(List<T>), new Type[] { typeof(T) });
            List<T> lists = (List<T>)_xs.Deserialize(_fs);
            if (lists.Count > 0)
            {
                response = importDelegate(lists,applicationPath);
            }
            else
            {
                response = "Invalid Type";
            }


           
            return response;
        }

        ~XMLSerializingService()
        {
            Dispose();
        }
    }
}
