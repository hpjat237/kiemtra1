using EssayManagement.Database;
using HandyControl.Controls;
using HandyControl.Interactivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for UCChiTietNhiemVu.xaml
    /// </summary>
    public partial class UCChiTietNhiemVu : UserControl
    {
        DBconnect dBconnect = new DBconnect();
        public UCChiTietNhiemVu()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            int roundedTienDo = (int)Math.Round(sldTienDo.Value);
            string sqlStr = string.Format("UPDATE NHIEMVU SET TuaDe = N'{0}', MoTa = N'{1}', TienDo = '{2}', NhanXet = N'{3}' WHERE MaNhiemVu = '{4}'", txtTuaDe.Text, txtMoTa.Text, roundedTienDo.ToString(), txtNhanXet.Text, txtMaNhiemVu.Text);
            dBconnect.ThucThi(sqlStr);
            HandyControl: ControlCommands.Close.Execute(null, this);
        }
        private void btnThaoLuan_Click(object sender, RoutedEventArgs e)
        {
            UCThaoLuan ucThaoLuan = new UCThaoLuan();
            Dialog.Show(ucThaoLuan);
        }
    }
}
