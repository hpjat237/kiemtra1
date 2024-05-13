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
        string maGV = Database.UserInSession.LoggedInUser.ToString();

        public UCThemThongBao()
        {
            InitializeComponent();
            load_maNhom();
        }

        private void load_maNhom()
        {
            string sqlStr = string.Format("SELECT * FROM LUANVAN WHERE MaGV = '{0}'", maGV);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataTable dtMaNhom = new DataTable();
            adapter.Fill(dtMaNhom);

            List<string> lstMaNhom = new List<string>();
            foreach(DataRow row in dtMaNhom.Rows)
                lstMaNhom.Add(row["MaLuanVan"].ToString());
            txtMaNhom.ItemsSource = lstMaNhom;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string sqlString = string.Format("INSERT INTO THONGBAO(MaNhom, TieuDe, NoiDung, NgayGui, MaGV) VALUES(N'{0}',N'{1}',N'{2}','{3}', '{4}')", txtMaNhom.Text, txtTieuDe.Text, txtNoiDung.Text, DateTime.Now, maGV);
            dBconnect.ThucThi(sqlString);
            HandyControl: ControlCommands.Close.Execute(null, this);
        }
    }
}
