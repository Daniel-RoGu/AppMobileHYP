USE `Asistencia` ;

/*----------------------------------------- Actualizacion Empresa------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ActualizacionEmpresa` $$
CREATE PROCEDURE `ActualizacionEmpresa`(
    NomEmpresaActual VARCHAR(450),
    NomEmpresaNuevo VARCHAR(450),
    Nit VARCHAR(450),
    logo VARCHAR(450),
    Estado VARCHAR(450)
) 
BEGIN
	UPDATE Empresa SET Empresa.NombreEmpresa = NomEmpresaNuevo, Empresa.NITEmpresa = Nit, Empresa.LogoEmpresa = logo, Empresa.EstadoEmpresa = Estado
    WHERE Empresa.NombreEmpresa = NomEmpresaActual;
END$$

/*----------------------------------------- Actualizacion Locacion------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ActualizacionLocacion` $$
CREATE PROCEDURE `ActualizacionLocacion`(
    NomLocacionActual VARCHAR(450),
    NomLocacionNuevo VARCHAR(450),
    RIGLocacion VARCHAR(450),
    PozoLocacion VARCHAR(450),
    Estado VARCHAR(450)
) 
BEGIN
	UPDATE Locacion SET Locacion.NombreLocacion = NomLocacionNuevo, Locacion.RIG = RIGLocacion, Locacion.Pozo = PozoLocacion, Locacion.EstadoLocacion = Estado
    WHERE Locacion.NombreLocacion = NomLocacionActual;
END$$


/*----------------------------------------- Actualizacion Usuario------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `ActualizacionUsuario` $$
CREATE PROCEDURE `ActualizacionUsuario`(
    idUsuario INT,
    NomUsuario VARCHAR(450),
    CargoUsuario VARCHAR(450),
    CelularUsuario VARCHAR(450),
    CorreoUsuario VARCHAR(450),
    EstadoUsuario VARCHAR(450),
    EPSUsuario VARCHAR(450),
    ARLUsuario VARCHAR(450),
    TpSangreUsuario VARCHAR(450),
    NumeroContactoEmergenciaUsuario VARCHAR(450),
    NombreContactoEmergenciaUsuario VARCHAR(450),
    TpUsuario VARCHAR(450),
    NumTarjetero VARCHAR(450)
) 
BEGIN
	DECLARE idTpUsuario INT;
	DECLARE idTarjetero INT;
    SET idTpUsuario = (SELECT TipoUsuario.idTipoUsuario FROM TipoUsuario WHERE TipoUsuario.TipoUsuario = TpUsuario);
    SET idTarjetero = (SELECT Tarjetero.idTarjetero FROM Tarjetero WHERE Tarjetero.NumeroTarjetero = NumTarjetero);

	UPDATE Usuario SET Usuario.NombreUsuario = NomUsuario, Usuario.Cargo = CargoUsuario, Usuario.Celular = CelularUsuario, 
    Usuario.Correo = CorreoUsuario, Usuario.EstadoEmpleado = EstadoUsuario, Usuario.EPS = EPSUsuario, Usuario.ARL = ARLUsuario,
    Usuario.TipoSangre = TpSangreUsuario, Usuario.NumeroContactoEmergencia = NumeroContactoEmergenciaUsuario, 
    Usuario.NombreContactoEmergencia = NombreContactoEmergenciaUsuario, Usuario.FkTipoUsuario = idTpUsuario, Usuario.FkTarjetero = idTarjetero
    WHERE Usuario.identificacionUsuario = idUsuario;
END$$




