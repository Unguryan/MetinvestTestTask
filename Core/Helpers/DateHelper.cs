using System;

namespace Core.Helpers
{
    public static class DateHelper
    {
        public static bool ValidateDates(DateTime startDate, DateTime endDate)
        {
            return startDate.DayOfWeek == DayOfWeek.Monday &&
                   endDate.DayOfWeek == DayOfWeek.Friday &&
                   startDate < endDate;
        }
    }
}
