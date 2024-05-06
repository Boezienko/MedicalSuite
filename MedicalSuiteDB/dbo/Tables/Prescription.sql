CREATE TABLE [dbo].[Prescription] (
    [PrescriptionId]         INT           IDENTITY (1, 1) NOT NULL,
    [PrescriptionName]       VARCHAR (50)  NOT NULL,
    [PrescriptionStrength]   VARCHAR (25)  NOT NULL,
    [PrescriptionQuantity]   VARCHAR (25)  NOT NULL,
    [PrescriptionDirections] VARCHAR (100) NOT NULL,
    [WrittenDate]            DATE          NOT NULL,
    [ExpirationDate]         DATE          NOT NULL,
    [PrescriptionScheduleId] INT           NOT NULL,
    [PersonId]               INT           NOT NULL,
    CONSTRAINT [PK_Prescription] PRIMARY KEY CLUSTERED ([PrescriptionId] ASC),
    CONSTRAINT [FK_Prescription_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId]),
    CONSTRAINT [FK_Prescription_PrescriptionSchedule] FOREIGN KEY ([PrescriptionScheduleId]) REFERENCES [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId])
);











