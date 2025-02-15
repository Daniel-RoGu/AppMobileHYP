USE `Asistencia` ;

/*----------------------------------------- Consulta RangoNumerosTarjetero------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaCompletaRangoNumerosTarjetero` $$
CREATE PROCEDURE `ConsultaCompletaRangoNumerosTarjetero`(
) 
BEGIN
	SELECT RangoNumerosTarjetero.* FROM RangoNumerosTarjetero;
END$$

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaParcialRangoNumerosTarjetero` $$
CREATE PROCEDURE `ConsultaParcialRangoNumerosTarjetero`(
    numeroTarjetero INT
) 
BEGIN
	DECLARE IdRangoTarjetero INT;
    SET IdRangoTarjetero = (SELECT Tarjetero.FkRangoNumerosTarjetero FROM Tarjetero WHERE Tarjetero.NumeroTarjetero = numeroTarjetero);
	SELECT RangoNumerosTarjetero.* FROM RangoNumerosTarjetero WHERE RangoNumerosTarjetero.idRangoNumerosTarjetero = IdRangoTarjetero;
END$$

/*----------------------------------------- Consulta Tarjetero------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaCompletaTarjetero` $$
CREATE PROCEDURE `ConsultaCompletaTarjetero`(
	tipoUsuario VARCHAR(450)
) 
BEGIN
	IF (tipoUsuario = "Vistante") THEN
		SELECT Tarjetero.* FROM Tarjetero
        ORDER BY Tarjetero.NumeroTarjetero
		LIMIT 200 OFFSET 300;
	ELSE 
		SELECT Tarjetero.* FROM Tarjetero
        ORDER BY Tarjetero.NumeroTarjetero
		LIMIT 300;
    END IF;	
END$$

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaCompletaTarjeteroEmpresa` $$
CREATE PROCEDURE `ConsultaCompletaTarjeteroEmpresa`(
	nomEmpresa VARCHAR(450)
) 
BEGIN
	DECLARE idEmpresa INT;
    SET idEmpresa = (SELECT Empresa.idEmpresa FROM Empresa WHERE Empresa.NombreEmpresa = nomEmpresa);
	SELECT Tarjetero.* FROM Tarjetero WHERE Tarjetero.Empresa_idEmpresa = idEmpresa;
END$$

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaParcialTarjetero` $$
CREATE PROCEDURE `ConsultaParcialTarjetero`(
    numeroReferencia INT
) 
BEGIN
	DECLARE TarjeteroUsuario INT;
	IF (numeroReferencia < 999) THEN
		SELECT Tarjetero.* FROM Tarjetero WHERE Tarjetero.NumeroTarjetero = numeroReferencia;
	ELSE
		SET TarjeteroUsuario = (SELECT Usuario.FkidTarjetero FROM Usuario WHERE Usuario.idUsuario = numeroReferencia);
		SELECT Tarjetero.* FROM Tarjetero WHERE Tarjetero.idTarjetero = TarjeteroUsuario;
    END IF;	
END$$

/*----------------------------------------- Consulta Empresa------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaCompletaEmpresa` $$
CREATE PROCEDURE `ConsultaCompletaEmpresa`(
) 
BEGIN
	SELECT Empresa.* FROM Empresa;
END$$

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaParcialEmpresa` $$
CREATE PROCEDURE `ConsultaParcialEmpresa`(
    nomEmpresa VARCHAR(450)
) 
BEGIN
	SELECT Empresa.* FROM Empresa WHERE Empresa.NombreEmpresa = nomEmpresa;
END$$

/*----------------------------------------- Consulta Locacion------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaCompletaLocacion` $$
CREATE PROCEDURE `ConsultaCompletaLocacion`(
) 
BEGIN
	SELECT Locacion.* FROM Locacion;
END$$

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaParcialLocacion` $$
CREATE PROCEDURE `ConsultaParcialLocacion`(
    nomLocacion VARCHAR(450)
) 
BEGIN
	SELECT Locacion.* FROM Locacion WHERE Locacion.NombreLocacion = nomLocacion;
END$$

/*----------------------------------------- Consulta TipoUsuario------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaCompletaTipoUsuario` $$
CREATE PROCEDURE `ConsultaCompletaTipoUsuario`(
) 
BEGIN
	SELECT TipoUsuario.* FROM TipoUsuario;
END$$

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaParcialTipoUsuario` $$
CREATE PROCEDURE `ConsultaParcialTipoUsuario`(
    nomTipoUsuario VARCHAR(450)
) 
BEGIN
	SELECT TipoUsuario.* FROM TipoUsuario WHERE TipoUsuario.TipoUsuario = nomTipoUsuario;
END$$

/*----------------------------------------- Consulta Hora------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaCompletaHora` $$
CREATE PROCEDURE `ConsultaCompletaHora`(
) 
BEGIN
	SELECT Hora.* FROM Hora;
END$$

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaParcialHora` $$
CREATE PROCEDURE `ConsultaParcialHora`(
    inicioHora VARCHAR(450),
    finHora VARCHAR(450)
) 
BEGIN
	SELECT Hora.* FROM Hora WHERE Hora.HoraInicio = inicioHora AND Hora.HoraFin = finHora;
END$$

/*----------------------------------------- Consulta Asistencia------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaCompletaAsistencia` $$
CREATE PROCEDURE `ConsultaCompletaAsistencia`(
) 
BEGIN
	SELECT Asistencia.* FROM Asistencia;
END$$

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaParcialAsistencia` $$
CREATE PROCEDURE `ConsultaParcialAsistencia`(
    fechaasistencia VARCHAR(450)
) 
BEGIN
	SELECT Asistencia.* FROM Asistencia WHERE Asistencia.FechaAsistencia = fechaasistencia;
END$$

/*----------------------------------------- Consulta DetalleAsistencia------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaCompletaDetalleAsistencia` $$
CREATE PROCEDURE `ConsultaCompletaDetalleAsistencia`(
) 
BEGIN
	SELECT DetalleAsistencia.* FROM DetalleAsistencia;
END$$

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaParcialDetalleAsistencia` $$
CREATE PROCEDURE `ConsultaParcialDetalleAsistencia`(
    fechaasistencia VARCHAR(450),
    identificacionUser INT
) 
BEGIN
	DECLARE idAsistencia INT;
    SET idAsistencia = (SELECT Asistencia.idAsistencia FROM Asistencia WHERE Asistencia.FechaAsistencia = fechaasistencia);
	SELECT DetalleAsistencia.* FROM DetalleAsistencia WHERE DetalleAsistencia.FkUsuario = identificacionUser AND DetalleAsistencia.FkAsistencia = idAsistencia;
END$$

/*----------------------------------------- Consulta Usuario------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaCompletaUsuario` $$
CREATE PROCEDURE `ConsultaCompletaUsuario`(
) 
BEGIN
	SELECT Usuario.* FROM Usuario;
END$$

-- Busca Usuarios por empresa, por locacion, por tipo de usuario, por identificacion de usuario o por codigo de Tarjetero
DELIMITER $$
DROP PROCEDURE IF EXISTS `ConsultaParcialUsuario` $$
CREATE PROCEDURE `ConsultaParcialUsuario`(
    nomEmpresa VARCHAR(450),
    nomLocacion VARCHAR(450),
    nomTipoUsuario VARCHAR(450),
    identificacionUser INT,
    codigoUser INT
) 
BEGIN
	DECLARE idTipoUsuario INT;
    DECLARE idCodigoUser INT;
    SET idCodigoUser = (SELECT Tarjetero.idTarjetero FROM Tarjetero WHERE Tarjetero.NumeroTarjetero = codigoUser);
    
    IF (nomEmpresa != NULL AND nomEmpresa != " ") THEN
        SELECT Usuario.* FROM Usuario 
        INNER JOIN Tarjetero
        INNER JOIN Empresa ON Empresa.NombreEmpresa = nomEmpresa
        WHERE Usuario.FkTarjetero = idTarjetero AND Tarjetero.Empresa_idEmpresa = Empresa.idEmpresa;        
	ELSEIF (nomLocacion != NULL AND nomLocacion != " ") THEN    
		SELECT Usuario.* FROM Usuario 
        INNER JOIN Tarjetero
        INNER JOIN Locacion ON Locacion.NombreLocacion = nomLocacion
        WHERE Usuario.FkTarjetero = idTarjetero AND Tarjetero.Locacion_idLocacion = Locacion.idLocacion;        
	ELSEIF (nomTipoUsuario != NULL AND nomTipoUsuario != " ") THEN    
		SET idTipoUsuario = (SELECT TipoUsuario.idTipoUsuario FROM TipoUsuario WHERE TipoUsuario.TipoUsuario = nomTipoUsuario);
        SELECT Usuario.* FROM Usuario WHERE Usuario.FkTipoUsuario = idTipoUsuario;
    ELSEIF (identificacionUser != NULL AND identificacionUser > 0 AND identificacionUser != " ") THEN
		SELECT Usuario.* FROM Usuario WHERE Usuario.identificacionUsuario = identificacionUser;
	ELSE 
		SELECT Usuario.* FROM Usuario WHERE Usuario.FkTarjetero = idCodigoUser;
    END IF;
    
END$$




