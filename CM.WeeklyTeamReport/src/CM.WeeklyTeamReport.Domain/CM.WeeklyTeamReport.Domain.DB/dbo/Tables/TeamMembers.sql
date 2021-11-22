CREATE TABLE [dbo].[TeamMembers] (
    [TeamMemberId] INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]    INT            NOT NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [Title]        NVARCHAR (50)  NOT NULL,
    [InviteLink]   NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_TeamMemberId] PRIMARY KEY CLUSTERED ([TeamMemberId] ASC),
    CONSTRAINT [FK_TM_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
);



