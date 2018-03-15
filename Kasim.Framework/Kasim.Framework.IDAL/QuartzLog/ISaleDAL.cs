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

* Filename: ISaleDAL
* Namespace: Kasim.Framework.IDAL.QuartzLog
* Classname: ISaleDAL
* Created: 2018-03-15 21:21:37
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Kasim.Framework.Entity.QuartzLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.IDAL.QuartzLog
{
    public interface ISaleDAL
    {
        DataTable GetEmpty(Invoice invoice);
        int AddEntity(Sale sale);
        int SetSaleId(string companyPrimaryKey, string id);
    }
}
