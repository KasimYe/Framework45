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
* namespace:Kasim.Framework.Entity.QuartzLog
* filename:Procurecatalog
* guid:c40ca1f9-110d-41dd-8055-eff0294100fc
* auth:lip86
* date:2018-01-03 19:09:33
* desc:
*
*=====================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.Entity.QuartzLog
{
    public class Procurecatalog : TimeEntity
    {
        /// <summary>
        /// 商品编号 1,int
        /// </summary>
        public int ProcurecatalogId { get; set; }
        /// <summary>
        /// 产品 ID,int
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 通用名,varchar(512)
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 商品名,varchar(36)
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 剂型,varchar(256)
        /// </summary>
        public string Medicinemodel { get; set; }
        /// <summary>
        /// 规格,varchar(256)
        /// </summary>
        public string Outlook { get; set; }
        /// <summary>
        /// 转换比,smallint
        /// </summary>
        public int? Factor { get; set; }
        /// <summary>
        /// 包装材质,varchar(36)
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 单位,varchar(36)
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 生产企业编号,varchar(36)
        /// </summary>
        public string CompanyIdSc { get; set; }
        /// <summary>
        /// 生产企业名称,varchar(200)
        /// </summary>
        public string CompanyNameSc { get; set; }
        /// <summary>
        /// 采购类别,tinyint，中标药品(0)、廉价药品(1)、紧张药品(2)、低价药品(3)、备案药品(4)
        /// </summary>
        public int? PurchaseType { get; set; }
        /// <summary>
        /// 来源名称,varchar(1024)
        /// </summary>
        public string SourceName { get; set; }
        /// <summary>
        /// 中包装,smallint
        /// </summary>
        public int? MiddlePack { get; set; }
        /// <summary>
        /// 大包装,smallint
        /// </summary>
        public int? MaxPack { get; set; }
        /// <summary>
        /// 中标价格,decimal(18,3)
        /// </summary>
        public decimal? BidPrice { get; set; }
        /// <summary>
        /// 是否撤废,tinyint，启用(1)停用(0)
        /// </summary>
        public int? IsUsing { get; set; }
        /// <summary>
        /// 存在为 1、不存在为 0
        /// </summary>
        public bool? IsExist { get; set; }
        /// <summary>
        /// 关联企业系统中的商品ID
        /// </summary>
        public string CompanyProcurecatalogId { get; set; }
    }

    /// <summary>
    /// 采购类别,tinyint，中标药品(0)、廉价药品(1)、紧张药品(2)、低价药品(3)、备案药品(4)
    /// </summary>
    public class PurchaseType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
