using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using mshtml;

namespace TorrentApp
{
    /// <summary>
    /// Interaction logic for BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        public string Link { get; set; }

        public BrowserWindow()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            webBrowser1.Navigate(Link);
            webBrowser1.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(webBrowser1_LoadCompleted);
            base.Show();
        }

        void webBrowser1_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (IsActive)
            {
                var content = webBrowser1.Document as IHTMLDocument2;
                var htmlBodyText = content.body.innerHTML;
                if (htmlBodyText != null)
                {
                    var x = htmlBodyText.IndexOf("<div class=download>", StringComparison.InvariantCultureIgnoreCase);
                    if (x == -1)
                    {
                        return;
                    }
                    htmlBodyText = htmlBodyText.Substring(x);
                    x = htmlBodyText.IndexOf("href=\"");
                    if (x == -1)
                    {
                        return;
                    }
                    htmlBodyText = htmlBodyText.Substring(x + 6);
                    x = htmlBodyText.IndexOf("\"");
                    if (x == -1)
                    {
                        return;
                    }
                    var href = htmlBodyText.Substring(0, x);
                    webBrowser1.Navigate(href);
                    Close();
                }
            }
        }
    }
}
