using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateExpressions.Generated;
using DateExpressions.Generated.Dates;
using FluentAssertions;
using Xunit;

namespace DateExpressions.Test
{
    public class DateExpressionTests
    {
        [Fact]
        public void can_get_every_day()
        {
            Assert
                .Expression("every day")
                .From("1991-01-01")
                .To("1991-01-03")
                .ShouldGive("1991-01-01", "1991-01-02", "1991-01-03");
        }

        [Fact]
        public void can_get_1st_day()
        {
            Assert
                .Expressions(
                    "1st day",
                    "1st")
                .From("1991-02-02")
                .To("1991-04-30")
                .ShouldGive("1991-02-02");
        }
        
        [Fact]
        public void can_get_last_day()
        {
            Assert
                .Expression("last day")
                .From("1991-02-01")
                .To("1991-04-15")
                .ShouldGive("1991-04-15");
        }

        [Fact]
        public void can_get_1st_monday()
        {
            Assert
                .Expressions(
                    "1st monday",
                    "first monday",
                    "monday")
                .From("2019-02-10")
                .To("2020-02-27")
                .ShouldGive("2019-02-11");
        }

        [Fact] public void can_get_2nd_monday()
        {
            Assert
                .Expression("2nd monday")
                .From("2019-02-10")
                .To("2019-02-27")
                .ShouldGive("2019-02-18");
        }

        [Fact]
        public void can_get_last_monday()
        {
            Assert
                .Expression("last monday")
                .From("2019-02-10")
                .To("2019-02-27")
                .ShouldGive("2019-02-25");
        }

        [Fact]
        public void can_get_1st_monday_of_2nd_month()
        {
            Assert
                .Expression("1st monday of 2nd month")
                .From("2019-02-10")
                .To("2019-04-27")
                .ShouldGive("2019-03-04");
        }

        [Fact]
        public void can_get_1st_monday_of_2nd_month_of_3rd_year()
        {
            Assert
                .Expression("1st monday of 2nd month of 3rd year")
                .From("2019-02-10")
                .To("2023-04-27")
                .ShouldGive("2021-02-01");
        }

        [Fact]
        public void can_get_every_monday()
        {
            Assert
                .Expressions("every monday")
                .From("2019-03-01")
                .To("2019-03-31")
                .ShouldGive(
                    "2019-03-04",
                    "2019-03-11",
                    "2019-03-18",
                    "2019-03-25"
                    );
        }

        [Fact]
        public void can_get_monday_tuesday_and_saturday()
        {
            Assert
                .Expressions(
                    "monday, tuesday and saturday")
                .From("2019-03-01")
                .To("2019-03-17")
                .ShouldGive(
                    "2019-03-02",
                    "2019-03-04",
                    "2019-03-05"
                );
        }

        [Fact]
        public void can_get_every_monday_tuesday_and_saturday()
        {
            Assert
                .Expressions(
                    "every monday, every tuesday and every saturday",
                    "every monday, tuesday and saturday")
                .From("2019-03-01")
                .To("2019-03-17")
                .ShouldGive(
                    "2019-03-02",
                    "2019-03-04", 
                    "2019-03-05", 
                    "2019-03-09",
                    "2019-03-11",
                    "2019-03-12",
                    "2019-03-16"
                    );
        }

        [Fact]
        public void can_get_first_day_of_every_month()
        {
            Assert
                .Expressions(
                    "first day of every month",
                    "first of every month",
                    "1st of every month")
                .From("2019-02-01")
                .To("2019-05-15")
                .ShouldGive(
                    "2019-02-01",
                    "2019-03-01",
                    "2019-04-01",
                    "2019-05-01"
                    );
        }

        [Fact]
        public void can_get_last_day_of_every_month()
        {
            Assert
                .Expressions(
                    "last day of every month",
                    "last of every month")
                .From("2019-02-01")
                .To("2019-05-15")
                .ShouldGive(
                    "2019-02-28",
                    "2019-03-31",
                    "2019-04-30"
                    );
        }

        [Fact]
        public void can_get_first_tuesday_thursday_and_sunday_of_every_month()
        {
            Assert
                .Expressions(
                    "first tuesday, thursday and sunday of every month")
                .From("2019-02-01")
                .To("2019-05-15")
                .ShouldGive(
                    "2019-02-03",
                    "2019-02-05",
                    "2019-02-07",
                    "2019-03-03",
                    "2019-03-05",
                    "2019-03-07",
                    "2019-04-02",
                    "2019-04-04",
                    "2019-04-07",
                    "2019-05-02",
                    "2019-05-05",
                    "2019-05-07"
                    );
        }

        [Fact]
        public void can_get_first_tuesday_thursday_and_sunday()
        {
            Assert
                .Expressions(
                    "first tuesday, thursday and sunday")
                .From("2019-02-01")
                .To("2019-05-15")
                .ShouldGive(
                    "2019-02-03",
                    "2019-02-05",
                    "2019-02-07"
                );
        }

        [Fact]
        public void can_get_last_tuesday_thursday_and_sunday_of_every_month()
        {
            Assert
                .Expression("last tuesday, thursday and sunday of every month")
                .From("2019-02-01")
                .To("2019-05-15")
                .ShouldGive(
                    "2019-02-24",
                    "2019-02-26",
                    "2019-02-28",
                    "2019-03-26",
                    "2019-03-28",
                    "2019-03-31",
                    "2019-04-25",
                    "2019-04-28",
                    "2019-04-30"
                    );
        }

        [Fact]
        public void can_get_last_tuesday_thursday_and_sunday()
        {
            Assert
                .Expression("last tuesday, thursday and sunday")
                .From("2019-02-01")
                .To("2019-05-15")
                .ShouldGive(
                    "2019-05-09",
                    "2019-05-12",
                    "2019-05-14"
                );
        }

        [Fact]
        public void can_get_first_and_last_monday_and_tuesday_of_every_month()
        {
            Assert
                .Expression("first and last monday and tuesday of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-04",
                    "2019-02-05",
                    "2019-02-25",
                    "2019-02-26",
                    "2019-03-04",
                    "2019-03-05",
                    "2019-03-25",
                    "2019-03-26",
                    "2019-04-01",
                    "2019-04-02"
                );
        }

        [Fact]
        public void can_get_first_monday_and_first_tuesday_of_every_month()
        {
            Assert
                .Expression("first monday and first tuesday of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-04",
                    "2019-02-05",
                    "2019-03-04",
                    "2019-03-05",
                    "2019-04-01",
                    "2019-04-02"
                );
        }

        [Fact]
        public void can_get_first_monday_and_last_tuesday_of_every_month()
        {
            Assert
                .Expression("first monday and last tuesday of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-04",
                    "2019-02-26",
                    "2019-03-04",
                    "2019-03-26",
                    "2019-04-01"
                );
        }

        [Fact]
        public void can_get_first_monday_and_every_tuesday_of_every_month()
        {
            Assert
                .Expression("first monday and every tuesday of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-04",
                    "2019-02-05",
                    "2019-02-12",
                    "2019-02-19",
                    "2019-02-26",
                    "2019-03-04",
                    "2019-03-05",
                    "2019-03-12",
                    "2019-03-19",
                    "2019-03-26",
                    "2019-04-01",
                    "2019-04-02",
                    "2019-04-09"
                );
        }

        [Fact]
        public void can_get_first_monday_and_wednesday_and_last_tuesday_and_sunday_of_every_month()
        {
            Assert
                .Expression("first monday and wednesday and last tuesday and sunday of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-04",
                    "2019-02-06",
                    "2019-02-24",
                    "2019-02-26",
                    "2019-03-04",
                    "2019-03-06",
                    "2019-03-26",
                    "2019-03-31",
                    "2019-04-01",
                    "2019-04-03"
                );
        }

        [Fact]
        public void can_get_13th_day_of_every_month()
        {
            Assert
                .Expression("13th day of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-13",
                    "2019-03-13",
                    "2019-04-13"
                );
        }

        [Fact]
        public void can_get_2nd_monday_and_3rd_tuesday_of_every_month()
        {
            Assert
                .Expression("2nd monday and 3rd tuesday of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-11",
                    "2019-02-19",
                    "2019-03-11",
                    "2019-03-19",
                    "2019-04-08"
                );
        }

        [Fact]
        public void can_get_1st_day_of_2nd_week_of_every_month()
        {
            Assert
                .Expression("1st day of 2nd week of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-04",
                    "2019-03-04",
                    "2019-04-08"
                );
        }

        [Fact]
        public void can_get_1st_day_of_2nd_and_3rd_week_of_every_month()
        {
            Assert
                .Expression("1st day of 2nd and 3rd week of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-04",
                    "2019-02-11",
                    "2019-03-04",
                    "2019-03-11",
                    "2019-04-08",
                    "2019-04-15"
                );
        }

        [Fact]
        public void can_get_every_day_of_1st_week_of_every_month()
        {
            Assert
                .Expression("every day of 1st week of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-01",
                    "2019-02-02",
                    "2019-02-03",
                    "2019-02-25",
                    "2019-02-26",
                    "2019-02-27",
                    "2019-02-28",
                    "2019-03-01",
                    "2019-03-02",
                    "2019-03-03",
                    "2019-04-01",
                    "2019-04-02",
                    "2019-04-03",
                    "2019-04-04",
                    "2019-04-05",
                    "2019-04-06",
                    "2019-04-07"
                );
        }

        [Fact]
        public void can_get_every_day_from_5th_to_8th_of_every_month()
        {
            Assert
                .Expression("from 5th to 8th of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-05",
                    "2019-02-06",
                    "2019-02-07",
                    "2019-02-08",
                    "2019-03-05",
                    "2019-03-06",
                    "2019-03-07",
                    "2019-03-08",
                    "2019-04-05",
                    "2019-04-06",
                    "2019-04-07",
                    "2019-04-08"
                );
        }

        [Fact]
        public void can_get_every_monday_and_from_5th_to_8th_and_20th_of_every_month()
        {
            Assert
                .Expression("every monday and every day from 5th to 8th and 20th day of every month")
                .From("2019-02-01")
                .To("2019-04-15")
                .ShouldGive(
                    "2019-02-04",
                    "2019-02-05",
                    "2019-02-06",
                    "2019-02-07",
                    "2019-02-08",
                    "2019-02-11",
                    "2019-02-18",
                    "2019-02-20",
                    "2019-02-25",
                    "2019-03-04",
                    "2019-03-05",
                    "2019-03-06",
                    "2019-03-07",
                    "2019-03-08",
                    "2019-03-11",
                    "2019-03-18",
                    "2019-03-20",
                    "2019-03-25",
                    "2019-04-01",
                    "2019-04-05",
                    "2019-04-06",
                    "2019-04-07",
                    "2019-04-08",
                    "2019-04-15"
                );
        }

        [Fact]
        public void can_get_friday_the_13th()
        {
            Assert
                .Expression("friday the 13th of every month")
                .From("2019-01-01")
                .To("2019-12-31")
                .ShouldGive(
                    "2019-09-13",
                    "2019-12-13"
                );
        }

        [Fact]
        public void can_get_1st_of_2nd_and_3rd_month()
        {
            Assert
                .Expression("1st of 2nd and 3rd month")
                .From("2019-02-01")
                .To("2020-05-15")
                .ShouldGive(
                    "2019-03-01",
                    "2019-04-01"
                );
        }

        [Fact]
        public void can_get_1st_of_2nd_and_3rd_month_of_every_year()
        {
            Assert
                .Expression("1st of 2nd and 3rd month of every year")
                .From("2019-02-01")
                .To("2020-05-15")
                .ShouldGive(
                    "2019-02-01",
                    "2019-03-01",
                    "2020-02-01",
                    "2020-03-01"
                );
        }

        [Fact]
        public void can_get_1st_of_february_and_march()
        {
            Assert
                .Expression("1st of february and march")
                .From("2019-02-01")
                .To("2020-05-15")
                .ShouldGive(
                    "2019-02-01",
                    "2019-03-01"
                );
        }

        [Fact]
        public void can_get_1st_of_february_and_march_of_every_year()
        {
            Assert
                .Expression("1st of february and march of every year")
                .From("2019-02-01")
                .To("2020-05-15")
                .ShouldGive(
                    "2019-02-01",
                    "2019-03-01",
                    "2020-02-01",
                    "2020-03-01"
                );
        }

        [Fact]
        public void can_get_1st_day_of_months_from_february_to_may_and_december()
        {
            Assert
                .Expression("1st day of every month from february to may and december")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-02-01",
                    "2019-03-01",
                    "2019-04-01",
                    "2019-05-01",
                    "2019-12-01"
                );
        }

        [Fact]
        public void can_get_1st_day_of_months_from_february_to_may_and_december_of_every_year()
        {
            Assert
                .Expression("1st day of every month from february to may and december of every year")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-02-01",
                    "2019-03-01",
                    "2019-04-01",
                    "2019-05-01",
                    "2019-12-01",
                    "2020-02-01",
                    "2020-03-01",
                    "2020-04-01",
                    "2020-05-01",
                    "2020-12-01"
                );
        }

        [Fact]
        public void can_get_1st_day_of_2016_and_2017_year()
        {
            Assert
                .Expression("1st day of 2016 and 2017")
                .From("2016-01-01")
                .To("2019-12-31")
                .ShouldGive(
                    "2016-01-01",
                    "2017-01-01"
                );
        }

        [Fact]
        public void can_get_first_and_last_monday_of_2016_and_2017_year()
        {
            Assert
                .Expression("first and last monday of 2019 and 2020")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-01-07",
                    "2019-12-30",
                    "2020-01-06",
                    "2020-12-28"
                );
        }

        [Fact]
        public void can_get_first_and_last_monday_of_april_and_june_of_every_year_from_2019_to_2020()
        {
            Assert
                .Expression("first and last monday " +
                            "of april and june " +
                            "of every year from 2019 to 2020")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-04-01",
                    "2019-04-29",
                    "2019-06-03",
                    "2019-06-24",
                    "2020-04-06",
                    "2020-04-27",
                    "2020-06-01",
                    "2020-06-29"
                );
        }

        [Fact]
        public void can_get_first_day_of_every_year_from_2019_to_2021_and_2023()
        {
            Assert
                .Expression("1st day of every year from 2019 to 2021 and 2023")
                .From("2019-01-01")
                .To("2023-12-31")
                .ShouldGive(
                    "2019-01-01",
                    "2020-01-01",
                    "2021-01-01",
                    "2023-01-01"
                );
        }


        [Fact]
        public void can_get_1st_of_april_and_2nd_of_may()
        {
            Assert
                .Expression("1st of april and 2nd of may")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-04-01",
                    "2019-05-02"             
                   );
        }

        [Fact]
        public void can_get_1st_of_april_and_2nd_of_may_of_every_year()
        {
            Assert
                .Expression("1st of april and 2nd of may of every year")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-04-01",
                    "2019-05-02",
                    "2020-04-01",
                    "2020-05-02"
                );
        }

        [Fact]
        public void can_get_1st_of_april_and_2nd_of_may_of_2019()
        {
            Assert
                .Expression("1st of april and 2nd of may of 2019")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-04-01",
                    "2019-05-02"
                );
        }

        [Fact]
        public void can_get_1st_day_of_2019_and_2nd_day_of_2020()
        {
            Assert
                .Expression("1st day of 2019 and 2nd day of 2020")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-01-01",
                    "2020-01-02"
                );
        }

        [Fact]
        public void can_get_1st_day_of_2019_and_last_day_of_every_month_of_2020_and_every_friday_the_13th()
        {
            Assert
                .Expression("1st day of 2019, " +
                            "last day of every month of 2020 " +
                            "and every friday the 13th")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-01-01",
                    "2019-09-13",
                    "2019-12-13",
                    "2020-01-31",
                    "2020-02-29",
                    "2020-03-13",
                    "2020-03-31",
                    "2020-04-30",
                    "2020-05-31",
                    "2020-06-30",
                    "2020-07-31",
                    "2020-08-31",
                    "2020-09-30",
                    "2020-10-31",
                    "2020-11-13",
                    "2020-11-30",
                    "2020-12-31"
                );
        }

        [Fact]
        public void can_get_every_day_from_28th_of_january_to_3rd_of_february()
        {
            Assert
                .Expression("from 30th of january to 2nd of february")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-01-30",
                    "2019-01-31",
                    "2019-02-01",
                    "2019-02-02"
                );
        }

        [Fact]
        public void can_get_every_day_from_28th_of_january_to_3rd_of_february_of_every_year()
        {
            Assert
                .Expression("from 30th of january to 2nd of february of every year")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-01-30",
                    "2019-01-31",
                    "2019-02-01",
                    "2019-02-02",
                    "2020-01-30",
                    "2020-01-31",
                    "2020-02-01",
                    "2020-02-02"
                );
        }

        [Fact]
        public void can_get_every_day_from_28th_of_january_to_3rd_of_february_and_1st_of_june()
        {
            Assert
                .Expression("from 30th of january to 2nd of february and 1st of june")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-01-30",
                    "2019-01-31",
                    "2019-02-01",
                    "2019-02-02",
                    "2019-06-01"
                );
        }

        [Fact]
        public void can_get_every_day_from_last_thursday_of_january_to_first_friday_of_february()
        {
            Assert
                .Expression("from last thursday of january to first friday of february")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-01-31",
                    "2019-02-01"
                );
        }

        [Fact]
        public void can_get_every_day_from_last_thursday_of_january_to_3rd_of_february()
        {
            Assert
                .Expression("from last thursday of january to 3rd of february")
                .From("2019-01-01")
                .To("2020-12-31")
                .ShouldGive(
                    "2019-01-31",
                    "2019-02-01",
                    "2019-02-02",
                    "2019-02-03"
                );
        }
    }
}

