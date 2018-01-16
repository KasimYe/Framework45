using Kasim.Framework.BLL.QuartzLog;
using Kasim.Framework.BLL.QuartzLog.CompanyInterface;
using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.IBLL.QuartzLog;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Topshelf;

namespace Kasim.Framework.QuartzLog
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>        
        static void Main(string[] args)
        { 
            FlashLogger.Instance().Register();
            HostFactory.Run(x =>
            {
                x.UseLog4Net();
                x.Service<ServiceRunner>();
                x.SetDescription("浙江省药械采购中心基础数据下载更新同步,上传下载各类单据.");
                x.SetDisplayName("药械采购平台数据定时更新同步服务");
                x.SetServiceName("ZjyxcgServiceQuartz");
                x.EnablePauseAndContinue();
            });

            //Test();
        }

        private static void Test()
        {
            string userCommand = "";
            while (userCommand != "exit")
            {

                IConnectionBLL connectionBll = new ConnectionBLL();
                var baseEntity = connectionBll.TestConnection();
                FlashLogger.Error("药械平台接口连接测试");
                WriteLine(baseEntity.ResultJson);

                IAccessTokeBLL accessTokeBll = new AccessTokeBLL();
                var accessTokenEntity = accessTokeBll.GetAccessTokenEntity();
                if (accessTokenEntity == null || string.IsNullOrEmpty(accessTokenEntity.AccessToken))
                {
                    FlashLogger.Error("有效令牌凭据不存在，重新获取令牌");
                    accessTokenEntity = accessTokeBll.GetToken();
                    accessTokeBll.SaveToken(accessTokenEntity);
                }
                else
                {
                    FlashLogger.Error("从数据库成功获取有效令牌凭据");
                }
                WriteLine(accessTokenEntity.ResultJson);
                //WriteLine(string.Format("过期时间：{0}",
                //    ((DateTime)accessTokenEntity.CurrentTime).AddSeconds((double)accessTokenEntity.ExpiresIn).ToString("yyyy-MM-dd HH:mm")));

                IProcurecatalogBLL procurecatalogBll = new ProcurecatalogBLL();
                var procurecatalogIdList = new List<object>
            {
                new { procurecatalogId = 1 },
                new { procurecatalogId = 2 },
                new { procurecatalogId = 3 }
            };
                var procurecatalogIds = JsonConvert.SerializeObject(new { list = procurecatalogIdList });
                List<Entity.QuartzLog.Procurecatalog> procurecatalogList = null;
                DateTime dateTimeM = DateTime.Now;
                FlashLogger.Error("下载商品信息");
                while (dateTimeM > Convert.ToDateTime("2017-09-01"))
                {
                    var listEntity = procurecatalogBll.GetProcurecatalogs("", dateTimeM.ToString("yyyy-MM"), "1");
                    procurecatalogList = listEntity.DataList;
                    if (procurecatalogList != null && procurecatalogList.Count > 0)
                    {
                        for (int i = 1; i <= listEntity.TotalPageCount; i++)
                        {
                            //procurecatalogBll.AddProcurecatalogs(procurecatalogList);
                            FlashLogger.Fatal(string.Format("{0} : 第{1}页/共{2}页 成功下载 {3} 条商品信息.", dateTimeM.ToString("yyyy-MM"),
                                i, listEntity.TotalPageCount, procurecatalogList.Count));
                            procurecatalogList = procurecatalogBll.GetProcurecatalogs("", dateTimeM.ToString("yyyy-MM"), (i + 1).ToString()).DataList;
                        }
                    }
                    dateTimeM = dateTimeM.AddMonths(-1);
                }
                Console.WriteLine("请输入您的指令");
                userCommand = Console.ReadLine();
            }
            Console.ReadKey();
        }

        private static void WriteLine(string v)
        {
            //Console.WriteLine(v);
        }

    }
}
