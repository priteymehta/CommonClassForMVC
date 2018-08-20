using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Pritey.Framework.Common;
using System.Text.RegularExpressions;
using System.Globalization;

public static class ExtendedMethods
{
    public static bool ValidEmail(this string stremail)
    {
        return Regex.IsMatch(stremail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
    }

    public static string GetFormatedDate(this DateTime date)
    {
        return date.ToString("dd/MM/yyyy");
    }

    public static string GetFormatedTime(this DateTime date)
    {
        return date.ToString("hh:mm:ss tt");
    }

    public static string GetFormatedDateTime(this DateTime date)
    {
        return date.ToString("dd/MM/yyyy hh:mm:ss tt");
    }

    public static string GetFromatedAmount(this Decimal amt)
    {
        return amt.ToString("c");
    }

    public static bool ValidatePANCardNumber(this String str)
    {

        bool blnResult = false;
        var match = Regex.Match(str, @"[A-Z]{5}\d{4}[A-Z]{1}", RegexOptions.IgnoreCase);

        if (match.Success)
        {
            blnResult = true;
        }

        return blnResult;
    }

    public static bool ValidateUserName(this String str)
    {
        bool blnResult = false;
        var match = Regex.Match(str, @"^[a-zA-Z][a-zA-Z0-9]{3,9}$", RegexOptions.IgnoreCase);

        if (match.Success)
        {
            blnResult = true;
        }
        return blnResult;
    }

    public static bool ValidateDate(this String strDate, string dateFormat)
    {
        bool blnResult = false;
        if (Regex.IsMatch(strDate, "(((0|1)[0-9]|2[1-9]|3[0-1])\\/(0[1-9]|1[0-2])\\/((19|20)\\d\\d))$"))
        {
            DateTime dt;
            blnResult = DateTime.TryParseExact(strDate, dateFormat, new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
        }
        else {
            blnResult = false;
        }
        return blnResult;
    }

    public static string ListToCSVString<T>(this ICollection<T> lst, string seprater)
    {
        return string.Join(seprater, lst);
    }

    public static string GetSubString(this string strValue, int Length)
    {
        if (strValue.Length > Length)
        {
            return strValue.Substring(0, Length);
        }
        else {
            return strValue;
        }
    }

    public static string GetSubString(this Int64 strValue, int Length)
    {
        if (strValue.ToString().Length > Length)
        {
            return strValue.ToString().Substring(0, Length);
        }
        else {
            return strValue.ToString();
        }
    }

}
