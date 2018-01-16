/*********************************************************************
 **                             _ooOoo_                             **
 **                            o8888888o                            **
 **                            88" . "88                            **
 **                            (| -_- |)                            **
 **                            O\  =  /O                            **
 **                         ____/`---'\____                         **
 **                       .'  \\|     |//  `.                       **
 **                      /  \\|||  :  |||//  \                      **
 **                     /  _||||| -:- |||||-  \                     **
 **                     |   | \\\  -  /// |   |                     **
 **                     | \_|  ''\---/''  |   |                     **
 **                     \  .-\__  `-`  ___/-. /                     **
 **                   ___`. .'  /--.--\  `. . __                    **
 **                ."" '<  `.___\_<|>_/___.'  >'"".                 **
 **               | | :  `- \`.;`\ _ /`;.`/ - ` : | |               **
 **               \  \ `-.   \_ __\ /__ _/   .-` /  /               **
 **          ======`-.____`-.___\_____/___.-`____.-'======          **
 **                             `=---='                             **
 **          ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^          **
 **                     佛祖保佑        永无BUG                     **
 **            佛曰:                                                **
 **                   写字楼里写字间，写字间里程序员；              **
 **                   程序人员写程序，又拿程序换酒钱。              **
 **                   酒醒只在网上坐，酒醉还来网下眠；              **
 **                   酒醉酒醒日复日，网上网下年复年。              **
 **                   但愿老死电脑间，不愿鞠躬老板前；              **
 **                   奔驰宝马贵者趣，公交自行程序员。              **
 **                   别人笑我忒疯癫，我笑自己命太贱；              **
 **                   不见满街漂亮妹，哪个归得程序员？              **
 *********************************************************************/
/*=====================================================================
* Copyright (c) 2018 All Rights Reserved.
* CLRVer.:4.0.30319.42000
* machinenameDESKTOP-U288O1H
* namespace:Kasim.Framework.SQLServerDAL.QuartzLog
* filename:DistributionDAL
* guid:fcaecf19-28ac-434e-9b8a-e9f706ed76f1
* auth:lip86
* date:2018-01-11 20:21:58
* desc:
*
*=====================================================================*/
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IDAL.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Kasim.Framework.SQLServerDAL.QuartzLog
{
    public class DistributionDAL : IDistributionDAL
    {
        public int AddEntity(Distribute entity)
        {
            throw new NotImplementedException();
        }

        public Distribute GetEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Distribute> GetListById(DateTime startDate, DateTime endDate, string orderDetailId)
        {
            using (var Conn = new ConnectionFactory("ErpConnStr").Connection)
            {
                string query = "SELECT DetailID AS companyDistributeId,d.APIOrderDetailId AS orderDetailId,Quantity AS distributeCount,f.FPHM AS invoiceId,pb.Batch AS batchCode,pb.ExpiryDate AS periodDate,"
                    + "d.Note AS distributeCustomInfo,'' AS firstInviceID,'' AS middleInviceID,'' AS secondInviceCode,'' AS distributeId "
                    + "FROM dbo.SaleBillDetail d,dbo.SaleBill f,dbo.ProductBatches pb WHERE f.SaleBillID=d.SaleBillID AND d.PBID=pb.PBID "
                    + "AND f.FormTypeID = 7 AND f.SystemDate >= @startDate AND f.SystemDate <= @endDate AND d.APIOrderDetailId=@orderDetailId";
                var result = Conn.Query<Distribute>(query, new { startDate, endDate }).ToList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }
    }
}
