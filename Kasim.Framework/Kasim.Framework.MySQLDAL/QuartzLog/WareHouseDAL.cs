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
* filename:WareHouseDAL
* guid:c9f596b1-a11e-4148-8c17-840e2be166ba
* auth:lip86
* date:2018-01-08 20:43:36
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
    public class WareHouseDAL : IWareHouseDAL
    {
        public int AddEntity(WareHouse entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "INSERT INTO `zjyxcg`.`warehouse` (`distributeId`,`warehouseCount`,`warehouseTime`,`warehouseCustomInfo`) "
                    + "VALUES(@distributeId,@warehouseCount,@warehouseTime,@warehouseCustomInfo) ;";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public WareHouse GetEntityById(string id)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT * FROM `warehouse` WHERE distributeId=@distributeId";
                var result = Conn.Query<WareHouse>(query, new { distributeId = id }).SingleOrDefault();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<WareHouse> GetList(DateTime startDate, DateTime endDate, string hospitalId)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT `warehouseCount`,`warehouseTime`,`warehouseCustomInfo`,"
                    + "`companyDistributeId`,d.`orderDetailId`,`distributeCount`,`invoiceId`,`batchCode`,`periodDate`,`distributeCustomInfo`,`firstInviceID`,`middleInviceID`,`secondInviceCode`,d.`distributeId`,"
                    + "`orderId`,`orderName`,`orderType`,`orderRemarks`,`totalDetailCount`,`hospitalId`,`hospitalDepartmentId`,`procurecatalogId`,`purchaseCount`,`purchasePrice`,`purchaseAmount`,`orderDetailState`,`detailDistributeAddress`,`submitTime`,`orderCustomInfo` "
                    + "FROM `zjyxcg`.`warehouse` w RIGHT JOIN `zjyxcg`.`distribute` d ON w.`distributeId`=d.`distributeId`,`zjyxcg`.`Order` o WHERE d.`orderDetailId`=o.`orderDetailId` AND o.`hospitalId`=@hospitalId AND w.warehouseTime>=@startDate AND w.warehouseTime <= @endDate";
                var result = Conn.Query<WareHouse, Distribute, Order, WareHouse>(query, (wareHouse, distribute, order) =>
                 {
                     distribute.Order = order;
                     wareHouse.Distribute = distribute;
                     return wareHouse;
                 }, new { hospitalId, startDate, endDate }, splitOn: "companyDistributeId,orderId").AsList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<WareHouse> GetList(string hospitalId)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT `warehouseCount`,`warehouseTime`,`warehouseCustomInfo`,"
                    + "`companyDistributeId`,d.`orderDetailId`,`distributeCount`,`invoiceId`,`batchCode`,`periodDate`,`distributeCustomInfo`,`firstInviceID`,`middleInviceID`,`secondInviceCode`,d.`distributeId`,"
                    + "`orderId`,`orderName`,`orderType`,`orderRemarks`,`totalDetailCount`,`hospitalId`,`hospitalDepartmentId`,`procurecatalogId`,`purchaseCount`,`purchasePrice`,`purchaseAmount`,`orderDetailState`,`detailDistributeAddress`,`submitTime`,`orderCustomInfo` "
                    + "FROM `zjyxcg`.`warehouse` w RIGHT JOIN `zjyxcg`.`distribute` d ON w.`distributeId`=d.`distributeId`,`zjyxcg`.`Order` o WHERE d.`orderDetailId`=o.`orderDetailId` AND o.`hospitalId`=@hospitalId ";
                var result = Conn.Query<WareHouse, Distribute, Order, WareHouse>(query, (wareHouse, distribute, order) =>
                {
                    distribute.Order = order;
                    wareHouse.Distribute = distribute;
                    return wareHouse;
                }, new { hospitalId }, splitOn: "companyDistributeId,orderId").AsList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }
    }
}
