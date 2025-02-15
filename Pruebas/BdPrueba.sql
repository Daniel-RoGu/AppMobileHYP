CREATE TABLE IF NOT EXISTS `TipoUsuario` (
  `idTipoUsuario` INT NOT NULL,
  `TipoUsuario` VARCHAR(45) NOT NULL,
  `EstadoTipoUsuario` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idTipoUsuario`));

CREATE TABLE IF NOT EXISTS `RangoNumerosTarjetero` (
  `idRangoNumerosTarjetero` INT NOT NULL,
  `TipoRango` VARCHAR(450) NOT NULL,
  `RangoSuperior` INT(250) NOT NULL,
  `RangoInferior` INT(250) NOT NULL,
  `EstadoRango` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idRangoNumerosTarjetero`));

CREATE TABLE IF NOT EXISTS `Empresa` (
  `idEmpresa` INT NOT NULL,
  `NombreEmpresa` VARCHAR(450) NOT NULL,
  `NITEmpresa` VARCHAR(45) NOT NULL,
  `LogoEmpresa` VARCHAR(45) NOT NULL,
  `EstadoEmpresa` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idEmpresa`));

CREATE TABLE IF NOT EXISTS `Locacion` (
  `idLocacion` INT NOT NULL,
  `NombreLocacion` VARCHAR(450) NOT NULL,
  `RIG` VARCHAR(450) NOT NULL,
  `Pozo` VARCHAR(450) NULL,
  `EstadoLocacion` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idLocacion`));


CREATE TABLE IF NOT EXISTS `Tarjetero` (
  `idTarjetero` INT NOT NULL,
  `NumeroTarjetero` INT(250) NOT NULL,
  `EstadoNumero` VARCHAR(45) NOT NULL,
  `FKRangoNumerosTarjetero` INT NOT NULL,
  `Empresa_idEmpresa` INT NOT NULL,
  `Locacion_idLocacion` INT NOT NULL,
  PRIMARY KEY (`idTarjetero`),
  CONSTRAINT `fk_Tarjetero_RangoNumerosTarjetero1`
    FOREIGN KEY (`FKRangoNumerosTarjetero`)
    REFERENCES `RangoNumerosTarjetero` (`idRangoNumerosTarjetero`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Tarjetero_Empresa1`
    FOREIGN KEY (`Empresa_idEmpresa`)
    REFERENCES `Empresa` (`idEmpresa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Tarjetero_Locacion1`
    FOREIGN KEY (`Locacion_idLocacion`)
    REFERENCES `Locacion` (`idLocacion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `Usuario` (
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
    REFERENCES `TipoUsuario` (`idTipoUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Usuario_Tarjetero1`
    FOREIGN KEY (`FKTarjetero`)
    REFERENCES `Tarjetero` (`idTarjetero`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


CREATE TABLE IF NOT EXISTS `Hora` (
  `idHora` INT NOT NULL,
  `HoraInicio` VARCHAR(45) NOT NULL,
  `HoraFin` VARCHAR(45) NOT NULL,
  `EstadoHora` VARCHAR(45) NULL,
  PRIMARY KEY (`idHora`));

CREATE TABLE IF NOT EXISTS `Asistencia` (
  `idAsistencia` INT NOT NULL,
  `FechaAsistencia` VARCHAR(45) NOT NULL,
  `EstadoAsistencia` VARCHAR(45) NULL,
  `FKHora` INT NOT NULL,
  PRIMARY KEY (`idAsistencia`),
  CONSTRAINT `fk_Asistencia_Hora`
    FOREIGN KEY (`FKHora`)
    REFERENCES `Hora` (`idHora`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `DetalleAsistencia` (
  `idDetalleAsistencia` INT NOT NULL,
  `EstadoAsistenciaUsuario` VARCHAR(45) NOT NULL,
  `FKUsuario` INT NOT NULL,
  `FKAsistencia` INT NOT NULL,
  PRIMARY KEY (`idDetalleAsistencia`),
  CONSTRAINT `fk_DetalleAsistencia_Usuario1`
    FOREIGN KEY (`FKUsuario`)
    REFERENCES `Usuario` (`identificacionUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DetalleAsistencia_Asistencia1`
    FOREIGN KEY (`FKAsistencia`)
    REFERENCES `Asistencia` (`idAsistencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS `Permisos` (
  `idPermisos` INT NOT NULL,
  `FechaInicioPermiso` VARCHAR(45) NOT NULL,
  `FechaFinPermiso` VARCHAR(45) NOT NULL,
  `EstadoPermiso` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idPermisos`));

CREATE TABLE IF NOT EXISTS `DetallePermisoUsuario` (
  `idDetallePermisoUsuario` INT NOT NULL,
  `DetallePermisoUsuario` VARCHAR(450) NOT NULL,
  `EstadoPermisoUsuario` VARCHAR(45) NOT NULL,
  `FKUsuario` INT NOT NULL,
  `FKPermisos` INT NOT NULL,
  PRIMARY KEY (`idDetallePermisoUsuario`),
  CONSTRAINT `fk_DetallePermisoUsuario_Usuario1`
    FOREIGN KEY (`FKUsuario`)
    REFERENCES `Usuario` (`identificacionUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DetallePermisoUsuario_Permisos1`
    FOREIGN KEY (`FKPermisos`)
    REFERENCES `Permisos` (`idPermisos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);