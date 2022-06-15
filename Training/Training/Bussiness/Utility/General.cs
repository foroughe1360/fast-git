using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Security.Cryptography;
using System.Web;
using System.IO;
using InterfaceEntity;

namespace Bussiness
{
    public class General
    {
        public enum CurrencyUnits
        {
            Rial, Toman
        }
        public DateTime ShamsiToMiladi(DateTime date)
        {
            System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();

            DateTime dt = x.ToDateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
            //DateTime dt = x.ToDateTime(1390, 4, 21, 0, 0, 0, 0, 0);

            return dt;
        }

        public string MiladiToShamsi(DateTime Value)
        {
            PersianCalendar pc = new PersianCalendar();

            string Year, Day, Month;
            Year = pc.GetYear(Value).ToString();
            Month = pc.GetMonth(Value).ToString();
            Day = pc.GetDayOfMonth(Value).ToString();
            if (Day.Length == 1)
            {
                Day = pc.GetDayOfMonth(Value).ToString().Insert(0, "0");
            }
            if (Month.Length == 1)
            {
                Month = pc.GetMonth(Value).ToString().Insert(0, "0");
            }
            string Date = Year + '/' + Month + '/' + Day;
            return Date;

        }

        public string shamsiYear(DateTime Value)
        {
            PersianCalendar pc = new PersianCalendar();
            string Date = Convert.ToString(pc.GetYear(Value));
            return Date;
        }

        public int checkMelliCode(string varmellicode)
        {
            char[] chArray = varmellicode.ToCharArray();
            int[] numArray = new int[chArray.Length];
            for (int i = 0; i < chArray.Length; i++)
            {
                numArray[i] = (int)char.GetNumericValue(chArray[i]);
            }
            int num2 = numArray[9];
            switch (varmellicode)
            {
                case "0000000000":
                case "1111111111":
                case "2222222222":
                case "3333333333":
                case "4444444444":
                case "5555555555":
                case "6666666666":
                case "7777777777":
                case "8888888888":
                case "9999999999":
                    return 1;//صحیح نمی باشد
            }
            int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
            int num4 = num3 - ((num3 / 11) * 11);
            if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
            {
                return 0;//صحیح می باشد
            }
            else
            {
                return 2;//نامعتبر است
            }
        }

        public String GetNumberOfText(String s)
        {
            string Temp = string.Empty;

            for (int index = 0; index < s.Length; index++)
            {
                if (Char.IsNumber(s[index]))
                {
                    Temp += s[index].ToString();
                }
            }
            return Temp;
        }

        public HeaderImage UploadImages(HttpPostedFileBase[] uploadImages)
        {
            if (uploadImages.Count() <= 1)
            {
                return null;
            }

            foreach (var image in uploadImages)
            {
                if (image.ContentLength > 0)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(image.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(image.ContentLength);
                    }
                    HeaderImage _HeaderImage = new HeaderImage(imageData, image.FileName, true);
                }
                else
                    return null;
            }
            return null;
        }
        public string GeneratePassword(int length) //length of salt   
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[length];
            var allowedCharCount = allowedChars.Length;
            for (var i = 0; i <= length - 1; i++)
            {
                chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public string EncodePassword(string pass, string salt) //encrypt password   
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            //return Convert.ToBase64String(inArray);   
            return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }
        public string EncodePasswordMd5(string pass) //Encrypt using MD5   
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)   
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string   
            return BitConverter.ToString(encodedBytes);
        }
        public string base64Encode(string sData) // Encode   
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public string base64Decode(string sData) //Decode   
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
        public string PersianDate(string format)
        {
            Persia.SolarDate solarDate = Persia.Calendar.ConvertToPersian(DateTime.Now);
            // getting the simple format of persian date
            return solarDate.ToString(format);

        }
        public DateTime ShamsiToMiladi(string DateStr)
        {
            PersianCalendar p = new PersianCalendar();
            string[] DigitArray = new string[3];
            DigitArray = DateStr.Split('/');
            return p.ToDateTime(int.Parse(DigitArray[0]), int.Parse(DigitArray[1]), int.Parse(DigitArray[2]), 0, 0, 0, 0);
        }
        public string MiladiChangeFormat(string DateStr)
        {
            PersianCalendar p = new PersianCalendar();
            string[] DigitArray = new string[3];
            DigitArray = DateStr.Split('/');
            //return (int.Parse(DigitArray[2])+ "/"+ int.Parse(DigitArray[0]) + "/" + int.Parse(DigitArray[1]));
            return (int.Parse(DigitArray[2]) + "/" + int.Parse(DigitArray[1]) + "/" + int.Parse(DigitArray[0]));
        }
        public string PersianDay(int day)
        {
            switch (day)
            {
                case 1: return "شنبه";
                case 2: return "یکشنبه";
                case 3: return "دوشنبه";
                case 4: return "سه شنیه";
                case 5: return "چهارشنبه";
                case 6: return "پنج شنبه";
                case 7: return "جمعه";
                default: return "";
            }
        }
        public string CurrentPersianDate()
        {
            PersianCalendar pc = new PersianCalendar();

            var Value = DateTime.Now;
            string Year, Day, Month;
            Year = pc.GetYear(Value).ToString();
            Month = pc.GetMonth(Value).ToString();
            Day = pc.GetDayOfMonth(Value).ToString();
            if (Day.Length == 1)
            {
                Day = pc.GetDayOfMonth(Value).ToString().Insert(0, "0");
            }
            if (Month.Length == 1)
            {
                Month = pc.GetMonth(Value).ToString().Insert(0, "0");
            }
            string Date = Year + '/' + Month + '/' + Day;
            return Date;
        }
        public string ToPartiallyAlphabetical(Int64 number, CurrencyUnits unit)
        {
            String thousand = " هزار";
            String million = " میلیون";
            String billion = " میلیارد";
            String separator = " و ";
            StringBuilder sb = new StringBuilder();

            if (unit == CurrencyUnits.Toman)
                number /= 10;
            Int64 temp1 = number / 1000000000;
            Int64 temp2 = number % 1000000000;
            if (temp1 > 0)
                sb.Append(temp1.ToString() + billion);
            temp1 = temp2 / 1000000;
            temp2 = temp2 % 1000000;
            if (temp1 > 0)
            {
                if (sb.Length > 0)
                    sb.Append(separator);
                sb.Append(temp1.ToString() + million);
            }
            temp1 = temp2 / 1000;
            temp2 = temp2 % 1000;
            if (temp1 > 0)
            {
                if (sb.Length > 0)
                    sb.Append(separator);
                sb.Append(temp1.ToString() + thousand);
            }

            if (temp2 > 0)
            {
                if (sb.Length > 0)
                    sb.Append(separator);
                sb.Append(temp2.ToString());
            }
            if (sb.Length > 0)
                if (unit == CurrencyUnits.Toman)
                    sb.Append(" تومان");
                else
                    sb.Append(" ریال");
            return sb.ToString();
        }
        public string ToFullyAlphabetical(Int64 number, CurrencyUnits unit)
        {
            String thousand = " هزار";
            String million = " میلیون";
            String billion = " میلیارد";
            String separator = " و ";
            StringBuilder sb = new StringBuilder();

            if (unit == CurrencyUnits.Toman)
                number /= 10;

            Int64 temp1 = number / 1000000000;
            Int64 temp2 = number % 1000000000;
            if (temp1 > 0)
                sb.Append(ToAlphabeticalBelow1000(temp1) + billion);
            temp1 = temp2 / 1000000;
            temp2 = temp2 % 1000000;
            if (temp1 > 0)
            {
                if (sb.Length > 0)
                    sb.Append(separator);
                sb.Append(ToAlphabeticalBelow1000(temp1) + million);
            }
            temp1 = temp2 / 1000;
            temp2 = temp2 % 1000;
            if (temp1 > 0)
            {
                if (sb.Length > 0)
                    sb.Append(separator);
                sb.Append(ToAlphabeticalBelow1000(temp1) + thousand);
            }

            if (temp2 > 0)
            {
                if (sb.Length > 0)
                    sb.Append(separator);
                sb.Append(ToAlphabeticalBelow1000(temp2));
            }
            if (sb.Length > 0)
                if (unit == CurrencyUnits.Toman)
                    sb.Append(" تومان");
                else
                    sb.Append(" ریال");
            return sb.ToString();
        }
        private string ToAlphabeticalBelow1000(Int64 number)
        {
            String[] zeroTo9 = new String[] { "صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" };
            String[] tenTo99 = new String[] { "", "ده", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
            String[] tenTo19 = new String[] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
            String[] hundredTo999 = new String[] { "", "صد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };
            String separator = " و ";

            StringBuilder sb = new StringBuilder();

            Int64 temp1 = number / 100;
            Int64 temp2 = number % 100;
            if (temp1 > 0)
                sb.Append(hundredTo999[temp1]);
            temp1 = temp2 / 10;
            temp2 = temp2 % 10;
            if (temp1 > 0)
            {
                if (temp1 != 1 || (temp1 == 1 && temp2 == 0))
                {
                    if (sb.Length > 0)
                        sb.Append(separator);
                    sb.Append(tenTo99[temp1]);
                }
                else if (temp1 == 1)
                {
                    if (sb.Length > 0)
                        sb.Append(separator);
                    sb.Append(tenTo19[temp2]);
                }
            }
            if (temp1 != 1 && temp2 > 0)
            {
                if (sb.Length > 0)
                    sb.Append(separator);
                sb.Append(zeroTo9[temp2]);
            }
            return sb.ToString();
        }

       
    }

    public static class UtilityMethod
    {
        public static string MiladiToPersion(this DateTime Value)
        {
            PersianCalendar pc = new PersianCalendar();

            string Year, Day, Month;
            Year = pc.GetYear(Value).ToString();
            Month = pc.GetMonth(Value).ToString();
            Day = pc.GetDayOfMonth(Value).ToString();
            if (Day.Length == 1)
            {
                Day = pc.GetDayOfMonth(Value).ToString().Insert(0, "0");
            }
            if (Month.Length == 1)
            {
                Month = pc.GetMonth(Value).ToString().Insert(0, "0");
            }
            string Date = Year + '/' + Month + '/' + Day;
            return Date;
        }
        public static string GetDayOfWeekName(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Saturday: return "شنبه";
                case DayOfWeek.Sunday: return "يکشنبه";
                case DayOfWeek.Monday: return "دوشنبه";
                case DayOfWeek.Tuesday: return "سه‏ شنبه";
                case DayOfWeek.Wednesday: return "چهارشنبه";
                case DayOfWeek.Thursday: return "پنجشنبه";
                case DayOfWeek.Friday: return "جمعه";
                default: return "";
            }
        }
        public static DateTime DefaultDateTime(this DateTime date)
        {
            return new DateTime(1753, 1, 1, 12, 0, 0);
        }
        public static string MiladiToPersionWithTime(this DateTime Value)
        {
            PersianCalendar pc = new PersianCalendar();

            string Year, Day, Month, Hour, Minute, Second;
            Year = pc.GetYear(Value).ToString();
            Month = pc.GetMonth(Value).ToString();
            Day = pc.GetDayOfMonth(Value).ToString();
            Hour = pc.GetHour(Value).ToString();
            Minute = pc.GetMinute(Value).ToString();
            Second = pc.GetSecond(Value).ToString();

            if (Day.Length == 1)
            {
                Day = pc.GetDayOfMonth(Value).ToString().Insert(0, "0");
            }
            if (Month.Length == 1)
            {
                Month = pc.GetMonth(Value).ToString().Insert(0, "0");
            }
            string Date = string.Format("{0}/{1}/{2}-{3}:{4}:{5}", Year, Month, Day, Hour, Minute, Second);
            return Date;
        }
        public static String MiladiChangeFormatEx(String DateStr)
        {
            PersianCalendar p = new PersianCalendar();
            string[] DigitArray = new string[3];
            DigitArray = DateStr.Split('/');
            //return (int.Parse(DigitArray[2])+ "/"+ int.Parse(DigitArray[0]) + "/" + int.Parse(DigitArray[1]));
            return (int.Parse(DigitArray[2]) + "/" + int.Parse(DigitArray[1]) + "/" + int.Parse(DigitArray[0]));
        }
    }
}

