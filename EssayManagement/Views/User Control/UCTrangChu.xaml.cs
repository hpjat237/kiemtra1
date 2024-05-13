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
using System.Windows.Threading;
using EssayManagement.Models;
using EssayManagement.Views.Windows;
using EssayManagement.Views.GiangVienForm;
using EssayManagement.Database;

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for UCTrangChu.xaml
    /// </summary>
    public partial class UCTrangChu : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect db = new DBconnect();

        string ma = Database.UserInSession.LoggedInUser.ToString();

        public UCTrangChu()
        {
            InitializeComponent();
            DataTable dtUser = load_data_User(Database.UserInSession.LoggedInUser.ToString());

            txbXinChao.Text = "Xin chào, " + dtUser.Rows[0]["HoTen"].ToString();
            load_data();
            load_TienDoLuanVan();
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

        private void load_data()
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM THONGBAO");
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

        private void load_TienDoLuanVan()
        {
            try
            {
                conn.Open();
                if (ma.Contains("GV"))
                {
                    string sqlStr = string.Format("SELECT * FROM LUANVAN WHERE MaGV = '{0}'", ma);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                    DataTable dtLuanVan = new DataTable();
                    adapter.Fill(dtLuanVan);
                    foreach (DataRow row in dtLuanVan.Rows)
                    {
                        UCTienDoLuanVan ucTienDoLuanVan = new UCTienDoLuanVan();
                        ucTienDoLuanVan.txbMaNhom.Text = "👤 " + row["MaLuanVan"].ToString();
                        ucTienDoLuanVan.txbTenLuanVan.Text = row["TenDeTai"].ToString();
                        ucTienDoLuanVan.wpbTienDo.Value = Convert.ToInt32(row["TienDo"].ToString());
                        ucTienDoLuanVan.txbWaveValue.Text = row["TienDo"].ToString() + '%';
                        spTienDo.Children.Add(ucTienDoLuanVan);
                    }
                }
                else
                {
                    string sqlStr = string.Format("SELECT MaNhom FROM SINHVIEN WHERE MaSV = '{0}'", ma);
                    var maNhom = db.LayGiaTri(sqlStr);
                    sqlStr = string.Format("SELECT * FROM NHIEMVU WHERE MaLuanVan = '{0}'", maNhom);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                    DataTable dtNhiemVu = new DataTable();
                    adapter.Fill(dtNhiemVu);
                    foreach (DataRow row in dtNhiemVu.Rows)
                    {
                        UCTienDoLuanVan ucTienDoLuanVan = new UCTienDoLuanVan();
                        ucTienDoLuanVan.txbMaNhom.Text = "👤 " + row["MaLuanVan"].ToString();
                        ucTienDoLuanVan.txbTenLuanVan.Text = row["TuaDe"].ToString();
                        ucTienDoLuanVan.wpbTienDo.Value = Convert.ToInt32(row["TienDo"].ToString());
                        ucTienDoLuanVan.txbWaveValue.Text = row["TienDo"].ToString() + '%';
                        spTienDo.Children.Add(ucTienDoLuanVan);
                    }
                }
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
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

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            wpThongBao.Children.Clear();
            load_data();

        }
    }
}
