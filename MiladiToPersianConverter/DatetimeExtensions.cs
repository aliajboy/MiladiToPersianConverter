using System.Globalization;

namespace MiladiToPersianConverter;

public static partial class DatetimeExtentions
{
    static DateTime EPOCH = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

    // Miladi To Persian Converters

    /// <summary>
    /// Converts .Net DateTime to Persian Calendar String
    /// </summary>
    /// <param name="MiladiDate"></param>
    /// <returns>Persian Date String With "14021013" Format</returns>
    public static string MiladiToPersian(this DateTime MiladiDate)
    {
        try
        {
            DateTime date = new(MiladiDate.Year, MiladiDate.Month, MiladiDate.Day);
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date).ToString("0000") + pc.GetMonth(date).ToString("00") + pc.GetDayOfMonth(date).ToString("00");
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// Converts .Net DateTime to Persian Calendar String with time Hours and Minutes
    /// </summary>
    /// <param name="MiladiDate">.Net Datetime datatype</param>
    /// <returns>Persian Date String With "140210132210" Format</returns>
    public static string MiladiToPersianWithMinutes(this DateTime MildaiDate)
    {
        try
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(MildaiDate).ToString("0000") +
                pc.GetMonth(MildaiDate).ToString("00") +
                pc.GetDayOfMonth(MildaiDate).ToString("00") +
                pc.GetHour(MildaiDate).ToString("00") +
                pc.GetMinute(MildaiDate).ToString("00");
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// Converts .Net DateTime to Persian Calendar String with time Hours, Minutes and Seconds
    /// </summary>
    /// <param name="datetime">.Net Datetime datatype</param>
    /// <returns>Persian Date String With "14021013221033" Format</returns>
    public static string MiladiToPersianWithSeconds(this DateTime datetime)
    {
        PersianCalendar pc = new PersianCalendar();
        return pc.GetYear(datetime).ToString() +
            pc.GetMonth(datetime).ToString("00") +
            pc.GetDayOfMonth(datetime).ToString("00") +
            pc.GetHour(datetime).ToString("00") +
            pc.GetMinute(datetime).ToString("00") +
            pc.GetSecond(datetime).ToString("00");
    }

    /// <summary>
    /// Converts Miladi Datetime to Persian and shows month name instead of number
    /// </summary>
    /// <param name="date"></param>
    /// <returns>Perisan Date String with format of : 22 esdand(in persian) 1377 </returns>
    public static string MiladiToPersianWithMonthName(this DateTime date)
    {
        var persianDate = MiladiToPersian(date);
        string day = persianDate.Substring(6, 2);
        string month = GetPersianMounth(Convert.ToInt32(persianDate.Substring(4, 2)));
        string year = persianDate.Substring(0, 4);
        return day + " " + month + " " + year;
    }

    /// <summary>
    /// Get The Day of the week in Persian String
    /// </summary>
    /// <param name="dayOfWeek"></param>
    /// <returns>Persian Day of the week From <c>DayOfWeek</c> DataType like : "یک شنبه"</returns>
    public static string GetPersianDayOfWeek(this DayOfWeek dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case DayOfWeek.Sunday:
                return "یک شنبه";
            case DayOfWeek.Monday:
                return "دو شنبه";
            case DayOfWeek.Tuesday:
                return "سه شنبه";
            case DayOfWeek.Wednesday:
                return "چهار شنبه";
            case DayOfWeek.Thursday:
                return "پنج شنبه";
            case DayOfWeek.Friday:
                return "جمعه";
            case DayOfWeek.Saturday:
                return "شنبه";
            default:
                return string.Empty;
        }
    }

    // Persian to Miladi Converters

    /// <summary>
    /// Converts Persian Date and Time String to Miladi DateTime.
    /// Input String Must be 12 Digits. For Example: 140209131423
    /// </summary>
    /// <param name="persianDate">persian datetime string with 12 digits "140209131423"</param>
    /// <returns>Miladi DateTime</returns>
    public static DateTime PersianToMiladiDateTime(this string persianDateTime)
    {
        try
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dateTime = new DateTime(Convert.ToInt32(persianDateTime.Substring(0, 4))
                                      , Convert.ToInt32(persianDateTime.Substring(4, 2))
                                      , Convert.ToInt32(persianDateTime.Substring(6, 2)), pc);
            TimeSpan ts = new TimeSpan(Convert.ToInt32(persianDateTime.Substring(8, 2)), Convert.ToInt32(persianDateTime.Substring(10, 2)), 0);
            dateTime = dateTime.Add(ts);
            return dateTime;
        }
        catch (Exception)
        {
            return DateTime.Now;
        }

    }

    /// <summary>
    /// Converts Persian Date String to Miladi DateTime.
    /// Input String Must be 8 Digits. For Example: 14020913
    /// </summary>
    /// <param name="persianDate"></param>
    /// <returns>Miladi DateTime</returns>
    public static DateTime PersianToMiladi(this string persianDate)
    {
        try
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(Convert.ToInt32(persianDate.Substring(0, 4))
                                      , Convert.ToInt32(persianDate.Substring(4, 2))
                                      , Convert.ToInt32(persianDate.Substring(6, 2)), pc);
            return dt;
        }
        catch (Exception)
        {

            return DateTime.Now;
        }

    }

    // Localization

    /// <summary>
    /// Set Datetime Sepereator for persian DatetimeString that has Hours and Minutes (Not Seconds)
    /// </summary>
    /// <param name="DateTime_">12 digit datetime string that has hours and minutes</param>
    /// <returns>a persian datetime string with this format : 1404/02/01 - 14:56</returns>
    public static string SetDateTimeSeprator(this string DateTime_)
    {
        if (DateTime_.Length < 12)
        {
            return DateTime_;
        }
        else
        {
            return DateTime_.Substring(8, 2) + ":" +
                   DateTime_.Substring(10, 2) + " - " +
                   DateTime_.Substring(0, 4) + "/" +
                   DateTime_.Substring(4, 2) + "/" +
                   DateTime_.Substring(6, 2);
        }
    }

    /// <summary>
    /// Set Datetime Sepereator for persian DatetimeString that has Hours and Minutes (Not Seconds)
    /// </summary>
    /// <param name="DateTime_">12 digit datetime string that has hours and minutes</param>
    /// <returns>a persian datetime string with this format : 1404-02-01 - 14:56</returns>
    public static string SetDateTimeSepratorDash(this string DateTime_)
    {
        if (DateTime_.Length < 12)
        {
            return DateTime_;
        }
        else
        {
            return DateTime_.Substring(8, 2) + ":" +
                   DateTime_.Substring(10, 2) + " - " +
                   DateTime_.Substring(0, 4) + "-" +
                   DateTime_.Substring(4, 2) + "-" +
                   DateTime_.Substring(6, 2);
        }
    }

    /// <summary>
    /// Set Slashes between persian datetime string that was made by MiladiToPersian() Method
    /// </summary>
    /// <param name="date">persian string like 14020902</param>
    /// <returns>put slashes between year, month and day like 1402/09/02</returns>
    public static string SetDateSlash(this string date)
    {
        string d = date;
        try
        {
            if (String.IsNullOrEmpty(date)) return "";

            if (date.Length == 6)
            {
                d = date.Substring(0, 2) + "/" +
                    date.Substring(2, 2) + "/" +
                    date.Substring(4, 2);
            }
            if (date.Length == 8)
            {
                d = date.Substring(0, 4) + "/" +
                    date.Substring(4, 2) + "/" +
                    date.Substring(6, 2);
            }
            if (date.Length != 8 && date.Length != 6)
            {
                if (date != null)
                    d = date;
                else
                    d = "";

            }
        }
        catch (Exception)
        {
            d = date;
        }
        return d;
    }

    /// <summary>
    /// Set Dashes between persian datetime string that was made by MiladiToPersian() Method
    /// </summary>
    /// <param name="date">persian string like 14020902</param>
    /// <returns>put Dashes between year, month and day like 1402-09-02</returns>
    public static string SetDateDash(this string date)
    {
        string d = date;
        try
        {
            if (string.IsNullOrEmpty(date)) return "";

            if (date.Length == 6)
            {
                d = date.Substring(0, 2) + "-" +
                    date.Substring(2, 2) + "-" +
                    date.Substring(4, 2);
            }
            if (date.Length == 8)
            {
                d = date.Substring(0, 4) + "-" +
                    date.Substring(4, 2) + "-" +
                    date.Substring(6, 2);
            }
            if (date.Length != 8 && date.Length != 6)
            {
                if (date != null)
                    d = date;
                else
                    d = "";

            }
        }
        catch (Exception)
        {
            d = date;
        }
        return d;
    }

    /// <summary>
    /// Set Time Seperator of ":" Between Times HH:mm:ss or HH:mm
    /// </summary>
    /// <param name="time">input time in string without space and just numbers in length of 4 or 6</param>
    /// <returns>HH:mm:ss or HH:mm based on input length</returns>
    public static string SetTimeSeparate(this string time)
    {
        string formattedTime = string.Empty;
        try
        {
            if (string.IsNullOrEmpty(time)) return string.Empty;

            if (time.Length == 6)
            {
                formattedTime = time.Substring(0, 2) + ":" + time.Substring(2, 2) + ":" + time.Substring(4, 2);
            }
            if (time.Length == 4)
            {
                formattedTime = time.Substring(0, 2) + ":" + time.Substring(2, 2);
            }
        }
        catch (Exception)
        {
            formattedTime = time;
        }

        return formattedTime;
    }

    // Utilities

    /// <summary>
    /// Convert DateTime To UnixTimeStamp
    /// </summary>
    /// <param name="date">DateTime</param>
    /// <param name="TimeZone">For example Tehran is +3:30 so TimeZone is 3.5</param>
    /// <returns>Unix TimeStamp</returns>
    public static double ToUnixTimeStamp(DateTime date, int TimeZone = 0)
    {
        TimeSpan newDate = (date - EPOCH);
        return Math.Floor(newDate.TotalSeconds) - (TimeZone * 3600);
    }

    /// <summary>
    /// Extension method for month number that gets number like 01 or 1 and converts it to string of فروردین
    /// </summary>
    /// <param name="MounthId">number of month in persian calendar</param>
    /// <returns>Persian Month name based on provided month number</returns>
    public static string GetPersianMounth(this int monthId)
    {
        switch (monthId)
        {
            case 1: return "فروردین";
            case 2: return "اردیبهشت";
            case 3: return "خرداد";
            case 4: return "تیر";
            case 5: return "مرداد";
            case 6: return "شهریور";
            case 7: return "مهر";
            case 8: return "آبان";
            case 9: return "آذر";
            case 10: return "دی";
            case 11: return "بهمن";
            case 12: return "اسفند";
            default: return string.Empty;
        }
    }
}