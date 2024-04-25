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
            BasicColumn();
            PieChart();
        }

        public void BasicColumn()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            Labels = new[] { "7", "8", "9", "10" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public void PieChart()
        {
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        /*public void BasicColumn_Diem()
        {
            DataTable dtLuanVan = load_data();
            if (dtLuanVan != null && dtLuanVan.Rows.Count > 0)
            {
                List<int> diemList = new List<int>();
                foreach (DataRow row in dtLuanVan.Rows)
                {
                    int diem = Convert.ToInt32(row["Diem"]);
                    diemList.Add(diem);
                }

                SeriesCollection = new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "Điểm",
                Values = new ChartValues<int>(diemList)
            }
        };

                Labels = diemList.Select((val, index) => (index + 1).ToString()).ToArray();
                Formatter = value => value.ToString("N");
            }
            DataContext = this;
        }*/

        /*public void PieChart_LinhVuc()
        {
            DataTable dtLuanVan = load_data();
            if (dtLuanVan != null && dtLuanVan.Rows.Count > 0)
            {
                Dictionary<string, int> fieldCounts = new Dictionary<string, int>();
                foreach (DataRow row in dtLuanVan.Rows)
                {
                    string field = row["LinhVuc"].ToString();
                    if (fieldCounts.ContainsKey(field))
                        fieldCounts[field]++;
                    else
                        fieldCounts.Add(field, 1);
                }

                SeriesCollection = new SeriesCollection();
                foreach (var item in fieldCounts)
                {
                    SeriesCollection.Add(new PieSeries
                    {
                        Title = item.Key,
                        Values = new ChartValues<int> { item.Value },
                        DataLabels = true
                    });
                }
            }
            DataContext = this;
        }*/
        /*
        public void PieChart_GiangVienHoTro()
        {
            DataTable dtLuanVan = load_data(); // Load dữ liệu từ cơ sở dữ liệu
            if (dtLuanVan != null && dtLuanVan.Rows.Count > 0)
            {
                Dictionary<string, int> gvCounts = new Dictionary<string, int>();
                foreach (DataRow row in dtLuanVan.Rows)
                {
                    string maGV = row["MaGV"].ToString();
                    if (gvCounts.ContainsKey(maGV))
                        gvCounts[maGV]++;
                    else
                        gvCounts.Add(maGV, 1);
                }

                SeriesCollection = new SeriesCollection();
                foreach (var item in gvCounts)
                {
                    SeriesCollection.Add(new PieSeries
                    {
                        Title = item.Key,
                        Values = new ChartValues<int> { item.Value },
                        DataLabels = true
                    });
                }
            }
            DataContext = this;
        }*/

        public DataTable load_data()
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM LUANVAN");
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtLuanVan = new DataTable();
                adapter.Fill(dtLuanVan);
                return dtLuanVan;
            }
            catch (Exception ex)
            {
                HandyControl.Controls.MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
