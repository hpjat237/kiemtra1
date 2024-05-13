using LiveCharts.Wpf;
using LiveCharts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using LiveCharts.Configurations;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using EssayManagement.Models;

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for UCThongKe.xaml
    /// </summary>
    public partial class UCThongKe : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public UCThongKe()
        {
            InitializeComponent();
            LoadChartData();
            load_dataSV();
        }


        class LuotDK
        {
            public string HoTen { get; set; }
            public int LuotDangKy { get; set; }
        }

        private void LoadChartData()
        {
            Dictionary<string, int> LuotDangKy = GetLuanVanData();
            Dictionary<string, string> GiangVien = GetDSGiangVien();
            List<LuotDK> list = new List<LuotDK>();

            foreach (var item in LuotDangKy)
            {
                list.Add(new LuotDK { HoTen = item.Key, LuotDangKy = item.Value });
            }

            list.Sort((x, y) => y.LuotDangKy.CompareTo(x.LuotDangKy));

            SeriesCollection = new SeriesCollection();

            foreach (var item in list)
            {
                SeriesCollection.Add(new RowSeries
                {
                    Title = GiangVien[item.HoTen],
                    Values = new ChartValues<int> { item.LuotDangKy }
                });
            }

            DataContext = this;
        }

        private Dictionary<string, int> GetLuanVanData()
        {
            Dictionary<string, int> LuotDangKy = new Dictionary<string, int>();
            string query = "SELECT * FROM LUANVAN";

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (LuotDangKy.ContainsKey(reader["MaGV"].ToString()))
                    {
                        LuotDangKy[reader["MaGV"].ToString()]++;
                    }
                    else
                    {
                        LuotDangKy[reader["MaGV"].ToString()] = 1;
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return LuotDangKy;
        }

        private Dictionary<string, string> GetDSGiangVien()
        {
            Dictionary<string, string> GiangVien = new Dictionary<string, string>();
            string query = "SELECT * FROM GIANGVIEN";

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GiangVien[reader["MaGV"].ToString()] = reader["HoTen"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return GiangVien;
        }

        public SeriesCollection SeriesCollection { get; set; }

        private void CartesianChart_DataClick(object sender, ChartPoint chartPoint)
        {
            Dictionary<string, string> GiangVien = GetDSGiangVien();
            string maGV = GiangVien.FirstOrDefault(x => x.Value == chartPoint.SeriesView.Title).Key;
            txbTenGV.Text = chartPoint.SeriesView.Title;
            load_data(maGV);
        }

        private void load_data(string maGV)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM LUANVAN WHERE MaGV = '{0}' ORDER BY MaDeTai", maGV);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtLuanVan = new DataTable();
                adapter.Fill(dtLuanVan);
                dgv.ItemsSource = dtLuanVan.DefaultView;
            }
            catch (Exception ex)
            {
                HandyControl.Controls.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void load_dataSV()
        {
            string sqlStr = "SELECT * FROM LUANVAN INNER JOIN SINHVIEN ON LUANVAN.MaLuanVan = SINHVIEN.MaNhom WHERE NgayKetThuc < GETDATE() AND TienDo < 100";
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtLuanVan = new DataTable();
                adapter.Fill(dtLuanVan);
                dgvSV.ItemsSource = dtLuanVan.DefaultView;
            }
            catch (Exception ex)
            {
                HandyControl.Controls.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}