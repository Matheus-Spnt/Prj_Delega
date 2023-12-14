-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`administrador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `administrador` (
  `id_adm` INT NOT NULL AUTO_INCREMENT,
  `nome_adm` VARCHAR(100) NULL,
  `cpf_adm` VARCHAR(45) NULL,
  `senha_adm` VARCHAR(45) NULL,
  PRIMARY KEY (`id_adm`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`cargos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cargos` (
  `id_cargos` INT NOT NULL AUTO_INCREMENT,
  `nome_cargos` VARCHAR(45) NULL,
  PRIMARY KEY (`id_cargos`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`funcionario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `funcionario` (
  `id_funcionario` INT NOT NULL AUTO_INCREMENT,
  `nome_funcionario` VARCHAR(100) NULL,
  `cpf_funcionario` VARCHAR(45) NULL,
  `senha_funcionario` VARCHAR(45) NULL,
  `administrador_id_adm` INT NOT NULL,
  `cargos_id_cargos` INT NOT NULL,
  PRIMARY KEY (`id_funcionario`, `administrador_id_adm`, `cargos_id_cargos`),
  INDEX `fk_funcionario_administrador_idx` (`administrador_id_adm` ASC),
  INDEX `fk_funcionario_cargos1_idx` (`cargos_id_cargos` ASC),
  CONSTRAINT `fk_funcionario_administrador`
    FOREIGN KEY (`administrador_id_adm`)
    REFERENCES `mydb`.`administrador` (`id_adm`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_funcionario_cargos1`
    FOREIGN KEY (`cargos_id_cargos`)
    REFERENCES `mydb`.`cargos` (`id_cargos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`funcoes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `funcoes` (
  `id_funcoes` INT NOT NULL AUTO_INCREMENT,
  `nome_funcoes` VARCHAR(100) NULL,
  `desc_funcoes` VARCHAR(250) NULL,
  `ex_funcoes` BOOL NOT NULL,
  `administrador_id_adm` INT NOT NULL,
  `cargos_id_cargos` INT NOT NULL,
  `funcionario_id_funcionario` INT NOT NULL,
  PRIMARY KEY (`id_funcoes`, `administrador_id_adm`, `cargos_id_cargos`, `funcionario_id_funcionario`),
  INDEX `fk_funcoes_administrador1_idx` (`administrador_id_adm` ASC),
  INDEX `fk_funcoes_cargos1_idx` (`cargos_id_cargos` ASC),
  INDEX `fk_funcoes_funcionario1_idx` (`funcionario_id_funcionario` ASC),
  CONSTRAINT `fk_funcoes_administrador1`
    FOREIGN KEY (`administrador_id_adm`)
    REFERENCES `mydb`.`administrador` (`id_adm`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_funcoes_cargos1`
    FOREIGN KEY (`cargos_id_cargos`)
    REFERENCES `mydb`.`cargos` (`id_cargos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_funcoes_funcionario1`
    FOREIGN KEY (`funcionario_id_funcionario`)
    REFERENCES `mydb`.`funcionario` (`id_funcionario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

/*ALTER TABLE `funcoes` ADD COLUMN `ex_funcoes` BOOL NOT NULL;*/

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


/* Cargos */

INSERT INTO `cargos` (`nome_cargos`)
VALUES 
  ('Transporte'),
  ('Carregador'),
  ('Vistoria');

/* Adm */

INSERT INTO `administrador` (`nome_adm`, `cpf_adm`, `senha_adm`)
VALUES 
  ('Alice Adams', '123456789', 'password1'),
  ('Bob Brown', '987654321', 'password2'),
  ('Claire Carter', '111223344', 'password3');
  
 /* Funcionário */

INSERT INTO `funcionario` (`nome_funcionario`, `cpf_funcionario`, `senha_funcionario`, `administrador_id_adm`, `cargos_id_cargos`)
VALUES 
  ('David Davis', '555111222', 'pass123', 1, 1),
  ('Emily Evans', '333444555', 'pass456', 1, 2),
  ('Frank Fisher', '777888999', 'pass789', 1, 3),
  ('Grace Green', '555111221', 'pass123', 2, 1),
  ('Henry Harrison', '333444552', 'pass456', 2, 2),
  ('Isabella Ingram', '777888993', 'pass789', 2, 3),
  ('Jake Johnson', '555111224', 'pass123', 3, 1),
  ('Kelly Knight', '333444556', 'pass456', 3, 2),
  ('Liam Lawson', '777888996', 'pass789', 3, 3);
  
  
  /* Funções */
  
  INSERT INTO `funcoes` (`nome_funcoes`, `desc_funcoes`, `ex_funcoes`, `administrador_id_adm`, `cargos_id_cargos`, `funcionario_id_funcionario`)
VALUES 
  ('Funcao1.1', 'Descricao1', 1, 1, 1, 1),
  ('Funcao1.2', 'Descricao1', 0, 1, 1, 1),
  ('Funcao1.3', 'Descricao1', 0, 1, 1, 1),
  ('Funcao2', 'Descricao2', 0, 1, 2, 2),
  ('Funcao3', 'Descricao3', 1, 1, 3, 3),
  ('Funcao1', 'Descricao1', 1, 2, 1, 4),
  ('Funcao2', 'Descricao2', 0, 2, 2, 5),
  ('Funcao3', 'Descricao3', 1, 2, 3, 6),
  ('Funcao1', 'Descricao1', 1, 3, 1, 7),
  ('Funcao2', 'Descricao2', 0, 3, 2, 8),
  ('Funcao3', 'Descricao3', 1, 3, 3, 9);
  
  
select fn.id_funcoes, fn.nome_funcoes, fn.desc_funcoes from funcoes fn join cargos c on(c.id_cargos = fn.cargos_id_cargos) join funcionario f on(f.id_funcionario = fn.funcionario_id_funcionario) where fn.funcionario_id_funcionario = 1 and ex_funcoes = 0 and fn.cargos_id_cargos= 1 ; 