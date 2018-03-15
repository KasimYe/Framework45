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

* Filename: SaleDAL
* Namespace: Kasim.Framework.MySQLDAL.QuartzLog
* Classname: SaleDAL
* Created: 2018-03-15 21:21:56
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Dapper;
using Kasim.Framework.Common.DBHelper;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IDAL.QuartzLog;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.MySQLDAL.QuartzLog
{
    public class SaleDAL : ISaleDAL
    {
        public int AddEntity(Sale entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "INSERT INTO `zjyxcg`.`sale` (`companyPrimaryKey`,`invoiceCode`,`invoiceID`,`goodsID`,`batchCode`,`periodDate`,`saleNumber`)"
                    + "VALUES(@companyPrimaryKey,@invoiceCode,@invoiceID,@goodsID,@batchCode,@periodDate,@saleNumber);";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public DataTable GetEmpty(Invoice invoice)
        {
            string query = "SELECT `companyPrimaryKey`,`invoiceCode`,`invoiceID`,s.`goodsID`,p.`procurecatalogId`,p.`productName`,p.`goodsName`,p.`outlook`,p.`companyNameSc`,`batchCode`,`periodDate`,`saleNumber` "
                    + "FROM `zjyxcg`.`sale` s,`zjyxcg`.`procurecatalog` p WHERE s.`goodsID`=p.`goodsId` AND s.`invoiceCode`=@InvoiceCode AND s.`invoiceID`=@InvoiceID;";
            DbHelperMySQL.connectionString = new ConnectionFactory().ConnectionString;
            var cmdParms = new MySqlParameter[] {
                new MySqlParameter("@InvoiceCode", invoice.InvoiceCode) ,
                new MySqlParameter("@InvoiceID", invoice.InvoiceID)
            };            
            return DbHelperMySQL.Query(query, cmdParms).Tables[0];
        }

        public int SetSaleId(string companyPrimaryKey, string id)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "UPDATE sale SET id=@id WHERE companyPrimaryKey=@companyPrimaryKey ;";
                var result = Conn.Execute(query, new { id, companyPrimaryKey });
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }
    }
}
