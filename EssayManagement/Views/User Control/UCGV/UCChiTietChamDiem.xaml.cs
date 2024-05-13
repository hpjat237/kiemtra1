using EssayManagement.Database;
using HandyControl.Controls;
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

namespace EssayManagement.Views.User_Control.UCGV
{
    /// <summary>
    /// Interaction logic for UCChiTietChamDiem.xaml
    /// </summary>
    public partial class UCChiTietChamDiem : UserControl
    {
        DBconnect dBconnect = new DBconnect();
        public UCChiTietChamDiem()
        {
            InitializeComponent();
            List<string> LinhVuc = new List<string> { "Website", "Application", "AI", "Data", "Cloud", "Security", "Architecture" };
            cbLinhVuc.ItemsSource = LinhVuc;
        }

        private void txtChamDiem_Click(object sender, RoutedEventArgs e)
        {
            int cnt = 0;
            if (txbDiem1.Text != "") cnt++;
            if (txbDiem2.Text != "") cnt++;
            if (txbDiem3.Text != "") cnt++;
            double diem1;
            double diem2;
            double diem3;
            if (txbDiem1.Text == "") diem1 = 0;
            else diem1 = Convert.ToDouble(txbDiem1.Text);
            if (txbDiem2.Text == "") diem2 = 0;
            else diem2 = Convert.ToDouble(txbDiem2.Text);
            if (txbDiem3.Text == "") diem3 = 0;
            else diem3 = Convert.ToDouble(txbDiem3.Text);
            double diemLuanVan = (diem1 + diem2 + diem3) / cnt;
            string sqlStr = string.Format("UPDATE LUANVAN SET Diem = '{0}', Diem1 = '{1}', Diem2 = '{2}', Diem3 = '{3}' WHERE MaLuanVan = '{4}'", diemLuanVan, txbDiem1.Text, txbDiem2.Text, txbDiem3.Text, txtMaLuanVan.Text);
            dBconnect.ThucThi(sqlStr);
            if (txbDiem1.Text != "" && txbDiem2.Text != "" && txbDiem3.Text!="")
            {
                sqlStr = string.Format("UPDATE LUANVAN SET TrangThai = 'DaCham' WHERE MaLuanVan = '{0}'", txtMaLuanVan.Text);
                dBconnect.ThucThi(sqlStr);
            }
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
