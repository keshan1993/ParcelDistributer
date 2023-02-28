CREATE TABLE [dbo].[Driver] (
    [numDriverID]        INT           IDENTITY (1, 1) NOT NULL,
    [varDriverName]      VARCHAR (100) NULL,
    [varDriverAddress]   VARCHAR (100) NULL,
    [varDriverNIC]       VARCHAR (100) NULL,
    [varDriverContactNo] VARCHAR (100) NULL,
    [bitActive]          BIT           NULL,
    [dtCreatedDate]      DATETIME      NULL,
    [dteditedDate]       DATETIME      NULL,
    [dtDeletedDate]      DATETIME      NULL,
    CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED ([numDriverID] ASC)
);

