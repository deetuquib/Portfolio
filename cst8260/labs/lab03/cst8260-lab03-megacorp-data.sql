SET NAMES utf8;
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

USE MEGACORP;

INSERT INTO employee (
    EmplId,
    EmplFname,
    EmplLname,
    EmplOffice,
    EmplPhone,
    EmplDept
) VALUES
    (1, 'Jack', 'Simpson', 'B728', '(614) 727-4411', 1),
    (2, 'Jim', 'McDonald', 'B728', '(614) 727-4412', 2),
    (3, 'William', 'Frane', 'B791', '(614) 727-4455', 3),
    (4, 'Linda', 'Zeller', 'B735', '(614) 727-4423', 2)
;

