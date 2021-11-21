CREATE TABLE [dbo].[Companies] (
    [CompanyId]   INT            IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (100) NOT NULL,
    [JoinedDate]  DATE           NOT NULL,
    CONSTRAINT [PK_CompanyId] PRIMARY KEY CLUSTERED ([CompanyId] ASC)
);

