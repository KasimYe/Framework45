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

* Filename: SaleBillDetail
* Namespace: Kasim.Framework.Entity.QuartzLog.SystemOther
* Classname: SaleBillDetail
* Created: 2018-04-11 00:00:12
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.Entity.QuartzLog.SystemOther
{
    public class SaleBillDetail
    {
        public int DetailID { get; set; }
        public int SaleBillID { get; set; }
        public int PBID { get; set; }
        public int CostID { get; set; }
        public int PID { get; set; }
        public int? SupplierID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Quantity2 { get; set; }
        public decimal Quantity3 { get; set; }
        public decimal CostPrice { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal NoTaxPrice { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal NoTaxTotal { get; set; }
        public decimal PaidTaxTotal { get; set; }
        public decimal PaidNoTaxTotal { get; set; }
        public string Batch { get; set; }
        public string ProductDate { get; set; }
        public string ExpiryDate { get; set; }
        public DateTime ProductDate2 { get; set; }
        public DateTime ExpiryDate2 { get; set; }
        public string SupplierName { get; set; }
        public decimal LSPrice { get; set; }
        public decimal PFPrice { get; set; }
        public decimal PuRate { get; set; }
        public int SubStatus { get; set; }
        public int? RequestID { get; set; }
        public int? RelatedID { get; set; }
        public string Note { get; set; }
        public decimal MdPrice { get; set; }
    }
}
