using EssayManagement.Views.User_Control;
using EssayManagement.Views.Windows;
using HandyControl.Controls;
using HandyControl.Tools.Extension;
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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using EssayManagement.Database;

namespace EssayManagement.Views.GiangVienForm
{
    /// <summary>
    /// Interaction logic for FGiangVien.xaml
    /// </summary>
    public partial class FGiangVien : System.Windows.Window
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public FGiangVien()
        {
            InitializeComponent();
            DataTable dtGV = load_data(Database.UserInSession.LoggedInUser.ToString());
            txbTen.Text = "Xin chào, " + dtGV.Rows[0]["HoTen"].ToString();
            dgvTimKiemGV.Visibility = Visibility.Collapsed;
        }

        public DataTable load_data(string ma)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM GIANGVIEN WHERE MaGV='{0}'", ma);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
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

        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }


        public void setActiveUserControl(UserControl userControl)
        {
            ucTrangChu.Visibility = Visibility.Collapsed;
            ucDeTai.Visibility = Visibility.Collapsed;
            ucLuanVan.Visibility = Visibility.Collapsed;
            ucThongKe.Visibility = Visibility.Collapsed;
            ucChamDiem.Visibility = Visibility.Collapsed;

            userControl.Visibility = Visibility.Visible;
        }

        private void sdmTrangChu_Selected(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(ucTrangChu);
        }

        private void sdmDeTai_Selected(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(ucDeTai);
        }

        private void sdmLuanVan_Selected(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(ucLuanVan);
        }

        private void sdmThongKe_Selected(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(ucThongKe);
        }
        private void sdmChamDiem_Selected(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(ucChamDiem);
        }
        private void btnDaiDien_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new UCThongTin());
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = sbTimKiemGV.Text;
            string sqlStr = string.Format("SELECT MaSV AS MaSo, HoTen, Email, Cmnd, NgaySinh, GioiTinh, Diachi, Sdt FROM SINHVIEN WHERE MaSV LIKE @searchText UNION " + "SELECT MaGV AS MaSo, HoTen, Email, Cmnd, NgaySinh, GioiTinh, Diachi, Sdt FROM GIANGVIEN WHERE MaGV LIKE @searchText");

            if (!string.IsNullOrEmpty(searchText))
            {
                dgvTimKiemGV.Visibility = Visibility.Visible;
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlStr, conn);
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTimKiemGV.ItemsSource = dt.DefaultView;

                    dgvTimKiemGV.Columns.Clear();

                    dgvTimKiemGV.ItemsSource = dt.DefaultView;
                    dgvTimKiemGV.DataContext = dt;
                    dgvTimKiemGV.AutoGenerateColumns = false;

                    DataGridTextColumn column1 = new DataGridTextColumn();
                    column1.Header = "Mã số";
                    column1.Binding = new Binding("MaSo");
                    dgvTimKiemGV.Columns.Add(column1);

                    DataGridTextColumn column2 = new DataGridTextColumn();
                    column2.Header = "Họ Tên";
                    column2.Binding = new Binding("HoTen");
                    dgvTimKiemGV.Columns.Add(column2);
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
                dgvTimKiemGV.Visibility = Visibility.Collapsed;
            }
        }

        private void dgvTimKiemGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UCThongTin ucThongTin = new UCThongTin();
            if (dgvTimKiemGV.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgvTimKiemGV.SelectedItem;
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
