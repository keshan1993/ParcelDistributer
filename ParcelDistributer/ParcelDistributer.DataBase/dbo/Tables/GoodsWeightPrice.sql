CREATE TABLE [dbo].[GoodsWeightPrice] (
    [numGoodsWeightPriceID] INT             IDENTITY (1, 1) NOT NULL,
    [numGoodsTypeID]        INT             NULL,
    [numWeightFrom]         DECIMAL (18, 2) NULL,
    [numDistanceFrom]       DECIMAL (18, 2) NULL,
    [numDistanceTo]         DECIMAL (18, 2) NULL,
    [numWeightTo]           DECIMAL (18, 2) NULL,
    [numPrice]              DECIMAL (18, 2) NULL,
    [bitActive]             BIT             NULL,
    [dtCreatedDate]         DATETIME        NULL,
    [dteditedDate]          DATETIME        NULL,
    [dtDeletedDate]         DATETIME        NULL,
    CONSTRAINT [PK_GoodsWeightPrice] PRIMARY KEY CLUSTERED ([numGoodsWeightPriceID] ASC),
    CONSTRAINT [FK_GoodsWeightPrice_GoodsType] FOREIGN KEY ([numGoodsTypeID]) REFERENCES [dbo].[GoodsType] ([numGoodsTypeID])
);

