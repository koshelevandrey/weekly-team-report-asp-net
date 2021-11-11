using System;

namespace CM.WeeklyTeamReport.Domain
{
    public class WeeklyReport
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public WeeklyStatus Morale { get; set; }
        public WeeklyStatus Stress { get; set; }
        public WeeklyStatus Workload { get; set; }
        public string MoraleComment { get; set; }
        public string StressComment { get; set; }
        public string WorkloadComment { get; set; }
        public string WeeklyHighText { get; set; }
        public string WeeklyLowText { get; set; }
        public string AnythingElseText { get; set; }

        public WeeklyReport(DateTime dateStart, DateTime dateEnd, WeeklyStatus morale,
            WeeklyStatus stress, WeeklyStatus workload, string weeklyHighText,
            string weeklyLowText, string anythingElseText)
        {
            DateStart = dateStart;
            DateEnd = dateEnd;
            Morale = morale;
            Stress = stress;
            Workload = workload;
            WeeklyHighText = weeklyHighText;
            WeeklyLowText = weeklyLowText;
            AnythingElseText = anythingElseText;
        }
    }
}
