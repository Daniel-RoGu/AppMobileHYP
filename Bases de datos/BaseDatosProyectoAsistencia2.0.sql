-- -----------------------------------------------------
-- Schema Asistencia
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Asistencia` DEFAULT CHARACTER SET utf8 ;
USE `Asistencia` ;

-- -----------------------------------------------------
-- Table `Asistencia`.`TipoUsuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`TipoUsuario` (
  `idTipoUsuario` INT NOT NULL,
  `TipoUsuario` VARCHAR(45) NOT NULL,
  `EstadoTipoUsuario` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idTipoUsuario`);


-- -----------------------------------------------------
-- Table `Asistencia`.`RangoNumerosTarjetero`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`RangoNumerosTarjetero` (
  `idRangoNumerosTarjetero` INT NOT NULL,
  `TipoRango` VARCHAR(450) NOT NULL,
  `RangoSuperior` INT(250) NOT NULL,
  `RangoInferior` INT(250) NOT NULL,
  `EstadoRango` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idRangoNumerosTarjetero`));


-- -----------------------------------------------------
-- Table `Asistencia`.`Empresa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Empresa` (
  `idEmpresa` INT NOT NULL,
  `NombreEmpresa` VARCHAR(450) NOT NULL,
  `NITEmpresa` VARCHAR(45) NOT NULL,
  `LogoEmpresa` VARCHAR(45) NOT NULL,
  `EstadoEmpresa` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idEmpresa`));


-- -----------------------------------------------------
-- Table `Asistencia`.`Locacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Locacion` (
  `idLocacion` INT NOT NULL,
  `NombreLocacion` VARCHAR(450) NOT NULL,
  `RIG` VARCHAR(450) NOT NULL,
  `Pozo` VARCHAR(450) NULL,
  `EstadoLocacion` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idLocacion`));


-- -----------------------------------------------------
-- Table `Asistencia`.`Tarjetero`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Tarjetero` (
  `idTarjetero` INT NOT NULL,
  `NumeroTarjetero` INT(1000) NOT NULL,
  `EstadoNumero` VARCHAR(45) NOT NULL,
  `FKRangoNumerosTarjetero` INT NOT NULL,
  `Empresa_idEmpresa` INT NOT NULL,
  `Locacion_idLocacion` INT NOT NULL,
  PRIMARY KEY (`idTarjetero`),
  CONSTRAINT `fk_Tarjetero_RangoNumerosTarjetero1`
    FOREIGN KEY (`FKRangoNumerosTarjetero`)
    REFERENCES `Asistencia`.`RangoNumerosTarjetero` (`idRangoNumerosTarjetero`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Tarjetero_Empresa1`
    FOREIGN KEY (`Empresa_idEmpresa`)
    REFERENCES `Asistencia`.`Empresa` (`idEmpresa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Tarjetero_Locacion1`
    FOREIGN KEY (`Locacion_idLocacion`)
    REFERENCES `Asistencia`.`Locacion` (`idLocacion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `Asistencia`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Usuario` (
  `identificacionUsuario` INT NOT NULL,
  `NombreUsuario` VARCHAR(200) NOT NULL,
  `Cargo` VARCHAR(200) NOT NULL,
  `Celular` VARCHAR(45) NOT NULL,
  `Correo` VARCHAR(200) NOT NULL,
  `EstadoEmpleado` VARCHAR(45) NULL,
  `EPS` VARCHAR(450) NOT NULL,
  `ARL` VARCHAR(450) NOT NULL,
  `TipoSangre` VARCHAR(450) NOT NULL,
  `NumeroContactoEmergencia` VARCHAR(45) NOT NULL,
  `NombreContactoEmergencia` VARCHAR(450) NOT NULL,
  `FKTipoUsuario` INT NOT NULL,
  `FKTarjetero` INT NOT NULL,
  PRIMARY KEY (`identificacionUsuario`),
  CONSTRAINT `fk_Usuario_TipoUsuario1`
    FOREIGN KEY (`FKTipoUsuario`)
    REFERENCES `Asistencia`.`TipoUsuario` (`idTipoUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Usuario_Tarjetero1`
    FOREIGN KEY (`FKTarjetero`)
    REFERENCES `Asistencia`.`Tarjetero` (`idTarjetero`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `Asistencia`.`Asistencia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Asistencia` (
  `idAsistencia` INT NOT NULL AUTO_INCREMENT,
  `FechaAsistencia` VARCHAR(45) NOT NULL,
  `EstadoAsistencia` VARCHAR(45) NULL,
  PRIMARY KEY (`idAsistencia`);


-- -----------------------------------------------------
-- Table `Asistencia`.`Hora`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Hora` (
  `idHora` INT NOT NULL AUTO_INCREMENT,
  `HoraInicio` VARCHAR(45) NOT NULL,
  `HoraFin` VARCHAR(45) NOT NULL,
  `EstadoHora` VARCHAR(45) NULL,
  `Usuario_identificacionUsuario` INT NOT NULL,
  `Asistencia_idAsistencia` INT NOT NULL,
  PRIMARY KEY (`idHora`),
  CONSTRAINT `fk_Hora_Usuario1`
    FOREIGN KEY (`Usuario_identificacionUsuario`)
    REFERENCES `Asistencia`.`Usuario` (`identificacionUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Hora_Asistencia1`
    FOREIGN KEY (`Asistencia_idAsistencia`)
    REFERENCES `Asistencia`.`Asistencia` (`idAsistencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `Asistencia`.`DetalleAsistencia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`DetalleAsistencia` (
  `idDetalleAsistencia` INT NOT NULL AUTO_INCREMENT,
  `EstadoAsistenciaUsuario` VARCHAR(45) NOT NULL,
  `FKUsuario` INT NOT NULL,
  `FKAsistencia` INT NOT NULL,
  PRIMARY KEY (`idDetalleAsistencia`),
  CONSTRAINT `fk_DetalleAsistencia_Usuario1`
    FOREIGN KEY (`FKUsuario`)
    REFERENCES `Asistencia`.`Usuario` (`identificacionUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DetalleAsistencia_Asistencia1`
    FOREIGN KEY (`FKAsistencia`)
    REFERENCES `Asistencia`.`Asistencia` (`idAsistencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `Asistencia`.`Permisos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Permisos` (
  `idPermisos` INT NOT NULL,
  `FechaInicioPermiso` VARCHAR(45) NOT NULL,
  `FechaFinPermiso` VARCHAR(45) NOT NULL,
  `EstadoPermiso` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idPermisos`);


-- -----------------------------------------------------
-- Table `Asistencia`.`DetallePermisoUsuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`DetallePermisoUsuario` (
  `idDetallePermisoUsuario` INT NOT NULL,
  `DetallePermisoUsuario` VARCHAR(450) NOT NULL,
  `EstadoPermisoUsuario` VARCHAR(45) NOT NULL,
  `FKUsuario` INT NOT NULL,
  `FKPermisos` INT NOT NULL,
  PRIMARY KEY (`idDetallePermisoUsuario`),
  CONSTRAINT `fk_DetallePermisoUsuario_Usuario1`
    FOREIGN KEY (`FKUsuario`)
    REFERENCES `Asistencia`.`Usuario` (`identificacionUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DetallePermisoUsuario_Permisos1`
    FOREIGN KEY (`FKPermisos`)
    REFERENCES `Asistencia`.`Permisos` (`idPermisos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `Asistencia`.`TipoDocumento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`TipoDocumento` (
  `idTipoDocumento` INT NOT NULL AUTO_INCREMENT,
  `TipoDocumento` VARCHAR(45) NOT NULL,
  `EstadoTipoDocumento` VARCHAR(45) NOT NULL,
  `Usuario_identificacionUsuario` INT NOT NULL,
  PRIMARY KEY (`idTipoDocumento`),
  CONSTRAINT `fk_TipoDocumento_Usuario1`
    FOREIGN KEY (`Usuario_identificacionUsuario`)
    REFERENCES `Asistencia`.`Usuario` (`identificacionUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
