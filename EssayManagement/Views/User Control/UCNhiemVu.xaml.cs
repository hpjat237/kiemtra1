using EssayManagement.Views.User_Control.UCSV;
using HandyControl.Controls;
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
using EssayManagement.Views.Windows;
using System.Xml.Linq;
using EssayManagement.Database;
using EssayManagement.Views.User_Control.UCHS;
using EssayManagement.Models;
using System.Windows.Threading;
using EssayManagement.Views.User_Control.UCGV;

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for UCNhiemVu.xaml
    /// </summary>
    public partial class UCNhiemVu : UserControl{
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        string maNguoiDung = Database.UserInSession.LoggedInUser.ToString();
        string maLV = "";

        public UCNhiemVu()
        {

            if (Parent is FSinhVien)
            {
                btnExit.Visibility = Visibility.Collapsed;
            }
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        public UCNhiemVu(string maLuanVan)
        {

            if (Parent is FSinhVien)
            {
                btnExit.Visibility = Visibility.Collapsed;
            }
            maLV = maLuanVan;
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            load_data(maNguoiDung);
        }

        public DataTable load_data(string ma){
            try
            {
                conn.Open();
                string sqlStr = "";
                if (maNguoiDung.Contains("GV")) 
                {
                    sqlStr = string.Format("SELECT MaLuanVan FROM LUANVAN WHERE MaLuanVan='{0}'", maLV);

                }
                else
                {
                    sqlStr = string.Format("SELECT MaNhom FROM SINHVIEN WHERE MaSV='{0}'", maNguoiDung);
                }
                var maLuanVan  = dBconnect.LayGiaTri(sqlStr);
                sqlStr = string.Format("SELECT * FROM NHIEMVU WHERE MaLuanVan='{0}'", maLuanVan);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtNhiemVu = new DataTable();
                adapter.Fill(dtNhiemVu);
                dgvNhiemVu.ItemsSource = dtNhiemVu.DefaultView;
                return dtNhiemVu;
            }
            catch (Exception ex)
            {
                GrowlSettings.ShowGrowlError(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnThemTask_Click(object sender, RoutedEventArgs e)
        {
            UCThemNhiemVu ucThemNhiemVu = new UCThemNhiemVu();
            ucThemNhiemVu.txtMaLuanVan.Text = this.txtMaLuanVan.Text.ToString();
            Dialog.Show(ucThemNhiemVu);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            load_data(maNguoiDung);
        }
        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void btnXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            UCChiTietNhiemVu ucChiTietNhiemVu = new UCChiTietNhiemVu();
            DataRowView dtr = (DataRowView)dgvNhiemVu.SelectedItem;
            ucChiTietNhiemVu.txtMaNhiemVu.Text = dtr.Row["MaNhiemVu"].ToString();
            ucChiTietNhiemVu.txtTuaDe.Text = dtr.Row["TuaDe"].ToString();
            ucChiTietNhiemVu.sldTienDo.Value = (byte)dtr.Row["TienDo"];
            ucChiTietNhiemVu.txtMoTa.Text = dtr.Row["MoTa"].ToString();
            ucChiTietNhiemVu.txtNhanXet.Text = dtr.Row["NhanXet"].ToString();
            Dialog.Show(ucChiTietNhiemVu);
        }
    }
}
