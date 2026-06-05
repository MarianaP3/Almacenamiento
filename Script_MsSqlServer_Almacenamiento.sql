CREATE DATABASE Almacenamiento
DROP DATABASE Almacenamiento
USE Almacenamiento

-- Esquemas

CREATE SCHEMA almacen
CREATE SCHEMA logistica

-- Tablas

CREATE TABLE almacen.Proveedor
(
	IdProveedor BIGINT IDENTITY (1,1) NOT NULL,
	NombreProveedor VARCHAR(100) NOT NULL,
	TelefonoProveedor VARCHAR(10) NOT NULL,
	CorreoProveedor VARCHAR(100) NOT NULL,
	DomicilioFiscal VARCHAR(100) NOT NULL,

	CONSTRAINT PK_PROVEEDOR PRIMARY KEY (IdProveedor)
)

ALTER TABLE almacen.Proveedor
ADD CONSTRAINT UQ_CORREO_PROVEEDOR UNIQUE (CorreoProveedor),
    CONSTRAINT UQ_TELEFONO_PROVEEDOR UNIQUE (TelefonoProveedor);

CREATE TABLE logistica.Cliente
(
	IdCliente BIGINT IDENTITY (1,1) NOT NULL,
	NombreCliente VARCHAR(100) NOT NULL,
	CorreoCliente VARCHAR(100) NOT NULL,
	TelefonoCliente VARCHAR(10) NOT NULL,

	CONSTRAINT PK_CLIENTE PRIMARY KEY (IdCliente)
)

CREATE TABLE almacen.Anaquel
(
	IdAnaquel BIGINT IDENTITY (1,1) NOT NULL,
	Columna INT NOT NULL,
	Fila INT NOT NULL,
	Nivel INT NOT NULL,
	Capacidad INT,

	CONSTRAINT PK_ANAQUEL PRIMARY KEY (IdAnaquel)
)

CREATE TABLE logistica.Transporte
(
	IdTransporte BIGINT IDENTITY (1,1) NOT NULL,
	Transporte VARCHAR(100) NOT NULL,
	Marca VARCHAR(100) NOT NULL,
	Modelo VARCHAR(100) NOT NULL,
	Color VARCHAR(100) NOT NULL,
	Placa VARCHAR(100) NOT NULL,
	Capacidad INT,

	CONSTRAINT PK_TRANSPORTE PRIMARY KEY (IdTransporte),
	CONSTRAINT CHK_TRANSPORTE CHECK (Transporte IN ('Camión', 'Camioneta', 'Motocicleta', 'Coche'))
)

CREATE TABLE logistica.Transportista
(
	IdTransportista BIGINT IDENTITY (1,1) NOT NULL,
	NombreTransportista VARCHAR(100) NOT NULL,
	TelefonoTransportista VARCHAR(10) NOT NULL,
	CorreoTransportista VARCHAR(100) NOT NULL,
	HoraEntrada TIME NOT NULL,
	HoraSalida TIME NOT NULL,

	CONSTRAINT PK_TRANSPORTISTA PRIMARY KEY (IdTransportista)
)

CREATE TABLE logistica.DomicilioCliente
(
	IdDomicilio BIGINT IDENTITY (1,1) NOT NULL,
	IdCliente BIGINT NOT NULL,
	Calle VARCHAR(100) NOT NULL,
	NumeroInterior VARCHAR(100) ,
	NumeroExterior VARCHAR(100),
	Colonia VARCHAR(100) NOT NULL,
	CodigoPostal VARCHAR(10) NOT NULL,

	CONSTRAINT PK_DOMICILIO PRIMARY KEY (IdDomicilio),
	CONSTRAINT FK_CLIENTE FOREIGN KEY (IdCliente) REFERENCES logistica.Cliente(IdCliente)
)


CREATE TABLE almacen.Producto
(
	IdProducto BIGINT IDENTITY(1,1) NOT NULL,
	IdProveedor BIGINT NOT NULL,
	IdDomicilio BIGINT NOT NULL,
	NombreProducto VARCHAR(100) NOT NULL,
	Peso FLOAT NOT NULL,
	Dimensiones VARCHAR(50) NOT NULL,
	CostoEntrega MONEY,

	CONSTRAINT PK_PRODUCTO PRIMARY KEY (IdProducto),
	CONSTRAINT FK_PROVEEDOR FOREIGN KEY (IdProveedor) REFERENCES almacen.Proveedor(IdProveedor)
)




CREATE TABLE almacen.AlmacenamientoProducto
(
	IdAlmacenamiento BIGINT IDENTITY(1,1) NOT NULL,
	IdAnaquel BIGINT NOT NULL,
	IdProducto BIGINT NOT NULL,
	FechaEntrega DATE NOT NULL,
	FechaSalida DATE NOT NULL,

	CONSTRAINT PK_ALMACENAMIENTO PRIMARY KEY (IdAlmacenamiento),
	CONSTRAINT FK_ANAQUEL FOREIGN KEY (IdAnaquel) REFERENCES almacen.anaquel(IdAnaquel),
	CONSTRAINT FK_PRODUCTO FOREIGN KEY (IdProducto) REFERENCES almacen.Producto(IdProducto)
)

CREATE TABLE logistica.Ruta
(
	IdRuta BIGINT IDENTITY(1,1) NOT NULL,
	IdTransportista BIGINT NOT NULL,
	IdTransporte BIGINT NOT NULL,
	HoraSalida TIME NOT NULL,
	HoraRegreso TIME NOT NULL,

	CONSTRAINT PK_RUTA PRIMARY KEY (IdRuta),
	CONSTRAINT FK_TRANSPORTISTA FOREIGN KEY (IdTransportista) REFERENCES logistica.Transportista(IdTransportista),
	CONSTRAINT FK_TRANSPORTE FOREIGN KEY (IdTransporte) REFERENCES logistica.Transporte(IdTransporte)
)

CREATE TABLE logistica.Entrega
(
	IdEntrega BIGINT IDENTITY(1,1) NOT NULL,
	IdRuta BIGINT NOT NULL,
	FechaEntrega DATE NOT NULL,
	EstadoEntrega VARCHAR(50),
	TotalProductos INT,

	CONSTRAINT PK_ENTREGA PRIMARY KEY (IdEntrega),
	CONSTRAINT FK_RUTA FOREIGN KEY (IdRuta) REFERENCES logistica.Ruta(IdRuta),
	CONSTRAINT CHK_ESTADO CHECK (EstadoEntrega IN ('No entregado', 'En proceso', 'Entregado'))
)

CREATE TABLE logistica.DetalleEntrega
(
	IdEntrega BIGINT NOT NULL,
	IdAlmacenamiento BIGINT NOT NULL,
    FechaReporte DATETIME NOT NULL,



	CONSTRAINT FK_ENTREGA FOREIGN KEY (IdEntrega) REFERENCES logistica.entrega(IdEntrega),
	CONSTRAINT FK_ALMACENAMIENTO FOREIGN KEY (IdAlmacenamiento) REFERENCES almacen.AlmacenamientoProducto(IdAlmacenamiento)
)
/*
***************************************************************  Disparador  ***************************************************************
DISPARADOR 1#

El disparador TGR_COSTO_ENTREGA se activa después de insertar o actualizar un producto
calculando el costo del producto con base en sus dimensiones alto*largo*ancho en (in) y peso en (Kg).

*/

CREATE TRIGGER TGR_COSTO_ENTREGA
ON almacen.Producto
AFTER INSERT, UPDATE
AS
BEGIN 
	DECLARE @CostoEnvio MONEY;
	DECLARE @LargoPaquete FLOAT;
	DECLARE @AnchoPaquete FLOAT;
	DECLARE @AltoPaquete FLOAT;
	DECLARE @PesoPaquete FLOAT;
	DECLARE @Dimensiones VARCHAR(100);
	DECLARE @IdProducto BIGINT;

	SELECT @Dimensiones = i.Dimensiones, @PesoPaquete = i.Peso, @IdProducto = i.IdProducto
	FROM inserted i;

	-- Se asume que la cadena de Dimensiones tiene el formato: Largo*Alto*Ancho
	SET @LargoPaquete = CONVERT(FLOAT, LEFT(@Dimensiones, CHARINDEX('*', @Dimensiones) - 1));
    SET @Dimensiones = RIGHT(@Dimensiones, LEN(@Dimensiones) - CHARINDEX('*', @Dimensiones));

    SET @AltoPaquete = CONVERT(FLOAT, LEFT(@Dimensiones, CHARINDEX('*', @Dimensiones) - 1));
    SET @Dimensiones = RIGHT(@Dimensiones, LEN(@Dimensiones) - CHARINDEX('*', @Dimensiones));

    SET @AnchoPaquete = CONVERT(FLOAT, @Dimensiones);

	-- Se calcula el envío con la fórmula: (LargoPaquete+AltoPaquete+AnchoPaquete) * PesoPaquete
	SET @CostoEnvio = ( @LargoPaquete + @AltoPaquete + @AnchoPaquete ) * @PesoPaquete;
	
	--Se actualizan los campos correspondientes en la tabla
	UPDATE almacen.Producto
	SET CostoEntrega = @CostoEnvio
	WHERE IdProducto = @IdProducto
END;

/*
***************************************************************  Disparador  ***************************************************************
DISPARADOR 2#

El disparador TGR_DETALLE_ENTREGA se activa después de que se inserta un nuevo registro en la tabla logistica.DetalleEntrega.
Su función es actualizar el estado de la entrega y ajustar la capacidad disponible de los anaqueles cuando un producto es entregado.

*/


CREATE TRIGGER TGR_DETALLE_ENTREGA  
ON logistica.DetalleEntrega
AFTER INSERT
AS
BEGIN
	DECLARE @IdEntrega BIGINT;
	DECLARE @IdAlmacenamiento BIGINT;

	SELECT @IdEntrega = i.IdEntrega, @IdAlmacenamiento = i.IdAlmacenamiento
	FROM inserted i;

	UPDATE logistica.Entrega
	SET EstadoEntrega = 'En proceso'
	WHERE IdEntrega = @IdEntrega

	UPDATE almacen.Anaquel
	SET Capacidad = Capacidad+1
	WHERE IdAnaquel = (SELECT IdAnaquel FROM almacen.AlmacenamientoProducto WHERE IdAlmacenamiento = @IdAlmacenamiento);
END;
/*
***************************************************************  Disparador  ***************************************************************
DISPARADOR 3#

El disparador TGR_ALMACENAMIENTO_PRODUCTO ajusta automáticamente la capacidad disponible de un anaquel 
cuando un producto es almacenado o modificado el cual disminuye la capacidad.

*/
CREATE TRIGGER TGR_ALMACENAMIENTO_PRODUCTO
ON almacen.AlmacenamientoProducto
AFTER INSERT, Update
AS
BEGIN
	DECLARE @IdAnaquel BIGINT;
	
	SELECT @IdAnaquel = i.IdAnaquel
	FROM inserted i;

	UPDATE almacen.Anaquel
	SET Capacidad = Capacidad-1
	WHERE IdAnaquel = @IdAnaquel;
END;

/*
***************************************************************  Disparador  ***************************************************************
DISPARADOR 4#

Este disparador TGR_HORARIO_TRANSPORTISTA impide asignar rutas fuera del horario laboral de los transportistas en la tabla 
logistica.Ruta.

*/

CREATE TRIGGER TGR_HORARIO_TRANSPORTISTA
ON logistica.Ruta 
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @DentroHorario BIT;
	DECLARE @HoraSalidaRuta TIME;
	DECLARE @IdTransportista BIGINT;
	DECLARE @HoraEntradaTransp TIME;
    DECLARE @HoraSalidaTransp TIME;

	SELECT @HoraSalidaRuta = i.HoraSalida, @IdTransportista = i.IdTransportista
	FROM inserted i;

	SELECT @HoraEntradaTransp = t.HoraEntrada, @HoraSalidaTransp = t.HoraSalida
    FROM logistica.Transportista t
    WHERE t.IdTransportista = @IdTransportista;

	IF @HoraSalidaRuta BETWEEN @HoraEntradaTransp AND @HoraSalidaTransp
	BEGIN
		SET @DentroHorario = 1;
	END
	ELSE
	BEGIN
		SET @DentroHorario = 0;
	END

	-- Si no está dentro del horario del transportista
	IF @DentroHorario = 0
	BEGIN
		RAISERROR('El transportista no está disponible en el horario de la ruta asignada.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

	-- Si está dentro del horario del transportista
	INSERT INTO logistica.Ruta (HoraSalida, HoraRegreso, IdTransportista, IdTransporte)
    SELECT i.HoraSalida, i.HoraRegreso, i.IdTransportista, i.IdTransporte
    FROM inserted i;
END;

/*
***************************************************************  Disparador  ***************************************************************
DISPARADOR 5#

Este disparador TGR_CAPACIDAD_TRANSPORTE asegura que los vehículos no excedan su capacidad máxima según el tipo al insertar en la 
tabla logistica.Entrega.
*/

CREATE TRIGGER TGR_CAPACIDAD_TRANSPORTE
ON logistica.Entrega
INSTEAD OF INSERT 
AS
BEGIN 
	DECLARE @IdTransporte BIGINT;
    DECLARE @CapacidadActual INT;
    DECLARE @TipoTransporte VARCHAR(50);
    DECLARE @CapacidadMaxima INT;
    DECLARE @TotalPaquetes INT;
	DECLARE @IdRuta BIGINT;

	SELECT @IdRuta = i.IdRuta
    FROM inserted i;

	SELECT @IdTransporte = r.IdTransporte
    FROM logistica.Ruta r
    WHERE r.IdRuta = @IdRuta;

	SELECT @TipoTransporte = t.Transporte, @CapacidadActual = t.Capacidad
    FROM logistica.Transporte t
    WHERE t.IdTransporte = @IdTransporte;

	IF @TipoTransporte = 'Camión'
        SET @CapacidadMaxima = 15;
    ELSE IF @TipoTransporte = 'Camioneta'
        SET @CapacidadMaxima = 10;
    ELSE IF @TipoTransporte = 'Coche'
        SET @CapacidadMaxima = 5;
    ELSE IF @TipoTransporte = 'Motocicleta'
        SET @CapacidadMaxima = 2;

	-- Se verifica si el transporte tiene la capacidad
	IF @CapacidadActual + 1 > @CapacidadMaxima
		BEGIN
			RAISERROR('El transporte no tiene la capacidad suficiente para llevar esta entrega.', 16, 1);
			ROLLBACK TRANSACTION;
			RETURN;
		END
	ELSE
		BEGIN
		-- Se actualiza la capacidad del transporte
        UPDATE logistica.Transporte
        SET Capacidad = Capacidad + 1
        WHERE IdTransporte = @IdTransporte;

		-- Se inserta la Entrega
        INSERT INTO logistica.Entrega (IdRuta, FechaEntrega, EstadoEntrega, TotalProductos)
        SELECT i.IdRuta, i.FechaEntrega, i.EstadoEntrega, i.TotalProductos
        FROM inserted i;
    END;
END;

/*
***************************************************************  Disparador  ***************************************************************
DISPARADOR 6#

Este disparador TGR_TOTAL_PRODUCTOS actualiza el campo TotalProductos en la tabla logistica.Entrega cada vez que se inserta un nuevo detalle
de entrega en logistica.DetalleEntrega. Incrementa el total de productos asociados a una entrega..
*/

CREATE TRIGGER TGR_TOTAL_PRODUCTOS
ON logistica.DetalleEntrega
AFTER INSERT
AS
BEGIN
    -- Declaración de variables
    DECLARE @IdEntrega BIGINT;

    -- Obtener el IdEntrega del registro insertado
    SELECT @IdEntrega = i.IdEntrega
    FROM inserted i;

    -- Incrementar el total de productos de la entrega correspondiente
    UPDATE logistica.Entrega
    SET TotalProductos = TotalProductos + 1
    WHERE IdEntrega = @IdEntrega;
END;
SELECT * FROM logistica.Entrega

/*
***************************************************************  Disparador  ***************************************************************
DISPARADOR 7#

Este disparador TGR_TOTAL_PRODUCTOS actualiza el campo TotalProductos en la tabla logistica.Entrega cada vez que se elimina un nuevo detalle
de entrega en logistica.DetalleEntrega. Decrementa el total de productos asociados a una entrega..
*/

CREATE TRIGGER TGR_DECREMENTA_TOTAL_PRODUCTOS
ON logistica.DetalleEntrega
AFTER DELETE
AS
BEGIN
    -- Evita mensajes adicionales
    SET NOCOUNT ON;

    -- Actualiza el TotalProductos de la tabla Entrega
    UPDATE logistica.Entrega
    SET TotalProductos = TotalProductos - 1
    WHERE IdEntrega IN (SELECT d.IdEntrega FROM deleted d);
END;
