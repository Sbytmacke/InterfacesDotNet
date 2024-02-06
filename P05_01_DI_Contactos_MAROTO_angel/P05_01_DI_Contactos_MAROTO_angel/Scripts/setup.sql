CREATE DATABASE [WorkSpaceDB];
GO

USE [WorkSpaceDB];
GO

CREATE TABLE [Departments] (
    [Name] NVARCHAR(50) PRIMARY KEY
);
GO

CREATE TABLE [Employees] (
    [Dni] NVARCHAR(10) PRIMARY KEY,
    [DepartmentName] NVARCHAR(50) NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Phone] NVARCHAR(15) NOT NULL,
    [Position] NVARCHAR(50) NOT NULL,
    [Image] VARBINARY(MAX) NULL,
    FOREIGN KEY ([DepartmentName]) REFERENCES [Departments]([Name])
);
GO

INSERT INTO [Departments] ([Name]) VALUES ('NO-DEPARTMENT');
INSERT INTO [Departments] ([Name]) VALUES ('RRHH');
INSERT INTO [Departments] ([Name]) VALUES ('SALES');
INSERT INTO [Departments] ([Name]) VALUES ('IT');
INSERT INTO [Departments] ([Name]) VALUES ('PROJECT');
INSERT INTO [Departments] ([Name]) VALUES ('SUPPORT');
INSERT INTO [Departments] ([Name]) VALUES ('MARKETING');
INSERT INTO [Departments] ([Name]) VALUES ('DEVELOPMENT');

INSERT INTO [Employees] ([Dni], [DepartmentName], [Name], [Email], [Phone], [Position], [Image]) VALUES ('12345678A', 'RRHH', 'Angel Maroto', 'chivi7401@gmail.com', '666555444', 'Manager', NULL);
INSERT INTO [Employees] ([Dni], [DepartmentName], [Name], [Email], [Phone], [Position], [Image]) VALUES ('98765432B', 'SALES', 'Maria López', 'maria.lopez@example.com', '555666777', 'Sales Representative', NULL);
INSERT INTO [Employees] ([Dni], [DepartmentName], [Name], [Email], [Phone], [Position], [Image]) VALUES ('56789012C', 'IT', 'Juan Pérez', 'juan.perez@example.com', '999888777', 'IT Specialist', NULL);
INSERT INTO [Employees] ([Dni], [DepartmentName], [Name], [Email], [Phone], [Position], [Image]) VALUES ('34567890D', 'PROJECT', 'Carlos Rodríguez', 'carlos.rodriguez@example.com', '777888999', 'Project Manager', NULL);
INSERT INTO [Employees] ([Dni], [DepartmentName], [Name], [Email], [Phone], [Position], [Image]) VALUES ('01234567E', 'SUPPORT', 'Laura Gómez', 'laura.gomez@example.com', '888999000', 'Technical Support', NULL);
INSERT INTO [Employees] ([Dni], [DepartmentName], [Name], [Email], [Phone], [Position], [Image]) VALUES ('23456789F', 'MARKETING', 'Ana Martínez', 'ana.martinez@example.com', '777111222', 'Marketing Specialist', NULL);
INSERT INTO [Employees] ([Dni], [DepartmentName], [Name], [Email], [Phone], [Position], [Image]) VALUES ('45678901G', 'DEVELOPMENT', 'Javier Sánchez', 'javier.sanchez@example.com', '333444555', 'Software Developer', NULL);
INSERT INTO [Employees] ([Dni], [DepartmentName], [Name], [Email], [Phone], [Position], [Image]) VALUES ('67890123H', 'RRHH', 'Elena García', 'elena.garcia@example.com', '111222333', 'HR Specialist', NULL);
INSERT INTO [Employees] ([Dni], [DepartmentName], [Name], [Email], [Phone], [Position], [Image]) VALUES ('89012345I', 'SALES', 'Pedro Hernández', 'pedro.hernandez@example.com', '555444333', 'Sales Team Lead', NULL);
