using HandyControl.Controls;
using HandyControl.Data;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EssayManagement.Database
{
    class GrowlSettings
    {
        public static void ShowGrowlInfo()
        {
            Growl.InfoGlobal("GrowlInfo");
        }

        public static void ShowGrowlSuccess(string mes)
        {
            Growl.SuccessGlobal(mes);
        }

        public static void ShowGrowlWarning()
        {
            Growl.WarningGlobal(new GrowlInfo
            {
                Message = "GrowlWarning",
                CancelStr = "Ignore",
                ActionBeforeClose = isConfirmed =>
                {
                    Growl.InfoGlobal(isConfirmed.ToString());
                    return true;
                }
            });
        }

        public static void ShowGrowlError(string mes)
        {
            GrowlInfo info = new GrowlInfo { Message = mes, ShowDateTime = false };
            string token = Guid.NewGuid().ToString();
            info.Token = token;

            Growl.ErrorGlobal(info);
            ClearGrowl(10,token);
        }

        public static async Task ClearGrowl(int seconds, string token)
        {
            await Task.Delay(seconds * 1000);
            Growl.Clear(token);
            Growl.ClearGlobal();
        }

        public static void ShowGrowlAsk()
        {
            Growl.AskGlobal("GrowlAsk", isConfirmed =>
            {
                Growl.InfoGlobal(isConfirmed.ToString());
                return true;
            });
        }

        public static void ShowGrowlFatal()
        {
            Growl.FatalGlobal(new GrowlInfo
            {
                Message = "GrowlFatal",
                ShowDateTime = false
            });
        }

        public static void ClearGrowls()
        {
            Growl.ClearGlobal();
        }
    }
}
