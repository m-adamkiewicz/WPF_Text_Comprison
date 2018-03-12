using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace Text_Comparer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comparedLines.Text = "You are comparing line:\n" + StringComparision.a.ToString();
        }

        private void firstTextLoad_Click(object sender, RoutedEventArgs e)
        {
            file1.Text = file_readout();
        }

        private void secondTextLoad_Click(object sender, RoutedEventArgs e)
        {
            file2.Text = file_readout();
        }

        private void compare_Click(object sender, RoutedEventArgs e)
        {
            comparision_result.Text = StringComparision.Compare(file1.Text.Split('\n'), file2.Text.Split('\n'), StringComparision.a);
            comparedLines.Text = "You are comparing line:\n" + StringComparision.a.ToString();
        }

        private void nextLine_Click(object sender, RoutedEventArgs e)
        {
            StringComparision.a++;
            comparedLines.Text = "You are comparing line:\n" + StringComparision.a.ToString();
        }

        private void previousLine_Click(object sender, RoutedEventArgs e)
        {
            if(StringComparision.a > 1)
                StringComparision.a--;
            comparedLines.Text = "You are comparing line:\n" + StringComparision.a.ToString();
        }
        public string file_readout()
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "Text file (*.txt)|*.txt";
            opn.Multiselect = false;
            string str = "";
            if (opn.ShowDialog() == true)
                str = File.ReadAllText(opn.FileName);
            return str;
        }
    }
}
