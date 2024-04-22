CREATE TABLE [dbo].[DoctorsOffice] (
    [DoctorsOfficeId]   INT           IDENTITY (1, 1) NOT NULL,
    [DoctorsOfficeName] VARCHAR (200) NOT NULL,
    [StreetAddress]     VARCHAR (100) NOT NULL,
    [City]              VARCHAR (50)  NOT NULL,
    [State]             VARCHAR (2)   NOT NULL,
    [ZipCode]           VARCHAR (10)  NOT NULL,
    [Phone]             VARCHAR (25)  NOT NULL,
    [PersonId]          INT           NOT NULL,
    CONSTRAINT [PK_DoctorsOffice] PRIMARY KEY CLUSTERED ([DoctorsOfficeId] ASC),
    CONSTRAINT [FK_DoctorsOffice_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId])
);







