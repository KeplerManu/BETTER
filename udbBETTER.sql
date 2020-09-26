--CANNOT DROP DATABASE PROPERLY
use master
go

IF EXISTS(select * from sys.databases where name='udbBetter')
DROP DATABASE udbBetter
go

CREATE DATABASE udbBetter
go

USE udbBetter
go


--Creates the tblUser table
CREATE TABLE tblUser
(
 userId INT IDENTITY(100001,1) PRIMARY KEY,
 username NVARCHAR(20) NOT NULL UNIQUE,
 firstName NVARCHAR (50) NOT NULL,
 lastName NVARCHAR (50) NOT NULL,
 email NVARCHAR(50) NOT NULL UNIQUE,
 passcode NVARCHAR(20) NOT NULL,
 parentEmail NVARCHAR(50) NOT NULL,
 pIN INT NOT NULL,
 exercisePoints INT NOT NULL DEFAULT 0,
 retired BIT NOT NULL DEFAULT 0,
 active BIT NOT NULL DEFAULT 0,
 suspended BIT NOT NULL DEFAULT 0,
 creationDate DATETIME DEFAULT GETDATE(),
 pointsLastUploaded DATETIME DEFAULT 2010-01-01,
 )
 --Creates the tblElement table
 CREATE TABLE tblElement
 (
 elementId INT IDENTITY(01,1) PRIMARY KEY,
 elementName NVARCHAR(10) NOT NULL,
 suspended BIT NOT NULL DEFAULT 0
 )
 
 CREATE TABLE tblTitan
 (
 titanId INT IDENTITY(000001,1) PRIMARY KEY,
 titanName NVARCHAR(20) NOT NULL,
 userId INT NOT NULL,
 elementId INT NOT NULL,
 experience INT NOT NULL DEFAULT 0,
 active BIT NOT NULL DEFAULT 0,
 suspended BIT NOT NULL DEFAULT 0,
 creationDate DATETIME  NOT NULL DEFAULT GETDATE(),
 imagePath NVARCHAR(50) NOT NULL,
 
 CONSTRAINT fk_Owner FOREIGN KEY (userId) references tblUser(userId),
 CONSTRAINT fk_Element FOREIGN KEY (elementId) references tblElement(elementId)
 ) 
 
 CREATE TABLE tblBattle
 (
 battleId INT IDENTITY(000001,1) PRIMARY KEY,
 battler1 INT NOT NULL,
 battler2 INT NOT NULL,
 battleTime DATETIME NOT NULL DEFAULT GETDATE(),
 battleWinner BIT NOT NULL,
 CONSTRAINT fk_Battler1 FOREIGN KEY (battler1) references tblTitan(titanId),
 CONSTRAINT fk_Battler2 FOREIGN KEY (battler2) references tblTitan(titanId)
 )
 
 CREATE TABLE tblExperience
 (
 expId INT IDENTITY(001,1) PRIMARY KEY,
 lvl TINYINT NOT NULL,
 step TINYINT NOT NULL,
 expMax INT NOT NULL
 )

 INSERT INTO tblElement (elementName)
 VALUES ('Water'), ('Fire'), ('Air'), ('Earth')
 go

 INSERT INTO tblExperience (lvl, step, expMax)
 VALUES (1, 1, 200), (1, 2, 425), (1, 3, 675), (1, 4, 1000),
 (2, 1, 1400), (2, 2, 1900), (2, 3, 2400), (2, 4, 3000),
 (3, 1, 3700), (3, 2, 4500), (3, 3, 5400), (3, 4, 6400),
 (4, 1, 7500), (4, 2, 8700), (4, 3, 10000), (4, 4, 11500),
 (5, 1, 11501)
 go
 
INSERT INTO tblUser (username, firstName, lastName, email, passcode, parentEmail, pIN)
VALUES ('TestAccount1', 'John', 'Smith', 'JohnSmith@nonexistant.com', 'password', 'JohnSmithParent@alsononexistant.com', 5555),
('TestAccount2', 'Ned', 'Kennedy', 'Who@nonexistant.com', 'password', 'JohnSmithParent2@alsononexistant.com', 1111)
go

 INSERT INTO tblTitan (titanName, userId, elementId, experience, active, suspended, imagePath)
 VALUES ('Titan1', 100001, 1, 0, 1, 0, '~/Images/water.jpg'),
 ('Titan2', 100001, 2, 0, 1, 0, '~/Images/fire.png'),
 ('Titan3', 100001, 3, 0, 1, 0, '~/Images/air.png'),
 ('Titan4', 100001, 4, 0, 1, 0, '~/Images/earth.png'),
 ('Titan5', 100002, 1, 400, 1, 0, '~/Images/water.jpg'),
 ('Titan6', 100002, 2, 300, 1, 0, '~/Images/fire.png'),
 ('Titan7', 100002, 3, 201, 1, 0, '~/Images/air.png'),
 ('Titan8', 100002, 4, 674, 1, 0, '~/Images/earth.png'),
 ('TitanHOF', 100002, 4, 11501, 0, 1, '~/Images/earth.png')
 go

 INSERT INTO tblBattle (battler1, battler2, battleWinner)
VALUES (19, 11, 1)