
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/13/2018 11:10:29
-- Generated from EDMX file: D:\FacultateChiriac\An3Sem2\TSP.NET\Prezentation\Domain\Biblioteca.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AUTORCARTE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CARTEs] DROP CONSTRAINT [FK_AUTORCARTE];
GO
IF OBJECT_ID(N'[dbo].[FK_CARTEGEN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CARTEs] DROP CONSTRAINT [FK_CARTEGEN];
GO
IF OBJECT_ID(N'[dbo].[FK_IMPRUMUTCARTE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IMPRUMUTs] DROP CONSTRAINT [FK_IMPRUMUTCARTE];
GO
IF OBJECT_ID(N'[dbo].[FK_IMPRUMUTCITITOR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IMPRUMUTs] DROP CONSTRAINT [FK_IMPRUMUTCITITOR];
GO
IF OBJECT_ID(N'[dbo].[FK_REVIEWIMPRUMUT]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[REVIEWs] DROP CONSTRAINT [FK_REVIEWIMPRUMUT];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AUTORs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AUTORs];
GO
IF OBJECT_ID(N'[dbo].[CARTEs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CARTEs];
GO
IF OBJECT_ID(N'[dbo].[CITITORs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CITITORs];
GO
IF OBJECT_ID(N'[dbo].[GENs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GENs];
GO
IF OBJECT_ID(N'[dbo].[IMPRUMUTs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IMPRUMUTs];
GO
IF OBJECT_ID(N'[dbo].[REVIEWs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[REVIEWs];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GENs'
CREATE TABLE [dbo].[GENs] (
    [GenId] int IDENTITY(1,1) NOT NULL,
    [Descriere] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'AUTORs'
CREATE TABLE [dbo].[AUTORs] (
    [AutorId] int IDENTITY(1,1) NOT NULL,
    [Nume] nvarchar(20)  NOT NULL,
    [Prenume] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'CARTEs'
CREATE TABLE [dbo].[CARTEs] (
    [CarteId] int IDENTITY(1,1) NOT NULL,
    [AutorId] int  NOT NULL,
    [Titlu] nvarchar(50)  NOT NULL,
    [GenId] int  NOT NULL
);
GO

-- Creating table 'IMPRUMUTs'
CREATE TABLE [dbo].[IMPRUMUTs] (
    [ImprumutId] int IDENTITY(1,1) NOT NULL,
    [CarteId] int  NOT NULL,
    [CititorId] int  NOT NULL,
    [DataImprumut] datetime  NOT NULL,
    [DataScadenta] datetime  NOT NULL,
    [DataRestituire] datetime  NULL
);
GO

-- Creating table 'CITITORs'
CREATE TABLE [dbo].[CITITORs] (
    [CititorId] int IDENTITY(1,1) NOT NULL,
    [Nume] nvarchar(15)  NOT NULL,
    [Prenume] nvarchar(15)  NOT NULL,
    [Adresa] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Stare] smallint  NOT NULL
);
GO

-- Creating table 'REVIEWs'
CREATE TABLE [dbo].[REVIEWs] (
    [ReviewId] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [ImprumutId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GenId] in table 'GENs'
ALTER TABLE [dbo].[GENs]
ADD CONSTRAINT [PK_GENs]
    PRIMARY KEY CLUSTERED ([GenId] ASC);
GO

-- Creating primary key on [AutorId] in table 'AUTORs'
ALTER TABLE [dbo].[AUTORs]
ADD CONSTRAINT [PK_AUTORs]
    PRIMARY KEY CLUSTERED ([AutorId] ASC);
GO

-- Creating primary key on [CarteId] in table 'CARTEs'
ALTER TABLE [dbo].[CARTEs]
ADD CONSTRAINT [PK_CARTEs]
    PRIMARY KEY CLUSTERED ([CarteId] ASC);
GO

-- Creating primary key on [ImprumutId] in table 'IMPRUMUTs'
ALTER TABLE [dbo].[IMPRUMUTs]
ADD CONSTRAINT [PK_IMPRUMUTs]
    PRIMARY KEY CLUSTERED ([ImprumutId] ASC);
GO

-- Creating primary key on [CititorId] in table 'CITITORs'
ALTER TABLE [dbo].[CITITORs]
ADD CONSTRAINT [PK_CITITORs]
    PRIMARY KEY CLUSTERED ([CititorId] ASC);
GO

-- Creating primary key on [ReviewId] in table 'REVIEWs'
ALTER TABLE [dbo].[REVIEWs]
ADD CONSTRAINT [PK_REVIEWs]
    PRIMARY KEY CLUSTERED ([ReviewId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AutorId] in table 'CARTEs'
ALTER TABLE [dbo].[CARTEs]
ADD CONSTRAINT [FK_AUTORCARTE]
    FOREIGN KEY ([AutorId])
    REFERENCES [dbo].[AUTORs]
        ([AutorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AUTORCARTE'
CREATE INDEX [IX_FK_AUTORCARTE]
ON [dbo].[CARTEs]
    ([AutorId]);
GO

-- Creating foreign key on [GenId] in table 'CARTEs'
ALTER TABLE [dbo].[CARTEs]
ADD CONSTRAINT [FK_CARTEGEN]
    FOREIGN KEY ([GenId])
    REFERENCES [dbo].[GENs]
        ([GenId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CARTEGEN'
CREATE INDEX [IX_FK_CARTEGEN]
ON [dbo].[CARTEs]
    ([GenId]);
GO

-- Creating foreign key on [CarteId] in table 'IMPRUMUTs'
ALTER TABLE [dbo].[IMPRUMUTs]
ADD CONSTRAINT [FK_IMPRUMUTCARTE]
    FOREIGN KEY ([CarteId])
    REFERENCES [dbo].[CARTEs]
        ([CarteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IMPRUMUTCARTE'
CREATE INDEX [IX_FK_IMPRUMUTCARTE]
ON [dbo].[IMPRUMUTs]
    ([CarteId]);
GO

-- Creating foreign key on [CititorId] in table 'IMPRUMUTs'
ALTER TABLE [dbo].[IMPRUMUTs]
ADD CONSTRAINT [FK_IMPRUMUTCITITOR]
    FOREIGN KEY ([CititorId])
    REFERENCES [dbo].[CITITORs]
        ([CititorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IMPRUMUTCITITOR'
CREATE INDEX [IX_FK_IMPRUMUTCITITOR]
ON [dbo].[IMPRUMUTs]
    ([CititorId]);
GO

-- Creating foreign key on [ImprumutId] in table 'REVIEWs'
ALTER TABLE [dbo].[REVIEWs]
ADD CONSTRAINT [FK_REVIEWIMPRUMUT]
    FOREIGN KEY ([ImprumutId])
    REFERENCES [dbo].[IMPRUMUTs]
        ([ImprumutId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_REVIEWIMPRUMUT'
CREATE INDEX [IX_FK_REVIEWIMPRUMUT]
ON [dbo].[REVIEWs]
    ([ImprumutId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------