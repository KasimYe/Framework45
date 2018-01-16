/**
 *                             _ooOoo_
 *                            o8888888o
 *                            88" . "88
 *                            (| -_- |)
 *                            O\  =  /O
 *                         ____/`---'\____
 *                       .'  \\|     |//  `.
 *                      /  \\|||  :  |||//  \
 *                     /  _||||| -:- |||||-  \
 *                     |   | \\\  -  /// |   |
 *                     | \_|  ''\---/''  |   |
 *                     \  .-\__  `-`  ___/-. /
 *                   ___`. .'  /--.--\  `. . __
 *                ."" '<  `.___\_<|>_/___.'  >'"".
 *               | | :  `- \`.;`\ _ /`;.`/ - ` : | |
 *               \  \ `-.   \_ __\ /__ _/   .-` /  /
 *          ======`-.____`-.___\_____/___.-`____.-'======
 *                             `=---='
 *          ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
 *                     佛祖保佑        永无BUG
 *            佛曰:
 *                   写字楼里写字间，写字间里程序员；
 *                   程序人员写程序，又拿程序换酒钱。
 *                   酒醒只在网上坐，酒醉还来网下眠；
 *                   酒醉酒醒日复日，网上网下年复年。
 *                   但愿老死电脑间，不愿鞠躬老板前；
 *                   奔驰宝马贵者趣，公交自行程序员。
 *                   别人笑我忒疯癫，我笑自己命太贱；
 *                   不见满街漂亮妹，哪个归得程序员？
*/
/*----------------------------------------------------------------
** Copyright (C) 2017 
**
** file：OrderDAL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-06 20:07:37
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

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
    public class OrderDAL : IOrderDAL
    {
        public int AddEntity(Order entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "INSERT INTO `zjyxcg`.`order` (`orderId`,`orderName`,`orderType`,`orderRemarks`,`totalDetailCount`,`orderDetailId`,`hospitalId`,`hospitalDepartmentId`,`procurecatalogId`,"
                    + "`purchaseCount`,`purchasePrice`,`purchaseAmount`,`orderDetailState`,`detailDistributeAddress`,`submitTime`,`orderCustomInfo`) "
                    + "VALUES(@orderId,@orderName,@orderType,@orderRemarks,@totalDetailCount,@orderDetailId,@hospitalId,@hospitalDepartmentId,@procurecatalogId,"
                    + "@purchaseCount,@purchasePrice,@purchaseAmount,@orderDetailState,@detailDistributeAddress,@submitTime,@orderCustomInfo) ;";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public Order GetEntityById(string id)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT * FROM `order` WHERE orderDetailId=@orderDetailId";
                var result = Conn.Query<Order>(query, new { orderDetailId = id }).SingleOrDefault();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<Order> GetList(DateTime startDate, DateTime endDate, string hospitalId, string procurecatalogId)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT * FROM `order` WHERE `submitTime` >= @startDate AND `submitTime` <= @endDate";
                var p= new DynamicParameters();
                p.Add("startDate", startDate);
                p.Add("endDate", endDate);
                if (!string.IsNullOrEmpty(hospitalId))
                {
                    query += " AND hospitalId=@hospitalId";
                    p.Add("hospitalId", hospitalId);
                }
                if (!string.IsNullOrEmpty(procurecatalogId))
                {
                    query += " AND procurecatalogId=@procurecatalogId";
                    p.Add("procurecatalogId", procurecatalogId);
                }
                query += " ORDER BY submitTime DESC";
                var result = Conn.Query<Order>(query, p).ToList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public int SetEntity(Order entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "UPDATE `zjyxcg`.`order` SET `orderDetailState`=@orderDetailState WHERE `orderId`=@orderId ;";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }
    }
}
