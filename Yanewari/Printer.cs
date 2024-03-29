﻿using System.Collections.Generic;
using System.Windows.Controls;
using System.Printing;
using System.Windows.Xps;
using System.Windows.Documents;
using System.Windows.Markup;
using Yanewari.ViewModels;
using Yanewari.Views;

namespace Yanewari
{
	public static class Printer
	{
		public static void Print(MainViewModel viewModel)
		{
			//Set up the WPF Control to be printed

			var fixedDoc = new FixedDocument();

			var objReportToPrint = new ToPrint();

			var ReportToPrint = objReportToPrint as UserControl;
			ReportToPrint.DataContext = viewModel;

			var pageContent = new PageContent();
			var fixedPage = new FixedPage();

			//Create first page of document
			fixedPage.Children.Add(ReportToPrint);
			((IAddChild)pageContent).AddChild(fixedPage);
			fixedDoc.Pages.Add(pageContent);

			SendFixedDocumentToPrinter(fixedDoc);
		}

		private static void SendFixedDocumentToPrinter(FixedDocument fixedDocument)
		{
			XpsDocumentWriter xpsdw;

			PrintDocumentImageableArea imgArea = null;
			//こちらのオーバーロードだと、プリンタ選択ダイアログが出る。
			xpsdw = PrintQueue.CreateXpsDocumentWriter(ref imgArea);

			if(xpsdw == null) { return; }

			//var ps = new LocalPrintServer();
			//var pq = ps.DefaultPrintQueue; 
			//こちらのオーバーロードだと、プリンタ選択ダイアログを飛ばして既定のプリンタにスプールされる
			//xpsdw = PrintQueue.CreateXpsDocumentWriter(pq);
			xpsdw.Write(fixedDocument);
		}
	}
}