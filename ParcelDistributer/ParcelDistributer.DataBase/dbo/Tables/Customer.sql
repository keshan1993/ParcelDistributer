CREATE TABLE [dbo].[Customer] (
    [numCustomerID]        INT           IDENTITY (1, 1) NOT NULL,
    [varCustomerName]      VARCHAR (100) NULL,
    [varCustomerAddress]   VARCHAR (100) NULL,
    [varCustomerNIC]       VARCHAR (100) NULL,
    [varCustomerContactNo] VARCHAR (100) NULL,
    [bitActive]            BIT           NULL,
    [dtCreatedDate]        DATETIME      NULL,
    [dteditedDate]         DATETIME      NULL,
    [dtDeletedDate]        DATETIME      NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([numCustomerID] ASC)
);

