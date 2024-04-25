using EssayManagement.Views.User_Control;
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

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for UCThongTin.xaml
    /// </summary>
    public partial class UCThongTin : UserControl
    {
        public UCThongTin()
        {
            InitializeComponent();
        }

        private void btnExit_MouseEnter(object sender, MouseEventArgs e)
        {
            btnExit.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(30, 130, 251));
        }

        private void btnExit_MouseLeave(object sender, MouseEventArgs e)
        {
            btnExit.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //ucThongTin.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_SuaDiem(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Luu(object sender, RoutedEventArgs e)
        {

        }
    }
}
