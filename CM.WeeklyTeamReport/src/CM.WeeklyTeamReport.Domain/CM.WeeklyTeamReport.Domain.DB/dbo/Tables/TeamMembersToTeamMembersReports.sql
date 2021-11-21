CREATE TABLE [dbo].[TeamMembersToTeamMembersReports] (
    [FromId] INT NOT NULL,
    [ToId]   INT NOT NULL,
    CONSTRAINT [PK_TMToTM] PRIMARY KEY CLUSTERED ([FromId] ASC, [ToId] ASC),
    CONSTRAINT [FK_TMToTM_TMFromId] FOREIGN KEY ([FromId]) REFERENCES [dbo].[TeamMembers] ([TeamMemberId]),
    CONSTRAINT [FK_TMToTM_TMToId] FOREIGN KEY ([ToId]) REFERENCES [dbo].[TeamMembers] ([TeamMemberId])
);





