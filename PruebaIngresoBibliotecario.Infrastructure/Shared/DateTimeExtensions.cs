using System;

namespace PruebaIngresoBibliotecario.Infrastructure.Shared
{
    public static class DateTimeExtensions
    {
        public static DateTime AddBusinessDays(this DateTime date, int days)
        {
            for (var i = 0; i < Math.Abs(days); i++)
            {
                do
                {
                    date = date.AddDays(1);
                } while (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
            }

            return date;
        }
    }
}
