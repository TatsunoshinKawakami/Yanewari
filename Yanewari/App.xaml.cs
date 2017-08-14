using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Yanewari
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void AppStart(object sender, StartupEventArgs e)
        {
            var win = new Views.MainView();
            win.Show();
        }
    }
}