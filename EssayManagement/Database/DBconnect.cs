using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HandyControl.Controls;
using EssayManagement.Views.User_Control;
using HandyControl.Tools.Extension;
using System.Windows;
using HandyControl.Tools;
using HandyControl.Properties.Langs;

namespace EssayManagement.Database
{
    internal class DBconnect
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public void ThucThi(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    GrowlSettings.ShowGrowlSuccess("Thành công");
                }
                else
                {
                    GrowlSettings.ShowGrowlError("Thất bại");
                }
            }
            catch (Exception ex)
            {
                GrowlSettings.ShowGrowlError(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public object LayGiaTri(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                var val = cmd.ExecuteScalar();
                if (val != null)
                {
                    return val.ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                GrowlSettings.ShowGrowlError(ex.Message);
                return "";
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
