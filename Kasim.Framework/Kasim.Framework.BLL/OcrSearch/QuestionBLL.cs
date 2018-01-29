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
** file：QuestionBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-29 11:07:56
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using Kasim.Framework.Entity.OcrSearch;
using Kasim.Framework.IBLL.OcrSearch;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Kasim.Framework.BLL.OcrSearch
{
    public class QuestionBLL : IQuestionBLL
    {
        public QuestionModel GetQuestion(JObject json)
        {
            if (json != null && !string.IsNullOrEmpty(Convert.ToString(json["words_result_num"])))
            {

                int num = Convert.ToInt32(json["words_result_num"]);
                QuestionModel question = null;
                JArray ja = (JArray)json["words_result"];
                var jaC = ja.Count;
                if (num > 3)
                {
                    question = new QuestionModel
                    {
                        Answer3 = ja[jaC - 1]["words"].ToString(),
                        Answer2 = ja[jaC - 2]["words"].ToString(),
                        Answer1 = ja[jaC - 3]["words"].ToString(),
                    };
                    var strQ = "";
                    for (int i = 0; i < jaC - 3; i++)
                    {
                        strQ += ja[i]["words"].ToString();
                    }
                    question.Question = strQ;
                }
                return question;
            }
            else
            {
                return null;
            }
        }

        protected string uri = "https://www.baidu.com/s?wd=";
        protected Encoding queryEncoding = Encoding.GetEncoding("gb2312");
        protected Encoding pageEncoding = Encoding.GetEncoding("gb2312");
        protected string resultPattern = @"(?<=找到相关结果[约]?)[0-9,]*?(?=个)";
        public int GetSearchCount(string search)
        {
            var url = uri + search;
            var html = this.search(url, "UTF-8");

            string searchcount = string.Empty;
            Regex regex = new Regex(resultPattern);
            Match match = regex.Match(html);

            if (match.Success)
            {
                searchcount = match.Value;
            }
            else
            {
                searchcount = "0";
            }

            if (searchcount.IndexOf(",") > 0)
            {
                searchcount = searchcount.Replace(",", string.Empty);
            }

            int.TryParse(searchcount, out int result);

            return result;

        }

        /// <summary>
        /// 搜索处理
        /// </summary>
        /// <param name="url">搜索网址</param>
        /// <param name="Chareset">编码</param>
        private string search(string url, string Chareset)
        {
            HttpState result = new HttpState();
            Uri uri = new Uri(url);
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.UseDefaultCredentials = true;
            myHttpWebRequest.ContentType = "text/html";
            myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.0; .NET CLR 1.1.4322; .NET CLR 2.0.50215;)";
            myHttpWebRequest.Method = "GET";
            myHttpWebRequest.CookieContainer = new CookieContainer();

            try
            {
                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                // 从 ResponseStream 中读取HTML源码并格式化 add by cqp
                result.Html = readResponseStream(response, Chareset);
                result.CookieContainer = myHttpWebRequest.CookieContainer;
                return result.Html;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
        private string readResponseStream(HttpWebResponse response, string Chareset)
        {
            string result = "";
            using (StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(Chareset)))
            {
                result = formatHTML(responseReader.ReadToEnd());
            }

            return result;
        }
        /// <summary>
        /// 描述:格式化网页源码
        /// 
        /// </summary>
        /// <param name="htmlContent"></param>
        /// <returns></returns>
        private string formatHTML(string htmlContent)
        {
            string result = "";

            result = htmlContent.Replace("&raquo;", "").Replace("&nbsp;", "")
                    .Replace("&copy;", "").Replace("/r", "").Replace("/t", "")
                    .Replace("/n", "").Replace("&amp;", "&");
            return result;
        }
    }
}
