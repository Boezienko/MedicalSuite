CREATE TABLE [dbo].[Appointments] (
    [AppointmentId]   INT      IDENTITY (1, 1) NOT NULL,
    [AppointmentDate] DATE     NOT NULL,
    [AppointmentTime] TIME (7) NOT NULL,
    [PersonId]        INT      NOT NULL,
    CONSTRAINT [FK_Appointments_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId]),
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([AppointmentId] ASC)
);



