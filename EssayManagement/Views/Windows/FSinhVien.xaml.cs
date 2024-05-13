using EssayManagement.Views.User_Control;
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
using System.Windows.Shapes;
using System.Windows.Automation;
using EssayManagement.Database;

namespace EssayManagement.Views.Windows
{
    /// <summary>
    /// Interaction logic for FSinhVien.xaml
    /// </summary>
    public partial class FSinhVien : System.Windows.Window
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        string maSV = Database.UserInSession.LoggedInUser.ToString();

        public FSinhVien()
        {
            InitializeComponent();
            DataTable dtSV = load_data_SV(maSV);
            txbTen.Text = "Xin chào, " + dtSV.Rows[0]["HoTen"].ToString();
            dgvTimKiemSV.Visibility = Visibility.Collapsed;
        }
        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }
        public void setActiveUserControl(UserControl userControl)
        {
            ucTrangChu.Visibility = Visibility.Collapsed;
            ucLuanVan.Visibility = Visibility.Collapsed;
            ucDaDuocDuyet.Visibility = Visibility.Collapsed;
            ucChuaDuocDuyet.Visibility = Visibility.Collapsed;
            ucNhiemVu.Visibility = Visibility.Collapsed;
            ucKhongCoNhiemVu.Visibility = Visibility.Collapsed;

            userControl.Visibility = Visibility.Visible;
        }
        private void sdmTrangChu_Selected(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(ucTrangChu);
        }

        private void sdmLuanVan_Selected(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(ucLuanVan);
        }
        private void sdmLuanVanCuaToi_Selected(object sender, RoutedEventArgs e)
        {
            string sqlStr = string.Format("SELECT MaNhom FROM SINHVIEN WHERE MaSV='{0}'", maSV);
            var maNhom = dBconnect.LayGiaTri(sqlStr);
            if (maNhom.ToString().Contains("LV"))
            {
                sqlStr = string.Format("SELECT * FROM LUANVAN WHERE MaLuanVan='{0}'", maNhom);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtLuanVan = new DataTable();
                adapter.Fill(dtLuanVan);
                ucDaDuocDuyet.txtMaLuanVan.Text = dtLuanVan.Rows[0]["MaLuanVan"].ToString();
                ucDaDuocDuyet.txtMaDeTai.Text = dtLuanVan.Rows[0]["MaDeTai"].ToString();
                ucDaDuocDuyet.txtTenDeTai.Text = dtLuanVan.Rows[0]["TenDeTai"].ToString();
                ucDaDuocDuyet.txtCongNghe.Text = dtLuanVan.Rows[0]["CongNghe"].ToString();
                ucDaDuocDuyet.cbLinhVuc.Text = dtLuanVan.Rows[0]["LinhVuc"].ToString();
                ucDaDuocDuyet.txtMoTa.Text = dtLuanVan.Rows[0]["MoTa"].ToString();
                ucDaDuocDuyet.txtNgayDangKy.Text = dtLuanVan.Rows[0]["NgayDangKy"].ToString();
                ucDaDuocDuyet.txtNgayKetThuc.Text = dtLuanVan.Rows[0]["NgayKetThuc"].ToString();
                ucDaDuocDuyet.txtHoTro.Text = dtLuanVan.Rows[0]["MaGV"].ToString();
                ucDaDuocDuyet.sldTienDo.Value = (byte)dtLuanVan.Rows[0]["TienDo"];
                ucDaDuocDuyet.txtYeuCau.Text = dtLuanVan.Rows[0]["YeuCau"].ToString();
                ucDaDuocDuyet.txtNhanXet.Text = dtLuanVan.Rows[0]["NhanXet"].ToString();
                ucDaDuocDuyet.txtDiem.Text = dtLuanVan.Rows[0]["Diem"].ToString();

                conn.Open();
                sqlStr = string.Format("SELECT MaSV, HoTen FROM SINHVIEN WHERE MaNhom='{0}'", maNhom);
                adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtSVThamGia = new DataTable();
                adapter.Fill(dtSVThamGia);
                string SVThamGia = "";
                for (int i = 0; i < dtSVThamGia.Rows.Count; i++)
                {
                    SVThamGia += dtSVThamGia.Rows[i]["MaSV"].ToString() + " - " + dtSVThamGia.Rows[i]["HoTen"].ToString() + "\n";
                }
                conn.Close();

                ucDaDuocDuyet.txtSVThamGia.Text = SVThamGia;

                if (dtLuanVan.Rows[0]["TrangThai"].ToString() == "DaCham")
                {
                    ucDaDuocDuyet.btnNopBai.IsEnabled = false;
                    ucDaDuocDuyet.btnLuu.IsEnabled = false;
                }

                setActiveUserControl(ucDaDuocDuyet);
            }
            else setActiveUserControl(ucChuaDuocDuyet);
        }

        public DataTable load_data(string maSV)
        {
            var maNhom = dBconnect.LayGiaTri(string.Format("SELECT MaNhom FROM SINHVIEN WHERE MaSV = '{0}'", maSV));
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM YEUCAUDANGKY WHERE MaYeuCau ='{0}'", maNhom);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtYeuCauDangKy = new DataTable();
                adapter.Fill(dtYeuCauDangKy);
                return dtYeuCauDangKy;
            }
            catch (Exception ex)
            {
                return null;
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable load_data_LV(string ma)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM LUANVAN WHERE  ='{0}'", ma);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtYeuCauDangKy = new DataTable();
                adapter.Fill(dtYeuCauDangKy);
                return dtYeuCauDangKy;
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
        public DataTable load_data_SV(string ma)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM SINHVIEN WHERE MaSV='{0}'", ma);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        private void sdmNhiemVu_Selected(object sender, RoutedEventArgs e)
        {
            string sqlStr = string.Format("SELECT MaNhom FROM SINHVIEN WHERE MaSV='{0}'", maSV);
            var maNhom = dBconnect.LayGiaTri(sqlStr);
            if (maNhom.ToString().Contains("LV"))
            {
                sqlStr = string.Format("SELECT * FROM NHIEMVU WHERE MaLuanVan='{0}'", maNhom);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtLuanVan = new DataTable();
                adapter.Fill(dtLuanVan);
                ucNhiemVu.txtMaLuanVan.Text = maNhom.ToString();
                ucNhiemVu.dgvNhiemVu.ItemsSource = dtLuanVan.DefaultView;
                setActiveUserControl(ucNhiemVu);
            }
            else setActiveUserControl(ucKhongCoNhiemVu);
        }
        private void btnDaiDien_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new UCThongTin());
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = sbTimKiemSV.Text;
            string sqlStr = string.Format("SELECT MaSV AS MaSo, HoTen, Email, Cmnd, NgaySinh, GioiTinh, Diachi, Sdt FROM SINHVIEN WHERE MaSV LIKE @searchText UNION " + "SELECT MaGV AS MaSo, HoTen, Email, Cmnd, NgaySinh, GioiTinh, Diachi, Sdt FROM GIANGVIEN WHERE MaGV LIKE @searchText");

            if (!string.IsNullOrEmpty(searchText))
            {
                dgvTimKiemSV.Visibility = Visibility.Visible;
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlStr, conn);
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTimKiemSV.ItemsSource = dt.DefaultView;

                    dgvTimKiemSV.Columns.Clear();

                    dgvTimKiemSV.ItemsSource = dt.DefaultView;
                    dgvTimKiemSV.DataContext = dt;
                    dgvTimKiemSV.AutoGenerateColumns = false;

                    DataGridTextColumn column1 = new DataGridTextColumn();
                    column1.Header = "Mã số";
                    column1.Binding = new Binding("MaSo");
                    dgvTimKiemSV.Columns.Add(column1);

                    DataGridTextColumn column2 = new DataGridTextColumn();
                    column2.Header = "Họ Tên";
                    column2.Binding = new Binding("HoTen");
                    dgvTimKiemSV.Columns.Add(column2);

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
            else
            {
                dgvTimKiemSV.Visibility = Visibility.Collapsed;
            }
        }

        private void dgvTimKiemGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UCThongTin ucThongTin = new UCThongTin();
            if (dgvTimKiemSV.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgvTimKiemSV.SelectedItem;
                string maSo = row["MaSo"].ToString();
                DataTable dt = load_data(maSo);

                ucThongTin.txtMaGVSV.Text = row["MaSo"].ToString();
                ucThongTin.txtHoTen.Text = row["HoTen"].ToString();
                ucThongTin.txtDiaChi.Text = row["Diachi"].ToString();
                ucThongTin.txtCMND.Text = row["Cmnd"].ToString();
                ucThongTin.dpNgaySinh.SelectedDate = DateTime.Parse(row["NgaySinh"].ToString());
                ucThongTin.txtEmail.Text = row["Email"].ToString();
                ucThongTin.txtSDT.Text = row["Sdt"].ToString();

                Dialog.Show(ucThongTin);
            }
        }
    }
}
