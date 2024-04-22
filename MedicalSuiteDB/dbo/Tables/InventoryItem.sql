CREATE TABLE [dbo].[InventoryItem] (
    [InventoryItemId]          INT            IDENTITY (1, 1) NOT NULL,
    [InventoryItemCode]        VARCHAR (5)    NOT NULL,
    [InventoryItemName]        VARCHAR (100)  NOT NULL,
    [InventoryItemDescription] VARCHAR (250)  NOT NULL,
    [InventoryItemPrice]       DECIMAL (5, 2) NOT NULL,
    [CategoryId]               INT            NOT NULL,
    CONSTRAINT [PK_InventoryItem] PRIMARY KEY CLUSTERED ([InventoryItemId] ASC),
    CONSTRAINT [FK_InventoryItem_InventoryItem] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);

