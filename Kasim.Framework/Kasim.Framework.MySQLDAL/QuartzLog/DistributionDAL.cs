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
* namespace:Kasim.Framework.MySQLDAL.QuartzLog
* filename:DistributionDAL
* guid:fe89d2a0-dcfe-4fcb-9daa-61f9f5723331
* auth:lip86
* date:2018-01-11 20:21:29
* desc:
*
*=====================================================================*/
using Dapper;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IDAL.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.MySQLDAL.QuartzLog
{
    public class DistributionDAL : IDistributionDAL
    {
        public int AddEntity(Distribute entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "INSERT INTO `zjyxcg`.`distribute` (`companyDistributeId`,`orderDetailId`,`distributeCount`,`invoiceId`,`batchCode`,`periodDate`,`distributeCustomInfo`,`firstInviceID`,`middleInviceID`,`secondInviceCode`,`distributeId`) "
                            + "VALUES(@companyDistributeId,@orderDetailId,@distributeCount,@invoiceId,@batchCode,@periodDate,@distributeCustomInfo,@firstInviceID,@middleInviceID,@secondInviceCode,@distributeId) ;";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public Distribute GetEntityById(string id)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT `companyDistributeId`,`orderDetailId`,`distributeCount`,`invoiceId`,`batchCode`,`periodDate`,`distributeCustomInfo`,`firstInviceID`,`middleInviceID`,`secondInviceCode`,`distributeId` FROM `zjyxcg`.`distribute` WHERE `companyDistributeId`=@companyDistributeId";
                var result = Conn.Query<Distribute>(query, new { companyDistributeId = id }).SingleOrDefault();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<Distribute> GetList(string hospitalId)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT MAX(`companyDistributeId`) AS companyDistributeId,d.`orderDetailId`,SUM(`distributeCount`) AS distributeCount,`invoiceId`,`batchCode`,`periodDate`,`distributeCustomInfo`,`firstInviceID`,`middleInviceID`,`secondInviceCode`,`distributeId`,"
                    + "`orderId`,`orderName`,`orderType`,`orderRemarks`,`totalDetailCount`,`hospitalId`,`hospitalDepartmentId`,`procurecatalogId`,`purchaseCount`,`purchasePrice`,`purchaseAmount`,`orderDetailState`,`detailDistributeAddress`,`submitTime`,`orderCustomInfo` "
                    + "FROM`zjyxcg`.`distribute` d,`zjyxcg`.`Order` o WHERE d.`orderDetailId`=o.`orderDetailId` AND o.`hospitalId`=@hospitalId"
                    + " GROUP BY d.`orderDetailId`,`invoiceId`,`batchCode`,`periodDate`,`distributeCustomInfo`,`firstInviceID`,`middleInviceID`,`secondInviceCode`,`distributeId`,`orderId`,`orderName`,`orderType`,"
                    + "`orderRemarks`,`totalDetailCount`,`hospitalId`,`hospitalDepartmentId`,`procurecatalogId`,`purchaseCount`,`purchasePrice`,`purchaseAmount`,`orderDetailState`,`detailDistributeAddress`,`submitTime`,`orderCustomInfo`";
                var result = Conn.Query<Distribute, Order, Distribute>(query, (distribute, order) =>
                  {
                      distribute.Order = order;
                      return distribute;
                  }, new { hospitalId }, splitOn: "orderId").AsList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<Distribute> GetListById(DateTime startDate, DateTime endDate, string orderDetailId)
        {
            throw new NotImplementedException();
        }

        public int SetDistributeId(string companyDistributeId, string distributeId)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "UPDATE distribute SET distributeId=@distributeId WHERE companyDistributeId=@companyDistributeId ;";
                var result = Conn.Execute(query, new { distributeId, companyDistributeId });
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }
    }
}
