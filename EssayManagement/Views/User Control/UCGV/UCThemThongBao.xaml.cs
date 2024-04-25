using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using EssayManagement.Database;
using HandyControl.Interactivity;

namespace EssayManagement.Views.User_Control.UCGV
{
    /// <summary>
    /// Interaction logic for UCThemThongBao.xaml
    /// </summary>
    public partial class UCThemThongBao : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();

        public UCThemThongBao()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string sqlString = string.Format("INSERT INTO THONGBAO(MaNhom, TieuDe, NoiDung, NgayGui) VALUES(N'{0}',N'{1}',N'{2}','{3}')", txtMaNhom.Text, txtTieuDe.Text, txtNoiDung.Text, DateTime.Now);
            dBconnect.ThucThi(sqlString);
            HandyControl: ControlCommands.Close.Execute(null, this);
        }
    }
}
