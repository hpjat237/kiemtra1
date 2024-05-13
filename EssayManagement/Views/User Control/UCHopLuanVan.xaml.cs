using EssayManagement.Database;
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

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for HopLuanVan.xaml
    /// </summary>
    public partial class HopLuanVan : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public HopLuanVan()
        {
            InitializeComponent();
        }
    }
}
