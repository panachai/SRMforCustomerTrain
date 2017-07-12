using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace SRMforCustomer.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[4];
            var intArray = new UInt32[10];
            for (int i = 0; i < 10; i++) {
                do {
                    provider.GetBytes(byteArray);
                    intArray[i] = BitConverter.ToUInt32(byteArray, 0);
                } while (intArray[i] < 1000000000); //ไว้เช็คไม่ให้ค่าแรกเป็น 0
            }

            //return Content(
            //    intArray[0] + " : " + intArray[1]
            //    + " : " + intArray[2] + " : " + intArray[3]
            //    + " : " + intArray[4] + " : " + intArray[5]
            //    + " : " + intArray[6] + " : " + intArray[7]
            //    + " : " + intArray[8] + " : " + intArray[9]
            //    );
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            //อาจจะไม่ทำ
            return View();
        }



    }
}