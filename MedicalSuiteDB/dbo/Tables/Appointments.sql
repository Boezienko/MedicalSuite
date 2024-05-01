CREATE TABLE [dbo].[Appointments] (
    [AppointmentId]    INT           IDENTITY (1, 1) NOT NULL,
    [AppointmentDate]  DATE          NOT NULL,
    [AppointmentTime]  TIME (7)      NOT NULL,
    [AppointmentNotes] VARCHAR (250) NULL,
    [DoctorsName]      VARCHAR (50)  NULL,
    [PersonId]         INT           NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([AppointmentId] ASC),
    CONSTRAINT [FK_Appointments_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId])
);





