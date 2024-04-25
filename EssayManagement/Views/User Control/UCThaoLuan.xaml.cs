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
    /// Interaction logic for UCThaoLuan.xaml
    /// </summary>
    public partial class UCThaoLuan : UserControl
    {
        public UCThaoLuan()
        {
            InitializeComponent();
        }
        /*public struct ChatInfoModel
        {
            public object Message { get; set; }

            public string SenderId { get; set; }

            public ChatRoleType Role { get; set; }

            public ChatMessageType Type { get; set; }

            public object Enclosure { get; set; }
        }*/
        //public ObservableCollection<ChatInfoModel> ChatInfos { get; set; } = new ObservableCollection<ChatInfoModel>();
        /*public interface IEnumerable
        {
            IEnumerator GetEnumerator();
        }
        private void btnGui_Click(object sender, RoutedEventArgs e)
        {
            //ChatBox.AppendText(txtTinNhan.Text);
            //ChatBox.ScrollToEnd();
            var info = new ChatInfoModel
            {
                Message = "Hello",
                SenderId = "1",
                Type = ChatMessageType.String,
                Role = ChatRoleType.Sender
            };
            ChatInfos.Add(info);
        }
        private bool _autoScroll = true;
        private void ScrollViewer_OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange == 0)
            {
                _autoScroll = ScrollViewer.VerticalOffset == ScrollViewer.ScrollableHeight;
            }

            if (_autoScroll && e.ExtentHeightChange != 0)
            {
                ScrollViewer.ScrollToVerticalOffset(ScrollViewer.ExtentHeight);
            }
        }*/
        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                AddMessageToChat("You", message);
                // Tại đây, bạn có thể gửi tin nhắn đến người nhận, xử lý logic liên quan đến giao tiếp mạng, v.v.
                // Ví dụ:
                // client.SendMessage(message);
                MessageTextBox.Clear();
            }
        }

        private void AddMessageToChat(string sender, string message)
        {
            ChatListBox.Items.Add($"{sender}: {message}");
            ChatListBox.ScrollIntoView(ChatListBox.Items[ChatListBox.Items.Count - 1]);
        }
    }
}
