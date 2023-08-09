


using System.Globalization;

namespace CaseBasedSchedule.Api.Converters
{
    public class DateConverter
    {
        public static IDictionary<string, string> CovertDateToString(DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            IDictionary<string,string> list = new Dictionary<string, string>();
            if(startTime.TotalMinutes < endTime.TotalMinutes)
            {
                var startDatum = new DateTime(date.Year, date.Month, date.Day, startTime.Hours, startTime.Minutes, 0);
                var endDatum = new DateTime(date.Year, date.Month, date.Day, endTime.Hours, endTime.Minutes, 0);
                list.Add("startTime", startDatum.ToString());
                list.Add("endTime", endDatum.ToString());
            }
            else if(endTime.TotalMinutes < startTime.TotalMinutes)
            {
                var differenceInDays = startTime.Subtract(endTime).Days;
                var startDatum = new DateTime(date.Year, date.Month, date.Day, startTime.Hours, startTime.Minutes, 0);
                var endDatum = new DateTime(date.Year, date.Month, date.Day + differenceInDays, endTime.Hours, endTime.Minutes, 0);
                list.Add("startTime", startDatum.ToString());
                list.Add("endTime", endDatum.ToString());
            }
            return list;
        }

        public static DateTime ConvertStringToDate(string value)
        {
           
            DateTime date;
            if(DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out date)) 
            {
                return date;
            }
            throw new Exception("Unable to convert string date");
        }
    }
}
