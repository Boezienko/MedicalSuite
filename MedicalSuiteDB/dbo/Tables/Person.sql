CREATE TABLE [dbo].[Person] (
    [PersonId]       INT          NOT NULL,
    [FirstName]      VARCHAR (50) NOT NULL,
    [LastName]       VARCHAR (50) NOT NULL,
    [Email]          VARCHAR (50) NOT NULL,
    [PasswordHash]   TEXT         NOT NULL,
    [LasLoginTime]   DATETIME     NOT NULL,
    [PrescriptionId] INT          NOT NULL,
    [RoleId]         INT          NOT NULL,
    [Telephone]      NCHAR (12)   NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC),
    CONSTRAINT [FK_Person_Prescription] FOREIGN KEY ([PrescriptionId]) REFERENCES [dbo].[Prescription] ([PrescriptionId]),
    CONSTRAINT [FK_Person_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])
);



