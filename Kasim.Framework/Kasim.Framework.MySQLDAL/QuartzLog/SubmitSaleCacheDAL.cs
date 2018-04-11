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

* Filename: SubmitSaleCacheDAL
* Namespace: Kasim.Framework.MySQLDAL.QuartzLog
* Classname: SubmitSaleCacheDAL
* Created: 2018-04-10 23:57:22
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Dapper;
using Kasim.Framework.Entity.QuartzLog.SystemOther;
using Kasim.Framework.IDAL.QuartzLog;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.MySQLDAL.QuartzLog
{
    public class SubmitSaleCacheDAL : ISubmitSaleCacheDAL
    {
        public List<SaleBill> GetTopFive(int MaxId)
        {
            using (var Conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MisConnectionString"].ConnectionString))
            {
                var query = "SELECT * FROM `t_salebill` WHERE invalid=0 AND SaleBillId>@MaxId ORDER BY SaleBillId LIMIT 5;";
                var reuslt = Conn.Query<SaleBill>(query, new { MaxId }).ToList();
                query = "SELECT * FROM `t_salebilldetail` WHERE SaleBillId=@SaleBillID ORDER BY DetailId;";
                reuslt.ForEach(x => {
                    x.SaleBillDetails = Conn.Query<SaleBillDetail>(query, new { x.SaleBillID }).ToList();
                });
                Conn.Close();
                Conn.Dispose();
                return reuslt;
            }
        }

        public string InsertBill(SaleBill s)
        {
            throw new NotImplementedException();
        }

        public int SetInvalid(int saleBillID)
        {
            using (var Conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MisConnectionString"].ConnectionString))
            {
                var query = "UPDATE `t_salebill` SET invalid=1 WHERE SaleBillId=@saleBillID;";
                var reuslt = Conn.Execute(query, new { saleBillID });                
                Conn.Close();
                Conn.Dispose();
                return reuslt;
            }
        }
    }
}
