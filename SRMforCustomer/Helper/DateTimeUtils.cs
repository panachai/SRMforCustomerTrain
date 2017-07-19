using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SRMforCustomer.Helper {
    public class DateTimeUtils {
        public static readonly CultureInfo CULTUREINFO = CultureInfo.CreateSpecificCulture("en-US");


        public static string DateFormat(DateTime dt) {
            return dt.ToString("dd/MM/yyyy", CULTUREINFO);
        }

        public static string TimeFormat(DateTime dt) {
            return string.Format(dt.ToString("HH:mm", CULTUREINFO));
        }

        public static string DateTimeFormat(DateTime dt) {
            return dt.ToString("dd/MM/yyyy HH:mm", CULTUREINFO);
        }
        public static string FullDateFormat(DateTime dt) {
            return dt.ToString("ddd MMMM yyyy", CULTUREINFO);
        }
        public static string DateTimeGeneralFormat(DateTime dt) {
            return dt.ToString("yyyy-MM-dd HH:mm", CULTUREINFO);
        }
        public static Double ConvertDateTimeToMiliSecond(DateTime dt) {
            return dt.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            ).TotalMilliseconds;


        }
    }
}