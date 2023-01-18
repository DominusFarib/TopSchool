
namespace TopSchool.Domain.Helpers;

    public static class DateTimeExtension
    {
        public static int TotalYears(this DateTime initDate)
        {
		int age = 0;
		DateTime zeroTime = new DateTime(1, 1, 1);
		var curDate = DateTime.UtcNow;

		if (curDate.Year > initDate.Year)
		{
			var timeSpan = curDate - initDate;
			age = (zeroTime + timeSpan).Year - 1;
		}

		return age;
	}

	public static int TotalMonths(this DateTime initDate)
	{
		int age = 0;

		var curDate = DateTime.UtcNow;	

		if (curDate.Year > initDate.Year)
		{
			age = TotalYears(initDate) * 12;
			age = age + (12 - initDate.Month);
			age = age + curDate.Month;

			if (curDate.Day < initDate.Day)
			{
				age--;
			}
		}
		else if (curDate.Year == initDate.Year && curDate.Month > initDate.Month)
		{
			age = curDate.Month - initDate.Month;

			if (curDate.Day < initDate.Day)
			{
				age--;
			}
		}

		return age;
	}

}
