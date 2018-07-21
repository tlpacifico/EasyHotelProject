using System;

namespace api.book.Util
{
    public class ParseString
    {
        public static DateTime ParseStringToDateTime(string dateTime)
        {
            var day = ExtractIntFromStringAndConvertToInt(dateTime, 0, 2);
            var month = ExtractIntFromStringAndConvertToInt(dateTime, 2, 2);
            var year = Convert.ToInt16(string.Concat(dateTime.Substring(4, 2), dateTime.Substring(6, 2)));

            var hour = ExtractIntFromStringAndConvertToInt(dateTime, 8, 2);
            var minutes = ExtractIntFromStringAndConvertToInt(dateTime, 10, 2);

            return new DateTime(year, month, day, hour, minutes, 0);

        }

        public static int ExtractIntFromStringAndConvertToInt(string sourceString, int start, int end)
        {
            return Convert.ToInt16(sourceString.Substring(start, end));
        }
    }
}