USE `Asistencia` ;

/*----------------------------------------- Eliminar Usuario------------------------------------------------*/

DELIMITER $$
DROP PROCEDURE IF EXISTS `EliminarUsuario` $$
CREATE PROCEDURE `EliminarUsuario`(
    IdUsuario VARCHAR(450)
) 
BEGIN
	DECLARE IdTarjeteroRef INT;
    SET IdTarjeteroRef = (SELECT Usuario.FkTarjetero FROM Usuario WHERE Usuario.identificacionUsuario = IdUsuario);
	UPDATE Usuario SET Usuario.EstadoEmpleado = "Des-Vinculado";
    UPDATE Tarjetero SET Tarjetero.NumeroTarjetero = 0 WHERE Tarjetero.idTarjetero = IdTarjeteroRef;
END$$