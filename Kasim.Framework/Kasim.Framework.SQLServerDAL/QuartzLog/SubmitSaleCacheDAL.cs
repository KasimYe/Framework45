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
* Namespace: Kasim.Framework.SQLServerDAL.QuartzLog
* Classname: SubmitSaleCacheDAL
* Created: 2018-04-10 23:56:59
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Kasim.Framework.Entity.QuartzLog.SystemOther;
using Kasim.Framework.IDAL.QuartzLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.SQLServerDAL.QuartzLog
{
    public class SubmitSaleCacheDAL : ISubmitSaleCacheDAL
    {
        public List<SaleBill> GetTopFive(int MaxId)
        {
            throw new NotImplementedException();
        }

        public string InsertBill(SaleBill s)
        {
            var reslut = "";
            using (var Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MisSqlServer"].ConnectionString))
            {
                Conn.Open();
                using (var Tran = Conn.BeginTransaction())
                {
                    using (var Comm = new SqlCommand())
                    {
                        try
                        {
                            Comm.Connection = Conn;
                            Comm.Transaction = Tran;
                            Comm.CommandType = CommandType.StoredProcedure;
                            Comm.CommandText = "InsertForm";
                            Comm.Parameters.Clear();
                            Comm.Parameters.Add("@FormTypeID", SqlDbType.Int).Value = s.FormTypeID;
                            Comm.Parameters.Add("@StoreID", SqlDbType.Int).Value = s.StoreID;
                            Comm.Parameters.Add("@ClientID", SqlDbType.Int).Value = s.ClientID;
                            Comm.Parameters.Add("@WarehouseID", SqlDbType.Int).Value = s.WarehouseId;
                            Comm.Parameters.Add("@CreatorID", SqlDbType.Int).Value = s.CreatorID;
                            Comm.Parameters.Add("@SalesID", SqlDbType.Int).Value = s.SalesID;
                            Comm.Parameters.Add("@Status", SqlDbType.Int).Value = s.Status;
                            Comm.Parameters.Add("@TransAddress", SqlDbType.NVarChar, 200).Value = s.TransAddress;
                            Comm.Parameters.Add("@Notes", SqlDbType.NVarChar, 255).Value = "缓存写入ID:" + s.SaleBillID.ToString();
                            Comm.Parameters.Add("@bOutlet", SqlDbType.Bit).Value = s.BOutlet;
                            Comm.Parameters.Add("@FormNumber", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                            Comm.Parameters.Add("@FID", SqlDbType.Int).Direction = ParameterDirection.Output;
                            Comm.ExecuteNonQuery();
                            reslut = "成功写入单据号:" + Comm.Parameters["@FormNumber"].Value.ToString();
                            var saleBillId = Convert.ToInt32(Comm.Parameters["@FID"].Value);
                            decimal zkSum = 0;
                            Comm.CommandText = "InsertDetail";
                            s.SaleBillDetails.ForEach(d =>
                            {
                                Comm.Parameters.Clear();
                                Comm.Parameters.Add("@FormTypeID", SqlDbType.Int).Value = s.FormTypeID;
                                Comm.Parameters.Add("@FID", SqlDbType.Int).Value = saleBillId;
                                Comm.Parameters.Add("@PID", SqlDbType.Int).Value = d.PID;
                                Comm.Parameters.Add("@CostID", SqlDbType.Int).Value = d.CostID;
                                Comm.Parameters.Add("@Quantity", SqlDbType.Money).Value = d.Quantity;
                                Comm.Parameters.Add("@NoTaxPrice", SqlDbType.Money).Value = d.NoTaxPrice;
                                Comm.Parameters.Add("@TaxPrice", SqlDbType.Money).Value = d.TaxPrice;
                                Comm.Parameters.Add("@PBID", SqlDbType.Int).Value = d.PBID;
                                Comm.Parameters.Add("@NoTaxTotal", SqlDbType.Money).Value = d.NoTaxTotal;
                                Comm.Parameters.Add("@TaxTotal", SqlDbType.Money).Value = d.TaxTotal;
                                Comm.Parameters.Add("@SubStatus", SqlDbType.TinyInt).Value = d.SubStatus;
                                Comm.Parameters.Add("@Quantity3", SqlDbType.Money).Value = d.Quantity3;
                                Comm.Parameters.Add("@bNoUpdateInventory", SqlDbType.Bit).Value = true;
                                Comm.ExecuteNonQuery();
                                if (d.Quantity3 > 0)
                                {
                                    zkSum += d.Quantity3 * d.TaxPrice;
                                }
                            });
                            if (zkSum != 0)
                            {
                                Comm.CommandText = "InsertZKDetail";
                                Comm.Parameters.Clear();
                                Comm.Parameters.Add("@SaleBillID", SqlDbType.Int).Value = saleBillId;
                                Comm.Parameters.Add("@PID", SqlDbType.Int).Value = 3;
                                Comm.Parameters.Add("@TaxPrice", SqlDbType.Money).Value = zkSum;
                                Comm.ExecuteNonQuery();
                            }
                            Comm.CommandText = "UpdateFormSum";
                            Comm.Parameters.Clear();
                            Comm.Parameters.Add("@FormTypeID", SqlDbType.Int).Value = s.FormTypeID;
                            Comm.Parameters.Add("@FID", SqlDbType.Int).Value = saleBillId;
                            Comm.ExecuteNonQuery();
                            Tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            reslut = ex.Message;
                        }
                        finally
                        {
                            Conn.Close();
                            Comm.Dispose();
                            Tran.Dispose();
                            Conn.Dispose();
                        }
                    }
                }
            }
            return reslut;
        }

        public int SetInvalid(int saleBillID)
        {
            throw new NotImplementedException();
        }
    }
}
