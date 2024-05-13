using EssayManagement.Database;
using EssayManagement.Views.User_Control.UCHS;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
    /// Interaction logic for UCThaoLuan.xaml
    /// </summary>
    public partial class UCThaoLuan : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DBconnect dBconnect = new DBconnect();
        string ma = Database.UserInSession.LoggedInUser.ToString();
        public UCThaoLuan()
        {
            InitializeComponent();
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ChatListBox.Items.Clear();
            AddMessageToChat();
        }
        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            UCChiTietNhiemVu ucchitietnhiemvu = new UCChiTietNhiemVu();
            string message = MessageTextBox.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                DataTable dtNguoiGui = load_data_SV(ma);
                string sqlStr = "";
                if(ma.Contains("SV"))
                    sqlStr = string.Format("SELECT HoTen FROM SINHVIEN WHERE MaSV = '{0}'", ma);
                else
                    sqlStr = string.Format("SELECT HoTen FROM GIANGVIEN WHERE MaGV = '{0}'", ma);
                var Ten = dBconnect.LayGiaTri(sqlStr);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                string sqlString = string.Format("INSERT INTO HOITHOAI(MaNhiemVu,NguoiGui,NoiDung,ThoiGian) VALUES('{0}',N'{1}',N'{2}','{3}')", txtMaNhiemVu.Text, Ten.ToString(), message, DateTime.Now);
                dBconnect.ThucThi(sqlString);
                MessageTextBox.Clear();
                LoadMessage(Ten.ToString(), message,DateTime.Now.ToString());
            }
        }

        public void AddMessageToChat()
        {
            UCChiTietNhiemVu ucchitietnhiemvu = new UCChiTietNhiemVu();
            DataTable dtHoiThoai = load_data();
            for (int i = 0; i < dtHoiThoai.Rows.Count; i++)
            {
                LoadMessage(dtHoiThoai.Rows[i]["NguoiGui"].ToString(), dtHoiThoai.Rows[i]["NoiDung"].ToString(), dtHoiThoai.Rows[i]["ThoiGian"].ToString());
            }
        }
        private void LoadMessage(string sender, string message, string time)
        {
            ChatListBox.Items.Add($"({time})\n{sender}: {message}\n");
            ChatListBox.ScrollIntoView(ChatListBox.Items[ChatListBox.Items.Count - 1]);
        }
        public DataTable load_data()
        {
            UCChiTietNhiemVu ucchitietnhiemvu = new UCChiTietNhiemVu();
            try
            {
                conn.Open();
                string sqlStrHT = string.Format("SELECT * FROM HOITHOAI WHERE MaNhiemVu='{0}'", txtMaNhiemVu.Text);
                SqlDataAdapter adapterSV = new SqlDataAdapter(sqlStrHT, conn);
                DataTable dtHoiThoai = new DataTable();
                adapterSV.Fill(dtHoiThoai);
                return dtHoiThoai;
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
        public DataTable load_data_SV(string ma)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM SINHVIEN,GIANGVIEN WHERE MaSV='{0}' OR MaGV='{0}'", ma);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}