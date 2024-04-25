using EssayManagement.Database;
using HandyControl.Controls;
using HandyControl.Interactivity;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace EssayManagement.Views.User_Control.UCHS
{
    /// <summary>
    /// Interaction logic for UCDangKyLuanVan.xaml
    /// </summary>
    public partial class UCDangKyLuanVan : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        string maSV = Database.UserInSession.LoggedInUser.ToString();
        public UCDangKyLuanVan()
        {
            InitializeComponent();
            List<string> LinhVuc = new List<string> { "Website", "Application", "AI", "Data", "Cloud", "Security", "Architecture" };
            cbLinhVuc.ItemsSource = LinhVuc;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnExit_MouseEnter(object sender, MouseEventArgs e)
        {
            btnExit.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(30, 130, 251));
        }

        private void btnExit_MouseLeave(object sender, MouseEventArgs e)
        {
            btnExit.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));

        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            string sqlString = "";
            sqlString = string.Format("SELECT SoLuongSV FROM DETAI WHERE MaDeTai = '{0}'", txtMaDeTai.Text);
            var soLuongSV = dBconnect.LayGiaTri(sqlString);
            if (soLuongSV == null)
            {
                if (lbSVThamGia.Items.Count > 3)
                {
                    GrowlSettings.ShowGrowlError("Số sinh viên vượt quá số lượng cho phép");
                    return;
                }
                else if (lbSVThamGia.Items.Count == 0)
                {
                    GrowlSettings.ShowGrowlError("Phải có ít nhất 1 sinh viên");
                    return;
                }
            }
            else
            {
                if (lbSVThamGia.Items.Count > Int32.Parse(soLuongSV.ToString()))
                {
                    GrowlSettings.ShowGrowlError("Số sinh viên vượt quá số lượng cho phép");
                    return;
                }
                else if (lbSVThamGia.Items.Count == Int32.Parse("0"))
                {
                    GrowlSettings.ShowGrowlError("Phải có ít nhất 1 sinh viên");
                    return;
                }
            }
            if (string.IsNullOrEmpty(this.txtMaGiangVien.Text))
            {
                GrowlSettings.ShowGrowlError("Phải có giảng viên hỗ trợ");
                return;
            }
            
            sqlString = string.Format("INSERT INTO YEUCAUDANGKY(MaDeTai, TenDeTai, CongNghe, LinhVuc, MaGV, MoTa, YeuCau, TrangThai, NgayDangKy, NgayKetThuc) " +
                                                "VALUES('{0}', N'{1}', N'{2}', N'{3}', '{4}', N'{5}', N'{6}', N'{7}', '{8}', '{9}')",
                                                txtMaDeTai.Text, txtTenDeTai.Text, txtCongNghe.Text, cbLinhVuc.Text, txtMaGiangVien.Text, txtMoTa.Text, txtYeuCau.Text, "Chưa duyệt", DateTime.Now, DateTime.Now.AddDays(14));
            dBconnect.ThucThi(sqlString);
            sqlString = string.Format("SELECT MaYeuCau FROM YEUCAUDANGKY WHERE MaDeTai = '{0}'", txtMaDeTai.Text);
            var maYC = dBconnect.LayGiaTri(sqlString);
            foreach (string item in lbSVThamGia.Items)
            {
                if (item.Contains("SV"))
                {
                    sqlString = string.Format("UPDATE SINHVIEN SET MaNhom = '{0}' WHERE MaSV = '{1}'", maYC, item);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            HandyControl: ControlCommands.Close.Execute(null, this);
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string sqlString = string.Format("SELECT MaSV FROM SINHVIEN WHERE MaSV = '{0}'", txtSVThamGia.Text);
            if (dBconnect.LayGiaTri(sqlString) == null)
            {
                GrowlSettings.ShowGrowlError("Sinh viên không tồn tại");
            }
            else if (txtSVThamGia.Text == "")
            {
                GrowlSettings.ShowGrowlError("Vui lòng nhập mã sinh viên");
            }
            else if (lbSVThamGia.Items.Contains(txtSVThamGia.Text))
            {
                GrowlSettings.ShowGrowlError("Sinh viên này đã được thêm");
            }
            else
            {
                sqlString = string.Format("SELECT MaNhom FROM SINHVIEN WHERE MaSV = '{0}'", txtSVThamGia.Text);
                if (dBconnect.LayGiaTri(sqlString).ToString() != "")
                {
                    GrowlSettings.ShowGrowlError("Sinh viên đã tham gia nhóm khác");
                }
                else
                {
                    lbSVThamGia.Items.Add(new ListBoxItem().Content = txtSVThamGia.Text);
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (lbSVThamGia.SelectedIndex != -1)
            {
                lbSVThamGia.Items.RemoveAt(lbSVThamGia.SelectedIndex);
            }
        }
    }
}
