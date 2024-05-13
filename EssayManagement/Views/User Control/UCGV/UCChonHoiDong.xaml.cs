using EssayManagement.Database;
using HandyControl.Interactivity;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace EssayManagement.Views.User_Control.UCGV
{
    /// <summary>
    /// Interaction logic for UCChonHoiDong.xaml
    /// </summary>
    public partial class UCChonHoiDong : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        public UCChonHoiDong()
        {
            InitializeComponent();
            LoadHoiDong();
            List<string> LinhVuc = new List<string> { "Website", "Application", "AI", "Data", "Cloud", "Security", "Architecture" };
            cbLinhVuc.ItemsSource = LinhVuc;
        }
        private void LoadHoiDong()
        {
            try
            {
                string sqlStr = "SELECT MaHoiDong, GVThamGia1, GVThamGia2, GVThamGia3 FROM HOIDONG";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtHoiDong = new DataTable();
                adapter.Fill(dtHoiDong);
        
                List<string> hoiDongList = new List<string>();

                foreach (DataRow row in dtHoiDong.Rows)
                {
                    string hoiDongInfo = string.Format("{0}: {1}, {2}, {3}", 
                                                        row["MaHoiDong"].ToString(), 
                                                        row["GVThamGia1"].ToString(), 
                                                        row["GVThamGia2"].ToString(), 
                                                        row["GVThamGia3"].ToString());
                    hoiDongList.Add(hoiDongInfo);
                }
                cbHoiDong.ItemsSource = hoiDongList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            string maHoiDong = cbHoiDong.Text.Length > 8 ? cbHoiDong.Text.Substring(0, 8) : cbHoiDong.Text;
            string sqlStr = string.Format("UPDATE LUANVAN SET MaHoiDong = '{0}' WHERE MaLuanVan = '{1}'", maHoiDong, txtMaLuanVan.Text);
            dBconnect.ThucThi(sqlStr);
            sqlStr = string.Format("UPDATE LUANVAN SET TrangThai = 'DaDangKy' WHERE MaLuanVan = '{0}'", txtMaLuanVan.Text);
            dBconnect.ThucThi(sqlStr);
            HandyControl: ControlCommands.Close.Execute(null, this);
        }
    }
}
