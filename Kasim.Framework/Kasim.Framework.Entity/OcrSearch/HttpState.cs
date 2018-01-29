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
** file：HttpState
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-29 12:51:03
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.Entity.OcrSearch
{
    public class HttpState
    {
        private string _statusDescription;

        public string StatusDescription
        {
            get { return _statusDescription; }
            set { _statusDescription = value; }
        }

        /// <summary>
        /// 回调 址址, 登陆测试中使用
        /// </summary>
        private string _callBackUrl;

        public string CallBackUrl
        {
            get { return _callBackUrl; }
            set { _callBackUrl = value; }
        }


        /// <summary>
        /// 网页网址 绝对路径格式
        /// </summary>
        private string _url;

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        /// <summary>
        /// 字符串的形式的Cookie信息
        /// </summary>
        private string _cookies;

        public string Cookies
        {
            get { return _cookies; }
            set { _cookies = value; }
        }

        /// <summary>
        /// Cookie信息
        /// </summary>
        private CookieContainer _cookieContainer = new CookieContainer();

        public CookieContainer CookieContainer
        {
            get { return _cookieContainer; }
            set { _cookieContainer = value; }
        }

        /// <summary>
        /// 网页源码
        /// </summary>
        private string _html;

        public string Html
        {
            get { return _html; }
            set { _html = value; }
        }

        /// <summary>
        /// 验证码临时文件(绝对路径)
        /// </summary>
        private string _tmpValCodePic;

        public string TmpValCodePic
        {
            get { return _tmpValCodePic; }
            set { _tmpValCodePic = value; }
        }

        /// <summary>
        /// 验证码临时文件名(相对路径)
        /// </summary>
        private string _tmpValCodeFileName = "emptyPic.gif";

        public string TmpValCodeFileName
        {
            get { return _tmpValCodeFileName; }
            set { _tmpValCodeFileName = value; }
        }

        /// <summary>
        /// 有验证码
        /// </summary>
        private bool _isValCode;

        public bool IsValCode
        {
            get { return _isValCode; }
            set { _isValCode = value; }
        }

        /// <summary>
        /// 验证码URL
        /// </summary>
        private string _valCodeURL;

        public string ValCodeURL
        {
            get { return _valCodeURL; }
            set { _valCodeURL = value; }
        }

        /// <summary>
        /// 验证码识别后的值
        /// </summary>
        private string _valCodeValue;

        public string ValCodeValue
        {
            get { return _valCodeValue; }
            set { _valCodeValue = value; }
        }

        /// <summary>
        /// 其它参数
        /// </summary>
        private Hashtable _otherParams = new Hashtable();

        public Hashtable OtherParams
        {
            get { return _otherParams; }
            set { _otherParams = value; }
        }

        // 重复添加处理 add by fengcj  09/11/19 PM
        public void addOtherParam(object key, object value)
        {
            if (!this.OtherParams.ContainsKey(key))
                this.OtherParams.Add(key, value);
            else
            {
                this.OtherParams[key] = value;
            }
        }

        public void removeOtherParam(object key)
        {
            this.OtherParams.Remove(key);
        }

        public object getOtherParam(object key)
        {
            return this.OtherParams[key];
        }
    }
}
