using MySql.Data.MySqlClient;
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
** file：ConnectionFactory
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 15:22:04
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Kasim.Framework.Factory
{
    public class ConnectionFactory
    {
        private string ProviderName;
        private string ConnectionString;
        public ConnectionFactory(string ConnectionStringName = "ConnectionString")
        {
            ProviderName = ConfigurationManager.ConnectionStrings[ConnectionStringName].ProviderName;
            ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }

        private IDbConnection _connection;
        public IDbConnection Connection
        {
            get
            {
                var connString = ConnectionString;

                if (_connection != null)
                {
                    if (_connection.State != ConnectionState.Closed)
                    {
                        _connection.Close();
                    }
                    _connection.Dispose();
                    _connection = null;
                }
                return _connection = CreateConnection(connString);
            }
        }

        public IDbConnection CreateConnection(string connString)
        {
            IDbConnection conn = null;
            if (ProviderName == "System.Data.SqlClient")
            {
                conn = new SqlConnection(connString);
            }
            else if (ProviderName == "MySql.Data.MySqlClient")
            {
                conn = new MySqlConnection(connString);
            }

            conn.Open();
            return conn;
        }
    }
}