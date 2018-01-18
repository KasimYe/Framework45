using System;
using System.Collections.Generic;
using Kasim.Framework.Common;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Kasim.Framework.UnitTest
{
    [TestClass]
    public class QuartzLogUnitTest
    {
        [TestMethod]
        public void HospitalCheckExist()
        {
            FlashLogger.Instance().Register();
            IHospitalBLL hospitalBll = new HospitalBLL();
            var hospitalIdList = new List<object>
            {
                new { hospitalId = "12319" },
                new { hospitalId = "2" },
                new { hospitalId = "10679" }
            };
            var hospitalIds = JsonConvert.SerializeObject(new { list = hospitalIdList });
            var checkList = hospitalBll.CheckExist(hospitalIds);
        }

        [TestMethod]
        public void ProcurecatalogCheckExist()
        {
            FlashLogger.Instance().Register();
            IProcurecatalogBLL procurecatalogBll = new ProcurecatalogBLL();
            var procurecatalogIdList = new List<object>
            {
                new { procurecatalogId = 12319 },
                new { procurecatalogId = 2 },
                new { procurecatalogId = 10679 }
            };
            var procurecatalogIds = JsonConvert.SerializeObject(new { list = procurecatalogIdList });
            var checkList = procurecatalogBll.CheckExist(procurecatalogIds);
        }
        [TestMethod]
        public void EncryptTest()
        {
            FlashLogger.Instance().Register();
            string orgUserName = "zjyp_j0049";
            string secret = "111111";
            string key = "yss.yh";
            var uname = MySecurity.SEncryptString(orgUserName, key);
            var psd = MySecurity.SEncryptString(secret, key);
            FlashLogger.Info(string.Format("\r\nOrgUserName:\r\n{0}\r\nSecret:\r\n{1}\r\n", uname, psd));

        }
    }
}
