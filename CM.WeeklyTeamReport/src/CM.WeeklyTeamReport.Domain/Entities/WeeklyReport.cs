using System;

namespace CM.WeeklyTeamReport.Domain
{
    public class WeeklyReport
    {
        public int WeeklyReportId { get; set; }
        public int TeamMemberId { get; set; }
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

        public WeeklyReport(int weeklyReportId, int teamMemberId, DateTime dateStart, DateTime dateEnd,
            WeeklyStatus morale, WeeklyStatus stress, WeeklyStatus workload,
            string moraleComment, string stressComment, string workloadComment,
            string weeklyHighText, string weeklyLowText, string anythingElseText)
        {
            WeeklyReportId = weeklyReportId;
            TeamMemberId = teamMemberId;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Morale = morale;
            Stress = stress;
            Workload = workload;
            MoraleComment = moraleComment;
            StressComment = stressComment;
            WorkloadComment = workloadComment;
            WeeklyHighText = weeklyHighText;
            WeeklyLowText = weeklyLowText;
            AnythingElseText = anythingElseText;
        }

        public WeeklyReport() { }
    }
}
