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
** file：Hospital
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-06 10:40:53
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
    public class Hospital:TimeEntity
    {
        /// <summary>
        /// 医疗机构编号,varchar(36)
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 医疗机构名称,varchar(50)
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 地址,varchar(500)
        /// </summary>
        public string HospitalAddress { get; set; }
        /// <summary>
        /// 部门编号,int
        /// </summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// 部门名称,varchar(128)
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 存在为 1、不存在为 0
        /// </summary>
        public bool? IsExist { get; set; }
    }
}
