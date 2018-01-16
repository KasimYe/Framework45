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
** file：WebRequestHttp
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 10:20:38
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.Common
{
    public class WebRequestHttp
    {
        static public string Get(string url, Encoding encoding,
            string accept= "text/html, application/xhtml+xml, */*",string contentType= "application/json")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = accept;// "text/html, application/xhtml+xml, */*";
            request.ContentType = contentType;//"application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                var result = reader.ReadToEnd();
                //JObject jObject = (JObject)JsonConvert.DeserializeObject(result);
                //StringBuilder str = new StringBuilder();
                //foreach (var obj in jObject)
                //{
                //    str.Append(string.Format("Key:{0}   Value:{1}\r\n", obj.Key, obj.Value));
                //    if (obj.Value is JObject)
                //    {
                //        foreach (var item in (JObject)obj.Value)
                //        {
                //            str.Append(string.Format("Key:{0}   Value:{1}\r\n", item.Key, item.Value));
                //        }
                //    }
                //}
                //var sb = str.ToString();
                //RequestModel requestModel = (RequestModel)JsonConvert.DeserializeObject(result, typeof(RequestModel));
                return result;
            }
        }

        static public string Post(string url, string body, Encoding encoding, 
            string accept = "text/html, application/xhtml+xml, */*", string contentType = "application/json")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = accept;// "text/html, application/xhtml+xml, */*";
            request.ContentType = contentType;// "application/json";

            byte[] buffer = encoding.GetBytes(body);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                var result = reader.ReadToEnd();
                //JObject jObject = (JObject)JsonConvert.DeserializeObject(result);
                //StringBuilder str = new StringBuilder();
                //foreach (var obj in jObject)
                //{
                //    str.Append(string.Format("Key:{0}   Value:{1}\r\n", obj.Key, obj.Value));
                //    if (obj.Value is JObject)
                //    {
                //        foreach (var item in (JObject)obj.Value)
                //        {
                //            str.Append(string.Format("Key:{0}   Value:{1}\r\n", item.Key, item.Value));
                //        }
                //    }
                //}
                //var sb = str.ToString();
                //RequestModel requestModel = (RequestModel)JsonConvert.DeserializeObject(result, typeof(RequestModel));
                return result;
            }
        }
    }
}
