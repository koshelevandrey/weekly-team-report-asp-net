using System;

namespace CM.WeeklyTeamReport.Domain
{
    public class WeeklyReport
    {
        public string DateStart;
        public string DateEnd;
        public string Year;
        public WeeklyStatus Morale;
        public WeeklyStatus Stress;
        public WeeklyStatus Workload;
        public string MoraleComment;
        public string StressComment;
        public string WorkloadComment;
        public string WeeklyHighText;
        public string WeeklyLowText;
        public string AnythingElseText;

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
