CREATE TABLE [dbo].[WeeklyReports] (
    [WeeklyReportId]   INT            IDENTITY (1, 1) NOT NULL,
    [TeamMemberId]     INT            NOT NULL,
    [DateStart]        DATE           NOT NULL,
    [DateEnd]          DATE           NOT NULL,
    [Morale]           INT            NOT NULL,
    [Stress]           INT            NOT NULL,
    [Workload]         INT            NOT NULL,
    [MoraleComment]    NVARCHAR (200) NULL,
    [StressComment]    NVARCHAR (200) NULL,
    [WorkloadComment]  NVARCHAR (200) NULL,
    [WeeklyHighText]   NVARCHAR (200) NOT NULL,
    [WeeklyLowText]    NVARCHAR (200) NOT NULL,
    [AnythingElseText] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_WeeklyReportId] PRIMARY KEY CLUSTERED ([WeeklyReportId] ASC),
    CONSTRAINT [CHK_Morale] CHECK ([Morale]>=(1) AND [Morale]<=(5)),
    CONSTRAINT [CHK_Stress] CHECK ([Stress]>=(1) AND [Stress]<=(5)),
    CONSTRAINT [CHK_Workload] CHECK ([Workload]>=(1) AND [Workload]<=(5)),
    CONSTRAINT [FK_WR_TeamMemberId] FOREIGN KEY ([TeamMemberId]) REFERENCES [dbo].[TeamMembers] ([TeamMemberId])
);



