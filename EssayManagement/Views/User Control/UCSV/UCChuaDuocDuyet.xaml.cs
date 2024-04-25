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
using HandyControl.Tools;
using HandyControl.Controls;

namespace EssayManagement.Views.User_Control.UCSV
{
    /// <summary>
    /// Interaction logic for UCChuaDuocDuyet.xaml
    /// </summary>
    public partial class UCChuaDuocDuyet : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        string maSV = Database.UserInSession.LoggedInUser.ToString();

        public UCChuaDuocDuyet()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetLang("en");
            load_data(maSV);
        }

        public void load_data(string maSV)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT MaNhom FROM SINHVIEN WHERE MaSV='{0}'", maSV);
                var maNhom = dBconnect.LayGiaTri(sqlStr);
                sqlStr = string.Format("SELECT * FROM YEUCAUDANGKY WHERE MaYeuCau='{0}'", maNhom);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtYeuCauDangKy = new DataTable();
                adapter.Fill(dtYeuCauDangKy);
                dgvYeuCauDuyet.ItemsSource = dtYeuCauDangKy.DefaultView;
            }
            catch (Exception ex)
            {
                GrowlSettings.ShowGrowlError(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            load_data(maSV);
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            string sqlStr = "";
            DataRowView dtr = (DataRowView)dgvYeuCauDuyet.SelectedItem;
            var maYeuCau = dtr.Row["MaYeuCau"].ToString();
            sqlStr = string.Format("SELECT MaNhom FROM SINHVIEN WHERE MaSV='{0}'", maSV);
            var maNhom = dBconnect.LayGiaTri(sqlStr);
            sqlStr = string.Format(@"
                DELETE FROM YEUCAUDANGKY WHERE MaYeuCau = N'{0}';
                UPDATE SINHVIEN SET MaNhom = '' WHERE MaNhom = '{1}';
            ", maYeuCau, maNhom); dBconnect.ThucThi(sqlStr);
            load_data(maSV);
        }
    }
}
