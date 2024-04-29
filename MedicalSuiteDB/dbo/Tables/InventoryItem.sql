CREATE TABLE [dbo].[InventoryItem] (
    [InventoryItemId]          INT            NOT NULL,
    [InventoryItemCode]        VARCHAR (5)    NOT NULL,
    [InventoryItemName]        NCHAR (100)    NOT NULL,
    [InventoryItemDescription] NCHAR (250)    NOT NULL,
    [InventoryItemPrice]       DECIMAL (5, 2) NOT NULL,
    [CategoryId]               INT            NOT NULL,
    CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED ([InventoryItemId] ASC),
    CONSTRAINT [FK_Inventory_DoctorsOffice] FOREIGN KEY ([InventoryItemCode]) REFERENCES [dbo].[DoctorsOffice] ([DoctorsOfficeId])
);



