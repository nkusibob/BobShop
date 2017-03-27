
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/24/2017 12:11:49
-- Generated from EDMX file: C:\Users\isa\Downloads\MyShop\BobShop\Mvc\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyShop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Adress_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Adress] DROP CONSTRAINT [FK_Adress_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_Adress_DeliverableCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Adress] DROP CONSTRAINT [FK_Adress_DeliverableCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_Category_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Category] DROP CONSTRAINT [FK_Category_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_Command_CommandStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Command] DROP CONSTRAINT [FK_Command_CommandStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_Command_DeliveryAdress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Command] DROP CONSTRAINT [FK_Command_DeliveryAdress];
GO
IF OBJECT_ID(N'[dbo].[FK_Command_InvoiceAdress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Command] DROP CONSTRAINT [FK_Command_InvoiceAdress];
GO
IF OBJECT_ID(N'[dbo].[FK_CommandLine_Command]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommandLine] DROP CONSTRAINT [FK_CommandLine_Command];
GO
IF OBJECT_ID(N'[dbo].[FK_CommandLine_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommandLine] DROP CONSTRAINT [FK_CommandLine_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_CommandStatus_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommandStatus] DROP CONSTRAINT [FK_CommandStatus_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_Customer_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_User];
GO
IF OBJECT_ID(N'[dbo].[FK_DeliverablePrice_DeliverableCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeliverablePrice] DROP CONSTRAINT [FK_DeliverablePrice_DeliverableCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_Media_MediaType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Media] DROP CONSTRAINT [FK_Media_MediaType];
GO
IF OBJECT_ID(N'[dbo].[FK_Price_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Price] DROP CONSTRAINT [FK_Price_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_UnitType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_UnitType];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_VATCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_VATCategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Adress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Adress];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Command]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Command];
GO
IF OBJECT_ID(N'[dbo].[CommandLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommandLine];
GO
IF OBJECT_ID(N'[dbo].[CommandStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommandStatus];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[DeliverableCountry]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliverableCountry];
GO
IF OBJECT_ID(N'[dbo].[DeliverablePrice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliverablePrice];
GO
IF OBJECT_ID(N'[dbo].[Media]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Media];
GO
IF OBJECT_ID(N'[dbo].[MediaType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaType];
GO
IF OBJECT_ID(N'[dbo].[parametres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[parametres];
GO
IF OBJECT_ID(N'[dbo].[Price]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Price];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[UnitType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UnitType];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[VATCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VATCategory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Adresses'
CREATE TABLE [dbo].[Adresses] (
    [AdressID] int IDENTITY(1,1) NOT NULL,
    [AdressCompany] nvarchar(64)  NULL,
    [AdressLine1] nvarchar(128)  NOT NULL,
    [AdressLine2] nvarchar(128)  NULL,
    [AdressZipCode] nvarchar(16)  NOT NULL,
    [AdressType] bit  NOT NULL,
    [AdressActive] bit  NOT NULL,
    [DeliverableCountryID] int  NOT NULL,
    [CustomerID] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(64)  NOT NULL,
    [CategoryDescription] nvarchar(255)  NOT NULL,
    [CategoryIsMenu] bit  NOT NULL,
    [MediaID] int  NOT NULL
);
GO

-- Creating table 'Commands'
CREATE TABLE [dbo].[Commands] (
    [CommandID] int IDENTITY(1,1) NOT NULL,
    [CommandDate] datetime  NOT NULL,
    [CommandFicsalDate] datetime  NOT NULL,
    [CommandeReference] nvarchar(32)  NOT NULL,
    [CommandStatusID] int  NOT NULL,
    [DeliveryAdressID] int  NOT NULL,
    [InvoiceAdressID] int  NULL
);
GO

-- Creating table 'CommandLines'
CREATE TABLE [dbo].[CommandLines] (
    [CommandLineID] int IDENTITY(1,1) NOT NULL,
    [CommandLineQuantity] int  NOT NULL,
    [CommandLinePrice] decimal(19,4)  NOT NULL,
    [CommandID] int  NOT NULL,
    [ProductID] int  NOT NULL
);
GO

-- Creating table 'CommandStatus'
CREATE TABLE [dbo].[CommandStatus] (
    [CommandStatusID] int IDENTITY(1,1) NOT NULL,
    [CommandStatusName] nvarchar(64)  NOT NULL,
    [CommandStatusProgress] smallint  NOT NULL,
    [MediaID] int  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerID] int IDENTITY(1,1) NOT NULL,
    [CustomerLastName] nvarchar(64)  NOT NULL,
    [CustomerFirstName] nvarchar(64)  NOT NULL,
    [CustomerCompany] nvarchar(96)  NULL,
    [CustomerActive] bit  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'DeliverableCountries'
CREATE TABLE [dbo].[DeliverableCountries] (
    [DeliverableCountryID] int IDENTITY(1,1) NOT NULL,
    [DeliverableCountryName] nvarchar(48)  NOT NULL
);
GO

-- Creating table 'DeliverablePrices'
CREATE TABLE [dbo].[DeliverablePrices] (
    [DeliverablePriceID] int IDENTITY(1,1) NOT NULL,
    [DeliverablePriceName] nvarchar(64)  NOT NULL,
    [DeliverablePriceTimeEstimation] tinyint  NOT NULL,
    [DeliverablePriceValue] decimal(10,4)  NOT NULL,
    [DeliverablePriceCountryID] int  NOT NULL
);
GO

-- Creating table 'Media'
CREATE TABLE [dbo].[Media] (
    [MediaID] int IDENTITY(1,1) NOT NULL,
    [MediaName] nvarchar(64)  NOT NULL,
    [MediaAlt] nvarchar(128)  NULL,
    [MediaUrl] nvarchar(max)  NOT NULL,
    [MediaTypeID] int  NOT NULL
);
GO

-- Creating table 'MediaTypes'
CREATE TABLE [dbo].[MediaTypes] (
    [MediaTypeID] int IDENTITY(1,1) NOT NULL,
    [MediaTypeName] nvarchar(64)  NOT NULL,
    [MediaTypeExtension] nvarchar(8)  NULL
);
GO

-- Creating table 'parametres'
CREATE TABLE [dbo].[parametres] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nbre] int  NOT NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [PriceID] int IDENTITY(1,1) NOT NULL,
    [PriceDate] datetime  NOT NULL,
    [PriceValue] decimal(19,4)  NOT NULL,
    [ProductID] int  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(128)  NOT NULL,
    [ProductDescription] nvarchar(255)  NULL,
    [ProductLongDescription] varchar(max)  NULL,
    [ProductReference] nvarchar(32)  NULL,
    [ProductManufacturerReference] nvarchar(128)  NOT NULL,
    [ProductBarCode] char(16)  NULL,
    [ProductAddingDate] datetime  NOT NULL,
    [ProductDiscontinued] bit  NOT NULL,
    [VATCategoryID] int  NOT NULL,
    [UnitTypeID] int  NOT NULL,
    [CategoryID] int  NOT NULL,
    [MediaID] int  NOT NULL
);
GO

-- Creating table 'UnitTypes'
CREATE TABLE [dbo].[UnitTypes] (
    [UnitTypeID] int IDENTITY(1,1) NOT NULL,
    [UnitTypeName] nvarchar(48)  NOT NULL,
    [UnitTypeSymbol] nvarchar(16)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserUsername] nvarchar(128)  NOT NULL,
    [UserPassword] nvarchar(255)  NOT NULL,
    [UserEmail] nvarchar(160)  NOT NULL,
    [UserSalt] nvarchar(32)  NOT NULL,
    [UserRegisterDate] datetime  NOT NULL,
    [UserLastLoginDate] datetime  NULL
);
GO

-- Creating table 'VATCategories'
CREATE TABLE [dbo].[VATCategories] (
    [VATCategoryID] int IDENTITY(1,1) NOT NULL,
    [VATCategoryName] nvarchar(64)  NOT NULL,
    [VATCategoryValue] decimal(5,3)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AdressID] in table 'Adresses'
ALTER TABLE [dbo].[Adresses]
ADD CONSTRAINT [PK_Adresses]
    PRIMARY KEY CLUSTERED ([AdressID] ASC);
GO

-- Creating primary key on [CategoryID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [CommandID] in table 'Commands'
ALTER TABLE [dbo].[Commands]
ADD CONSTRAINT [PK_Commands]
    PRIMARY KEY CLUSTERED ([CommandID] ASC);
GO

-- Creating primary key on [CommandLineID] in table 'CommandLines'
ALTER TABLE [dbo].[CommandLines]
ADD CONSTRAINT [PK_CommandLines]
    PRIMARY KEY CLUSTERED ([CommandLineID] ASC);
GO

-- Creating primary key on [CommandStatusID] in table 'CommandStatus'
ALTER TABLE [dbo].[CommandStatus]
ADD CONSTRAINT [PK_CommandStatus]
    PRIMARY KEY CLUSTERED ([CommandStatusID] ASC);
GO

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [DeliverableCountryID] in table 'DeliverableCountries'
ALTER TABLE [dbo].[DeliverableCountries]
ADD CONSTRAINT [PK_DeliverableCountries]
    PRIMARY KEY CLUSTERED ([DeliverableCountryID] ASC);
GO

-- Creating primary key on [DeliverablePriceID] in table 'DeliverablePrices'
ALTER TABLE [dbo].[DeliverablePrices]
ADD CONSTRAINT [PK_DeliverablePrices]
    PRIMARY KEY CLUSTERED ([DeliverablePriceID] ASC);
GO

-- Creating primary key on [MediaID] in table 'Media'
ALTER TABLE [dbo].[Media]
ADD CONSTRAINT [PK_Media]
    PRIMARY KEY CLUSTERED ([MediaID] ASC);
GO

-- Creating primary key on [MediaTypeID] in table 'MediaTypes'
ALTER TABLE [dbo].[MediaTypes]
ADD CONSTRAINT [PK_MediaTypes]
    PRIMARY KEY CLUSTERED ([MediaTypeID] ASC);
GO

-- Creating primary key on [id] in table 'parametres'
ALTER TABLE [dbo].[parametres]
ADD CONSTRAINT [PK_parametres]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [PriceID] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([PriceID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [UnitTypeID] in table 'UnitTypes'
ALTER TABLE [dbo].[UnitTypes]
ADD CONSTRAINT [PK_UnitTypes]
    PRIMARY KEY CLUSTERED ([UnitTypeID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [VATCategoryID] in table 'VATCategories'
ALTER TABLE [dbo].[VATCategories]
ADD CONSTRAINT [PK_VATCategories]
    PRIMARY KEY CLUSTERED ([VATCategoryID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerID] in table 'Adresses'
ALTER TABLE [dbo].[Adresses]
ADD CONSTRAINT [FK_Adress_Customer]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Customers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Adress_Customer'
CREATE INDEX [IX_FK_Adress_Customer]
ON [dbo].[Adresses]
    ([CustomerID]);
GO

-- Creating foreign key on [DeliverableCountryID] in table 'Adresses'
ALTER TABLE [dbo].[Adresses]
ADD CONSTRAINT [FK_Adress_DeliverableCountry]
    FOREIGN KEY ([DeliverableCountryID])
    REFERENCES [dbo].[DeliverableCountries]
        ([DeliverableCountryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Adress_DeliverableCountry'
CREATE INDEX [IX_FK_Adress_DeliverableCountry]
ON [dbo].[Adresses]
    ([DeliverableCountryID]);
GO

-- Creating foreign key on [DeliveryAdressID] in table 'Commands'
ALTER TABLE [dbo].[Commands]
ADD CONSTRAINT [FK_Command_DeliveryAdress]
    FOREIGN KEY ([DeliveryAdressID])
    REFERENCES [dbo].[Adresses]
        ([AdressID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Command_DeliveryAdress'
CREATE INDEX [IX_FK_Command_DeliveryAdress]
ON [dbo].[Commands]
    ([DeliveryAdressID]);
GO

-- Creating foreign key on [InvoiceAdressID] in table 'Commands'
ALTER TABLE [dbo].[Commands]
ADD CONSTRAINT [FK_Command_InvoiceAdress]
    FOREIGN KEY ([InvoiceAdressID])
    REFERENCES [dbo].[Adresses]
        ([AdressID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Command_InvoiceAdress'
CREATE INDEX [IX_FK_Command_InvoiceAdress]
ON [dbo].[Commands]
    ([InvoiceAdressID]);
GO

-- Creating foreign key on [MediaID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_Category_Media]
    FOREIGN KEY ([MediaID])
    REFERENCES [dbo].[Media]
        ([MediaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Category_Media'
CREATE INDEX [IX_FK_Category_Media]
ON [dbo].[Categories]
    ([MediaID]);
GO

-- Creating foreign key on [CategoryID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Category]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Category'
CREATE INDEX [IX_FK_Product_Category]
ON [dbo].[Products]
    ([CategoryID]);
GO

-- Creating foreign key on [CommandStatusID] in table 'Commands'
ALTER TABLE [dbo].[Commands]
ADD CONSTRAINT [FK_Command_CommandStatus]
    FOREIGN KEY ([CommandStatusID])
    REFERENCES [dbo].[CommandStatus]
        ([CommandStatusID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Command_CommandStatus'
CREATE INDEX [IX_FK_Command_CommandStatus]
ON [dbo].[Commands]
    ([CommandStatusID]);
GO

-- Creating foreign key on [CommandID] in table 'CommandLines'
ALTER TABLE [dbo].[CommandLines]
ADD CONSTRAINT [FK_CommandLine_Command]
    FOREIGN KEY ([CommandID])
    REFERENCES [dbo].[Commands]
        ([CommandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommandLine_Command'
CREATE INDEX [IX_FK_CommandLine_Command]
ON [dbo].[CommandLines]
    ([CommandID]);
GO

-- Creating foreign key on [ProductID] in table 'CommandLines'
ALTER TABLE [dbo].[CommandLines]
ADD CONSTRAINT [FK_CommandLine_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommandLine_Product'
CREATE INDEX [IX_FK_CommandLine_Product]
ON [dbo].[CommandLines]
    ([ProductID]);
GO

-- Creating foreign key on [MediaID] in table 'CommandStatus'
ALTER TABLE [dbo].[CommandStatus]
ADD CONSTRAINT [FK_CommandStatus_Media]
    FOREIGN KEY ([MediaID])
    REFERENCES [dbo].[Media]
        ([MediaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommandStatus_Media'
CREATE INDEX [IX_FK_CommandStatus_Media]
ON [dbo].[CommandStatus]
    ([MediaID]);
GO

-- Creating foreign key on [UserID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_Customer_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Customer_User'
CREATE INDEX [IX_FK_Customer_User]
ON [dbo].[Customers]
    ([UserID]);
GO

-- Creating foreign key on [DeliverablePriceCountryID] in table 'DeliverablePrices'
ALTER TABLE [dbo].[DeliverablePrices]
ADD CONSTRAINT [FK_DeliverablePrice_DeliverableCountry]
    FOREIGN KEY ([DeliverablePriceCountryID])
    REFERENCES [dbo].[DeliverableCountries]
        ([DeliverableCountryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeliverablePrice_DeliverableCountry'
CREATE INDEX [IX_FK_DeliverablePrice_DeliverableCountry]
ON [dbo].[DeliverablePrices]
    ([DeliverablePriceCountryID]);
GO

-- Creating foreign key on [MediaTypeID] in table 'Media'
ALTER TABLE [dbo].[Media]
ADD CONSTRAINT [FK_Media_MediaType]
    FOREIGN KEY ([MediaTypeID])
    REFERENCES [dbo].[MediaTypes]
        ([MediaTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Media_MediaType'
CREATE INDEX [IX_FK_Media_MediaType]
ON [dbo].[Media]
    ([MediaTypeID]);
GO

-- Creating foreign key on [MediaID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Media]
    FOREIGN KEY ([MediaID])
    REFERENCES [dbo].[Media]
        ([MediaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Media'
CREATE INDEX [IX_FK_Product_Media]
ON [dbo].[Products]
    ([MediaID]);
GO

-- Creating foreign key on [ProductID] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_Price_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Price_Product'
CREATE INDEX [IX_FK_Price_Product]
ON [dbo].[Prices]
    ([ProductID]);
GO

-- Creating foreign key on [UnitTypeID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_UnitType]
    FOREIGN KEY ([UnitTypeID])
    REFERENCES [dbo].[UnitTypes]
        ([UnitTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_UnitType'
CREATE INDEX [IX_FK_Product_UnitType]
ON [dbo].[Products]
    ([UnitTypeID]);
GO

-- Creating foreign key on [VATCategoryID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_VATCategory]
    FOREIGN KEY ([VATCategoryID])
    REFERENCES [dbo].[VATCategories]
        ([VATCategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_VATCategory'
CREATE INDEX [IX_FK_Product_VATCategory]
ON [dbo].[Products]
    ([VATCategoryID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------