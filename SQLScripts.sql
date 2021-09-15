CREATE SCHEMA [Instances];

CREATE TABLE [Instances].[Categories]
(
	[InstanceId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(64) NOT NULL,
	[Description] VARCHAR(256) NOT NULL,
	[CreatedTimestamp] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(), 
)

GO


CREATE TABLE [Instances].[CategoryAttributes]
(
	[InstanceId] INT NOT NULL,
	[Key] VARCHAR(64) NOT NULL,
	[Value] VARCHAR(512) NOT NULL, 
    CONSTRAINT [PK_CategoryAttributes] PRIMARY KEY ([InstanceId], [Key]), 
    CONSTRAINT [FK_CategoryAttributes_Categories] FOREIGN KEY ([InstanceId]) REFERENCES [Instances].[Categories]([InstanceId]) ON DELETE CASCADE
)



CREATE TABLE [Instances].[CategoryCategories]
(
	[InstanceId] INT NOT NULL,
	[CategoryInstanceId] INT NOT NULL, 
    CONSTRAINT [PK_CategoryCategories] PRIMARY KEY ([InstanceId], [CategoryInstanceId]), 
    CONSTRAINT [FK_CategoryCategories_Categories] FOREIGN KEY ([InstanceId]) REFERENCES [Instances].[Categories]([InstanceId]) ON DELETE CASCADE, 
    CONSTRAINT [FK_CategoryCategories_Categories_Categories] FOREIGN KEY ([CategoryInstanceId]) REFERENCES [Instances].[Categories]([InstanceId])
)

CREATE TABLE [Instances].[Products]
(
	[InstanceId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(256) NOT NULL,
	[Description] VARCHAR(256) NOT NULL,
	[ProductImageUris] VARCHAR(MAX) NOT NULL,
	[ValidSkus] VARCHAR(MAX) NOT NULL,
	[CreatedTimestamp] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(), 
)

GO

CREATE TABLE [Instances].[ProductCategories]
(
	[InstanceId] INT NOT NULL,
	[CategoryInstanceId] INT NOT NULL, 
    CONSTRAINT [PK_ProductCategories] PRIMARY KEY ([InstanceId], [CategoryInstanceId]), 
    CONSTRAINT [FK_ProductCategories_Products] FOREIGN KEY ([InstanceId]) REFERENCES [Instances].[Products]([InstanceId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductCategories_Categories] FOREIGN KEY ([CategoryInstanceId]) REFERENCES [Instances].[Categories]([InstanceId]) ON DELETE CASCADE
)

CREATE TABLE [Instances].[ProductAttributes]
(
	[InstanceId] INT NOT NULL,
	[Key] VARCHAR(64) NOT NULL,
	[Value] VARCHAR(512) NOT NULL, 
    CONSTRAINT [PK_ProductAttributes] PRIMARY KEY ([InstanceId], [Key]), 
    CONSTRAINT [FK_ProductAttributes_Products] FOREIGN KEY ([InstanceId]) REFERENCES [Instances].[Products]([InstanceId]) ON DELETE CASCADE
)

GO

CREATE INDEX [IX_ProductAttributes_Key_Value] ON [Instances].[ProductAttributes] ([Key] ASC, [Value] ASC)






