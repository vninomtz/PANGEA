
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/18/2020 01:25:29
-- Generated from EDMX file: C:\Users\IvanGutru\Desktop\SextoSemestre\2.-DesarrolloDeSoftware\PANGEA\DataAccess\EntityModelPangea.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Pangea];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Actividades_Articulos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actividades] DROP CONSTRAINT [FK_Actividades_Articulos];
GO
IF OBJECT_ID(N'[dbo].[FK_Actividades_Eventos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actividades] DROP CONSTRAINT [FK_Actividades_Eventos];
GO
IF OBJECT_ID(N'[dbo].[FK_ConceptosFinancieros_Actividades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConceptosFinancieros] DROP CONSTRAINT [FK_ConceptosFinancieros_Actividades];
GO
IF OBJECT_ID(N'[dbo].[FK_Horarios_Actividades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Horarios] DROP CONSTRAINT [FK_Horarios_Actividades];
GO
IF OBJECT_ID(N'[dbo].[FK_IncripcionActividades_Actividades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IncripcionActividades] DROP CONSTRAINT [FK_IncripcionActividades_Actividades];
GO
IF OBJECT_ID(N'[dbo].[FK_Materiales_Actividades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Materiales] DROP CONSTRAINT [FK_Materiales_Actividades];
GO
IF OBJECT_ID(N'[dbo].[FK_Tareas_Actividades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tareas] DROP CONSTRAINT [FK_Tareas_Actividades];
GO
IF OBJECT_ID(N'[dbo].[FK_Articulos_Tracks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK_Articulos_Tracks];
GO
IF OBJECT_ID(N'[dbo].[FK_AsistentesEvento_Asistentes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsistentesEvento] DROP CONSTRAINT [FK_AsistentesEvento_Asistentes];
GO
IF OBJECT_ID(N'[dbo].[FK_IncripcionActividades_Asistentes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IncripcionActividades] DROP CONSTRAINT [FK_IncripcionActividades_Asistentes];
GO
IF OBJECT_ID(N'[dbo].[FK_Personal_Comites]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal] DROP CONSTRAINT [FK_Personal_Comites];
GO
IF OBJECT_ID(N'[dbo].[FK_ConceptosFinancieros_Presupuestos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConceptosFinancieros] DROP CONSTRAINT [FK_ConceptosFinancieros_Presupuestos];
GO
IF OBJECT_ID(N'[dbo].[FK_Personal_Cuentas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal] DROP CONSTRAINT [FK_Personal_Cuentas];
GO
IF OBJECT_ID(N'[dbo].[FK_AsistentesEvento_Eventos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsistentesEvento] DROP CONSTRAINT [FK_AsistentesEvento_Eventos];
GO
IF OBJECT_ID(N'[dbo].[FK_Materiales_Eventos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Materiales] DROP CONSTRAINT [FK_Materiales_Eventos];
GO
IF OBJECT_ID(N'[dbo].[FK_Personal_Eventos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal] DROP CONSTRAINT [FK_Personal_Eventos];
GO
IF OBJECT_ID(N'[dbo].[FK_Presupuestos_Eventos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Presupuestos] DROP CONSTRAINT [FK_Presupuestos_Eventos];
GO
IF OBJECT_ID(N'[dbo].[FK_Tracks_Eventos1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tracks] DROP CONSTRAINT [FK_Tracks_Eventos1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Actividades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actividades];
GO
IF OBJECT_ID(N'[dbo].[Articulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articulos];
GO
IF OBJECT_ID(N'[dbo].[Asistentes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Asistentes];
GO
IF OBJECT_ID(N'[dbo].[Comites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comites];
GO
IF OBJECT_ID(N'[dbo].[ConceptosFinancieros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConceptosFinancieros];
GO
IF OBJECT_ID(N'[dbo].[Cuentas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuentas];
GO
IF OBJECT_ID(N'[dbo].[Eventos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Eventos];
GO
IF OBJECT_ID(N'[dbo].[Horarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Horarios];
GO
IF OBJECT_ID(N'[dbo].[Materiales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materiales];
GO
IF OBJECT_ID(N'[dbo].[Personal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal];
GO
IF OBJECT_ID(N'[dbo].[Presupuestos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Presupuestos];
GO
IF OBJECT_ID(N'[dbo].[Tareas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tareas];
GO
IF OBJECT_ID(N'[dbo].[Tracks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tracks];
GO
IF OBJECT_ID(N'[dbo].[AsistentesEvento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AsistentesEvento];
GO
IF OBJECT_ID(N'[dbo].[IncripcionActividades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncripcionActividades];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Actividades'
CREATE TABLE [dbo].[Actividades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdEvento] int  NOT NULL,
    [Titulo] nvarchar(100)  NOT NULL,
    [Descripcion] varchar(max)  NOT NULL,
    [Gratuito] bit  NOT NULL,
    [Costo] float  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [Tipo] nvarchar(50)  NOT NULL,
    [UltimaModificacion] datetime  NULL,
    [IdArticulo] int  NULL,
    [Cupo] int  NULL
);
GO

-- Creating table 'Articulos'
CREATE TABLE [dbo].[Articulos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(50)  NOT NULL,
    [descripcion] nvarchar(50)  NOT NULL,
    [fecha_creacion] datetime  NOT NULL,
    [ultima_actualizacion] datetime  NOT NULL,
    [autor] nvarchar(50)  NOT NULL,
    [archivo] varchar(max)  NOT NULL,
    [idTrack] int  NOT NULL
);
GO

-- Creating table 'Asistentes'
CREATE TABLE [dbo].[Asistentes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Apellido] nvarchar(50)  NOT NULL,
    [Correo] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'Comites'
CREATE TABLE [dbo].[Comites] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(100)  NOT NULL,
    [Descripcion] varchar(max)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [UltimaModificacion] datetime  NULL,
    [IdEvento] int  NOT NULL
);
GO

-- Creating table 'ConceptosFinancieros'
CREATE TABLE [dbo].[ConceptosFinancieros] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tipo] nvarchar(50)  NOT NULL,
    [Monto] float  NOT NULL,
    [Concepto] nvarchar(50)  NOT NULL,
    [Fecha_creacion] datetime  NOT NULL,
    [IdActividad] int  NOT NULL,
    [IdPresupuesto] int  NULL
);
GO

-- Creating table 'Cuentas'
CREATE TABLE [dbo].[Cuentas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Apellido] nvarchar(50)  NOT NULL,
    [Correo] nvarchar(510)  NOT NULL,
    [Contrasenia] nvarchar(50)  NOT NULL,
    [Telefono] nvarchar(10)  NULL,
    [Token] nvarchar(250)  NULL,
    [UltimoAcceso] datetime  NULL
);
GO

-- Creating table 'Eventos'
CREATE TABLE [dbo].[Eventos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodigoEvento] nvarchar(50)  NOT NULL,
    [Nombre] nvarchar(150)  NOT NULL,
    [Descripcion] varchar(max)  NOT NULL,
    [Eliminado] bit  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFin] datetime  NOT NULL,
    [Lugar] nvarchar(150)  NOT NULL,
    [Gratuito] bit  NOT NULL,
    [Costo] float  NULL
);
GO

-- Creating table 'Horarios'
CREATE TABLE [dbo].[Horarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Direccion] nvarchar(150)  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFin] datetime  NOT NULL,
    [Lugar] nvarchar(150)  NOT NULL,
    [IdActividad] int  NOT NULL
);
GO

-- Creating table 'Materiales'
CREATE TABLE [dbo].[Materiales] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Descripcion] varchar(max)  NOT NULL,
    [Cantidad] int  NOT NULL,
    [IdActividad] int  NOT NULL,
    [IdEvento] int  NULL
);
GO

-- Creating table 'Personal'
CREATE TABLE [dbo].[Personal] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Asignado] bit  NOT NULL,
    [Cargo] nvarchar(50)  NULL,
    [IdEvento] int  NOT NULL,
    [IdCuenta] int  NOT NULL,
    [IdComite] int  NULL
);
GO

-- Creating table 'Presupuestos'
CREATE TABLE [dbo].[Presupuestos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Gasto_tentativo] float  NOT NULL,
    [Gasto_real] float  NULL,
    [IdEvento] int  NULL
);
GO

-- Creating table 'Tareas'
CREATE TABLE [dbo].[Tareas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Descripcion] varchar(max)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [Finalizada] bit  NOT NULL,
    [Responsable] nvarchar(50)  NOT NULL,
    [UltimaModificacion] datetime  NULL,
    [FechaFinalizacion] datetime  NULL,
    [IdActividad] int  NOT NULL
);
GO

-- Creating table 'Tracks'
CREATE TABLE [dbo].[Tracks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] varchar(max)  NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [IdEvento] int  NULL
);
GO

-- Creating table 'AsistentesEvento'
CREATE TABLE [dbo].[AsistentesEvento] (
    [Asistencia] bit  NOT NULL,
    [Pago] bit  NOT NULL,
    [Cantidad] float  NOT NULL,
    [IdAsistente] int  NOT NULL,
    [IdEvento] int  NOT NULL
);
GO

-- Creating table 'IncripcionActividades'
CREATE TABLE [dbo].[IncripcionActividades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [asistencia] bit  NOT NULL,
    [pago] bit  NOT NULL,
    [fecha_inscripcion] datetime  NOT NULL,
    [idActividad] int  NOT NULL,
    [idAsistente] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [PK_Actividades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [PK_Articulos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Asistentes'
ALTER TABLE [dbo].[Asistentes]
ADD CONSTRAINT [PK_Asistentes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comites'
ALTER TABLE [dbo].[Comites]
ADD CONSTRAINT [PK_Comites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConceptosFinancieros'
ALTER TABLE [dbo].[ConceptosFinancieros]
ADD CONSTRAINT [PK_ConceptosFinancieros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cuentas'
ALTER TABLE [dbo].[Cuentas]
ADD CONSTRAINT [PK_Cuentas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Eventos'
ALTER TABLE [dbo].[Eventos]
ADD CONSTRAINT [PK_Eventos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Horarios'
ALTER TABLE [dbo].[Horarios]
ADD CONSTRAINT [PK_Horarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Materiales'
ALTER TABLE [dbo].[Materiales]
ADD CONSTRAINT [PK_Materiales]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personal'
ALTER TABLE [dbo].[Personal]
ADD CONSTRAINT [PK_Personal]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Presupuestos'
ALTER TABLE [dbo].[Presupuestos]
ADD CONSTRAINT [PK_Presupuestos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [PK_Tareas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tracks'
ALTER TABLE [dbo].[Tracks]
ADD CONSTRAINT [PK_Tracks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Asistencia], [Pago], [Cantidad], [IdAsistente], [IdEvento] in table 'AsistentesEvento'
ALTER TABLE [dbo].[AsistentesEvento]
ADD CONSTRAINT [PK_AsistentesEvento]
    PRIMARY KEY CLUSTERED ([Asistencia], [Pago], [Cantidad], [IdAsistente], [IdEvento] ASC);
GO

-- Creating primary key on [id] in table 'IncripcionActividades'
ALTER TABLE [dbo].[IncripcionActividades]
ADD CONSTRAINT [PK_IncripcionActividades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdArticulo] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [FK_Actividades_Articulos]
    FOREIGN KEY ([IdArticulo])
    REFERENCES [dbo].[Articulos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Actividades_Articulos'
CREATE INDEX [IX_FK_Actividades_Articulos]
ON [dbo].[Actividades]
    ([IdArticulo]);
GO

-- Creating foreign key on [IdEvento] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [FK_Actividades_Eventos]
    FOREIGN KEY ([IdEvento])
    REFERENCES [dbo].[Eventos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Actividades_Eventos'
CREATE INDEX [IX_FK_Actividades_Eventos]
ON [dbo].[Actividades]
    ([IdEvento]);
GO

-- Creating foreign key on [IdActividad] in table 'ConceptosFinancieros'
ALTER TABLE [dbo].[ConceptosFinancieros]
ADD CONSTRAINT [FK_ConceptosFinancieros_Actividades]
    FOREIGN KEY ([IdActividad])
    REFERENCES [dbo].[Actividades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConceptosFinancieros_Actividades'
CREATE INDEX [IX_FK_ConceptosFinancieros_Actividades]
ON [dbo].[ConceptosFinancieros]
    ([IdActividad]);
GO

-- Creating foreign key on [IdActividad] in table 'Horarios'
ALTER TABLE [dbo].[Horarios]
ADD CONSTRAINT [FK_Horarios_Actividades]
    FOREIGN KEY ([IdActividad])
    REFERENCES [dbo].[Actividades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Horarios_Actividades'
CREATE INDEX [IX_FK_Horarios_Actividades]
ON [dbo].[Horarios]
    ([IdActividad]);
GO

-- Creating foreign key on [idActividad] in table 'IncripcionActividades'
ALTER TABLE [dbo].[IncripcionActividades]
ADD CONSTRAINT [FK_IncripcionActividades_Actividades]
    FOREIGN KEY ([idActividad])
    REFERENCES [dbo].[Actividades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IncripcionActividades_Actividades'
CREATE INDEX [IX_FK_IncripcionActividades_Actividades]
ON [dbo].[IncripcionActividades]
    ([idActividad]);
GO

-- Creating foreign key on [IdActividad] in table 'Materiales'
ALTER TABLE [dbo].[Materiales]
ADD CONSTRAINT [FK_Materiales_Actividades]
    FOREIGN KEY ([IdActividad])
    REFERENCES [dbo].[Actividades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Materiales_Actividades'
CREATE INDEX [IX_FK_Materiales_Actividades]
ON [dbo].[Materiales]
    ([IdActividad]);
GO

-- Creating foreign key on [IdActividad] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK_Tareas_Actividades]
    FOREIGN KEY ([IdActividad])
    REFERENCES [dbo].[Actividades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tareas_Actividades'
CREATE INDEX [IX_FK_Tareas_Actividades]
ON [dbo].[Tareas]
    ([IdActividad]);
GO

-- Creating foreign key on [idTrack] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK_Articulos_Tracks]
    FOREIGN KEY ([idTrack])
    REFERENCES [dbo].[Tracks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Articulos_Tracks'
CREATE INDEX [IX_FK_Articulos_Tracks]
ON [dbo].[Articulos]
    ([idTrack]);
GO

-- Creating foreign key on [IdAsistente] in table 'AsistentesEvento'
ALTER TABLE [dbo].[AsistentesEvento]
ADD CONSTRAINT [FK_AsistentesEvento_Asistentes]
    FOREIGN KEY ([IdAsistente])
    REFERENCES [dbo].[Asistentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AsistentesEvento_Asistentes'
CREATE INDEX [IX_FK_AsistentesEvento_Asistentes]
ON [dbo].[AsistentesEvento]
    ([IdAsistente]);
GO

-- Creating foreign key on [idAsistente] in table 'IncripcionActividades'
ALTER TABLE [dbo].[IncripcionActividades]
ADD CONSTRAINT [FK_IncripcionActividades_Asistentes]
    FOREIGN KEY ([idAsistente])
    REFERENCES [dbo].[Asistentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IncripcionActividades_Asistentes'
CREATE INDEX [IX_FK_IncripcionActividades_Asistentes]
ON [dbo].[IncripcionActividades]
    ([idAsistente]);
GO

-- Creating foreign key on [IdComite] in table 'Personal'
ALTER TABLE [dbo].[Personal]
ADD CONSTRAINT [FK_Personal_Comites]
    FOREIGN KEY ([IdComite])
    REFERENCES [dbo].[Comites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Personal_Comites'
CREATE INDEX [IX_FK_Personal_Comites]
ON [dbo].[Personal]
    ([IdComite]);
GO

-- Creating foreign key on [IdPresupuesto] in table 'ConceptosFinancieros'
ALTER TABLE [dbo].[ConceptosFinancieros]
ADD CONSTRAINT [FK_ConceptosFinancieros_Presupuestos]
    FOREIGN KEY ([IdPresupuesto])
    REFERENCES [dbo].[Presupuestos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConceptosFinancieros_Presupuestos'
CREATE INDEX [IX_FK_ConceptosFinancieros_Presupuestos]
ON [dbo].[ConceptosFinancieros]
    ([IdPresupuesto]);
GO

-- Creating foreign key on [IdCuenta] in table 'Personal'
ALTER TABLE [dbo].[Personal]
ADD CONSTRAINT [FK_Personal_Cuentas]
    FOREIGN KEY ([IdCuenta])
    REFERENCES [dbo].[Cuentas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Personal_Cuentas'
CREATE INDEX [IX_FK_Personal_Cuentas]
ON [dbo].[Personal]
    ([IdCuenta]);
GO

-- Creating foreign key on [IdEvento] in table 'AsistentesEvento'
ALTER TABLE [dbo].[AsistentesEvento]
ADD CONSTRAINT [FK_AsistentesEvento_Eventos]
    FOREIGN KEY ([IdEvento])
    REFERENCES [dbo].[Eventos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AsistentesEvento_Eventos'
CREATE INDEX [IX_FK_AsistentesEvento_Eventos]
ON [dbo].[AsistentesEvento]
    ([IdEvento]);
GO

-- Creating foreign key on [IdEvento] in table 'Materiales'
ALTER TABLE [dbo].[Materiales]
ADD CONSTRAINT [FK_Materiales_Eventos]
    FOREIGN KEY ([IdEvento])
    REFERENCES [dbo].[Eventos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Materiales_Eventos'
CREATE INDEX [IX_FK_Materiales_Eventos]
ON [dbo].[Materiales]
    ([IdEvento]);
GO

-- Creating foreign key on [IdEvento] in table 'Personal'
ALTER TABLE [dbo].[Personal]
ADD CONSTRAINT [FK_Personal_Eventos]
    FOREIGN KEY ([IdEvento])
    REFERENCES [dbo].[Eventos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Personal_Eventos'
CREATE INDEX [IX_FK_Personal_Eventos]
ON [dbo].[Personal]
    ([IdEvento]);
GO

-- Creating foreign key on [IdEvento] in table 'Presupuestos'
ALTER TABLE [dbo].[Presupuestos]
ADD CONSTRAINT [FK_Presupuestos_Eventos]
    FOREIGN KEY ([IdEvento])
    REFERENCES [dbo].[Eventos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Presupuestos_Eventos'
CREATE INDEX [IX_FK_Presupuestos_Eventos]
ON [dbo].[Presupuestos]
    ([IdEvento]);
GO

-- Creating foreign key on [IdEvento] in table 'Tracks'
ALTER TABLE [dbo].[Tracks]
ADD CONSTRAINT [FK_Tracks_Eventos1]
    FOREIGN KEY ([IdEvento])
    REFERENCES [dbo].[Eventos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tracks_Eventos1'
CREATE INDEX [IX_FK_Tracks_Eventos1]
ON [dbo].[Tracks]
    ([IdEvento]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------