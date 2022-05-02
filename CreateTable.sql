USE [DotNetWebTestSandbox]
GO

/****** Object: Table [dbo].[AddressBookEntry] Script Date: 15/05/2021 23:33:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AddressBookEntrys] (
    [FirstName]       NVARCHAR (MAX) NULL,
    [LastName]        NVARCHAR (MAX) NULL,
    [EmailAddress]    NVARCHAR (MAX) NULL,
    [TelephoneNumber] NVARCHAR (MAX) NULL,
    [Id]              NVARCHAR (50)  NOT NULL
);


