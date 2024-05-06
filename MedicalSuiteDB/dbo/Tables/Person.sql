CREATE TABLE [dbo].[Person] (
    [PersonId]       INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]      VARCHAR (50) NOT NULL,
    [LastName]       VARCHAR (50) NOT NULL,
    [Email]          VARCHAR (50) NOT NULL,
    [PasswordHash]   TEXT         NOT NULL,
    [LastLoginTime]  DATETIME     NOT NULL,
    [PrescriptionId] INT          NULL,
    [RoleId]         INT          NOT NULL,
    [Telephone]      VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC)
);













