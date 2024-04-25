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
using EssayManagement.Database;
using System.Reflection.PortableExecutable;
using System.Data.SqlTypes;
using HandyControl.Interactivity;
using EssayManagement.Models;

namespace EssayManagement.Views.User_Control.UCGV
{
    /// <summary>
    /// Interaction logic for UCChamDiem.xaml
    /// </summary>
    public partial class UCChamDiem : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        string maGV = Database.UserInSession.LoggedInUser.ToString();

        public UCChamDiem()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM LUANVAN WHERE TienDo=100");
                string sqlStr1 = string.Format("SELECT * FROM HOIDONG");

                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlStr1, conn);

                DataTable dtLuanVan = new DataTable();
                DataTable dtHoiDong = new DataTable();

                adapter.Fill(dtLuanVan);
                adapter1.Fill(dtHoiDong);

                dgvHoiDong.ItemsSource = dtHoiDong.DefaultView;

                foreach (DataRow row in dtLuanVan.Rows)
                {
                    HopLuanVan HopLV = new HopLuanVan();
                    HopLV.txbTieuDe.Text = row["TenDeTai"].ToString();
                    HopLV.txbLinhVuc.Text = row["LinhVuc"].ToString();
                    HopLV.txbNgayGui.Text = "🕑 " + row["NgayDangKy"].ToString();
                    HopLV.Margin = new Thickness(0, 0, 10, 0);
                    HopLV.MouseLeftButtonUp += new MouseButtonEventHandler(HopLV_Selected);
                    HopLV.Tag = new { MaLuanVan = row["MaLuanVan"].ToString()};
                    wpLuanVan.Children.Add(HopLV);
                }
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
        private void HopLV_Selected(object sender, MouseButtonEventArgs e)
        {
            var luanVan = (dynamic)(sender as HopLuanVan).Tag;

            conn.Open();
            string sqlStr = string.Format("SELECT * FROM LUANVAN WHERE MaLuanVan='{0}'", luanVan.MaLuanVan);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataTable dtLuanVan = new DataTable();
            adapter.Fill(dtLuanVan);

            UCChiTietLuanVan ucChiTietLuanVan = new UCChiTietLuanVan();
            ucChiTietLuanVan.txtMaLuanVan.Text = dtLuanVan.Rows[0]["MaLuanVan"].ToString();
            ucChiTietLuanVan.txtMaDeTai.Text = dtLuanVan.Rows[0]["MaDeTai"].ToString();
            ucChiTietLuanVan.txtTenDeTai.Text = dtLuanVan.Rows[0]["TenDeTai"].ToString();
            ucChiTietLuanVan.txtCongNghe.Text = dtLuanVan.Rows[0]["CongNghe"].ToString();
            ucChiTietLuanVan.cbLinhVuc.Text = dtLuanVan.Rows[0]["LinhVuc"].ToString();
            ucChiTietLuanVan.dtpNgayDangKy.Text = dtLuanVan.Rows[0]["NgayDangKy"].ToString();
            ucChiTietLuanVan.dtpNgayKetThuc.Text = dtLuanVan.Rows[0]["NgayKetThuc"].ToString();
            ucChiTietLuanVan.txtTienDo.Text = dtLuanVan.Rows[0]["TienDo"].ToString();
            ucChiTietLuanVan.txtMoTa.Text = dtLuanVan.Rows[0]["MoTa"].ToString();
            ucChiTietLuanVan.txtNhanXet.Text = dtLuanVan.Rows[0]["NhanXet"].ToString();
            ucChiTietLuanVan.txtYeuCau.Text = dtLuanVan.Rows[0]["YeuCau"].ToString();
            Dialog.Show(ucChiTietLuanVan);

            sqlStr = string.Format("SELECT MaSV, HoTen FROM SINHVIEN WHERE MaNhom='{0}'", dtLuanVan.Rows[0]["MaLuanVan"].ToString());
            adapter = new SqlDataAdapter(sqlStr, conn);
            DataTable dtSVThamGia = new DataTable();
            adapter.Fill(dtSVThamGia);
            string SVThamGia = "";
            for (int i = 0; i < dtSVThamGia.Rows.Count; i++)
            {
                SVThamGia += dtSVThamGia.Rows[i]["MaSV"].ToString() + " - " + dtSVThamGia.Rows[i]["HoTen"].ToString() + "\n";
            }
            conn.Close();

            ucChiTietLuanVan.txtSVThamGia.Text = SVThamGia;

            Dialog.Show(ucChiTietLuanVan);
        }

        private void btnChiTietLuanVan_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnChamDiem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string sqlString = string.Format("SELECT MaGV FROM GIANGVIEN WHERE MaGV = '{0}'", txtMaGiangVien.Text);
            if (dBconnect.LayGiaTri(sqlString) == null)
            {
                GrowlSettings.ShowGrowlError("Giảng viên không tồn tại");
            }
            else if (txtMaGiangVien.Text == "")
            {
                GrowlSettings.ShowGrowlError("Vui lòng nhập mã giảng viên");
            }
            else if (lbThanhVien.Items.Contains(txtMaGiangVien.Text))
            {
                GrowlSettings.ShowGrowlError("Giảng viên này đã được thêm");
            }
            else
            {
            lbThanhVien.Items.Add(new ListBoxItem().Content = txtMaGiangVien.Text);

            }
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (lbThanhVien.SelectedIndex != -1)
            {
                lbThanhVien.Items.RemoveAt(lbThanhVien.SelectedIndex);
            }
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            string sqlString = "";
            if (lbThanhVien.Items.Count > 3)
            {
                GrowlSettings.ShowGrowlError("Số giảng viên vượt quá số lượng cho phép");
                return;
            }
            else if (lbThanhVien.Items.Count == 0)
            {
                GrowlSettings.ShowGrowlError("Phải có ít nhất 1 giảng viên");
                return;
            }

            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("INSERT INTO HOIDONG(GVThamGia) VALUES ");

            foreach (var item in lbThanhVien.Items)
            {
                sqlBuilder.Append(string.Format("('{0}'),", item));
            }

            sqlBuilder.Remove(sqlBuilder.Length - 1, 1);

            dBconnect.ThucThi(sqlBuilder.ToString());
            btnLoad_Click(sender, e);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }
    }
}
