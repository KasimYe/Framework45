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

* Filename: InvoiceDAL
* Namespace: Kasim.Framework.MySQLDAL.QuartzLog
* Classname: InvoiceDAL
* Created: 2018-03-14 21:12:31
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Dapper;
using Kasim.Framework.Common.DBHelper;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IDAL.QuartzLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.MySQLDAL.QuartzLog
{
    public class InvoiceDAL : IInvoiceDAL
    {
        public int AddEntity(Invoice entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "INSERT INTO `zjyxcg`.`invoice` (`companyPrimaryKey`,`invoiceCode`,`invoiceID`,`invoiceDate`,`invoiceType`,`saleID`,`saleRemark`,`buyID`,`buyRemarks`,`picUrl`,`picMD5`) "
                            + "VALUES(@companyPrimaryKey,@invoiceCode,@invoiceID,@invoiceDate,@invoiceType,@saleID,@saleRemark,@buyID,@buyRemarks,@picUrl,@picMD5); ";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public DataTable GetTable(DateTime startDate, DateTime endDate)
        {      
                string query = "SELECT `companyPrimaryKey`,`invoiceCode`,`invoiceID`,`invoiceDate`,`invoiceType`,`saleID`,`saleRemark`,`buyID`,`buyRemarks`,`picUrl`,`picMD5`,`id`,s.`companyName` AS saleName,b.`companyName` AS buyName "
                    + "FROM `zjyxcg`.`invoice` i,`zjyxcg`.`company` s,`zjyxcg`.`company` b WHERE i.`saleID`=s.`companyId` AND i.`buyID`=b.`companyId`;";          
                DbHelperMySQL.connectionString = new ConnectionFactory().ConnectionString;
                return DbHelperMySQL.Query(query).Tables[0];
         
        }

        public int SetInvoiceId(string companyPrimaryKey, string id)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "UPDATE invoice SET id=@id WHERE companyPrimaryKey=@companyPrimaryKey ;";
                var result = Conn.Execute(query, new { id, companyPrimaryKey });
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }
    }
}
