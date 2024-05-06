CREATE TABLE [dbo].[InventoryItem] (
    [InventoryItemId]          INT            IDENTITY (1, 1) NOT NULL,
    [InventoryItemCode]        VARCHAR (5)    NOT NULL,
    [InventoryItemName]        NCHAR (100)    NOT NULL,
    [InventoryItemDescription] NCHAR (250)    NOT NULL,
    [InventoryItemPrice]       DECIMAL (5, 2) NOT NULL,
    [CategoryId]               INT            NOT NULL,
    CONSTRAINT [PK_InventoryItem] PRIMARY KEY CLUSTERED ([InventoryItemId] ASC)
);





