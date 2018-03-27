/*
                 ___====-_  _-====___
           _--^^^#####//      \\#####^^^--_
        _-^##########// (    ) \\##########^-_
       -############//  |\^^/|  \\############-
     _/############//   (@::@)   \\############\_
    /#############((     \\//     ))#############\
   -###############\\    (oo)    //###############-
  -#################\\  / VV \  //#################-
 -###################\\/      \//###################-
_#/|##########/\######(   /\   )######/\##########|\#_
|/ |#/\#/\#/\/  \#/\##\  |  |  /##/\#/  \/\#/\#/\#| \|
`  |/  V  V  `   V  \#\| |  | |/#/  V   '  V  V  \|  '
   `   `  `      `   / | |  | | \   '      '  '   '
                    (  | |  | |  )
                   __\ | |  | | /__
                  (vvv(VVV)(VVV)vvv)                  

* Filename: ReductSqlDAL
* Namespace: Kasim.Framework.SQLServerDAL.QuartzLog
* Classname: ReductSqlDAL
* Created: 2018-03-26 20:25:56
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Kasim.Framework.IDAL.QuartzLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.SQLServerDAL.QuartzLog
{
    public class ReductSqlDAL : IReductSqlDAL
    {
        public string ReductGo(string dbName, string openAway)
        {
            var cmdText = string.Format("EXEC  killspid  'Bz_MIS';RESTORE DATABASE {0} FROM DISK='{1}' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10", dbName, openAway);
            SqlCommand cmdBakRst = new SqlCommand();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=master;uid=sa;pwd=BRYY@abc123;");
            try
            {
                conn.Open();
                cmdBakRst.Connection = conn;
                cmdBakRst.CommandTimeout = 3600;
                cmdBakRst.CommandType = CommandType.Text;

                //string setOffline = "Alter database GroupMessage Set Offline With rollback immediate ";
                //string setOnline = " Alter database GroupMessage Set Online With Rollback immediate";
                cmdBakRst.CommandText = cmdText;

                cmdBakRst.ExecuteNonQuery();

                return "恭喜你，数据成功恢复为所选文档的状态！";

            }
            catch (SqlException sexc)
            {
                return "失败，可能是对数据库操作失败，原因：" + sexc;
            }
            catch (Exception ex)
            {
                return "对不起，操作失败，可能原因：" + ex;
            }
            finally
            {
                cmdBakRst.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public string ReductGo(string dbName, string openAway, string dbName_Data, string dbName_Log)
        {
            var cmdText = string.Format("restore database {0} from disk='{1}' WITH replace, MOVE '{0}_Data' TO '{2}',MOVE '{0}_Log' TO '{3}'", dbName, openAway, dbName_Data, dbName_Log);
            SqlCommand cmdBakRst = new SqlCommand();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=master;uid=sa;pwd=BRYY@abc123;");
            try
            {
                conn.Open();
                cmdBakRst.Connection = conn;
                cmdBakRst.CommandType = CommandType.Text;

                //string setOffline = "Alter database GroupMessage Set Offline With rollback immediate ";
                //string setOnline = " Alter database GroupMessage Set Online With Rollback immediate";
                cmdBakRst.CommandText = cmdText;

                cmdBakRst.ExecuteNonQuery();

                return "恭喜你，数据成功恢复为所选文档的状态！";

            }
            catch (SqlException sexc)
            {
                return "失败，可能是对数据库操作失败，原因：" + sexc;
            }
            catch (Exception ex)
            {
                return "对不起，操作失败，可能原因：" + ex;
            }
            finally
            {
                cmdBakRst.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
