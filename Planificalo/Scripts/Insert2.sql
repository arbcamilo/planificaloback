-- Insertar registros en la tabla Usuarios
INSERT INTO Usuarios (TipoDocumento, DocumentoIdentidad, Nombre, Email, Celular, Estado, FechaCreacionCuenta, FechaNacimiento, Discriminator)
VALUES 
('CC', 1234567890, 'Juan Perez', 'juan.perez@example.com', '3001234567', 'Activo', '2023-01-01', '1990-01-01', 'Usuario'),
('CC', 2345678901, 'Maria Gomez', 'maria.gomez@example.com', '3002345678', 'Activo', '2023-01-02', '1991-02-01', 'Usuario'),
('CC', 3456789012, 'Carlos Ruiz', 'carlos.ruiz@example.com', '3003456789', 'Activo', '2023-01-03', '1992-03-01', 'Usuario'),
('CC', 4567890123, 'Ana Torres', 'ana.torres@example.com', '3004567890', 'Activo', '2023-01-04', '1993-04-01', 'Usuario'),
('CC', 5678901234, 'Luis Martinez', 'luis.martinez@example.com', '3005678901', 'Activo', '2023-01-05', '1994-05-01', 'Usuario');

-- Insertar registros en la tabla TiposEvento
INSERT INTO TiposEvento (Nombre)
VALUES 
('Conferencia'),
('Seminario'),
('Taller'),
('Webinar'),
('Fiesta');

-- Insertar registros en la tabla Eventos
INSERT INTO Eventos (Titulo, Fecha, UsuarioId, Lugar, TipoEventoId)
VALUES 
('Conferencia de Tecnología', '2023-06-01', 1, 'Auditorio Principal', 1),
('Seminario de Marketing', '2023-07-01', 2, 'Sala de Conferencias', 2),
('Taller de Programación', '2023-08-01', 3, 'Laboratorio de Computo', 3),
('Webinar de Seguridad', '2023-09-01', 4, 'Online', 4),
('Fiesta de Fin de Año', '2023-12-31', 5, 'Salón de Eventos', 5);

-- Insertar registros en la tabla Invitados
INSERT INTO Invitados (Nombre, Email, EstadoInvitado)
VALUES 
('Pedro Lopez', 'pedro.lopez@example.com', 1),
('Laura Sanchez', 'laura.sanchez@example.com', 1),
('Jorge Ramirez', 'jorge.ramirez@example.com', 0),
('Sofia Fernandez', 'sofia.fernandez@example.com', 1),
('Miguel Castro', 'miguel.castro@example.com', 0);

-- Insertar registros en la tabla Invitaciones
INSERT INTO Invitaciones (EventoId, InvitadoId, FechaEnvio, EstadoInvitacion)
VALUES 
(1, 1, '2023-05-01', 1),
(2, 2, '2023-06-01', 1),
(3, 3, '2023-07-01', 0),
(4, 4, '2023-08-01', 1),
(5, 5, '2023-09-01', 0);

-- Insertar registros en la tabla Productos
INSERT INTO Productos (TipoProducto, Precio, Cantidad, Descripcion)
VALUES 
('Sillas', 100.00, 50, 'A'),
('Mesas', 200.00, 30, 'B'),
('Tortas', 300.00, 20, 'C'),
('Vestidos', 400.00, 10, 'D'),
('Manteles', 500.00, 5, 'E');

-- Insertar registros en la tabla Proveedores
INSERT INTO Proveedores (Nombre, Pais, Departamento, Ciudad, Direccion, Email, TelefonoContacto, EsPersonaNatural, Estado, Calificacion, TipoDocumento, DocumentoIdentidad)
VALUES 
('Proveedor 1', 'Colombia', 'Antioquia', 'Medellin', 'Calle 1', 'proveedor1@example.com', '3001111111', 1, 'Activo', 4.5, 'NIT', 900000001),
('Proveedor 2', 'Colombia', 'Cundinamarca', 'Bogota', 'Calle 2', 'proveedor2@example.com', '3002222222', 0, 'Activo', 4.0, 'NIT', 900000002),
('Proveedor 3', 'Colombia', 'Valle del Cauca', 'Cali', 'Calle 3', 'proveedor3@example.com', '3003333333', 1, 'Activo', 3.5, 'NIT', 900000003),
('Proveedor 4', 'Colombia', 'Atlantico', 'Barranquilla', 'Calle 4', 'proveedor4@example.com', '3004444444', 0, 'Activo', 4.8, 'NIT', 900000004),
('Proveedor 5', 'Colombia', 'Santander', 'Bucaramanga', 'Calle 5', 'proveedor5@example.com', '3005555555', 1, 'Activo', 4.2, 'NIT', 900000005);

-- Insertar registros en la tabla Servicios
INSERT INTO Servicios (TipoServicio, Cantidad, Precio, Descripcion)
VALUES 
('Servicio A', 2, 1000.00, ''),
('Servicio B', 3, 2000.00, ''),
('Servicio C', 4, 3000.00, ''),
('Servicio D', 8, 4000.00, ''),
('Servicio E', 3, 5000.00, '');

-- Insertar registros en la tabla Cotizaciones
INSERT INTO Cotizaciones (EventoId, ProveedorId, Cantidad, Total, FechaCreacion, FechaRespuesta, Estado, Notas)
VALUES 
(1, 1, 10, 1000.00, '2023-05-01', '2023-06-01', 'Pendiente', 'Nota 1'),
(2, 2, 20, 2000.00, '2023-06-01', '2023-07-01', 'Pendiente', 'Nota 2'),
(3, 3, 30, 3000.00, '2023-07-01', '2023-08-01', 'Pendiente', 'Nota 3'),
(4, 4, 40, 4000.00, '2023-08-01', '2023-09-01', 'Pendiente', 'Nota 4'),
(5, 5, 50, 5000.00, '2023-09-01', '2023-10-01', 'Pendiente', 'Nota 5');

-- Insertar registros en la tabla ProveedorProductos
INSERT INTO ProveedorProductos (ProveedorId, ProductoId)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

-- Insertar registros en la tabla ProveedorServicios
INSERT INTO ProveedorServicios (ProveedorId, ServicioId)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

-- Insertar registros en la tabla CotizacionProductos
INSERT INTO CotizacionProductos (CotizacionId, ProductoId, Cantidad, PrecioUnitario)
VALUES 
(1, 1, 10, 100.00),
(2, 2, 20, 200.00),
(3, 3, 30, 300.00),
(4, 4, 40, 400.00),
(5, 5, 50, 500.00);

-- Insertar registros en la tabla CotizacionServicios
INSERT INTO CotizacionServicios (CotizacionId, ServicioId, Cantidad, PrecioUnitario)
VALUES 
(1, 1, 10, 1000.00),
(2, 2, 20, 2000.00),
(3, 3, 30, 3000.00),
(4, 4, 40, 4000.00),
(5, 5, 50, 5000.00);
