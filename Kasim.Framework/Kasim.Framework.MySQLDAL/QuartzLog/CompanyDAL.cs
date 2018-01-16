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
** file：CompanyDAL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-06 12:41:57
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
    public class CompanyDAL : ICompanyDAL
    {
        public int AddEntity(Company entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "INSERT INTO `zjyxcg`.`company` (`companyId`,`companyName`,`address`,`companyContactTel`,`companyContactFax`,`zipCode`,`email`,`addTime`,`lastUpdateTime`)"
                    + "VALUES (@companyId,@companyName,@address,@companyContactTel,@companyContactFax,@zipCode,@email,@addTime,@lastUpdateTime) ;";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public Company GetEntityById(string id)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT * FROM company WHERE companyId=@companyId";
                var result = Conn.Query<Company>(query, new { companyId = id }).SingleOrDefault();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<Company> GetListByDate(DateTime startDate, DateTime endDate)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT `companyId`,`companyName`,`address`,`companyContactTel`,`companyContactFax`,`zipCode`,`email`,`addTime`,`lastUpdateTime` FROM Company WHERE `lastUpdateTime` >= @startDate AND `lastUpdateTime` <= @endDate ORDER BY lastUpdateTime";
                var result = Conn.Query<Company>(query, new { startDate, endDate }).ToList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<Company> GetListByName(string companyName)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT `companyId`,`companyName`,`address`,`companyContactTel`,`companyContactFax`,`zipCode`,`email`,`addTime`,`lastUpdateTime` FROM Company WHERE companyName LIKE @name ORDER BY lastUpdateTime";
                var result = Conn.Query<Company>(query, new { name = '%' + companyName + '%' }).ToList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }
    }
}
