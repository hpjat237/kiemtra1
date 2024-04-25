using EssayManagement.Views.GiangVienForm;
using EssayManagement.Views.Object;
using HandyControl.Controls;
using HandyControl.Tools;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using System.Data.SqlClient;
using System.Data;
using EssayManagement.Models;
using EssayManagement.Views.User_Control.UCGV;
using EssayManagement.Database;

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for UCDeTaiGiangVien.xaml
    /// </summary>
    public partial class UCDeTaiGiangVien : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();

        public UCDeTaiGiangVien()
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

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
            e.Row.Height = double.NaN;
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
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new UCThemDeTai());
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            UCChiTietDeTai ucChiTietDeTai = new UCChiTietDeTai();
            DataRowView dtr = (DataRowView)dgvDeTai.SelectedItem;
            ucChiTietDeTai.txtMaDeTai.Text = dtr.Row["MaDeTai"].ToString();
            ucChiTietDeTai.txtTenDeTai.Text = dtr.Row["TenDeTai"].ToString();
            ucChiTietDeTai.txtCongNghe.Text = dtr.Row["CongNghe"].ToString();
            ucChiTietDeTai.cbLinhVuc.Text = dtr.Row["LinhVuc"].ToString();
            ucChiTietDeTai.txtMoTaDeTai.Text = dtr.Row["MoTa"].ToString();
            ucChiTietDeTai.txtYeuCau.Text = dtr.Row["YeuCau"].ToString();
            ucChiTietDeTai.txtSoLuongThanhVien.Text = dtr.Row["SoLuongSV"].ToString();
            Dialog.Show(ucChiTietDeTai);
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dtr = (DataRowView)dgvDeTai.SelectedItem;
            var maDeTai = dtr.Row["MaDeTai"].ToString();
            string sqlStr = string.Format("DELETE FROM DETAI WHERE MaDeTai='{0}'", maDeTai);
            dBconnect.ThucThi(sqlStr);
            load_data();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            load_data();
        }
    }
}
