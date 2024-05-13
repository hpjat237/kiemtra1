using EssayManagement.Database;
using HandyControl.Interactivity;
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
using System.Data.SqlTypes;
using HandyControl.Controls;

namespace EssayManagement.Views.User_Control.UCGV
{
    /// <summary>
    /// Interaction logic for UCDuyetLuanVan.xaml
    /// </summary>
    public partial class UCDuyetLuanVan : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        string maGV = Database.UserInSession.LoggedInUser.ToString();
        public UCDuyetLuanVan()
        {
            InitializeComponent();
            List<string> LinhVuc = new List<string> { "Website", "Application", "AI", "Data", "Cloud", "Security", "Architecture" };
            cbLinhVuc.ItemsSource = LinhVuc;
        }

        private void btnChapNhan_Click(object sender, RoutedEventArgs e)
        {
            string sqlStr = string.Format("UPDATE YEUCAUDANGKY SET NhanXet = N'{0}', TrangThai = N'Đã duyệt' WHERE MaYeuCau='{1}'; " +
                "INSERT INTO LUANVAN(MaDeTai, TenDeTai, MaGV, NgayDangKy, NgayKetThuc, TienDo, MoTa, NhanXet, CongNghe, LinhVuc, YeuCau) " +
                "VALUES('{2}',N'{3}','{4}','{5}','{6}','{7}',N'{8}',N'{9}',N'{10}', N'{11}', N'{12}');" +
                "UPDATE DETAI SET TrangThai = N'{13}' WHERE MaDeTai = '{2}'",
                txtNhanXet.Text, txtMaYeuCau.Text, txtMaDeTai.Text, txtTenDeTai.Text, maGV, txtNgayDangKy.Text, txtNgayKetThuc.Text, 0, txtMoTa.Text, txtNhanXet.Text, txtCongNghe.Text, cbLinhVuc.Text, txtYeuCau.Text, "Đã được đăng ký");
            dBconnect.ThucThi(sqlStr);

            sqlStr = string.Format("SELECT MaLuanVan FROM LUANVAN WHERE MaDeTai = '{0}'", txtMaDeTai.Text);
            var maLuanVan = dBconnect.LayGiaTri(sqlStr);

            sqlStr = string.Format("SELECT MaSV FROM SINHVIEN WHERE MaNhom ='{0}'", txtMaYeuCau.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataTable dtSVThamGia = new DataTable();
            adapter.Fill(dtSVThamGia);

            for (int i = 0; i < dtSVThamGia.Rows.Count; i++)
            {
                string maSV = dtSVThamGia.Rows[i]["MaSV"].ToString();
                sqlStr = string.Format("UPDATE SINHVIEN SET MaNhom = '{0}' WHERE MaSV = '{1}'", maLuanVan, maSV);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    Growl.ErrorGlobal("Không lấy update được mã sinh viên");
                }
                conn.Close();
            }
            string checkExistsQuery = string.Format("SELECT COUNT(*) FROM DETAI WHERE TenDeTai = N'{0}'", txtTenDeTai.Text);
            object result = dBconnect.LayGiaTri(checkExistsQuery);
            int existingCount = 0;
            if (result != null)
            {
                if (int.TryParse(result.ToString(), out existingCount))
                {
                    if (existingCount == 0)
                    {
                        int demSLSV = 0;
                        for (int i = 0; i < dtSVThamGia.Rows.Count; i++)
                        {
                            demSLSV++;
                        }

                        sqlStr = string.Format("INSERT INTO DETAI(TenDeTai, CongNghe, LinhVuc, MaGV, MoTa, YeuCau, TrangThai, SoluongSV) " +
                                                "VALUES(N'{0}', N'{1}', N'{2}', '{3}', N'{4}', N'{5}', N'{6}', N'{7}')",
                                                txtTenDeTai.Text, txtCongNghe.Text, cbLinhVuc.Text, maGV, txtMoTa.Text, txtYeuCau.Text, "Đã được đăng ký", demSLSV);
                        dBconnect.ThucThi(sqlStr);
                    }
                }
                else
                {
                    Growl.ErrorGlobal("Lỗi xảy ra khi xử lý dữ liệu từ cơ sở dữ liệu.");
                }
            }
            else
            {
                Growl.ErrorGlobal("Không có dữ liệu phản hồi từ cơ sở dữ liệu.");
            }
            HandyControl: ControlCommands.Close.Execute(null, this);
        }

        private void btnTuChoi_Click(object sender, RoutedEventArgs e)
        {
            string sqlStr = string.Format("UPDATE YEUCAUDANGKY SET NhanXet = N'{0}', TrangThai = N'Từ chối' WHERE MaYeuCau='{1}'", txtNhanXet.Text, txtMaYeuCau.Text);
            dBconnect.ThucThi(sqlStr);
            sqlStr = string.Format("UPDATE SINHVIEN SET MaNhom = '' WHERE MaNhom='{0}'", txtMaYeuCau.Text);
            HandyControl: ControlCommands.Close.Execute(null, this);
        }
    }
}