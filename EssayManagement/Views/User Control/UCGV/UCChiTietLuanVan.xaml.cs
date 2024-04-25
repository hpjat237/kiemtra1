using EssayManagement.Database;
using EssayManagement.Views.User_Control.UCHS;
using HandyControl.Controls;
using HandyControl.Interactivity;
using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EssayManagement.Views.User_Control.UCGV
{
    /// <summary>
    /// Interaction logic for UCChiTietLuanVan.xaml
    /// </summary>
    public partial class UCChiTietLuanVan : UserControl
    {
        DBconnect dBconnect = new DBconnect();
        public UCChiTietLuanVan()
        {
            InitializeComponent();
            List<string> LinhVuc = new List<string> { "Website", "Application", "AI", "Data", "Cloud", "Security", "Architecture" };
            cbLinhVuc.ItemsSource = LinhVuc;
        }

        private void txtLuu_Click(object sender, RoutedEventArgs e)
        {
            string sqlStr = string.Format("UPDATE LUANVAN SET NgayDangKy = '{0}', NgayKetThuc = '{1}', NhanXet = N'{2}', YeuCau = N'{3}' WHERE MaLuanVan = '{4}'", dtpNgayDangKy.Text, dtpNgayKetThuc.Text, txtNhanXet.Text, txtYeuCau.Text, txtMaLuanVan.Text);
            dBconnect.ThucThi(sqlStr);
            HandyControl: ControlCommands.Close.Execute(null, this);
        }

        private void txtNhiemVu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string maLuanVan = this.txtMaLuanVan.Text.ToString();
                UCNhiemVu ucNhiemVu = new UCNhiemVu(maLuanVan);
                ucNhiemVu.txtMaLuanVan.Text = maLuanVan;
                Dialog.Show(ucNhiemVu);
            }
            catch (Exception ex)
            {
                Growl.ErrorGlobal(ex.Message);
            }
        }
    }
}