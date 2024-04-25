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

namespace EssayManagement.Views.User_Control
{
    /// <summary>
    /// Interaction logic for UCThemNhiemVu.xaml
    /// </summary>
    public partial class UCThemNhiemVu : UserControl
    {
        DBconnect dBconnect = new DBconnect();
        public UCThemNhiemVu()
        {
            InitializeComponent();
        }

        private void txtThem_Click(object sender, RoutedEventArgs e)
        {
            int roundedTienDo = (int)Math.Round(sldTienDo.Value);
            string sqlString = string.Format("INSERT INTO NHIEMVU(MaLuanVan, TuaDe, MoTa, TienDo, NhanXet) VALUES('{0}',N'{1}',N'{2}','{3}', N'{4}')", txtMaLuanVan.Text, txtTuaDe.Text, txtMoTa.Text, roundedTienDo.ToString(), txtNhanXet.Text);
            dBconnect.ThucThi(sqlString);
            HandyControl: ControlCommands.Close.Execute(null, this);
        }
    }
}
