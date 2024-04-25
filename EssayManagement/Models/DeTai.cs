using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssayManagement.Models
{
    internal class DeTai
    {
        private string maDeTai;
        private string tenDeTai;
        private string khoa;
        private string moTa;

        public string MaDeTai { get => maDeTai; set => maDeTai = value; }
        public string TenDeTai { get => tenDeTai; set => tenDeTai = value; }
        public string Khoa { get => khoa; set => khoa = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        
    }
}
