-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema sic_bd
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema sic_bd
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `sic_bd` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
USE `sic_bd` ;

-- -----------------------------------------------------
-- Table `sic_bd`.`info_colaborador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`info_colaborador` (
  `no_nomina` INT UNSIGNED NOT NULL,
  `colab_nombres` VARCHAR(45) NOT NULL,
  `colab_ap_paterno` VARCHAR(45) NOT NULL,
  `colab_ap_materno` VARCHAR(45) NOT NULL,
  `colab_rfc` VARCHAR(13) NOT NULL,
  `colab_curp` VARCHAR(18) NOT NULL,
  `colab_fecha_nac` DATE NOT NULL,
  `colab_sexo` INT UNSIGNED NOT NULL,
  `colab_est_civil` VARCHAR(45) NOT NULL,
  `colab_pais` INT NOT NULL,
  `colab_fecha_alta` TIMESTAMP NOT NULL,
  `colab_fecha_baja` TIMESTAMP NULL DEFAULT NULL,
  `colab_alta_isste` DATETIME NULL DEFAULT NULL,
  `colab_nss` VARCHAR(45) NOT NULL,
  `colab_lentes` TINYINT NOT NULL,
  `colab_cp_sat` VARCHAR(45) NULL DEFAULT NULL,
  `colab_salario` INT UNSIGNED NULL DEFAULT NULL,
  `colab_tipo_sangre` VARCHAR(45) NOT NULL,
  `colab_direccion` VARCHAR(255) NOT NULL,
  `colab_colonia` VARCHAR(45) NOT NULL,
  `colab_manz` VARCHAR(45) NOT NULL,
  `colab_lote` VARCHAR(45) NOT NULL,
  `colab_num_int` VARCHAR(45) NOT NULL,
  `colab_num_ext` VARCHAR(45) NOT NULL,
  `colab_cp` VARCHAR(45) NOT NULL,
  `colab_calle` VARCHAR(45) NOT NULL,
  `colab_av` VARCHAR(45) NOT NULL,
  `colab_fracc` VARCHAR(45) NOT NULL,
  `colab_estado` VARCHAR(45) NOT NULL,
  `colab_puesto` VARCHAR(255) NULL DEFAULT NULL,
  `colab_paqueteria` VARCHAR(100) NULL DEFAULT NULL,
  `colab_lenguaje_programacion` VARCHAR(100) NULL DEFAULT NULL,
  `colab_lengua_indigena` VARCHAR(45) NULL DEFAULT NULL,
  `colab_trayectoria_anios` TINYINT NULL DEFAULT NULL,
  `colab_gobierno` TINYINT NULL DEFAULT NULL,
  PRIMARY KEY (`no_nomina`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`alergias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`alergias` (
  `alergias_id` INT NOT NULL AUTO_INCREMENT,
  `no_nomina` INT UNSIGNED NOT NULL,
  `alergias_descripcion` TEXT NOT NULL,
  PRIMARY KEY (`alergias_id`),
  INDEX `no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  CONSTRAINT `fk_alergia_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`permisos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`permisos` (
  `permisos_id` INT NOT NULL,
  `permisos_tipo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`permisos_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_acceso`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_acceso` (
  `acceso_user` VARCHAR(16) NOT NULL,
  `no_nomina` INT UNSIGNED NOT NULL,
  `acceso_contrasena` VARCHAR(32) NOT NULL,
  `acceso_permiso` INT NOT NULL,
  `create_time` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  INDEX `no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  INDEX `fk_permisos_tipos_idx` (`acceso_permiso` ASC) VISIBLE,
  CONSTRAINT `fk_permisos_tipos`
    FOREIGN KEY (`acceso_permiso`)
    REFERENCES `sic_bd`.`permisos` (`permisos_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_capacitacion_tipo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_capacitacion_tipo` (
  `capacitacion_tipo_id` INT NOT NULL AUTO_INCREMENT,
  `capacitacion_tipo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`capacitacion_tipo_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_capacitacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_capacitacion` (
  `capacitacion_id` INT NOT NULL,
  `no_nomina` INT UNSIGNED NOT NULL,
  `capacitacion_nombre` VARCHAR(100) NOT NULL,
  `capacitacion_tipo` INT NOT NULL,
  PRIMARY KEY (`capacitacion_id`),
  INDEX `no_nomina_idx` (`no_nomina` ASC) INVISIBLE,
  INDEX `fk_capacitacion_tipo_capacitacion_tipo_id_idx` (`capacitacion_tipo` ASC) VISIBLE,
  CONSTRAINT `fk_capacitacion_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_capacitacion_tipo_capacitacion_tipo_id`
    FOREIGN KEY (`capacitacion_tipo`)
    REFERENCES `sic_bd`.`colab_capacitacion_tipo` (`capacitacion_tipo_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_cel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_cel` (
  `colab_cel` INT NOT NULL,
  `no_nomina` INT UNSIGNED NOT NULL,
  `cel_tipo` ENUM('Personal', 'Casa', 'Trabajo') NOT NULL,
  `ext` INT NULL DEFAULT NULL,
  PRIMARY KEY (`colab_cel`),
  INDEX `no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  CONSTRAINT `fk_cel_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_contacto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_contacto` (
  `contacto_celular` VARCHAR(45) NOT NULL,
  `no_nomina` INT UNSIGNED NOT NULL,
  `contacto_nombre` VARCHAR(45) NOT NULL,
  `contacto_parentesco` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`contacto_celular`),
  INDEX `no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  CONSTRAINT `fk_contacto_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_correo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_correo` (
  `colab_correo` VARCHAR(45) NOT NULL,
  `no_nomina` INT UNSIGNED NOT NULL,
  `correo_tipo` ENUM('Personal', 'Institucional') NULL DEFAULT NULL,
  PRIMARY KEY (`colab_correo`),
  INDEX `no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  CONSTRAINT `fk_correo_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_dependientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_dependientes` (
  `id_dependiente` INT NOT NULL AUTO_INCREMENT,
  `no_nomina` INT UNSIGNED NOT NULL,
  `dependiente_nombre` VARCHAR(50) NULL DEFAULT NULL,
  `dependiente_parentesco` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id_dependiente`),
  INDEX `no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  CONSTRAINT `fk_dependientes_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_exp_laboral`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_exp_laboral` (
  `id_exp_laboral` TINYINT NOT NULL,
  `no_nomina` INT UNSIGNED NOT NULL,
  `empresa_nombre` VARCHAR(45) NOT NULL,
  `trabajo_inicio` DATE NOT NULL,
  `trabajo_fin` DATE NOT NULL,
  `trabajo_puesto` VARCHAR(100) NOT NULL,
  `trabajo_area` VARCHAR(100) NOT NULL,
  `trabajo_sueldo` INT NOT NULL,
  `jefe_nombre` VARCHAR(50) NOT NULL,
  `jefe_puesto` VARCHAR(100) NOT NULL,
  `jefe_cel` VARCHAR(45) NOT NULL,
  `trabajo_razon_sepracion` TEXT NOT NULL,
  PRIMARY KEY (`id_exp_laboral`),
  INDEX `fk_exp_no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  CONSTRAINT `fk_exp_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_grado_actual`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_grado_actual` (
  `id_grado_actual` INT NOT NULL,
  `no_nomina` INT UNSIGNED NOT NULL,
  `grado_actual` VARCHAR(45) NOT NULL,
  `grado_institucion` VARCHAR(45) NOT NULL,
  `grado_nombre` VARCHAR(45) NOT NULL,
  `grado_nivel` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_grado_actual`),
  INDEX `no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  CONSTRAINT `fk_grado_actual_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_grados_tipos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_grados_tipos` (
  `grado_tipo_id` INT NOT NULL,
  `grado_tipo` INT NULL DEFAULT NULL,
  PRIMARY KEY (`grado_tipo_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_grados`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_grados` (
  `grado_folio` INT NOT NULL,
  `no_nomina` INT UNSIGNED NOT NULL,
  `grado_nombre` VARCHAR(45) NULL DEFAULT NULL,
  `grado_cedula` VARCHAR(45) NULL DEFAULT NULL,
  `grado_tipo` INT NULL DEFAULT NULL,
  `grado_ultimo` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL,
  PRIMARY KEY (`grado_folio`),
  INDEX `no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  INDEX `fk_grado_tipo_idx` (`grado_tipo` ASC) VISIBLE,
  CONSTRAINT `fk_grado_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_grado_tipo`
    FOREIGN KEY (`grado_tipo`)
    REFERENCES `sic_bd`.`colab_grados_tipos` (`grado_tipo_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`colab_idiomas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`colab_idiomas` (
  `id_colab_idioma` TINYINT UNSIGNED NOT NULL,
  `no_nomina` INT UNSIGNED NOT NULL,
  `idioma_nombre` VARCHAR(45) NULL DEFAULT NULL,
  `idioma_dominio` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id_colab_idioma`),
  INDEX `fk_idiomas_no_nomina_idx` (`no_nomina` ASC) INVISIBLE,
  CONSTRAINT `fk_idiomas_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `sic_bd`.`discapacidades`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`discapacidades` (
  `discapacidad_id` INT NOT NULL AUTO_INCREMENT,
  `no_nomina` INT UNSIGNED NOT NULL,
  `discapacidades` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`discapacidad_id`),
  INDEX `no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  CONSTRAINT `fk_discapidad_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci
COMMENT = 'Discapacidades con concatenación en back';


-- -----------------------------------------------------
-- Table `sic_bd`.`informacion_hijos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sic_bd`.`informacion_hijos` (
  `hijo_curp` VARCHAR(45) NOT NULL,
  `no_nomina` INT UNSIGNED NOT NULL,
  `hijo_nombre` VARCHAR(45) NULL DEFAULT NULL,
  `hijo_fecha_nac` DATE NULL DEFAULT NULL,
  `hijo_sexo` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`hijo_curp`),
  INDEX `no_nomina_idx` (`no_nomina` ASC) VISIBLE,
  CONSTRAINT `fk_hijo_no_nomina`
    FOREIGN KEY (`no_nomina`)
    REFERENCES `sic_bd`.`info_colaborador` (`no_nomina`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
