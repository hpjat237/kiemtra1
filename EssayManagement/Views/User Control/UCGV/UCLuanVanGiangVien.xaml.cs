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
using HandyControl.Controls;
using EssayManagement.Views.User_Control.UCGV;
using HandyControl.Tools;
using EssayManagement.Database;

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for UCLuanVan.xaml
    /// </summary>
    public partial class UCLuanVanGiangVien : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        string maGV = Database.UserInSession.LoggedInUser.ToString();
        public UCLuanVanGiangVien()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetLang("en");
            load_data(maGV);
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        public void load_data(string ma){
            try
            {
                conn.Open();
                string sqlStr1 = string.Format("SELECT * FROM YEUCAUDANGKY WHERE MaGV='{0}'", ma);
                string sqlStr2 = string.Format("SELECT * FROM LUANVAN WHERE MaGV='{0}'", ma);

                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlStr1, conn);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sqlStr2, conn);
                DataTable dtYeuCauDangKy = new DataTable();
                DataTable dtLuanVanHoTro = new DataTable();
                adapter1.Fill(dtYeuCauDangKy);
                adapter2.Fill(dtLuanVanHoTro);
                dgvYeuCau.ItemsSource = dtYeuCauDangKy.DefaultView;
                dgvHoTro.ItemsSource = dtLuanVanHoTro.DefaultView;
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
        /* public void load_data(string ma)
         {
             try
             {
                 conn.Open();
                 string sqlStr = string.Format("SELECT * FROM LUANVAN WHERE MaGV='{0}'", ma);
                 string sqlStr = string.Format("SELECT * FROM YEUCAUDANGKY WHERE MaGV='{0}'", ma);
                 SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                 DataTable dt = new DataTable();
                 adapter.Fill(dt);
                 dgvYeuCau.ItemsSource = dt.DefaultView;
                 *//*if (dt.Rows.Count > 0)
                 {
                     DataRow row = dt.Rows[0];
                     UCHangLuanVan.txtMaDeTai.Text = row["MaDeTai"].ToString();
                     UCHangLuanVan.txtTenDeTai.Text = row["TenDeTai"].ToString();
                     UCHangLuanVan.txtMaDeTai.Text = row["ThoiHan"].ToString();
                     UCHangLuanVan.txtMaDeTai.Text = row["TrangThai"].ToString();
                 }*//*
             }
             catch (Exception ex)
             {
                 HandyControl.Controls.MessageBox.Show(ex.Message);
             }
             finally
             {
                 conn.Close();
             }
         }*/


        private void btnXemChiTietYC_Click(object sender, RoutedEventArgs e)
        {
            UCDuyetLuanVan ucDuyetLuanVan = new UCDuyetLuanVan();
            DataRowView dtr = (DataRowView)dgvYeuCau.SelectedItem;

            // Binding dữ liệu vào UCDuyetLuanVan
            ucDuyetLuanVan.txtMaYeuCau.Text = dtr.Row["MaYeuCau"].ToString();
            ucDuyetLuanVan.txtMaDeTai.Text = dtr.Row["MaDeTai"].ToString();
            ucDuyetLuanVan.txtTenDeTai.Text = dtr.Row["TenDeTai"].ToString();
            ucDuyetLuanVan.txtCongNghe.Text = dtr.Row["CongNghe"].ToString();
            ucDuyetLuanVan.cbLinhVuc.Text = dtr.Row["LinhVuc"].ToString();
            string sqlStr = string.Format("SELECT MaNhom FROM SINHVIEN WHERE MaNhom='{0}'", dtr.Row["MaDeTai"].ToString());
            ucDuyetLuanVan.txtNgayDangKy.Text = dtr.Row["NgayDangKy"].ToString();
            ucDuyetLuanVan.txtNgayKetThuc.Text = dtr.Row["NgayKetThuc"].ToString();
            ucDuyetLuanVan.txtMoTa.Text = dtr.Row["MoTa"].ToString();
            ucDuyetLuanVan.txtNhanXet.Text = dtr.Row["NhanXet"].ToString();
            ucDuyetLuanVan.txtTrangThai.Text = dtr.Row["TrangThai"].ToString();
            ucDuyetLuanVan.txtYeuCau.Text = dtr.Row["YeuCau"].ToString();

            // Load danh sách sinh viên tham gia
            conn.Open();
            sqlStr = string.Format("SELECT MaSV, HoTen FROM SINHVIEN WHERE MaNhom='{0}'", dtr.Row["MaYeuCau"].ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataTable dtSVThamGia = new DataTable();
            adapter.Fill(dtSVThamGia);
            string SVThamGia = "";
            for (int i = 0; i < dtSVThamGia.Rows.Count; i++)
            {
                SVThamGia += dtSVThamGia.Rows[i]["MaSV"].ToString() + " - " + dtSVThamGia.Rows[i]["HoTen"].ToString() + "\n";
            }
            conn.Close();

            ucDuyetLuanVan.txtSVThamGia.Text = SVThamGia; // Thêm danh sách sinh viên tham gia vào textbox

            if (ucDuyetLuanVan.txtTrangThai.Text == "Đã duyệt" || ucDuyetLuanVan.txtTrangThai.Text == "Từ chối")
            {
                ucDuyetLuanVan.btnChapNhan.IsEnabled = false;
                ucDuyetLuanVan.btnTuChoi.IsEnabled = false;
                ucDuyetLuanVan.txtNhanXet.IsEnabled = false;
            }
            Dialog.Show(ucDuyetLuanVan);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            load_data(maGV);
        }

        private void btnXemChiTietLV_Click(object sender, RoutedEventArgs e)
        {
            UCChiTietLuanVan ucChiTietLuanVan = new UCChiTietLuanVan();
            DataRowView dtr = (DataRowView)dgvHoTro.SelectedItem;
            ucChiTietLuanVan.txtMaLuanVan.Text = dtr.Row["MaLuanVan"].ToString();
            ucChiTietLuanVan.txtMaDeTai.Text = dtr.Row["MaDeTai"].ToString();
            ucChiTietLuanVan.txtTenDeTai.Text = dtr.Row["TenDeTai"].ToString();
            ucChiTietLuanVan.txtCongNghe.Text = dtr.Row["CongNghe"].ToString();
            ucChiTietLuanVan.cbLinhVuc.Text = dtr.Row["LinhVuc"].ToString();
            ucChiTietLuanVan.dtpNgayDangKy.Text = dtr.Row["NgayDangKy"].ToString();
            ucChiTietLuanVan.dtpNgayKetThuc.Text = dtr.Row["NgayKetThuc"].ToString();
            ucChiTietLuanVan.txtTienDo.Text = dtr.Row["TienDo"].ToString();
            ucChiTietLuanVan.txtMoTa.Text = dtr.Row["MoTa"].ToString();
            ucChiTietLuanVan.txtNhanXet.Text = dtr.Row["NhanXet"].ToString();
            ucChiTietLuanVan.txtYeuCau.Text = dtr.Row["YeuCau"].ToString();

            // Load danh sách sinh viên tham gia
            conn.Open();
            string sqlStr = string.Format("SELECT MaSV, HoTen FROM SINHVIEN WHERE MaNhom='{0}'", dtr.Row["MaLuanVan"].ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataTable dtSVThamGia = new DataTable();
            adapter.Fill(dtSVThamGia);
            string SVThamGia = "";
            for (int i = 0; i < dtSVThamGia.Rows.Count; i++)
            {
                SVThamGia += dtSVThamGia.Rows[i]["MaSV"].ToString() + " - " + dtSVThamGia.Rows[i]["HoTen"].ToString() + "\n";
            }
            conn.Close();

            ucChiTietLuanVan.txtSVThamGia.Text = SVThamGia; // Thêm danh sách sinh viên tham gia vào textbox

            Dialog.Show(ucChiTietLuanVan);
        }
    }
}