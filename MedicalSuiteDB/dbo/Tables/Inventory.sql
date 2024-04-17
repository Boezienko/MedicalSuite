CREATE TABLE [dbo].[Inventory] (
    [InventoryId]     INT IDENTITY (1, 1) NOT NULL,
    [DoctorsOfficeId] INT NOT NULL,
    CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED ([InventoryId] ASC),
    CONSTRAINT [FK_Inventory_DoctorsOffice] FOREIGN KEY ([DoctorsOfficeId]) REFERENCES [dbo].[DoctorsOffice] ([DoctorsOfficeId])
);







