using EssayManagement.Views.GiangVienForm;
using EssayManagement.Views.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EssayManagement.Models;
using EssayManagement.Database;
using HandyControl.Controls;

namespace EssayManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public MainWindow()
        {
            InitializeComponent();
            load_data();
            this.txtTaiKhoan.Focus();
        }

        private void btnExit_MouseEnter(object sender, MouseEventArgs e)
        {
            btnExit.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(30,130,251));
        }

        private void btnExit_MouseLeave(object sender, MouseEventArgs e)
        {
            btnExit.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0,0,0));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtTaiKhoan = load_data();
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Password;
            DataRow[] rows = dtTaiKhoan.Select($"TaiKhoan = '{taiKhoan}'");
            if (rows.Length > 0)
            {
                string storedMatKhau = rows[0]["MatKhau"].ToString();
                if (storedMatKhau == matKhau)
                {
                    UserInSession.LoggedInUser = taiKhoan;
                    if (taiKhoan.Contains("SV"))
                    {
                        FSinhVien fSinhVien = new FSinhVien();
                        fSinhVien.Show();
                        FDangNhap.Hide();
                    }
                    else if (taiKhoan.Contains("GV"))
                    {
                        FGiangVien fGiangVien = new FGiangVien();
                        fGiangVien.Show();
                        FDangNhap.Hide();
                    }
                }
                else
                {
                    GrowlSettings.ShowGrowlError("Sai mật khẩu! Vui lòng thử lại.");
                }
            }
            else
            {
                GrowlSettings.ShowGrowlError("Tài khoản không tồn tại!");
            }
            /*string taiKhoan = txtTaiKhoan.Text;
            if (taiKhoan.Contains("sv"))
            {
                FSinhVien fSinhVien = new FSinhVien();
                fSinhVien.Show();
                FDangNhap.Hide();
            }
            else if (taiKhoan.Contains("gv"))
            {
                FGiangVien fGiangVien = new FGiangVien();
                fGiangVien.Show();
                FDangNhap.Hide();
            }
            else
            {
                MessageBox.Show("sv hoặc gv");
            }*/
        }

        public DataTable load_data()
        {
            try
            {
                conn.Open();
                string sqlStrSV = "SELECT MaSV AS TaiKhoan, MatKhau FROM SINHVIEN";
                string sqlStrGV = "SELECT MaGV AS TaiKhoan, MatKhau FROM GIANGVIEN";
                SqlDataAdapter adapterSV = new SqlDataAdapter(sqlStrSV, conn);
                SqlDataAdapter adapterGV = new SqlDataAdapter(sqlStrGV, conn);
                DataTable dtTaiKhoan = new DataTable();
                adapterSV.Fill(dtTaiKhoan);
                adapterGV.Fill(dtTaiKhoan);
                return dtTaiKhoan;
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

        private void DangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
    }
}