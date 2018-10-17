
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/16/2018 19:16:24
-- Generated from EDMX file: C:\Users\Ramon\source\repos\ProjetoRamonLP2\ProjetoRamonLP2\Models\Produto.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [projetoLP2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProdutoSet1'
CREATE TABLE [dbo].[ProdutoSet1] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Preco] nvarchar(max)  NOT NULL,
    [CategoriaCodigoCategoria] int  NOT NULL
);
GO

-- Creating table 'CategoriaSet'
CREATE TABLE [dbo].[CategoriaSet] (
    [CodigoCategoria] int IDENTITY(1,1) NOT NULL,
    [NomeCategoria] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Codigo] in table 'ProdutoSet1'
ALTER TABLE [dbo].[ProdutoSet1]
ADD CONSTRAINT [PK_ProdutoSet1]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [CodigoCategoria] in table 'CategoriaSet'
ALTER TABLE [dbo].[CategoriaSet]
ADD CONSTRAINT [PK_CategoriaSet]
    PRIMARY KEY CLUSTERED ([CodigoCategoria] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoriaCodigoCategoria] in table 'ProdutoSet1'
ALTER TABLE [dbo].[ProdutoSet1]
ADD CONSTRAINT [FK_ProdutoCategoria]
    FOREIGN KEY ([CategoriaCodigoCategoria])
    REFERENCES [dbo].[CategoriaSet]
        ([CodigoCategoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdutoCategoria'
CREATE INDEX [IX_FK_ProdutoCategoria]
ON [dbo].[ProdutoSet1]
    ([CategoriaCodigoCategoria]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------