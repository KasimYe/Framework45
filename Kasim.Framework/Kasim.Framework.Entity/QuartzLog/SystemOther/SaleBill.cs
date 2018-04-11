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

* Filename: SaleBill
* Namespace: Kasim.Framework.Entity.QuartzLog.SystemOther
* Classname: SaleBill
* Created: 2018-04-11 00:00:02
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
    public class SaleBill
    {
        public int DetailID { get; set; }
        public int SaleBillID { get; set; }
        public string FormNumber { get; set; }
        public int FormTypeID { get; set; }
        public string FormTypeName { get; set; }
        public int RelatedFid { get; set; }
        public int RequestFid { get; set; }
        public int StoreID { get; set; }
        public int ClientID { get; set; }
        public int CreatorID { get; set; }
        public int SalesID { get; set; }
        public decimal NoTaxSum { get; set; }
        public decimal TaxSum { get; set; }
        public DateTime SystemDate { get; set; }
        public DateTime SystemTime { get; set; }
        public string TransAddress { get; set; }
        public decimal Quantity { get; set; }
        public decimal Quantity3 { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal NoTaxPrice { get; set; }
        public decimal MDPrice { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal NoTaxTotal { get; set; }
        public string Batch { get; set; }
        public string ExpiryDate { get; set; }
        public string ProductDate { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string CreatorName { get; set; }
        public string SalesName { get; set; }
        public int? WarehouseId { get; set; }
        public int? RequestFID { get; set; }
        public int? Status { get; set; }
        public string Notes { get; set; }
        public string BillNotes { get; set; }
        public decimal TaxPuRate { get; set; }
        public bool BOutlet { get; set; }
        public bool BMhj { get; set; }
        public bool BPuHuo { get; set; }
        public bool BCold { get; set; }
        public List<SaleBillDetail> SaleBillDetails { get; set; }
    }
}
