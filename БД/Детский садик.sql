-- MySQL Script generated by MySQL Workbench
-- 03/13/15 04:41:17
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema kindergarten
-- -----------------------------------------------------
-- Детский садик "Колобок"

-- -----------------------------------------------------
-- Schema kindergarten
--
-- Детский садик "Колобок"
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `kindergarten` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `kindergarten` ;

-- -----------------------------------------------------
-- Table `kindergarten`.`tbl_children`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`tbl_children` (
  `ID` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `LName` VARCHAR(45) NOT NULL,
  `FName` VARCHAR(45) NOT NULL,
  `PName` VARCHAR(45) NOT NULL,
  `Birth` DATE NOT NULL,
  `Address` VARCHAR(45) NULL,
  `Group` VARCHAR(10) NULL,
  `MFName` VARCHAR(45) NULL,
  `MLName` VARCHAR(45) NULL,
  `MPName` VARCHAR(45) NULL,
  `MPhone` VARCHAR(45) NULL,
  `FFName` VARCHAR(45) NULL,
  `FLName` VARCHAR(45) NULL,
  `FPName` VARCHAR(45) NULL,
  `FPhone` VARCHAR(45) NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kindergarten`.`tbl_payment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`tbl_payment` (
  `ID` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Date` DATE NOT NULL,
  `Buyer` VARCHAR(60) NOT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kindergarten`.`tbl_goods`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`tbl_goods` (
  `IDPayment` INT UNSIGNED NOT NULL,
  `Gds` VARCHAR(60) NOT NULL,
  `Count` INT UNSIGNED NOT NULL DEFAULT 1,
  `Unit` VARCHAR(40) CHARACTER SET 'utf8' COLLATE 'utf8_general_ci' NOT NULL,
  `Price` DOUBLE UNSIGNED NOT NULL,
  INDEX `fk_tbl_goods_tbl_payment1_idx` (`IDPayment` ASC),
  CONSTRAINT `fk_tbl_goods_tbl_payment1`
    FOREIGN KEY (`IDPayment`)
    REFERENCES `kindergarten`.`tbl_payment` (`ID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kindergarten`.`tbl_payslip`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`tbl_payslip` (
  `ID` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Date` DATE NOT NULL,
  `ReportingFrom` DATE NOT NULL,
  `ReportingTo` DATE NOT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kindergarten`.`tbl_personnel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`tbl_personnel` (
  `ID` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `LName` VARCHAR(45) NOT NULL,
  `FName` VARCHAR(45) NOT NULL,
  `PName` VARCHAR(45) NOT NULL,
  `Post` VARCHAR(45) NOT NULL,
  `Salary` DOUBLE UNSIGNED NOT NULL,
  `DateReceipt` DATE NOT NULL,
  `DateDismissal` DATE NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kindergarten`.`tbl_payslipPeople`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`tbl_payslipPeople` (
  `IDPayslip` INT UNSIGNED NOT NULL,
  `IDPerson` INT UNSIGNED NOT NULL,
  `Name` VARCHAR(80) NOT NULL,
  `Post` VARCHAR(60) NOT NULL,
  `Salary` DOUBLE UNSIGNED NOT NULL,
  `WorkedDays` INT UNSIGNED NOT NULL,
  INDEX `fk_tbl_payslip_people_tbl_payslip1_idx` (`IDPayslip` ASC),
  INDEX `fk_tbl_payslipPeople_tbl_personnel1_idx` (`IDPerson` ASC),
  CONSTRAINT `fk_tbl_payslip_people_tbl_payslip1`
    FOREIGN KEY (`IDPayslip`)
    REFERENCES `kindergarten`.`tbl_payslip` (`ID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_tbl_payslipPeople_tbl_personnel1`
    FOREIGN KEY (`IDPerson`)
    REFERENCES `kindergarten`.`tbl_personnel` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kindergarten`.`tbl_history`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`tbl_history` (
  `ID` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Date` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Events` VARCHAR(100) NOT NULL,
  `User` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;

USE `kindergarten` ;

-- -----------------------------------------------------
-- Placeholder table for view `kindergarten`.`GetChildren`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`GetChildren` (`ID` INT, `LName` INT, `FName` INT, `PName` INT, `Birth` INT, `Address` INT, `Group` INT, `MFName` INT, `MLName` INT, `MPName` INT, `MPhone` INT, `FFName` INT, `FLName` INT, `FPName` INT, `FPhone` INT);

-- -----------------------------------------------------
-- Placeholder table for view `kindergarten`.`GetPayment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`GetPayment` (`ID` INT, `Date` INT, `Buyer` INT);

-- -----------------------------------------------------
-- Placeholder table for view `kindergarten`.`GetPersonnel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`GetPersonnel` (`ID` INT, `LName` INT, `FName` INT, `PName` INT, `Post` INT, `Salary` INT, `DateReceipt` INT, `DateDismissal` INT);

-- -----------------------------------------------------
-- Placeholder table for view `kindergarten`.`GetPayslip`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`GetPayslip` (`ID` INT, `Date` INT, `ReportingFrom` INT, `ReportingTo` INT);

-- -----------------------------------------------------
-- Placeholder table for view `kindergarten`.`GetPersonnelForPayslip`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`GetPersonnelForPayslip` (`ID` INT, `Name` INT, `Post` INT, `Salary` INT);

-- -----------------------------------------------------
-- Placeholder table for view `kindergarten`.`GetHistory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kindergarten`.`GetHistory` (`ID` INT, `Date` INT, `Events` INT, `User` INT);

-- -----------------------------------------------------
-- procedure GetChild
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetChild`(IN MyID INT UNSIGNED)
BEGIN
	SELECT * FROM tbl_children
		WHERE ID = MyID;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DelChild
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DelChild`(IN MyID INT UNSIGNED)
BEGIN
	DELETE FROM tbl_children 
    WHERE ID = MyID;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure UpdateChild
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateChild`(IN MyID INT UNSIGNED, IN MyFName VARCHAR(45), IN MyLName VARCHAR(45), IN MyPName VARCHAR(45), IN MyBirth DATE, IN MyAddress VARCHAR(45), IN MyGroup VARCHAR(10), 
IN MFName VARCHAR(45), IN MLName VARCHAR(45), IN MPName VARCHAR(45), IN MPhone VARCHAR(20), 
IN FFName VARCHAR(45), IN FLName VARCHAR(45), IN FPName VARCHAR(45), IN FPhone VARCHAR(20))
BEGIN
	UPDATE tbl_children
    SET `FName` = MyFName, `LName` = MyLName, `PName` = MyPName, `Birth` = MyBirth, `Address` = MyAddress, `Group` = MyGroup,
    `MFName` = MFName, `MLName` = MLName, `MPName` = MPName, `MPhone` = MPhone, 
    `FFName` = FFName, `FLName` = FLName, `FPName` = FPName, `FPhone` = FPhone
    WHERE `ID` = MyID;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure AddGoods
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddGoods`(IN MyId INT UNSIGNED, IN MyGds VARCHAR(60), IN MyCount INT, IN MyUnit VARCHAR(40), IN MyPrice DOUBLE)
BEGIN
	INSERT INTO tbl_goods (`IDPayment`, `Gds`, `Count`, `Unit`, `Price`) VALUES (MyId, MyGds, MyCount, MyUnit, MyPrice);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- function AddPayment
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `AddPayment`(MyDate DATE, MyBuyer VARCHAR(60)) 
RETURNS int(10) unsigned
BEGIN
	INSERT INTO tbl_payment (`Date`, `Buyer`) VALUES (MyDate, MyBuyer);
    RETURN last_insert_id();
END$$

DELIMITER ;

-- -----------------------------------------------------
-- function AddChild
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `AddChild`(MyFName VARCHAR(45), MyLName VARCHAR(45), MyPName VARCHAR(45), MyBirth DATE, MyAddress VARCHAR(45), MyGroup VARCHAR(10), 
MFName VARCHAR(45), MLName VARCHAR(45), MPName VARCHAR(45), MPhone VARCHAR(20), 
FFName VARCHAR(45), FLName VARCHAR(45), FPName VARCHAR(45), FPhone VARCHAR(20)) 
RETURNS int(10) unsigned
BEGIN
	INSERT INTO tbl_children (`FName`, `LName`, `PName`, `Birth`, `Address`, `Group`, 
    `MFName`, `MLName`, `MPName`, `MPhone`, 
    `FFName`, `FLName`, `FPName`, `FPhone`) VALUES (MyFName, MyLName, MyPName, MyBirth, MyAddress, MyGroup, 
    MFName, MLName, MPName, MPhone, 
    FFName, FLName, FPName, FPhone);

	RETURN last_insert_id();

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure GetGoodsByIDPayment
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetGoodsByIDPayment`(IN ID INT UNSIGNED)
BEGIN
	SELECT `Gds`, `Count`, `Unit`, `Price` FROM tbl_goods
    WHERE `IDPayment` = ID;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure AddPerson
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddPerson`(IN MyFName VARCHAR(45), IN MyLName VARCHAR(45), IN MyPName VARCHAR(45), IN MyPost VARCHAR(45), IN MySalary DOUBLE) 
BEGIN
	DECLARE lastID INT UNSIGNED;
	
	INSERT INTO tbl_personnel (`FName`, `LName`, `PName`, `Post`, `Salary`, `DateReceipt`) VALUES (MyFName, MyLName, MyPName, MyPost, MySalary, NOW());
	
    SET lastID = LAST_INSERT_ID();
    
    SELECT ID, DateReceipt FROM tbl_personnel
    WHERE ID = lastID;
    
END$$

DELIMITER ;

-- -----------------------------------------------------
-- function DelPerson
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `DelPerson`(MyID INT UNSIGNED) 
RETURNS DATE
BEGIN
	-- DECLARE dateDismissal DATE;
    SET @dateDismissal = (SELECT DateDismissal FROM tbl_personnel WHERE ID = MyID);
    
    IF @dateDismissal IS NULL THEN
		SET @dateDismissal = NOW();
        
        UPDATE tbl_personnel SET tbl_personnel.DateDismissal = @dateDismissal
		WHERE tbl_personnel.ID = MyID;
    END IF;
    
    RETURN @dateDismissal;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure UpdatePerson
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePerson`(IN MyID INT UNSIGNED, IN MyPost VARCHAR(45), IN MySalary DOUBLE)
BEGIN
	UPDATE tbl_personnel SET tbl_personnel.Post = MyPost,  tbl_personnel.Salary = MySalary
	WHERE tbl_personnel.ID = MyID;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure BringBackPerson
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `BringBackPerson`(IN MyID INT UNSIGNED) 
BEGIN
	UPDATE tbl_personnel SET tbl_personnel.DateDismissal = NULL
	WHERE tbl_personnel.ID = MyID;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- function AddPayslip
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `AddPayslip`(MyDate DATE, MyReportingFrom DATE, MyReportingTo DATE) 
RETURNS INT UNSIGNED
BEGIN
	INSERT INTO tbl_payslip (`Date`, `ReportingFrom`, `ReportingTo`) VALUES (MyDate, MyReportingFrom, MyReportingTo);
    
    RETURN LAST_INSERT_ID();
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure AddPayslipPeople
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddPayslipPeople`(IN MyIDPayslip INT UNSIGNED, IN MyIDPerson INT UNSIGNED, IN MyName VARCHAR(80), IN MyPost VARCHAR(80), IN MySalary DOUBLE, IN MyWorkedDays INT UNSIGNED)
BEGIN
	INSERT INTO tbl_payslipPeople (`IDPayslip`, `IDPerson`, `Name`, `Post`, `Salary`, `WorkedDays`) VALUES (MyIDPayslip, MyIDPerson, MyName, MyPost, MySalary, MyWorkedDays);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure GetPayslipPeopleAtIDPayslip
-- -----------------------------------------------------

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetPayslipPeopleAtIDPayslip`(IN ID INT UNSIGNED)
BEGIN
	SELECT tbl_payslipPeople.IDPerson, tbl_payslipPeople.Name, tbl_payslipPeople.Post, tbl_payslipPeople.Salary, tbl_payslipPeople.WorkedDays FROM tbl_payslipPeople
    WHERE `IDPayslip` = ID
    GROUP BY tbl_payslipPeople.IDPerson;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- View `kindergarten`.`GetChildren`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kindergarten`.`GetChildren`;
USE `kindergarten`;
CREATE  OR REPLACE VIEW `GetChildren` AS
SELECT * FROM tbl_children
GROUP BY tbl_children.LName, tbl_children.FName, tbl_children.PName;

-- -----------------------------------------------------
-- View `kindergarten`.`GetPayment`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kindergarten`.`GetPayment`;
USE `kindergarten`;
CREATE  OR REPLACE VIEW `GetPayment` AS
SELECT * FROM tbl_payment
GROUP BY tbl_payment.ID DESC;


-- -----------------------------------------------------
-- View `kindergarten`.`GetPersonnel`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kindergarten`.`GetPersonnel`;
USE `kindergarten`;
CREATE  OR REPLACE VIEW `GetPersonnel` AS
SELECT * FROM tbl_personnel
GROUP BY tbl_personnel.DateDismissal, tbl_personnel.ID;


-- -----------------------------------------------------
-- View `kindergarten`.`GetPayslip`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kindergarten`.`GetPayslip`;
USE `kindergarten`;
CREATE  OR REPLACE VIEW `GetPayslip` AS
SELECT * FROM tbl_payslip
GROUP BY tbl_payslip.ID DESC;

-- -----------------------------------------------------
-- View `kindergarten`.`GetPersonnelForPayslip`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kindergarten`.`GetPersonnelForPayslip`;
USE `kindergarten`;
CREATE  OR REPLACE VIEW `GetPersonnelForPayslip` AS
SELECT tbl_personnel.ID ,CONCAT(tbl_personnel.LName, ' ', SubString(tbl_personnel.FName, 1, 1), '. ', SubString(tbl_personnel.PName, 1, 1), '. ') AS Name, tbl_personnel.Post, tbl_personnel.Salary FROM tbl_personnel
WHERE tbl_personnel.DateDismissal IS NULL
GROUP BY Name;

-- -----------------------------------------------------
-- View `kindergarten`.`GetHistory`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `kindergarten`.`GetHistory`;
USE `kindergarten`;
CREATE  OR REPLACE VIEW `GetHistory` AS
SELECT * FROM tbl_history
GROUP BY tbl_history.ID DESC;

USE `kindergarten`;

DELIMITER $$
USE `kindergarten`$$
CREATE DEFINER = CURRENT_USER TRIGGER `kindergarten`.`tbl_children_AFTER_INSERT` AFTER INSERT ON `tbl_children` FOR EACH ROW
BEGIN
	INSERT INTO tbl_history (`Events`, `User`)
    VALUES (CONCAT('Новый ребёнок \'', NEW.LName, ' ', SUBSTRING(NEW.FName, 1, 1), '. ', SUBSTRING(NEW.PName, 1, 1), '.\''), 
    USER());
END$$

USE `kindergarten`$$
CREATE DEFINER = CURRENT_USER TRIGGER `kindergarten`.`tbl_children_AFTER_UPDATE` AFTER UPDATE ON `tbl_children` FOR EACH ROW
BEGIN
	INSERT INTO tbl_history (`Events`, `User`)
    VALUES (CONCAT('Новые изменения у ребёнка \'', NEW.LName, ' ', SUBSTRING(NEW.FName, 1, 1), '. ', SUBSTRING(NEW.PName, 1, 1), '.\''), 
    USER());
END$$

USE `kindergarten`$$
CREATE DEFINER = CURRENT_USER TRIGGER `kindergarten`.`tbl_children_BEFORE_DELETE` BEFORE DELETE ON `tbl_children` FOR EACH ROW
BEGIN
	INSERT INTO tbl_history (`Events`, `User`)
    VALUES (CONCAT('Удаление ребёнка \'', OLD.LName, ' ', SUBSTRING(OLD.FName, 1, 1), '. ', SUBSTRING(OLD.PName, 1, 1), '.\''), 
    USER());
END$$

USE `kindergarten`$$
CREATE DEFINER = CURRENT_USER TRIGGER `kindergarten`.`tbl_payment_AFTER_INSERT` AFTER INSERT ON `tbl_payment` FOR EACH ROW
BEGIN
	INSERT INTO tbl_history (`Events`, `User`)
    VALUES (CONCAT('Новая квитанция \'', NEW.Buyer, '\''), 
    USER());
END$$

USE `kindergarten`$$
CREATE DEFINER = CURRENT_USER TRIGGER `kindergarten`.`tbl_payslip_AFTER_INSERT` AFTER INSERT ON `tbl_payslip` FOR EACH ROW
BEGIN
	INSERT INTO tbl_history (`Events`, `User`)
    VALUES (CONCAT('Добавлена расчётная ведомость №', NEW.ID), USER());
END$$

USE `kindergarten`$$
CREATE DEFINER = CURRENT_USER TRIGGER `kindergarten`.`tbl_personnel_AFTER_INSERT` AFTER INSERT ON `tbl_personnel` FOR EACH ROW
BEGIN
	INSERT INTO tbl_history (`Events`, `User`)
    VALUES (CONCAT('Новый сотрудник \'', NEW.LName, ' ', SUBSTRING(NEW.FName, 1, 1), '. ', SUBSTRING(NEW.PName, 1, 1), '.\''), 
    USER());
END$$

USE `kindergarten`$$
CREATE DEFINER = CURRENT_USER TRIGGER `kindergarten`.`tbl_personnel_AFTER_UPDATE` AFTER UPDATE ON `tbl_personnel` FOR EACH ROW
BEGIN
	DECLARE MyEvents VARCHAR(100);
    SET MyEvents = CONCAT(' \'', NEW.LName, ' ', SUBSTRING(NEW.FName, 1, 1), '. ', SUBSTRING(NEW.PName, 1, 1), '.\'');
    
    IF NEW.DateDismissal IS NOT NULL THEN
		SET MyEvents = CONCAT('Уволен сотрудник', MyEvents);
	ELSEIF OLD.DateDismissal IS NULL THEN
		SET MyEvents = CONCAT('Новые изменения у сотрудника', MyEvents);
	ELSE
		SET MyEvents = CONCAT('Восстановлен сотрудник', MyEvents);
	END IF;
    
    INSERT INTO tbl_history (`Events`, `User`) VALUES (MyEvents, USER());
END$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
