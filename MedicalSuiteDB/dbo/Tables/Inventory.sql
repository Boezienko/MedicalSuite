CREATE TABLE [dbo].[Inventory] (
    [InventoryId]     INT NOT NULL,
    [DoctorsOfficeId] INT NOT NULL,
    CONSTRAINT [PK_Inventory_1] PRIMARY KEY CLUSTERED ([InventoryId] ASC),
    CONSTRAINT [FK_Inventory_DoctorsOffice] FOREIGN KEY ([DoctorsOfficeId]) REFERENCES [dbo].[DoctorsOffice] ([DoctorsOfficeId])
);

