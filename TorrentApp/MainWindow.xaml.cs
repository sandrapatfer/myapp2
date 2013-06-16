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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TraktClient;

namespace TorrentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _nextBigBangEpisode = 23;
        private int _nextgrimmEpisode = 19;
        private int _nextmasterchefEpisode = 60;
        private int _nextCastleEpisode = 19;

        public MainWindow()
        {
            var c = new Class1();
            InitializeComponent();
        }

        private void OpenLinkWindow(string name, int seasonNr, ref int episodeNr)
        {
            var win = new BrowserWindow();
            win.Link = string.Format(@"http://thepiratebay.se/search/{0}%20s0{1}e{2}/0/99/0",
                name,
                seasonNr,
                episodeNr);
            episodeNr++;
            win.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OpenLinkWindow("big%20bang%20theory", 6, ref _nextBigBangEpisode);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OpenLinkWindow("grimm", 2, ref _nextgrimmEpisode);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            OpenLinkWindow("masterchef%20australia", 4, ref _nextmasterchefEpisode);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            OpenLinkWindow("castle", 5, ref _nextCastleEpisode);
        }
    }
}
