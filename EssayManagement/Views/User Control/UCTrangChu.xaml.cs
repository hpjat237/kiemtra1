using HandyControl.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HandyControl.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EssayManagement.Views.User_Control.UCGV;
using EssayManagement.Models;
using EssayManagement.Views.Windows;
using EssayManagement.Views.GiangVienForm;

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for UCTrangChu.xaml
    /// </summary>
    public partial class UCTrangChu : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        string ma = Database.UserInSession.LoggedInUser.ToString();

        public UCTrangChu()
        {
            InitializeComponent();
            DataTable dtUser = load_data_User(Database.UserInSession.LoggedInUser.ToString());

            txbXinChao.Text = "Xin chào, " + dtUser.Rows[0]["HoTen"].ToString();
            load_data();
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        public DataTable load_data_User(string ma)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format(@"SELECT HoTen FROM GIANGVIEN WHERE MaGV='{0}' UNION SELECT HoTen FROM SINHVIEN WHERE MaSV='{0}'", ma);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Database.GrowlSettings.ShowGrowlError(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /*public void load_data()
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM THONGBAO");
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtThongBao = new DataTable();
                adapter.Fill(dtThongBao);
                dgvThongBao.ItemsSource = dtThongBao.DefaultView;
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }*/

        /*private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            load_data();
        }*/

        
        /*private void btnXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            UCChiTietThongBao ucChiTietThongBao = new UCChiTietThongBao();
            DataRowView dtr = (DataRowView)dgvThongBao.SelectedItem;
            ucChiTietThongBao.txtMaNhom.Text = dtr.Row["MaNhom"].ToString();
            ucChiTietThongBao.txtTieuDe.Text = dtr.Row["TieuDe"].ToString();
            ucChiTietThongBao.txtNoiDung.Text = dtr.Row["NoiDung"].ToString();
            ucChiTietThongBao.txtNgayGui.Text = dtr.Row["NgayGui"].ToString();
            Dialog.Show(ucChiTietThongBao);
        }*/

        private void load_data()
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM THONGBAO WHERE MaGV='{0}'", ma);
                if(ma.Contains("HS"))
                    sqlStr = string.Format("SELECT * FROM THONGBAO WHERE MaNhom='{0}'", ma); // chua xu ly sinh vien
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtThongBao = new DataTable();
                adapter.Fill(dtThongBao);
                foreach (DataRow row in dtThongBao.Rows)
                {
                    UCHopThongBao ucHopThongBao = new UCHopThongBao();
                    ucHopThongBao.txbTieuDe.Text = row["TieuDe"].ToString();
                    ucHopThongBao.txbNoiDung.Text = row["NoiDung"].ToString();
                    ucHopThongBao.txbNgayGui.Text = "🕑 " + row["NgayGui"].ToString();
                    wpThongBao.Children.Add(ucHopThongBao);
                }
            }
            catch (Exception ex)
            {

                Database.GrowlSettings.ShowGrowlError(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnThongBao_Click(object sender, RoutedEventArgs e)
        {

            Dialog.Show(new UCThemThongBao());
        }
    }
}
