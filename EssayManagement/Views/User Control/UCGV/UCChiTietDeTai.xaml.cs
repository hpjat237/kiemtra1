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
using EssayManagement.Database;
using EssayManagement.Models;
using HandyControl.Interactivity;

namespace EssayManagement.Views.User_Control.UCGV
{
    /// <summary>
    /// Interaction logic for UCChiTietDeTai.xaml
    /// </summary>
    public partial class UCChiTietDeTai : UserControl
    {
        DBconnect dBconnect = new DBconnect();
        public UCChiTietDeTai()
        {
            InitializeComponent();
            List<string> LinhVuc = new List<string> { "Website", "Application", "AI", "Data", "Cloud", "Security", "Architecture" };
            cbLinhVuc.ItemsSource = LinhVuc;
        }


        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            string sqlStr = string.Format("UPDATE DETAI SET TenDeTai = N'{0}', MoTa = N'{1}' WHERE MaDeTai = '{2}'", txtTenDeTai.Text, txtMoTaDeTai.Text, txtMaDeTai.Text);
            dBconnect.ThucThi(sqlStr);
            HandyControl: ControlCommands.Close.Execute(null, this);
        }

    }
}
