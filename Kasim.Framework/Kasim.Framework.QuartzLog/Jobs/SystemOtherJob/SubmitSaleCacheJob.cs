/*
                 ___====-_  _-====___
           _--^^^#####//      \\#####^^^--_
        _-^##########// (    ) \\##########^-_
       -############//  |\^^/|  \\############-
     _/############//   (@::@)   \\############\_
    /#############((     \\//     ))#############\
   -###############\\    (oo)    //###############-
  -#################\\  / VV \  //#################-
 -###################\\/      \//###################-
_#/|##########/\######(   /\   )######/\##########|\#_
|/ |#/\#/\#/\/  \#/\##\  |  |  /##/\#/  \/\#/\#/\#| \|
`  |/  V  V  `   V  \#\| |  | |/#/  V   '  V  V  \|  '
   `   `  `      `   / | |  | | \   '      '  '   '
                    (  | |  | |  )
                   __\ | |  | | /__
                  (vvv(VVV)(VVV)vvv)                  

* Filename: SubmitSaleCacheJob
* Namespace: Kasim.Framework.QuartzLog.Jobs.SystemOtherJob
* Classname: SubmitSaleCacheJob
* Created: 2018-04-10 23:43:09
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Kasim.Framework.BLL.QuartzLog.SystemOther;
using Kasim.Framework.IBLL.QuartzLog.SystemOther;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.QuartzLog.Jobs.SystemOtherJob
{
    public class SubmitSaleCacheJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            ISubmitSaleCacheBLL bll = new SubmitSaleCacheBLL();
            bll.Submit();
        }
    }
}
