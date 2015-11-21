CREATE TABLE [dbo].[Invoice] (
    [InvoiceID]            INT            IDENTITY (1000001, 1) NOT NULL,
    [UserID]               NVARCHAR (50)  NOT NULL,
    [InvoiceDate]          DATETIME       NOT NULL,
    [ShippingDate]         DATETIME       NOT NULL,
    [ShipToName]           NVARCHAR (75)  NOT NULL,
    [ShippingAddressLine1] NVARCHAR (50)  NOT NULL,
    [ShippingAddressLine2] NVARCHAR (50)  NOT NULL,
    [ShippingCity]         NVARCHAR (50)  NOT NULL,
    [ShippingState]        NCHAR (2)      NOT NULL,
    [ShippingZip]          NCHAR (10)     NOT NULL,
    [TotalDue]             MONEY          NOT NULL,
    PRIMARY KEY CLUSTERED ([InvoiceID] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Person] ([UserID])
);

CREATE TABLE [dbo].[InvoiceItems] (
    [InvoiceItemID] INT              IDENTITY (1, 1) NOT NULL,
    [InvoiceID]     INT              ,
    [Product]       UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([InvoiceItemID] ASC),
    CONSTRAINT [UQ_InvoiceItems_InvoiceID_ProductID] UNIQUE NONCLUSTERED ([InvoiceID] ASC, [Product] ASC),
    FOREIGN KEY ([InvoiceID]) REFERENCES [dbo].[Invoice] ([InvoiceID]),
    FOREIGN KEY ([Product]) REFERENCES [dbo].[ProductDiscription] ([DiscriptionID])
);
