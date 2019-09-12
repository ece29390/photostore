using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;

using System.Configuration;
namespace PhotoStore.UtilityServices.Printing
{
    public class Printing : IDisposable
    {
        readonly string _applicationPath;
        public Printing(string applicationpath)
        {
            _printerName = ConfigurationManager.AppSettings["PrinterName"].ToString();
            _applicationPath = applicationpath;
        }
        private int _currentPageIndex = 0;
        private IList<Stream> _streams;
        readonly string  _printerName;
        private Stream CreateStream(string name,
            string filenameextension, Encoding encoding, string mimetype,
            bool willseek)
        {
            Stream stream = new FileStream(
                string.Format(@"{0}\{1}.{2}",_applicationPath, name, filenameextension),
                FileMode.Create);
            _streams.Add(stream);
            return stream;
            
        }

        private void Export(LocalReport report,string owner)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<DeviceInfo>");
            sb.Append(string.Format("<OutputFormat>{0}</OutputFormat>",ConfigurationManager.AppSettings["ImageName"]));
            sb.Append(string.Concat("<PageWidth>"
                , ConfigurationManager.AppSettings[string.Format("{0}Width",owner)]
                , "</PageWidth>"));
            sb.Append(
                string.Concat("<PageHeight>",
                ConfigurationManager.AppSettings[string.Format("{0}Height", owner)]
                , "</PageHeight>"));
            sb.Append(
                string.Concat("<MarginTop>",
                ConfigurationManager.AppSettings[string.Format("{0}MarginTop", owner)]
                ,"</MarginTop>"));
            sb.Append(
                string.Concat("<MarginLeft>",
                ConfigurationManager.AppSettings[string.Format("{0}MarginLeft", owner)]
                , "</MarginLeft>"));
            sb.Append(
               string.Concat("<MarginRight>",
               ConfigurationManager.AppSettings[string.Format("{0}MarginRight", owner)]
               , "</MarginRight>"));
            sb.Append(
              string.Concat("<MarginBottom>",
              ConfigurationManager.AppSettings[string.Format("{0}MarginBottom", owner)]
              , "</MarginBottom>"));
            //sb.Append(
            // string.Concat("<Orientation>",
            // ConfigurationManager.AppSettings[string.Format("{0}Orientation", owner)]
            // , "</Orientation>"));
            sb.Append(
             string.Concat("<DPiX>",
             ConfigurationManager.AppSettings[string.Format("{0}DPiX", owner)]
             , "</DPiX>"));
            sb.Append(
            string.Concat("<DPiY>",
            ConfigurationManager.AppSettings[string.Format("{0}DPiY", owner)]
            , "</DPiY>"));
            sb.Append(
             string.Concat("<ColumnSpacing>",
             ConfigurationManager.AppSettings[string.Format("{0}ColumnSpacing", owner)]
             , "</ColumnSpacing>"));
            sb.Append("<ColorDepth>32</ColorDepth>");
            sb.Append("</DeviceInfo>");
            _streams = new List<Stream>();
            Warning[] warnings;
            report.Render(
                "Image", sb.ToString(), CreateStream, out warnings);

            foreach (Stream stream in _streams)
            {
                stream.Position = 0;
            }

        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
	    {
            Metafile pageImage = new
              Metafile(_streams[_currentPageIndex]);
	            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
	            _currentPageIndex++;
	            ev.HasMorePages = (_currentPageIndex < this._streams.Count);

            
        }
        private void Print()
        {
            if (_streams == null || _streams.Count == 0)
                return;

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = _printerName;

            if (!printDocument.PrinterSettings.IsValid)
            {
                throw new Exception(string.Format("Can't find printer \"{0}\".",
                    _printerName));
            }

            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            PageSettings pageSettings = printDocument.DefaultPageSettings;
            pageSettings.Landscape = false;
            
            //pageSettings.PaperSize = new PaperSize("Half Letter", 5, 8);
            printDocument.Print();
        }

        public void Run(string owner,LocalReport report)
        {
            Export(report, owner);
            Print();
        }
        #region IDisposable Members

        public void Dispose()
        {
            if (_streams != null)
            {
                foreach (Stream stream in _streams)
                {
                    stream.Close();
                   
                }
                _streams = null;
            }

            string[] fileNames = Directory.GetFiles(_applicationPath,
                string.Format("*.{0}",
                ConfigurationManager.AppSettings["ImageName"].ToString().ToLower()));
            foreach(string file in fileNames)
            {
                    File.Delete(file);
            }
                
        }

        #endregion
    }

}
