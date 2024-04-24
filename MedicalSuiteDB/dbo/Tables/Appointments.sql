CREATE TABLE [dbo].[Appointments] (
    [AppointmentId]   INT      IDENTITY (1, 1) NOT NULL,
    [AppointmentDate] DATE     NOT NULL,
    [AppointmentTime] TIME (7) NOT NULL,
    [PersonId]        INT      NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([AppointmentId] ASC),
    CONSTRAINT [FK_Appointments_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId])
);



