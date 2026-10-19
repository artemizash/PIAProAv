-- Creación de Catálogos base
CREATE TABLE Rol (
    id_rol INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
);
INSERT INTO Rol (nombre)
VALUES ('Administrador'), ('Operativo');

CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    id_rol INT NOT NULL,
    correo VARCHAR(100) UNIQUE NOT NULL,
    contrasena VARCHAR(255) NOT NULL CHECK (LEN(contrasena) >= 8),
    nombre_completo VARCHAR(150) NOT NULL,
    numero_nomina VARCHAR(20) UNIQUE NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    fecha_registro DATETIME DEFAULT GETDATE(),
    debe_cambiar_contrasena BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (id_rol) REFERENCES Rol(id_rol)
);
CREATE TABLE Historial_contrasena (
    id_historial INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    contrasena VARCHAR(255) NOT NULL,
    fecha_cambio DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

CREATE TABLE Cliente (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre_completo VARCHAR(150) NOT NULL,
    rfc VARCHAR(13) UNIQUE NOT NULL,
    domicilio VARCHAR(255) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    correo VARCHAR(100) UNIQUE NOT NULL,
    telefono_casa VARCHAR(15),
    telefono_celular VARCHAR(15),
    fecha_registro DATETIME DEFAULT GETDATE()
);

-- Estadios y sus dependencias
CREATE TABLE Estadio (
    id_estadio INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario_registro INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    ciudad VARCHAR(100) NOT NULL,
    capacidad_total INT NOT NULL,
    mapa VARBINARY(MAX), -- O VARCHAR si guardan la ruta de la imagen
    fecha_registro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_usuario_registro) REFERENCES Usuario(id_usuario)
);

CREATE TABLE Zona (
    id_zona INT IDENTITY(1,1) PRIMARY KEY,
    id_estadio INT NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    precio_base DECIMAL(10,2) NOT NULL,
    cupo INT NOT NULL,
    activa BIT DEFAULT 1,
    FOREIGN KEY (id_estadio) REFERENCES Estadio(id_estadio)
);

CREATE TABLE Asiento (
    id_asiento INT IDENTITY(1,1) PRIMARY KEY,
    id_zona INT NOT NULL,
    fila VARCHAR(5) NOT NULL,
    numero INT NOT NULL,
    activo BIT DEFAULT 1,
    FOREIGN KEY (id_zona) REFERENCES Zona(id_zona)
);

-- Equipos y Partidos
CREATE TABLE Equipo (
    id_equipo INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    ciudad VARCHAR(100),
    activo BIT DEFAULT 1
);

CREATE TABLE Partido (
    id_partido INT IDENTITY(1,1) PRIMARY KEY,
    id_estadio INT NOT NULL,
    id_usuario_registro INT NOT NULL,
    fecha_hora DATETIME NOT NULL,
    estado VARCHAR(20) NOT NULL CHECK (estado IN ('programado', 'terminado', 'cancelado')),
    fecha_registro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_estadio) REFERENCES Estadio(id_estadio),
    FOREIGN KEY (id_usuario_registro) REFERENCES Usuario(id_usuario)
);

CREATE TABLE partido_equipo (
    id_partido INT NOT NULL,
    id_equipo INT NOT NULL,
    local_visitante VARCHAR(20) CHECK (local_visitante IN ('local', 'visitante')),
    PRIMARY KEY (id_partido, id_equipo),
    FOREIGN KEY (id_partido) REFERENCES Partido(id_partido),
    FOREIGN KEY (id_equipo) REFERENCES Equipo(id_equipo)
);

-- Ventas, Facturación y Cancelación
CREATE TABLE Venta (
    id_venta INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT NOT NULL,
    id_usuario INT NOT NULL,
    folio UNIQUEIDENTIFIER DEFAULT NEWID(), -- Genera el GUID automáticamente
    metodo_pago VARCHAR(20) NOT NULL CHECK (metodo_pago IN ('credito', 'debito', 'efectivo')),
    estado VARCHAR(20) DEFAULT 'completada',
    fecha_venta DATETIME DEFAULT GETDATE(),
    subtotal DECIMAL(10,2) NOT NULL,
    iva DECIMAL(10,2) NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

CREATE TABLE detalle_venta (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_venta INT NOT NULL,
    id_partido INT NOT NULL,
    id_asiento INT NOT NULL,
    cantidad INT DEFAULT 1,
    precio_unitario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_venta) REFERENCES Venta(id_venta),
    FOREIGN KEY (id_partido) REFERENCES Partido(id_partido),
    FOREIGN KEY (id_asiento) REFERENCES Asiento(id_asiento)
);

CREATE TABLE Factura (
    id_factura INT IDENTITY(1,1) PRIMARY KEY,
    id_venta INT NOT NULL,
    folio_factura VARCHAR(50) UNIQUE NOT NULL,
    fecha_emision DATETIME DEFAULT GETDATE(),
    emisor_nombre VARCHAR(150) NOT NULL,
    emisor_rfc VARCHAR(13) NOT NULL,
    emisor_domicilio VARCHAR(255) NOT NULL,
    receptor_nombre VARCHAR(150) NOT NULL,
    receptor_rfc VARCHAR(13) NOT NULL,
    receptor_domicilio VARCHAR(255) NOT NULL,
    subtotal DECIMAL(10,2) NOT NULL,
    iva DECIMAL(10,2) NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_venta) REFERENCES Venta(id_venta)
);

CREATE TABLE Cancelacion (
    id_cancelacion INT IDENTITY(1,1) PRIMARY KEY,
    id_venta INT NOT NULL,
    id_usuario INT NOT NULL, -- Debe ser un administrador
    motivo VARCHAR(255) NOT NULL,
    fecha_cancelacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_venta) REFERENCES Venta(id_venta),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);