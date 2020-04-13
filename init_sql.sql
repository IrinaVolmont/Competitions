--
-- Файл сгенерирован с помощью SQLiteStudio v3.2.1 в Пн апр 13 11:49:24 2020
--
-- Использованная кодировка текста: UTF-8
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Таблица: Competition
DROP TABLE IF EXISTS Competition;
CREATE TABLE Competition (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL);
INSERT INTO Competition (ID, Name) VALUES (1, 'Чемпионат и первенство Санкт-Петербурга');
INSERT INTO Competition (ID, Name) VALUES (2, 'Kids-Cross');
INSERT INTO Competition (ID, Name) VALUES (3, 'Кубок');

-- Таблица: CompetitionResult
DROP TABLE IF EXISTS CompetitionResult;
CREATE TABLE CompetitionResult (ID INTEGER PRIMARY KEY AUTOINCREMENT, TryNumber INTEGER NOT NULL, Member INTEGER REFERENCES Member (ID), Evaluation INTEGER NOT NULL, ConductCompetition INTEGER REFERENCES ConductCompetition (ID), UNIQUE (TryNumber, Member, ConductCompetition));
INSERT INTO CompetitionResult (ID, TryNumber, Member, Evaluation, ConductCompetition) VALUES (1, 1, 1, 5, 1);
INSERT INTO CompetitionResult (ID, TryNumber, Member, Evaluation, ConductCompetition) VALUES (2, 2, 1, 5, 1);

-- Таблица: ConductCompetition
DROP TABLE IF EXISTS ConductCompetition;
CREATE TABLE ConductCompetition (ID INTEGER PRIMARY KEY AUTOINCREMENT, SportTypeCompetition INTEGER REFERENCES SportTypeCompetition (ID), DateTime DATETIME NOT NULL, UNIQUE (DateTime, SportTypeCompetition));
INSERT INTO ConductCompetition (ID, SportTypeCompetition, DateTime) VALUES (1, 1, '2020-09-10');

-- Таблица: Discipline
DROP TABLE IF EXISTS Discipline;
CREATE TABLE Discipline (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL UNIQUE, UnitType INTEGER REFERENCES UnitType (ID) NOT NULL);
INSERT INTO Discipline (ID, Name, UnitType) VALUES (1, 'Слайды', 1);
INSERT INTO Discipline (ID, Name, UnitType) VALUES (2, 'Полоса препядствий', 3);
INSERT INTO Discipline (ID, Name, UnitType) VALUES (3, 'Прыжки с трамплина', 2);
INSERT INTO Discipline (ID, Name, UnitType) VALUES (4, 'Прыжки в длину', 2);
INSERT INTO Discipline (ID, Name, UnitType) VALUES (5, 'Прыжки в высоту', 2);
INSERT INTO Discipline (ID, Name, UnitType) VALUES (6, 'Спид слалом', 1);
INSERT INTO Discipline (ID, Name, UnitType) VALUES (7, 'Слалом баттл', 1);
INSERT INTO Discipline (ID, Name, UnitType) VALUES (8, 'Слалом классика', 1);

-- Таблица: Employee
DROP TABLE IF EXISTS Employee;
CREATE TABLE Employee (ID INTEGER PRIMARY KEY AUTOINCREMENT, Login TEXT NOT NULL UNIQUE, FullName TEXT NOT NULL, Role INTEGER REFERENCES Role (ID) NOT NULL);
INSERT INTO Employee (ID, Login, FullName, Role) VALUES (1, 'Volmont', 'Вольмонт Ирина', 1);
INSERT INTO Employee (ID, Login, FullName, Role) VALUES (2, 'Karandeeva', 'Карандеева Анна', 2);

-- Таблица: Member
DROP TABLE IF EXISTS Member;
CREATE TABLE Member (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, FullName TEXT NOT NULL, DateOfBirth DATETIME NOT NULL);
INSERT INTO Member (ID, FullName, DateOfBirth) VALUES (1, 'Мурашов Александр Михайлович', '1994-04-24');

-- Таблица: Role
DROP TABLE IF EXISTS Role;
CREATE TABLE Role (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL UNIQUE);
INSERT INTO Role (ID, Name) VALUES (1, 'Инструктор');
INSERT INTO Role (ID, Name) VALUES (2, 'Администратор');

-- Таблица: SportType
DROP TABLE IF EXISTS SportType;
CREATE TABLE SportType (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL UNIQUE);
INSERT INTO SportType (ID, Name) VALUES (1, 'Скейтборд');
INSERT INTO SportType (ID, Name) VALUES (2, 'Беговел');
INSERT INTO SportType (ID, Name) VALUES (3, 'Лонг борд');
INSERT INTO SportType (ID, Name) VALUES (4, 'Ролики');

-- Таблица: SportTypeCompetition
DROP TABLE IF EXISTS SportTypeCompetition;
CREATE TABLE SportTypeCompetition (ID INTEGER PRIMARY KEY AUTOINCREMENT, Competition INTEGER REFERENCES Competition (ID) NOT NULL, SportTypeDiscipline INTEGER NOT NULL REFERENCES SportTypeDiscipline (ID), UNIQUE (Competition, SportTypeDiscipline));
INSERT INTO SportTypeCompetition (ID, Competition, SportTypeDiscipline) VALUES (1, 2, 7);

-- Таблица: SportTypeDiscipline
DROP TABLE IF EXISTS SportTypeDiscipline;
CREATE TABLE SportTypeDiscipline (ID INTEGER PRIMARY KEY AUTOINCREMENT, SportType INTEGER REFERENCES SportType (ID) NOT NULL, Discipline INTEGER REFERENCES Discipline (ID) NOT NULL, UNIQUE (SportType, Discipline));
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (1, 4, 8);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (2, 4, 7);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (3, 4, 6);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (4, 4, 5);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (5, 4, 4);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (6, 4, 3);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (7, 4, 2);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (8, 4, 1);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (9, 3, 2);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (10, 2, 2);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (11, 1, 5);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (12, 1, 3);
INSERT INTO SportTypeDiscipline (ID, SportType, Discipline) VALUES (13, 1, 2);

-- Таблица: UnitType
DROP TABLE IF EXISTS UnitType;
CREATE TABLE UnitType (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL UNIQUE);
INSERT INTO UnitType (ID, Name) VALUES (1, 'балл');
INSERT INTO UnitType (ID, Name) VALUES (2, 'сантиметр');
INSERT INTO UnitType (ID, Name) VALUES (3, 'секунда');

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
