CREATE TABLE [dbo].[Employee] (
    [numEmployeeID]        INT           IDENTITY (1, 1) NOT NULL,
    [varEmployeeName]      VARCHAR (100) NULL,
    [varEmployeeAddress]   VARCHAR (100) NULL,
    [varEmployeeNIC]       VARCHAR (100) NULL,
    [varEmployeeContactNo] VARCHAR (100) NULL,
    [bitActive]            BIT           NULL,
    [dtCreatedDate]        DATETIME      NULL,
    [dteditedDate]         DATETIME      NULL,
    [dtDeletedDate]        DATETIME      NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([numEmployeeID] ASC)
);

