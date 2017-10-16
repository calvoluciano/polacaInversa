/*CREO NUEVO ESQUEMA */
CREATE SCHEMA [POLACA_INVERSA] AUTHORIZATION [gd];
GO

/*CREO LA TABLA DE USUARIOS */

CREATE TABLE [POLACA_INVERSA].USUARIOS(
	ID_USUARIO INT PRIMARY KEY IDENTITY(1,1),
	USERNAME VARCHAR(250),
	PASSWORD VARCHAR(250),
	ID_ROL INT,
	ID_SUCURSAL INT,
	HABILITADO TINYINT DEFAULT 1
);
GO
/*CREO LA TABLA DE ROLES */
CREATE TABLE [POLACA_INVERSA].ROLES (
	ID_ROL INT IDENTITY(1,1) PRIMARY KEY,
	NOMBRE_ROL VARCHAR(250) UNIQUE,
	HABILITADO TINYINT DEFAULT 1
);
GO
/*CREO LA TABLA DE ROLES POR USUARIO*/
CREATE TABLE [POLACA_INVERSA].ROL_USUARIO (
	ID_USUARIO INT NOT NULL,
	ID_ROL INT NOT NULL
);
GO
/*CREO LA TABLA DE ACCESOS*/
CREATE TABLE [POLACA_INVERSA].ACCESOS (
	ID_ACCESO INT IDENTITY(1,1) PRIMARY KEY,
	NOMBRE VARCHAR(100) UNIQUE,
);
GO
/*CREO LA TABLA DE ROL POR ACCESOS*/
CREATE TABLE [POLACA_INVERSA].ROL_ACCESOS (
	ID_ROL INT NOT NULL,
	ID_ACCESO INT NOT NULL,
);
GO
/*CREO LA TABLA DE FACTURAS */
CREATE TABLE [POLACA_INVERSA].FACTURAS (
	ID_FACTURA INT PRIMARY KEY,
	CUIT VARCHAR(50),
	DNI_CLIENTE VARCHAR(50),
	ID_PAGO INT,
	ID_RENDICION INT,
	ID_DEVOLUCION INT,
	FECHA_ALTA DATETIME,
	FECHA_VENCIMIENTO DATETIME,
	TOTAL INT
);
GO
/*CREO LA TABLA DE PAGOS */
CREATE TABLE [POLACA_INVERSA].PAGOS (
	ID_PAGO INT PRIMARY KEY,
	ID_SUCURSAL INT,
	FECHA_PAGO DATETIME,
	TOTAL_PAGO INT
);
GO
/*CREO LA TABLA DE SUCURSALES*/
CREATE TABLE [POLACA_INVERSA].SUCURSALES (
	ID_SUCURSAL INT IDENTITY(1,1) PRIMARY KEY,
	NOMBRE VARCHAR(250),
	DIRECCION VARCHAR(250),
	CODIGO_POSTAL INT,
	ESTADO_SUCURSAL INT
);
GO
/*CREO LA TABLA DE SUCURSAL POR USUARIO*/
CREATE TABLE [POLACA_INVERSA].SUCURSAL_USUARIO (
	ID_USUARIO INT NOT NULL,
	ID_SUCURSAL INT NOT NULL
);
GO
/*CREO LA TABLA DE CLIENTES*/
CREATE TABLE [POLACA_INVERSA].CLIENTES (
	ID_CLIENTE INT PRIMARY KEY IDENTITY(1,1),
	DNI VARCHAR(20) UNIQUE,
	NOMBRE VARCHAR(250),
	APELLIDO VARCHAR(250),
	MAIL VARCHAR(100),
	DIRECCION VARCHAR(100),
	CODIGO_POSTAL INT,
	FECHA_NACIMIENTO DATETIME
);
GO
/* CREO LAS PRIMARY KEY COMPUESTAS  */
alter table [POLACA_INVERSA].ROL_USUARIO add constraint PK_ROL_USUARIO
	primary key clustered (ID_USUARIO,ID_ROL);
GO
alter table [POLACA_INVERSA].ROL_ACCESOS add constraint PK_ROL_ACCESOS
	primary key clustered (ID_ROL,ID_ACCESO);
GO
alter table [POLACA_INVERSA].SUCURSAL_USUARIO add constraint PK_SUCURSAL_USUARIO
	primary key clustered (ID_USUARIO,ID_SUCURSAL);
GO

/*CREO LAS FOREIGN KEY*/ 

alter table [POLACA_INVERSA].ROL_ACCESOS add constraint FK1_ROL_ACCESOS
	foreign key (ID_ROL) references [POLACA_INVERSA].ROLES (ID_ROL);
GO
alter table [POLACA_INVERSA].ROL_ACCESOS add constraint FK2_ROL_ACCESOS
	foreign key (ID_ACCESO) references [POLACA_INVERSA].ACCESOS (ID_ACCESO);
GO	
alter table [POLACA_INVERSA].ROL_USUARIO add constraint FK1_ROL_USUARIO
	foreign key (ID_ROL) references [POLACA_INVERSA].ROLES (ID_ROL);
GO	
alter table [POLACA_INVERSA].ROL_USUARIO add constraint FK2_ROL_USUARIO
	foreign key (ID_USUARIO) references [POLACA_INVERSA].USUARIOS (ID_USUARIO);
GO
alter table [POLACA_INVERSA].SUCURSAL_USUARIO add constraint FK1_SUCURSAL_USUARIO
	foreign key (ID_USUARIO) references [POLACA_INVERSA].USUARIOS (ID_USUARIO);
GO
alter table [POLACA_INVERSA].SUCURSAL_USUARIO add constraint FK2_SUCURSAL_USUARIO
	foreign key (ID_SUCURSAL) references [POLACA_INVERSA].SUCURSALES (ID_SUCURSAL);
GO

/* -- MIGRACION -- */

/*Para ejecutar las procedures una vez creadas, ejecutar: [POLACA_INVERSA].NombreProcedure */

CREATE PROCEDURE [POLACA_INVERSA].MigrarClientes
AS
BEGIN

	INSERT INTO [POLACA_INVERSA].CLIENTES(NOMBRE, APELLIDO, DNI, MAIL, DIRECCION, CODIGO_POSTAL, FECHA_NACIMIENTO)
	SELECT DISTINCT Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Mail, Cliente_Direccion, Cliente_Codigo_Postal, Cliente_Fecha_Nac) 
	FROM gd_esquema.Maestra

END;
GO 