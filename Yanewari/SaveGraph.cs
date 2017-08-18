using System.Collections.Generic;
using System.Windows.Controls;
using System.Printing;
using System.IO;
using System.Windows.Input;
using System.Windows;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Windows.Documents;
using System.Windows.Markup;
using Yanewari.ViewModels;
using Yanewari.Views;

namespace Yanewari
{
    public static class SaveGraph
    {
        public static void Save(MainViewModel viewModel, string path)
        {
            using (XpsDocument xpsdoc = new XpsDocument(path, FileAccess.Write))
            {
                XpsDocumentWriter xpsdw = XpsDocument.CreateXpsDocumentWriter(xpsdoc);
                VisualsToXpsDocument vToXpsD = (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();

                var fixedDoc = new FixedDocument();

                var objReportToPrint = new ToPrint();

                var ReportToPrint = objReportToPrint as UserControl;
                ReportToPrint.DataContext = viewModel;

                vToXpsD.Write(ReportToPrint);
                vToXpsD.EndBatchWrite();
            }
        }
    }
}