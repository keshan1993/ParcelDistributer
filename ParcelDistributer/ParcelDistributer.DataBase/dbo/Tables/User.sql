CREATE TABLE [dbo].[User] (
    [numUserID]       INT          IDENTITY (1, 1) NOT NULL,
    [varUserName]     VARCHAR (50) NULL,
    [varUserPassword] VARCHAR (50) NULL,
    [bitIsCustomer]   BIT          NULL,
    [numCustomerID]   INT          NULL,
    [bitIsDriver]     BIT          NULL,
    [numDriverID]     INT          NULL,
    [bitIsEmployee]   BIT          NULL,
    [numEmployeeID]   INT          NULL,
    [bitActive]       BIT          NULL,
    [dtCreatedDate]   DATETIME     NULL,
    [dteditedDate]    DATETIME     NULL,
    [dtDeletedDate]   DATETIME     NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([numUserID] ASC)
);

