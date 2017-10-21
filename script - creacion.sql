use GD2C2017
go

/*Se eliminan objetos existentes*/

IF OBJECT_ID('POLACA_INVERSA.ROL_ACCESOS','U') IS NOT NULL
    DROP TABLE POLACA_INVERSA.ROL_ACCESOS;

IF OBJECT_ID('POLACA_INVERSA.ACCESOS','U') IS NOT NULL
    DROP TABLE POLACA_INVERSA.ACCESOS;

IF OBJECT_ID('POLACA_INVERSA.ROL_USUARIO','U') IS NOT NULL
    DROP TABLE POLACA_INVERSA.ROL_USUARIO;

IF OBJECT_ID('POLACA_INVERSA.ROLES','U') IS NOT NULL
    DROP TABLE POLACA_INVERSA.ROLES;

IF OBJECT_ID('POLACA_INVERSA.SUCURSAL_USUARIO','U') IS NOT NULL
    DROP TABLE POLACA_INVERSA.SUCURSAL_USUARIO;

IF OBJECT_ID('POLACA_INVERSA.USUARIOS','U') IS NOT NULL
    DROP TABLE POLACA_INVERSA.USUARIOS;
	
IF OBJECT_ID('POLACA_INVERSA.PAGOS','U') IS NOT NULL
    DROP TABLE POLACA_INVERSA.SUCURSALES;

IF OBJECT_ID('POLACA_INVERSA.PAGOS','U') IS NOT NULL
    DROP TABLE POLACA_INVERSA.PAGOS;
	
IF OBJECT_ID('POLACA_INVERSA.FACTURAS','U') IS NOT NULL
    DROP TABLE POLACA_INVERSA.FACTURAS;

IF OBJECT_ID('POLACA_INVERSA.CLIENTES','U') IS NOT NULL
    DROP TABLE POLACA_INVERSA.CLIENTES;

IF OBJECT_ID('POLACA_INVERSA.SPLOGIN') IS NOT NULL
    DROP PROCEDURE POLACA_INVERSA.SPLOGIN;

IF OBJECT_ID('POLACA_INVERSA.USUARIO_GET_ID') IS NOT NULL
    DROP FUNCTION POLACA_INVERSA.USUARIO_GET_ID;
	
IF OBJECT_ID('LOS_MODERADAMENTE_ADECUADOS.USUARIO_GET_ROLES') IS NOT NULL
    DROP FUNCTION LOS_MODERADAMENTE_ADECUADOS.USUARIO_GET_ROLES;
	
IF OBJECT_ID('POLACA_INVERSA.MigrarClientes') IS NOT NULL
    DROP PROCEDURE POLACA_INVERSA.MigrarClientes;

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'POLACA_INVERSA')
    DROP SCHEMA POLACA_INVERSA
GO
	
/*CREO NUEVO ESQUEMA */

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'POLACA_INVERSA')
  BEGIN
    EXEC ('CREATE SCHEMA POLACA_INVERSA;');
  END;

/*CREO LA TABLA DE USUARIOS */

CREATE TABLE [POLACA_INVERSA].USUARIOS(
	ID_USUARIO INT PRIMARY KEY IDENTITY(1,1),
	USERNAME NVARCHAR(20) UNIQUE NOT NULL,
	PASSWORD VARBINARY(250) NOT NULL,
	ID_ROL INT,
	ID_SUCURSAL INT,
	HABILITADO BIT NOT NULL,
	INTENTOS TINYINT NOT NULL
);
GO
/*CREO LA TABLA DE ROLES */
CREATE TABLE [POLACA_INVERSA].ROLES (
	ID_ROL TINYINT IDENTITY(1,1) PRIMARY KEY,
	NOMBRE_ROL VARCHAR(250) UNIQUE,
	HABILITADO BIT NOT NULL
);
GO
/*CREO LA TABLA DE ROLES POR USUARIO*/
CREATE TABLE [POLACA_INVERSA].ROL_USUARIO (
	ID_USUARIO INT FOREIGN KEY REFERENCES POLACA_INVERSA.USUARIOS(Id_Usuario),
	ID_ROL TINYINT FOREIGN KEY REFERENCES POLACA_INVERSA.ROLES(Id_Rol),
	PRIMARY KEY(ID_USUARIO,ID_ROL)
);
GO
/*CREO LA TABLA DE ACCESOS*/
CREATE TABLE [POLACA_INVERSA].ACCESOS (
	ID_ACCESO TINYINT IDENTITY(1,1) PRIMARY KEY,
	NOMBRE VARCHAR(100) UNIQUE,
);
GO
/*CREO LA TABLA DE ROL POR ACCESOS*/
CREATE TABLE [POLACA_INVERSA].ROL_ACCESOS (
	ID_ROL TINYINT FOREIGN KEY REFERENCES POLACA_INVERSA.ROLES(Id_Rol),
	ID_ACCESO TINYINT FOREIGN KEY REFERENCES POLACA_INVERSA.ACCESOS(Id_Acceso),
	PRIMARY KEY (ID_ROL,ID_ACCESO)
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
/* CREO LAS PRIMARY KEY COMPUESTAS  
alter table [POLACA_INVERSA].ROL_USUARIO add constraint PK_ROL_USUARIO
	primary key clustered (ID_USUARIO,ID_ROL);
GO
alter table [POLACA_INVERSA].ROL_ACCESOS add constraint PK_ROL_ACCESOS
	primary key clustered (ID_ROL,ID_ACCESO);
GO*/
alter table [POLACA_INVERSA].SUCURSAL_USUARIO add constraint PK_SUCURSAL_USUARIO
	primary key clustered (ID_USUARIO,ID_SUCURSAL);
GO

/*CREO LAS FOREIGN KEY*/ 
/*
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
GO*/
alter table [POLACA_INVERSA].SUCURSAL_USUARIO add constraint FK1_SUCURSAL_USUARIO
	foreign key (ID_USUARIO) references [POLACA_INVERSA].USUARIOS (ID_USUARIO);
GO
alter table [POLACA_INVERSA].SUCURSAL_USUARIO add constraint FK2_SUCURSAL_USUARIO
	foreign key (ID_SUCURSAL) references [POLACA_INVERSA].SUCURSALES (ID_SUCURSAL);
GO

-- Funciones

CREATE FUNCTION POLACA_INVERSA.USUARIO_GET_ID(@usuario VARCHAR(20)) RETURNS INT AS
BEGIN
	RETURN	(SELECT id_usuario
			FROM POLACA_INVERSA.Usuarios
			WHERE username = @usuario)
END
GO

CREATE FUNCTION POLACA_INVERSA.USUARIO_GET_ROLES(@usuarioId int) RETURNS TABLE
AS
	RETURN	(SELECT nombre_rol AS Nombre, R.ID_ROL, habilitado AS Habilitado
				FROM POLACA_INVERSA.ROLES as R
					JOIN POLACA_INVERSA.ROL_USUARIO as R_U ON  R_U.ID_ROL= R.ID_ROL
				WHERE R_U.ID_USUARIO = @usuarioId)
GO
					
-- Procedimientos

CREATE PROC POLACA_INVERSA.SPLOGIN
	@usuario varchar(20),
	@contrasenia varbinary(256)
AS
BEGIN

	DECLARE @pass varbinary(256), @intentos TINYINT, @habilitado BIT

	SELECT @pass=password, @intentos=intentos, @habilitado = habilitado
	FROM POLACA_INVERSA.USUARIOS
	WHERE username = @usuario

	IF (@pass IS NULL) 
	BEGIN
		RAISERROR ('Usuario inexistente!', 16, 1)
		RETURN
	END

	IF (@habilitado = 0) 
	BEGIN
		RAISERROR ('Usuario inhabilitado!', 16, 1)
		RETURN
	END

	IF (@pass <> @contrasenia) 
	BEGIN
		UPDATE POLACA_INVERSA.USUARIOS SET intentos = @intentos + 1
		WHERE username = @usuario
		DECLARE @error varchar(100)= 'Contrasenia Incorrecta! Intentos restantes: ' + str(2 - @intentos)
		RAISERROR (@error, 16, 1)

		IF(@intentos = 2)
		BEGIN
			UPDATE POLACA_INVERSA.USUARIOS SET habilitado = 0
			WHERE username = @usuario
		END
		RETURN
	END

	UPDATE POLACA_INVERSA.USUARIOS SET intentos = 0
	WHERE username = @usuario

END
GO



/* -- MIGRACION -- */

/*Para ejecutar las procedures una vez creadas, ejecutar: [POLACA_INVERSA].NombreProcedure */

CREATE PROCEDURE [POLACA_INVERSA].MigrarClientes
AS
BEGIN

	INSERT INTO [POLACA_INVERSA].CLIENTES(NOMBRE, APELLIDO, DNI, MAIL, DIRECCION, CODIGO_POSTAL, FECHA_NACIMIENTO)
	SELECT DISTINCT "Cliente-Nombre", "Cliente-Apellido", "Cliente-Dni", Cliente_Mail, Cliente_Direccion, Cliente_Codigo_Postal, "Cliente-Fecha_Nac"
	FROM gd_esquema.Maestra

END;
GO

--Usuario Administrador

INSERT INTO POLACA_INVERSA.USUARIOS (USERNAME,PASSWORD,HABILITADO,INTENTOS)
values('admin',(SELECT CONVERT(VARBINARY(250), '0XE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 1)),1,0);

--Rol

INSERT POLACA_INVERSA.ROLES (nombre_rol, habilitado)
VALUES	('Administrador', 1),
		('Cobrador', 1)
		
--ACCESOS
INSERT POLACA_INVERSA.ACCESOS (nombre)
VALUES	('ABM de Rol'),
		('ABM de Cliente'),
		('ABM de Empresa'),
		('ABM de Factura'),
		('ABM de Sucursal'),
		('Registro de Pago'),
		('Fegistro de Rendicion'),
		('Listado Estadistico')

--Accesos x Rol
INSERT POLACA_INVERSA.ROL_ACCESOS (id_rol, id_acceso)
	VALUES (1, 1), (1,2), (1,3),(1,5)

-- Rol_X_Usuario

INSERT POLACA_INVERSA.ROL_USUARIO (id_usuario, id_rol)
VALUES (1,1)

EXEC [POLACA_INVERSA].MigrarClientes
go