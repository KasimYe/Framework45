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
** file：Order
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-06 19:53:39
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.Entity.QuartzLog
{
    public class Order
    {
        /// <summary>
        /// 订单编号 2,varchar(36)
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单名称,varchar(1024)
        /// </summary>
        public string OrderName { get; set; }
        /// <summary>
        /// 订单类型,tinyint，正常订单(0)急救药品临时订单(1)
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 订单备注,varchar(1024)
        /// </summary>
        public string OrderRemarks { get; set; }
        /// <summary>
        /// 总单行数,int
        /// </summary>
        public int TotalDetailCount { get; set; }
        /// <summary>
        /// 订单明细编号,varchar(36)
        /// </summary>
        public string OrderDetailId { get; set; }
        /// <summary>
        /// 医疗机构编号,varchar(36)
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 医疗机构部门编号,int
        /// </summary>
        public int HospitalDepartmentId { get; set; }
        /// <summary>
        /// 商品编号,int
        /// </summary>
        public int ProcurecatalogId { get; set; }
        /// <summary>
        /// 采购数量,int
        /// </summary>
        public int PurchaseCount { get; set; }
        /// <summary>
        /// 采购价格,decimal(18,3)
        /// </summary>
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// 采购金额,decimal(18,3)
        /// </summary>
        public decimal PurchaseAmount { get; set; }
        /// <summary>
        /// 订单明细状态,tinyint，已保存待提交(0)已提交待响应(1)已响应待配送(2)拒绝响应(3)已配送待收货(4)拒绝配送(5)未及时配送(6)收货中(7)已收货(8)已撤单(9)
        /// </summary>
        public int OrderDetailState { get; set; }
        /// <summary>
        /// 送货地址,varchar(1024)
        /// </summary>
        public string DetailDistributeAddress { get; set; }
        /// <summary>
        /// 订单时间,datetime
        /// </summary>
        public object SubmitTime { get; set; }
        /// <summary>
        /// 自定义订单信息,varchar(500)
        /// </summary>
        public string OrderCustomInfo { get; set; }
    }

    /// <summary>
    /// 订单明细状态,tinyint，已保存待提交(0)已提交待响应(1)已响应待配送(2)拒绝响应(3)已配送待收货(4)拒绝配送(5)未及时配送(6)收货中(7)已收货(8)已撤单(9)
    /// </summary>
    public class OrderDetailState
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}
