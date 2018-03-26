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

* Filename: CronDAL
* Namespace: Kasim.Framework.MySQLDAL.QuartzLog
* Classname: CronDAL
* Created: 2018-03-26 19:59:18
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Dapper;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.IDAL.QuartzLog;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.MySQLDAL.QuartzLog
{
    public class CronDAL : ICronDAL
    {
        private string connectionString;

        public CronDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string GetEntity(string cronName)
        {
            using (var Conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM t_cron WHERE cronName=@cronName ;";
                var result = Conn.Query<Cron>(query, new { cronName }).SingleOrDefault();
                Conn.Close();
                Conn.Dispose();
                return result == null ? "" : result.CronValue;
            }
        }
    }
}
