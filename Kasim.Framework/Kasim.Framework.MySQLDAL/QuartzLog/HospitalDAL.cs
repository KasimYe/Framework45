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
** file：HospitalDAL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-06 11:25:29
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
    public class HospitalDAL : IHospitalDAL
    {
        public int AddEntity(Hospital entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "INSERT INTO `zjyxcg`.`hospital` (`hospitalId`,`hospitalName`,`hospitalAddress`,`departmentId`,`groupName`,`addTime`,`lastUpdateTime`)"
                    + "VALUES (@hospitalId,@hospitalName,@hospitalAddress,@departmentId,@groupName,@addTime,@lastUpdateTime) ;";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public int SetEntity(Hospital entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "UPDATE `zjyxcg`.`hospital` SET  `hospitalName` = @hospitalName,`hospitalAddress` = @hospitalAddress,`groupName` = @groupName,"
                    + "`lastUpdateTime` = @lastUpdateTime WHERE `hospitalId` = @hospitalId AND `departmentId` = @departmentId ;";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public Hospital GetEntityById(string id, int id2)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT * FROM hospital WHERE hospitalId=@hospitalId AND departmentId=@departmentId";
                var result = Conn.Query<Hospital>(query, new { hospitalId = id, departmentId = id2 }).SingleOrDefault();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public Hospital GetEntityById(string id)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT * FROM hospital WHERE hospitalId=@hospitalId LIMIT 1";
                var result = Conn.Query<Hospital>(query, new { hospitalId = id }).SingleOrDefault();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<Hospital> GetListByDate(DateTime startDate, DateTime endDate)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT hospitalId,hospitalName,hospitalAddress,departmentId,groupName,`addTime`,lastUpdateTime FROM Hospital WHERE `lastUpdateTime` >= @startDate AND `lastUpdateTime` <= @endDate ORDER BY lastUpdateTime";
                var result = Conn.Query<Hospital>(query, new { startDate, endDate }).ToList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<Hospital> GetListByName(string hospitalName)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT hospitalId,hospitalName,hospitalAddress,departmentId,groupName,`addTime`,lastUpdateTime FROM Hospital WHERE hospitalName LIKE @name ORDER BY lastUpdateTime";
                var result = Conn.Query<Hospital>(query, new { name = '%' + hospitalName + '%' }).ToList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }
    }
}
