using EssayManagement.Database;
using HandyControl.Interactivity;
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
using EssayManagement.Database;
using HandyControl.Interactivity;
using HandyControl.Controls;
using System.Data;
using System.Data.SqlClient;

namespace EssayManagement.Views.User_Control.UCSV
{
    /// <summary>
    /// Interaction logic for UCDaDuocDuyet.xaml
    /// </summary>
    public partial class UCDaDuocDuyet : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        
        public UCDaDuocDuyet()
        {
            InitializeComponent();
            List<string> LinhVuc = new List<string> { "Website", "Application", "AI", "Data", "Cloud", "Security", "Architecture" };
            cbLinhVuc.ItemsSource = LinhVuc;
            
        }

        /*private void load()
        {
            string sqlStr = "SELECT * FROM LUANVAN WHERE MaLuanVan";
            DataTable dtLuanVan = new DataTable();
            
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            adapter.Fill(dtLuanVan);
        }*/

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            int roundedTienDo = (int)Math.Round(sldTienDo.Value);
            string sqlStr = string.Format("UPDATE LUANVAN SET TienDo=N'{0}' WHERE MaLuanVan = '{1}'", roundedTienDo.ToString(), txtMaLuanVan.Text);
            dBconnect.ThucThi(sqlStr);
            HandyControl: ControlCommands.Close.Execute(null, this);
        }

        private void btnNhiemVu_Click(object sender, RoutedEventArgs e)
        {
            int roundedTienDo = (int)Math.Round(sldTienDo.Value);
            if (roundedTienDo == 100)
            {
                HandyControl.Controls.MessageBox.Show("Nộp thành công");
            }
            else HandyControl.Controls.MessageBox.Show("Tiến độ chưa đạt 100%");
        }
    }
}
