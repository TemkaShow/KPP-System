-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema KPP_DB
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema KPP_DB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `KPP_DB` DEFAULT CHARACTER SET utf8 ;
USE `KPP_DB` ;

-- -----------------------------------------------------
-- Table `KPP_DB`.`Positions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `KPP_DB`.`Positions` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `position` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  UNIQUE INDEX `position_UNIQUE` (`position` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `KPP_DB`.`UserStatus`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `KPP_DB`.`UserStatus` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `status` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `KPP_DB`.`PassStatus`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `KPP_DB`.`PassStatus` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `status` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `KPP_DB`.`Passes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `KPP_DB`.`Passes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `issue_date` DATETIME NOT NULL,
  `expiration_date` DATETIME NOT NULL,
  `status_id` INT NOT NULL,
  PRIMARY KEY (`id`, `status_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_Passes_PassStatus1_idx` (`status_id` ASC) VISIBLE,
  CONSTRAINT `fk_Passes_PassStatus1`
    FOREIGN KEY (`status_id`)
    REFERENCES `KPP_DB`.`PassStatus` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `KPP_DB`.`Zones`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `KPP_DB`.`Zones` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `security_lvl` INT NULL,
  `capacity` INT NULL,
  `current_occupancy` INT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `KPP_DB`.`Users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `KPP_DB`.`Users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NULL,
  `phone_number` VARCHAR(45) NOT NULL,
  `address` VARCHAR(45) NOT NULL,
  `department` VARCHAR(45) NOT NULL,
  `hire_date` DATETIME NOT NULL,
  `position_id` INT NOT NULL,
  `status_id` INT NOT NULL,
  `pass_id` INT NOT NULL,
  `Zones_id` INT NOT NULL,
  PRIMARY KEY (`id`, `position_id`, `status_id`, `pass_id`, `Zones_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_Users_Positions_idx` (`position_id` ASC) VISIBLE,
  INDEX `fk_Users_UserStatus1_idx` (`status_id` ASC) VISIBLE,
  INDEX `fk_Users_Passes1_idx` (`pass_id` ASC) VISIBLE,
  INDEX `fk_Users_Zones1_idx` (`Zones_id` ASC) VISIBLE,
  CONSTRAINT `fk_Users_Positions`
    FOREIGN KEY (`position_id`)
    REFERENCES `KPP_DB`.`Positions` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Users_UserStatus1`
    FOREIGN KEY (`status_id`)
    REFERENCES `KPP_DB`.`UserStatus` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Users_Passes1`
    FOREIGN KEY (`pass_id`)
    REFERENCES `KPP_DB`.`Passes` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Users_Zones1`
    FOREIGN KEY (`Zones_id`)
    REFERENCES `KPP_DB`.`Zones` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
