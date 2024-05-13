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
using System.Windows.Threading;
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
using System.Diagnostics.Eventing.Reader;

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
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            load_data();
        }
        private void load_data()
        {
            try
            {
                conn.Open();
                string sqlStr1 = string.Format("SELECT * FROM HOIDONG");
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlStr1, conn);
                DataTable dtHoiDong = new DataTable();
                adapter1.Fill(dtHoiDong);
                dgvHoiDong.ItemsSource = dtHoiDong.DefaultView;
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
        private void LoadData()
        {
            try
            {
                conn.Open();

                string sqlStrMaHoiDong = string.Format(@"SELECT MaHoiDong FROM HOIDONG 
                                        WHERE GVThamGia1 = '{0}' 
                                           OR GVThamGia2 = '{0}' 
                                           OR GVThamGia3 = '{0}'", maGV);

                SqlDataAdapter adapterMaHoiDong = new SqlDataAdapter(sqlStrMaHoiDong, conn);
                DataTable dtMaHoiDong = new DataTable();
                adapterMaHoiDong.Fill(dtMaHoiDong);

                string maHoiDongList = string.Join(",", dtMaHoiDong.AsEnumerable().Select(row => "'" + row.Field<string>("MaHoiDong") + "'"));

                string sqlStrLuanVan = string.Format(@"SELECT * 
                                       FROM LUANVAN 
                                       WHERE (TienDo = 100 
                                         AND TrangThai = 'ChuaDangKy')
                                         OR MaHoiDong IN ({0})", maHoiDongList);


                SqlDataAdapter adapterLuanVan = new SqlDataAdapter(sqlStrLuanVan, conn);
                DataTable dtLuanVan = new DataTable();
                adapterLuanVan.Fill(dtLuanVan);

                dgvHoiDong.ItemsSource = dtLuanVan.DefaultView;

                foreach (DataRow row in dtLuanVan.Rows)
                {
                    HopLuanVan HopLV = new HopLuanVan();
                    HopLV.txbTieuDe.Text = row["TenDeTai"].ToString();
                    HopLV.txbLinhVuc.Text = row["LinhVuc"].ToString();
                    HopLV.txbNgayGui.Text = "🕑 " + row["NgayDangKy"].ToString();
                    HopLV.txbTrangThai.Text = (row["TrangThai"].ToString() == "ChuaDangKy") ? "Chưa đăng ký" : (row["TrangThai"].ToString() == "DaDangKy") ? "Đã đăng ký" : "Đã chấm điểm";
                    HopLV.Margin = new Thickness(0, 0, 10, 10);
                    HopLV.MouseLeftButtonUp += new MouseButtonEventHandler(HopLV_Selected);
                    HopLV.Tag = new { MaLuanVan = row["MaLuanVan"].ToString() };

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
            string sqlStr = string.Format("SELECT TrangThai FROM LUANVAN WHERE MaLuanVan='{0}'", luanVan.MaLuanVan);
            SqlCommand command = new SqlCommand(sqlStr, conn);
            string trangThai = command.ExecuteScalar()?.ToString();
            conn.Close();
            if (trangThai.Equals("ChuaDangKy"))
            {
                conn.Open();
                sqlStr = string.Format("SELECT * FROM LUANVAN WHERE MaLuanVan='{0}'", luanVan.MaLuanVan);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtLuanVan = new DataTable();
                adapter.Fill(dtLuanVan);
                UCChonHoiDong ucChonHoiDong = new UCChonHoiDong();
                ucChonHoiDong.txtMaLuanVan.Text = dtLuanVan.Rows[0]["MaLuanVan"].ToString();
                ucChonHoiDong.txtMaDeTai.Text = dtLuanVan.Rows[0]["MaDeTai"].ToString();
                ucChonHoiDong.txtTenDeTai.Text = dtLuanVan.Rows[0]["TenDeTai"].ToString();
                ucChonHoiDong.txtCongNghe.Text = dtLuanVan.Rows[0]["CongNghe"].ToString();
                ucChonHoiDong.cbLinhVuc.Text = dtLuanVan.Rows[0]["LinhVuc"].ToString();
                ucChonHoiDong.txtMoTa.Text = dtLuanVan.Rows[0]["MoTa"].ToString();
                ucChonHoiDong.txtNhanXet.Text = dtLuanVan.Rows[0]["NhanXet"].ToString();
                ucChonHoiDong.txtYeuCau.Text = dtLuanVan.Rows[0]["YeuCau"].ToString();

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
                ucChonHoiDong.txtSVThamGia.Text = SVThamGia;

                Dialog.Show(ucChonHoiDong);
            }
            else if (trangThai.Equals("DaDangKy"))
            {
            conn.Open();
            sqlStr = string.Format("SELECT * FROM LUANVAN WHERE MaLuanVan='{0}'", luanVan.MaLuanVan);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataTable dtLuanVan = new DataTable();
            adapter.Fill(dtLuanVan);

            UCChiTietChamDiem ucChiTietChamDiem = new UCChiTietChamDiem();
            ucChiTietChamDiem.txtMaLuanVan.Text = dtLuanVan.Rows[0]["MaLuanVan"].ToString();
            ucChiTietChamDiem.txtMaDeTai.Text = dtLuanVan.Rows[0]["MaDeTai"].ToString();
            ucChiTietChamDiem.txtTenDeTai.Text = dtLuanVan.Rows[0]["TenDeTai"].ToString();
            ucChiTietChamDiem.txtCongNghe.Text = dtLuanVan.Rows[0]["CongNghe"].ToString();
            ucChiTietChamDiem.cbLinhVuc.Text = dtLuanVan.Rows[0]["LinhVuc"].ToString();
            ucChiTietChamDiem.dtpNgayDangKy.Text = dtLuanVan.Rows[0]["NgayDangKy"].ToString();
            ucChiTietChamDiem.dtpNgayKetThuc.Text = dtLuanVan.Rows[0]["NgayKetThuc"].ToString();
            ucChiTietChamDiem.txtTienDo.Text = dtLuanVan.Rows[0]["TienDo"].ToString();
            ucChiTietChamDiem.txtMoTa.Text = dtLuanVan.Rows[0]["MoTa"].ToString();
            ucChiTietChamDiem.txtNhanXet.Text = dtLuanVan.Rows[0]["NhanXet"].ToString();
            ucChiTietChamDiem.txtYeuCau.Text = dtLuanVan.Rows[0]["YeuCau"].ToString();
            ucChiTietChamDiem.txbDiem1.Text = (dtLuanVan.Rows[0]["Diem1"].ToString() == "0") ? "" : dtLuanVan.Rows[0]["Diem1"].ToString();
            ucChiTietChamDiem.txbDiem2.Text = (dtLuanVan.Rows[0]["Diem2"].ToString() == "0") ? "" : dtLuanVan.Rows[0]["Diem2"].ToString();
            ucChiTietChamDiem.txbDiem3.Text = (dtLuanVan.Rows[0]["Diem3"].ToString() == "0") ? "" : dtLuanVan.Rows[0]["Diem3"].ToString();

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
            ucChiTietChamDiem.txtSVThamGia.Text = SVThamGia;

            if(ucChiTietChamDiem.txbDiem1.Text != "") ucChiTietChamDiem.txbDiem1.IsReadOnly = true;
            if(ucChiTietChamDiem.txbDiem1.Text != "") ucChiTietChamDiem.txbDiem1.IsReadOnly = true;
            if (ucChiTietChamDiem.txbDiem1.Text != "") ucChiTietChamDiem.txbDiem1.IsReadOnly = true;

            Dialog.Show(ucChiTietChamDiem);
            }
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
            else if (lbThanhVien.Items.Count <3)
            {
                GrowlSettings.ShowGrowlError("Phải có đủ 3 giảng viên");
                return;
            }

            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("INSERT INTO HOIDONG(GVThamGia1, GVThamGia2, GVThamGia3) VALUES ");

            List<string> values = [];
            foreach (var item in lbThanhVien.Items)
            {
                values.Add(item.ToString());
            }
            sqlBuilder.Append(string.Format("('{0}', '{1}', '{2}'),", values[0], values[1], values[2]));

            sqlBuilder.Remove(sqlBuilder.Length - 1, 1);

            dBconnect.ThucThi(sqlBuilder.ToString());
            string sqlStr = string.Format("UPDATE HOIDONG SET SoLuong = '{0}' WHERE MaHoiDong = MAX(MaHoiDong)", lbThanhVien.Items.Count);
            dBconnect.ThucThi(sqlStr);
            HandyControl: ControlCommands.Close.Execute(null, this);
            btnLoad_Click(sender, e);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string sqlStr1 = string.Format("SELECT * FROM HOIDONG");
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlStr1, conn);
                DataTable dtHoiDong = new DataTable();
                adapter1.Fill(dtHoiDong);
                dgvHoiDong.ItemsSource = dtHoiDong.DefaultView;
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

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
        }

        private void btnLoad1_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
