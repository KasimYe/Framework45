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
using Kasim.Framework.Factory;
using Kasim.Framework.IDAL.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.MySQLDAL.QuartzLog
{
    public class InvoiceDAL : IInvoiceDAL
    {
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
