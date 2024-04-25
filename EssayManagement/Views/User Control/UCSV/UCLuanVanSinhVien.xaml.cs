using EssayManagement.Views.User_Control.UCHS;
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
using System.Data.SqlTypes;

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for UCLuanVanSinhVien.xaml
    /// </summary>
    public partial class UCLuanVanSinhVien : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        public UCLuanVanSinhVien()
        {
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM DETAI");

                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtDeTai = new DataTable();
                adapter.Fill(dtDeTai);
                dgvDeTai.ItemsSource = dtDeTai.DefaultView;
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

        private void ccbLocGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedValues = "";
            if (ccbLocGV.SelectedItems.Count > 0)
            {
                foreach (var item in ccbLocGV.SelectedItems)
                {
                    selectedValues += "'" + ((CheckComboBoxItem)item).Content + "',";
                }
                selectedValues = selectedValues.TrimEnd(',');
            }
            else
            {
                selectedValues = "";
                foreach (var item in ccbLocGV.Items)
                {
                    selectedValues += "'" + ((CheckComboBoxItem)item).Content + "',";
                }
                selectedValues = selectedValues.TrimEnd(',');
            }

            try
            {
                conn.Open();
                string sqlStr = $"SELECT * FROM DETAI WHERE Linhvuc IN ({selectedValues})";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtLuanVan = new DataTable();
                adapter.Fill(dtLuanVan);
                dgvDeTai.ItemsSource = dtLuanVan.DefaultView;
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

        private void btnChonDeTai_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dtr = (DataRowView)dgvDeTai.SelectedItem;
                if (dtr != null)
                {
                    UCDangKyLuanVan ucDangKyLuanVan = new UCDangKyLuanVan();
                    if (dtr.Row["TrangThai"].ToString() == "Có thể đăng ký")
                    {
                        ucDangKyLuanVan.txtMaDeTai.Text = dtr.Row["MaDeTai"].ToString();
                        ucDangKyLuanVan.txtTenDeTai.Text = dtr.Row["TenDeTai"].ToString();
                        ucDangKyLuanVan.txtSVThamGia.SetValue(InfoElement.TitleProperty, string.Format("(Tối đa {0} sinh viên)", dtr.Row["SoLuongSV"].ToString()));
                        ucDangKyLuanVan.txtCongNghe.Text = dtr.Row["CongNghe"].ToString();
                        ucDangKyLuanVan.cbLinhVuc.Text = dtr.Row["LinhVuc"].ToString();
                        ucDangKyLuanVan.txtMoTa.Text = dtr.Row["MoTa"].ToString();
                        ucDangKyLuanVan.txtYeuCau.Text = dtr.Row["YeuCau"].ToString();
                        ucDangKyLuanVan.txtMaGiangVien.Text = dtr.Row["MaGV"].ToString();
                        Dialog.Show(ucDangKyLuanVan);
                    }
                    else
                    {
                        GrowlSettings.ShowGrowlError("Đề tài này đã được đăng ký");
                    }
                }
                else
                {
                    GrowlSettings.ShowGrowlError("Hãy chọn đề tài!");
                }
            }
            catch (Exception ex)
            {
                GrowlSettings.ShowGrowlError($"Đã xảy ra lỗi: {ex.Message}");
            }

        }

        private void btnThemDeTai_Click(object sender, RoutedEventArgs e)
        {
            UCDangKyLuanVan ucDangKyLuanVan = new UCDangKyLuanVan();
            DataRowView dtr = (DataRowView)dgvDeTai.SelectedItem;

            string sqlString = string.Format("SELECT MAX(Id)+1 FROM DETAI");
            var maxDemNhiemVu = dBconnect.LayGiaTri(sqlString);
            maxDemNhiemVu = maxDemNhiemVu.ToString().PadLeft(8, '0');
            ucDangKyLuanVan.txtMaDeTai.Text = "DT" + maxDemNhiemVu.ToString();

            ucDangKyLuanVan.txtSVThamGia.SetValue(InfoElement.TitleProperty, string.Format("(Tối đa 3 sinh viên)"));
            Dialog.Show(ucDangKyLuanVan);
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            load_data();
        }
    }
}
