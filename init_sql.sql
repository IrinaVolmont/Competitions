--
-- Файл сгенерирован с помощью SQLiteStudio v3.2.1 в Пн апр 13 00:24:17 2020
--
-- Использованная кодировка текста: UTF-8
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Таблица: Competition
DROP TABLE IF EXISTS Competition;
CREATE TABLE Competition (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL);

-- Таблица: CompetitionResult
DROP TABLE IF EXISTS CompetitionResult;
CREATE TABLE CompetitionResult (ID INTEGER PRIMARY KEY AUTOINCREMENT, TryNumber INTEGER NOT NULL, Member INTEGER REFERENCES Member (ID), Evaluation INTEGER NOT NULL, ConductCompetition INTEGER REFERENCES ConductCompetition (ID), UNIQUE (TryNumber, Member, ConductCompetition));

-- Таблица: ConductCompetition
DROP TABLE IF EXISTS ConductCompetition;
CREATE TABLE ConductCompetition (ID INTEGER PRIMARY KEY AUTOINCREMENT, SportTypeCompetition INTEGER REFERENCES SportTypeCompetition (ID), DateTime DATETIME NOT NULL, UNIQUE (DateTime, SportTypeCompetition));

-- Таблица: Discipline
DROP TABLE IF EXISTS Discipline;
CREATE TABLE Discipline (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL UNIQUE, UnitType INTEGER REFERENCES UnitType (ID) NOT NULL);

-- Таблица: Employee
DROP TABLE IF EXISTS Employee;
CREATE TABLE Employee (ID INTEGER PRIMARY KEY AUTOINCREMENT, Login TEXT NOT NULL UNIQUE, FullName TEXT NOT NULL, Role INTEGER REFERENCES Role (ID) NOT NULL);

-- Таблица: Member
DROP TABLE IF EXISTS Member;
CREATE TABLE Member (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, FullName TEXT NOT NULL, DateOfBirth DATETIME NOT NULL);

-- Таблица: Role
DROP TABLE IF EXISTS Role;
CREATE TABLE Role (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL UNIQUE);

-- Таблица: SportType
DROP TABLE IF EXISTS SportType;
CREATE TABLE SportType (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL UNIQUE);

-- Таблица: SportTypeCompetition
DROP TABLE IF EXISTS SportTypeCompetition;
CREATE TABLE SportTypeCompetition (ID INTEGER PRIMARY KEY AUTOINCREMENT, Competition INTEGER REFERENCES Competition (ID) NOT NULL, SportTypeDiscipline INTEGER NOT NULL REFERENCES SportTypeDiscipline (ID), UNIQUE (Competition, SportTypeDiscipline));

-- Таблица: SportTypeDiscipline
DROP TABLE IF EXISTS SportTypeDiscipline;
CREATE TABLE SportTypeDiscipline (ID INTEGER PRIMARY KEY AUTOINCREMENT, SportType INTEGER REFERENCES SportType (ID) NOT NULL, Discipline INTEGER REFERENCES Discipline (ID) NOT NULL, UNIQUE (SportType, Discipline));

-- Таблица: UnitType
DROP TABLE IF EXISTS UnitType;
CREATE TABLE UnitType (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL UNIQUE);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
