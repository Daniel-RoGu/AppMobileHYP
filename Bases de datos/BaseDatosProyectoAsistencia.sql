
-- -----------------------------------------------------
-- Schema Asistencia
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Asistencia` DEFAULT CHARACTER SET utf8 ;
USE `Asistencia` ;
/*CREATE DATABASE bdColegio CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
DROP SCHEMA `Asistencia`;*/
-- -----------------------------------------------------
-- Table `Asistencia`.`TipoUsuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`TipoUsuario` (
  `idTipoUsuario` INT NOT NULL AUTO_INCREMENT,
  `TipoUsuario` VARCHAR(45) NOT NULL,
  `EstadoTipoUsuario` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idTipoUsuario`));

ALTER TABLE `Asistencia`.`TipoUsuario` AUTO_INCREMENT = 0;

-- -----------------------------------------------------
-- Table `Asistencia`.`RangoNumerosTarjetero`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`RangoNumerosTarjetero` (
  `idRangoNumerosTarjetero` INT NOT NULL AUTO_INCREMENT,
  `TipoRango` VARCHAR(450) NOT NULL,
  `RangoSuperior` INT(250) NOT NULL,
  `RangoInferior` INT(250) NOT NULL,
  `EstadoRango` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idRangoNumerosTarjetero`));

ALTER TABLE `Asistencia`.`RangoNumerosTarjetero` AUTO_INCREMENT = 11;

-- -----------------------------------------------------
-- Table `Asistencia`.`Empresa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Empresa` (
  `idEmpresa` INT NOT NULL AUTO_INCREMENT,
  `NombreEmpresa` VARCHAR(450) NOT NULL,
  `NITEmpresa` VARCHAR(45) NOT NULL,
  `LogoEmpresa` VARCHAR(45) NOT NULL,
  `EstadoEmpresa` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idEmpresa`));

ALTER TABLE `Asistencia`.`Empresa` AUTO_INCREMENT = 1012;

-- -----------------------------------------------------
-- Table `Asistencia`.`Locacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Locacion` (
  `idLocacion` INT NOT NULL AUTO_INCREMENT,
  `NombreLocacion` VARCHAR(450) NOT NULL,
  `RIG` VARCHAR(450) NOT NULL,
  `Pozo` VARCHAR(450) NULL,
  `EstadoLocacion` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idLocacion`));

ALTER TABLE `Asistencia`.`Locacion` AUTO_INCREMENT = 11013;

-- -----------------------------------------------------
-- Table `Asistencia`.`Tarjetero`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Tarjetero` (
  `idTarjetero` INT NOT NULL AUTO_INCREMENT,
  `NumeroTarjetero` INT(250) NOT NULL,
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

ALTER TABLE `Asistencia`.`Tarjetero` AUTO_INCREMENT = 12;

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
-- Table `Asistencia`.`Hora`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Hora` (
  `idHora` INT NOT NULL AUTO_INCREMENT,
  `HoraInicio` VARCHAR(45) NOT NULL,
  `HoraFin` VARCHAR(45) NOT NULL,
  `EstadoHora` VARCHAR(45) NULL,
  PRIMARY KEY (`idHora`));

ALTER TABLE `Asistencia`.`Hora` AUTO_INCREMENT = 1011013;

-- -----------------------------------------------------
-- Table `Asistencia`.`Asistencia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Asistencia` (
  `idAsistencia` INT NOT NULL AUTO_INCREMENT,
  `FechaAsistencia` VARCHAR(45) NOT NULL,
  `EstadoAsistencia` VARCHAR(45) NULL,
  `FKHora` INT NOT NULL,
  PRIMARY KEY (`idAsistencia`),
  CONSTRAINT `fk_Asistencia_Hora`
    FOREIGN KEY (`FKHora`)
    REFERENCES `Asistencia`.`Hora` (`idHora`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

ALTER TABLE `Asistencia`.`Asistencia` AUTO_INCREMENT = 2011013;

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

ALTER TABLE `Asistencia`.`DetalleAsistencia` AUTO_INCREMENT = 3011013;

-- -----------------------------------------------------
-- Table `Asistencia`.`Permisos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`Permisos` (
  `idPermisos` INT NOT NULL AUTO_INCREMENT,
  `FechaInicioPermiso` VARCHAR(45) NOT NULL,
  `FechaFinPermiso` VARCHAR(45) NOT NULL,
  `EstadoPermiso` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idPermisos`));

ALTER TABLE `Asistencia`.`Permisos` AUTO_INCREMENT = 4011113;

-- -----------------------------------------------------
-- Table `Asistencia`.`DetallePermisoUsuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Asistencia`.`DetallePermisoUsuario` (
  `idDetallePermisoUsuario` INT NOT NULL AUTO_INCREMENT,
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

ALTER TABLE `Asistencia`.`DetallePermisoUsuario` AUTO_INCREMENT = 4011213;