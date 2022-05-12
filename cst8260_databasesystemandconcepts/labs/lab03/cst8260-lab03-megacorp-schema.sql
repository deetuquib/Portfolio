SET NAMES utf8;
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

DROP SCHEMA IF EXISTS MEGACORP;
CREATE SCHEMA MEGACORP;
USE MEGACORP;

CREATE TABLE IF NOT EXISTS `employee` (
    `EmplId` INT UNIQUE NOT NULL AUTO_INCREMENT,  -- Unique numeric identifier for each employee
    `EmplFname` VARCHAR(25) NOT NULL,  -- Employee's first name
    `EmplLname` VARCHAR(25) NOT NULL,  -- Employee's last name
    `EmplOffice` VARCHAR(5) NOT NULL,  -- Employee's office number
    `EmplPhone` VARCHAR(25),  -- Employee's phone number
    `EmplDept` INT NOT NULL,  -- Which department the employee works in (DeptId from department table)
    PRIMARY KEY (`EmplId`),
    KEY `idxFkEmplDept` (`EmplDept`),
    CONSTRAINT `fkEmplDept` FOREIGN KEY (`EmplDept`) REFERENCES `department` (`DeptId`) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS `department` (
    `DeptId` INT UNIQUE NOT NULL AUTO_INCREMENT,  -- Unique numeric identifier for each dept
    `DeptName` VARCHAR(25) NOT NULL,  -- Department name
    `DeptOffice` VARCHAR(5) NOT NULL,  -- Department main office number
    `DeptPhone` VARCHAR(25) NOT NULL,  -- Department main phone number
    `DeptSupervisor` INT NOT NULL,  -- EmplId of supervisor (EmplId from employee table)
    PRIMARY KEY (`DeptId`),
    KEY `idxFkDeptSupervisor` (`DeptSupervisor`),
    CONSTRAINT `fkDeptSupervisor` FOREIGN KEY (`DeptSupervisor`) REFERENCES `employee` (`EmplId`) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS `project` (
    `ProjectId` INT UNIQUE NOT NULL AUTO_INCREMENT,  -- Unique numeric identifier for each project
    `ProjectClient` VARCHAR(15) NOT NULL,  -- Short name of client
    `ProjectLead` INT NOT NULL,  -- Employee in charge of each project (EmplId from employee table)
    `ProjectContactPhone` VARCHAR(25),  -- Client contact phone number
    PRIMARY KEY (`ProjectId`),
    KEY `idxFkProjectLead` (`ProjectLead`),
    CONSTRAINT `fkProjectLead` FOREIGN KEY (`ProjectLead`) REFERENCES `employee` (`EmplId`) ON DELETE RESTRICT ON UPDATE CASCADE
);
