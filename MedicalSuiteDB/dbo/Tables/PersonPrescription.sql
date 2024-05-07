CREATE TABLE [dbo].[PersonPrescription] (
    [PrescriptionId] INT NOT NULL,
    [PersonId]       INT NOT NULL,
    CONSTRAINT [PK_PersonPrescription] PRIMARY KEY CLUSTERED ([PrescriptionId] ASC),
    CONSTRAINT [FK_PersonPrescription_Prescription] FOREIGN KEY ([PrescriptionId]) REFERENCES [dbo].[PersonPrescription] ([PrescriptionId])
);

