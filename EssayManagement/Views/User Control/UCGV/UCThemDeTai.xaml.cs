using EssayManagement.Views.GiangVienForm;
using EssayManagement.Database;
using HandyControl.Controls;
using HandyControl.Interactivity;
using HandyControl.Tools;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using System.Data.SqlClient;

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for UCThemDeTai.xaml
    /// </summary>
    public partial class UCThemDeTai : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        string maGV = Database.UserInSession.LoggedInUser.ToString();
        public UCThemDeTai()
        {
            InitializeComponent();
            List<string> LinhVuc = new List<string> { "Website", "Application", "AI", "Data", "Cloud", "Security", "Architecture" };
            cbLinhVuc.ItemsSource = LinhVuc;
        }


        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string sqlString = string.Format("INSERT INTO DETAI(TenDeTai, MoTa, CongNghe, LinhVuc, SoLuongSV, YeuCau, TrangThai, MaGV) VALUES(N'{0}',N'{1}',N'{2}', N'{3}', '{4}', N'{5}', N'{6}' ,'{7}')", 
                                                txtTenDeTai.Text, txtMoTaDeTai.Text, txtCongNghe.Text, cbLinhVuc.Text, txtSoLuongThanhVien.Text, txtYeuCau.Text, "Có thể đăng ký", maGV);
            dBconnect.ThucThi(sqlString);
            HandyControl:ControlCommands.Close.Execute(null, this);
        }
    }
}
