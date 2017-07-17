using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRMforCustomer.Helper {
    public class Util {
        public static int CalculateCheckDigi(string txt) {
            /*
             * Add the odd number digits: 0+6+0+2+1+5 = 14.
             * Multiply the result by 3: 14 × 3 = 42.
             * Add the even number digits: 3+0+0+4+4 = 11.
             * Add the two results together: 42 + 11 = 53.
             * To calculate the check digit, take the remainder of (53 / 10), which is also known as (53 modulo 10), and if not 0, subtract from 10. Therefore, the check digit value is 7. i.e. (53 / 10) = 5 remainder 3; 10 - 3 = 7.
             */
            int[] digis = txt.ToCharArray().ToList().ConvertAll(c => Convert.ToInt32(c.ToString())).ToArray();
            int[] odds = digis.Where(w => w % 2 != 0).ToArray();
            int[] evens = digis.Where(w => w % 2 == 0).ToArray();
            int sumOdd = odds.Sum();
            int sumEvent = evens.Sum();
            int remain = ((sumOdd * 3) + sumEvent) % 10;
            int checkDigit = 10 - remain == 0 ? 10 : remain;
            return checkDigit;
        }

        public static bool IsValidOTP(string otp) {
            string code = otp.Substring(0, otp.Length - 1);
            int checkDigit = Convert.ToInt32(otp.Last().ToString());
            return checkDigit == CalculateCheckDigi(code);
        }
    }
}