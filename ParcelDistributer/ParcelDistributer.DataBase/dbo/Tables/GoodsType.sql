CREATE TABLE [dbo].[GoodsType] (
    [numGoodsTypeID]          INT           IDENTITY (1, 1) NOT NULL,
    [varGoodsTypeName]        VARCHAR (100) NULL,
    [varGoodsTypeDescription] VARCHAR (100) NULL,
    [bitActive]               BIT           NULL,
    [dtCreatedDate]           DATETIME      NULL,
    [dteditedDate]            DATETIME      NULL,
    [dtDeletedDate]           DATETIME      NULL,
    CONSTRAINT [PK_GoodsType] PRIMARY KEY CLUSTERED ([numGoodsTypeID] ASC)
);

