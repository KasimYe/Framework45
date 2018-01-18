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
* filename:ProcurecatalogDAL
* guid:f47c8fd1-2df5-4267-a2b2-89617c6e64ea
* auth:lip86
* date:2018-01-03 21:06:24
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
    public class ProcurecatalogDAL : IProcurecatalogDAL
    {
        public int AddEntity(Procurecatalog entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "INSERT INTO `zjyxcg`.`procurecatalog` (`procurecatalogId`,`goodsId`,`productName`,`goodsName`,`medicinemodel`,`outlook`,`factor`,`materialName`,"
                    + "`unit`,`companyIdSc`,`companyNameSc`,`purchaseType`,`sourceName`,`middlePack`,`maxPack`,`bidPrice`,`isUsing`,`addTime`,`lastUpdateTime`)"
                    + "VALUES (@procurecatalogId,@goodsId,@productName,@goodsName,@medicinemodel,@outlook,@factor,@materialName,"
                    + "@unit,@companyIdSc,@companyNameSc,@purchaseType,@sourceName,@middlePack,@maxPack,@bidPrice,@isUsing,@addTime,@lastUpdateTime ) ;";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public int SetEntity(Procurecatalog entity)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "UPDATE `zjyxcg`.`procurecatalog` SET `goodsId` = @goodsId,`productName` = @productName,`goodsName` = @goodsName,`medicinemodel` = @medicinemodel,`outlook` = @outlook,"
                    + "`factor` = @factor,`materialName` = @materialName,`unit` = @unit,`companyIdSc` = @companyIdSc,`companyNameSc` = @companyNameSc,`purchaseType` = @purchaseType,`sourceName` = @sourceName,"
                    + "`middlePack` = @middlePack,`maxPack` = @maxPack,`bidPrice` = @bidPrice,`isUsing` = @isUsing,`lastUpdateTime` = @lastUpdateTime "
                    + "WHERE `procurecatalogId` = @procurecatalogId ;";
                var result = Conn.Execute(query, entity);
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public Procurecatalog GetEntityById(int id)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT * FROM procurecatalog WHERE procurecatalogId=@procurecatalogId";
                var result = Conn.Query<Procurecatalog>(query, new { procurecatalogId = id }).SingleOrDefault();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<Procurecatalog> GetListByDate(DateTime startDate, DateTime endDate)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT * FROM procurecatalog WHERE `lastUpdateTime` >= @startDate AND `lastUpdateTime` <= @endDate ORDER BY lastUpdateTime";
                var result = Conn.Query<Procurecatalog>(query, new { startDate, endDate }).ToList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }

        public List<Procurecatalog> GetListByName(string productName)
        {
            using (var Conn = new ConnectionFactory().Connection)
            {
                string query = "SELECT * FROM procurecatalog WHERE productName LIKE @name ORDER BY lastUpdateTime";
                var result = Conn.Query<Procurecatalog>(query, new { name = '%' + productName + '%' }).ToList();
                Conn.Close();
                Conn.Dispose();
                return result;
            }
        }
    }
}
