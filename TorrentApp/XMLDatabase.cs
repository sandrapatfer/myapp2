using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace TorrentApp
{
    class XMLDatabase
    {
        public void LoadData()
        {
            XElement dataRoot;

            var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fileName = Path.Combine(myDocs, "TorrentSeries.xml");
            if (File.Exists(fileName))
            {
            }
            else
            {
                dataRoot = new XElement("root");        
            }
        }
    }
}
