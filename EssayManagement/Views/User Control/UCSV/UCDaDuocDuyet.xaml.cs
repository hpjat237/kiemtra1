using EssayManagement.Database;
using HandyControl.Interactivity;
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
using HandyControl.Interactivity;

namespace EssayManagement.Views.User_Control.UCSV
{
    /// <summary>
    /// Interaction logic for UCDaDuocDuyet.xaml
    /// </summary>
    public partial class UCDaDuocDuyet : UserControl
    {
        DBconnect dBconnect = new DBconnect();
        public UCDaDuocDuyet()
        {
            InitializeComponent();
            List<string> LinhVuc = new List<string> { "Website", "Application", "AI", "Data", "Cloud", "Security", "Architecture" };
            cbLinhVuc.ItemsSource = LinhVuc;
            List<short> TienDo = new List<short> { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            cbTienDo.ItemsSource = TienDo;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            string sqlStr = string.Format("UPDATE LUANVAN SET TienDo=N'{0}' WHERE MaLuanVan = '{1}'",cbTienDo.Text, txtMaLuanVan.Text);
            dBconnect.ThucThi(sqlStr);
            HandyControl: ControlCommands.Close.Execute(null, this);
        }

        private void txtMaLuanVan_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
