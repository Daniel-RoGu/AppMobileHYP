USE `Asistencia` ;

/*----------------------------------------- Registrar RangoNumerosTarjetero------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarRangoNumerosTarjetero` $$
CREATE PROCEDURE `RegistrarRangoNumerosTarjetero`(
    NombreTipopRango VARCHAR(400),
    RangoMaximo INT,
    RangoInferior INT
) 
BEGIN
	INSERT INTO RangoNumerosTarjetero (TipoRango, RangoSuperior, RangoInferior, EstadoRango) VALUE (nombreTipopRango, RangoMaximo, RangoInferior, "Disponible");
END$$

/*----------------------------------------- Registrar Tarjetero------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarTarjetero` $$
CREATE PROCEDURE `RegistrarTarjetero`(
    NumTarjetero VARCHAR(400),
    TpRango VARCHAR(400),
    empresaUsuario VARCHAR(400),
    locacionUsuario VARCHAR(400)
) 
BEGIN
	DECLARE IdTipoRango INT;
    DECLARE idempresa INT;
    DECLARE idlocacion INT;
    SET IdTipoRango = (SELECT RangoNumerosTarjetero.idRangosNumerosTarjetero FROM RangoNumerosTarjetero WHERE RangoNumerosTarjetero.TipoRano = TpRango);
	SET idempresa = (SELECT Empresa.idEmpresa FROM Empresa WHERE Empresa.NombreEmpresa = empresaUsuario);
    SET idlocacion = (SELECT Locacion.idLocacion FROM Locacion WHERE Locacion.NombreLocacion = locacionUsuario);
    INSERT INTO Tarjetero (NumeroTarjetero, EstadoNumero, FkRangoNumerosTarjetero, Empresa_idEmpresa, Locacion_idLocacion) VALUE (NumTarjetero, "Disponible", IdTipoRango, idempresa, idlocacion);
END$$


/*----------------------------------------- Registrar Empresa------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarEmpresa` $$
CREATE PROCEDURE `RegistrarEmpresa`(
    NomEmpresa VARCHAR(400),
    NITempresa VARCHAR(400),
    Logoempresa VARCHAR(400)
) 
BEGIN
	INSERT INTO Empresa (NombreEmpresa, NITEmpresa, LogoEmpresa, EstadoEmpresa) VALUE (NomEmpresa, NITempresa, Logoempresa, "Activo");
END$$

/*----------------------------------------- Registrar Locacion------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarLocacion` $$
CREATE PROCEDURE `RegistrarLocacion`(
    NomLocacion VARCHAR(400),
    RIGLocacion VARCHAR(400),
    nomPozo VARCHAR(400)
) 
BEGIN
	INSERT INTO Locacion (NombreLocacion, RIG, Pozo, EstadoLocacion) VALUE (NomLocacion, RIGLocacion, nomPozo, "Activo");
END$$


/*----------------------------------------- Registrar Locacion------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarTipoUsuario` $$
CREATE PROCEDURE `RegistrarTipoUsuario`(
    TpUsuario VARCHAR(400)
) 
BEGIN
	INSERT INTO TipoUsuario (TipoUsuario, EstadoTipoUsuario) VALUE (TpUsuario, "Activo");
END$$

/*----------------------------------------- Registrar Hora------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarHora` $$
CREATE PROCEDURE `RegistrarHora`(
    Horainicio VARCHAR(400),
    Horafin VARCHAR(400)
) 
BEGIN
	INSERT INTO Hora (HoraInicio, HoraFin, EstadoHora) VALUE (Horainicio, Horafin, "Registrado");
END$$


/*----------------------------------------- Registrar Asistencia------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarAsistencia` $$
CREATE PROCEDURE `RegistrarAsistencia`(
    fechaasistencia VARCHAR(400),
    horainicia VARCHAR(400),
    horasale VARCHAR(400)
) 
BEGIN
	DECLARE idhora INT;
    SET idhora = (SELECT Hora.idHora FROM Hora WHERE Hora.HoraInicio = Horainicia AND Hora.HoraFIN = horasale);
	INSERT INTO Asistencia (FechaAsistencia, EstadoAsistencia, FkHora) VALUE (fechaasistencia, "Registrado", idhora);
END$$


/*----------------------------------------- Registrar DetalleAsistencia------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarDetalleAsistencia` $$
CREATE PROCEDURE `RegistrarDetalleAsistencia`(
    fechaasistencia VARCHAR(400),
    idusuario VARCHAR(400)
) 
BEGIN
    DECLARE idAsistencia INT;
    SET idAsistencia = (SELECT Asistencia.idAsistencia FROM Asistencia WHERE Asistencia.FechaAsistencia = fechaasistencia);
	INSERT INTO DetalleAsistencia (EstadoAsistenciaUsuario, FkUsuario, FkAsistencia) VALUE (fechaasistencia, "Registrado", idusuario, idAsistencia);
END$$


/*----------------------------------------- Registrar Permisos------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarPermisos` $$
CREATE PROCEDURE `RegistrarPermisos`(
    fechaInicio VARCHAR(400),
    fechaFin VARCHAR(400)
) 
BEGIN
	INSERT INTO Permisos (FechaInicioPermiso, FechaFinPermiso, EstadoPermiso) VALUE (fechaInicio, fechaFin, "Registrado");
END$$

/*----------------------------------------- Registrar DetallePermisoUsuario------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarDetallePermisoUsuario` $$
CREATE PROCEDURE `RegistrarDetallePermisoUsuario`(
    detallepermiso VARCHAR(400),
    idusuario VARCHAR(400),
    fechaInicio VARCHAR(400),
    fechaFin VARCHAR(400)
) 
BEGIN
    DECLARE idPermiso INT;
    SET idPermiso = (SELECT Permisos.idPermiso FROM Permisos WHERE Permisos.FechaInicioPermiso = fechaInicio AND Permisos.FechaFinPermiso = fechaFin);
	INSERT INTO DetallePermisoUsuario (DetallePermisoUsuario, EstadoAsistenciaUsuario, FkUsuario, FkPermiso) VALUE (detallepermiso, "Registrado", idusuario, idPermiso);
END$$

/*----------------------------------------- Registrar Usuario------------------------------------------------*/
DELIMITER $$
DROP PROCEDURE IF EXISTS `RegistrarUsuario` $$
CREATE PROCEDURE `RegistrarUsuario`(
    nomUsuario VARCHAR(400),
    cargoUsuario VARCHAR(400),
    celularUsuario VARCHAR(400),
    correoUsuario VARCHAR(400),
    EPSUsuario VARCHAR(400),
    ARLUsuario VARCHAR(400),
    TipoSangreUsuario VARCHAR(400),
    NumeroContactoEmergenciaUsuario VARCHAR(400),
    NombreContactoEmergenciaUsuario VARCHAR(400),
    tipoUsuario VARCHAR(400),
    numeroTarjetero VARCHAR(400)
) 
BEGIN    
    DECLARE idtpusuario INT;
    DECLARE idtarjetero INT;
    
    SET idtpusuario = (SELECT TipoUsuario.idTipoUsuario FROM TipoUsuario WHERE TipoUsuario.TipoUsuario = tipoUsuario);
    SET idtarjetero = (SELECT Tarjetero.idTarjetero FROM Tarjetero WHERE Tarjetero.NumeroTarjetero = numeroTarjetero);
    
    /*
    IF (tipoUsuario != "Visitante") THEN
		IF (numeroTarjetero < 300) THEN
			INSERT INTO Usuario (NombreUsuario, Cargo, Celular, Correo, EstadoEmpleado, EPS, ARL, TipoSangre, NumeroContactoEmergencia, NombreContactoEmergencia, FkTipoUsuario, FkTarjetero) 
			VALUE (nomUsuario, cargoUsuario, celularUsuario, correoUsuario, "Registrado", EPSUsuario, ARLUsuario, TipoSangreUsuario, NumeroContactoEmergenciaUsuario, NombreContactoEmergenciaUsuario, idtpusuario, idtarjetero);
        END IF;
	Else
		IF (numeroTarjetero > 300) THEN
			INSERT INTO Usuario (NombreUsuario, Cargo, Celular, Correo, EstadoEmpleado, EPS, ARL, TipoSangre, NumeroContactoEmergencia, NombreContactoEmergencia, FkTipoUsuario, FkTarjetero) 
			VALUE (nomUsuario, cargoUsuario, celularUsuario, correoUsuario, "Registrado", EPSUsuario, ARLUsuario, TipoSangreUsuario, NumeroContactoEmergenciaUsuario, NombreContactoEmergenciaUsuario, idtpusuario, idtarjetero);
        END IF;
    END IF;
    */
    INSERT INTO Usuario (NombreUsuario, Cargo, Celular, Correo, EstadoEmpleado, EPS, ARL, TipoSangre, NumeroContactoEmergencia, NombreContactoEmergencia, FkTipoUsuario, FkTarjetero) 
	VALUE (nomUsuario, cargoUsuario, celularUsuario, correoUsuario, "Registrado", EPSUsuario, ARLUsuario, TipoSangreUsuario, NumeroContactoEmergenciaUsuario, NombreContactoEmergenciaUsuario, idtpusuario, idtarjetero);
	
END$$
