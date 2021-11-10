using System;

namespace CM.WeeklyTeamReport.Domain
{
    public class WeeklyReport
    {
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string Year { get; set; }
        public WeeklyStatus Morale { get; set; }
        public WeeklyStatus Stress { get; set; }
        public WeeklyStatus Workload { get; set; }
        public string MoraleComment { get; set; }
        public string StressComment { get; set; }
        public string WorkloadComment { get; set; }
        public string WeeklyHighText { get; set; }
        public string WeeklyLowText { get; set; }
        public string AnythingElseText { get; set; }

        public WeeklyReport(string dateStart, string dateEnd, string year, WeeklyStatus morale,
            WeeklyStatus stress, WeeklyStatus workload, string weeklyHighText,
            string weeklyLowText, string anythingElseText)
        {
            DateStart = dateStart;
            DateEnd = dateEnd;
            Year = year;
            Morale = morale;
            Stress = stress;
            Workload = workload;
            WeeklyHighText = weeklyHighText;
            WeeklyLowText = weeklyLowText;
            AnythingElseText = anythingElseText;
        }
    }
}
