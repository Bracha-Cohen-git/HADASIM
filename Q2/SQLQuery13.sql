-- Part II
CREATE DATABASE FamilyTree;

USE FamilyTree;

-- Create a Persons table
CREATE TABLE Persons (
    Person_Id INT PRIMARY KEY,
    Personal_Name NVARCHAR(20) NOT NULL,
    Family_Name NVARCHAR(20) NOT NULL,
    Gender NVARCHAR(10) CHECK (Gender IN ('זכר', 'נקבה')),
    Father_Id INT NULL,
    Mother_Id INT NULL,
    Spouse_Id INT NULL,
    FOREIGN KEY (Father_Id) REFERENCES Persons(Person_Id),
    FOREIGN KEY (Mother_Id) REFERENCES Persons(Person_Id),
    FOREIGN KEY (Spouse_Id) REFERENCES Persons(Person_Id)
);

-- Inserting values into the Persons table
INSERT INTO Persons (Person_Id, Personal_Name, Family_Name, Gender, Father_Id, Mother_Id, Spouse_Id)
VALUES 
    (111, 'אבא', 'כהן', 'זכר', NULL, NULL, 222),
    (222, 'אמא', 'כהן', 'נקבה', NULL, NULL, 111),
    (333, 'בני', 'כהן', 'זכר', 111, 222, NULL),
    (444, 'בתיה', 'כהן', 'נקבה', 111, 222, NULL),
    (555, 'משה', 'לוי', 'זכר', NULL, NULL, 666),
	(666, 'ברכה', 'לוי', 'נקבה', NULL, NULL, 555),
	(777, 'אבי', 'לב', 'זכר', NULL, NULL, 888),
    (888, 'אביבה', 'לב', 'נקבה', NULL, NULL, NULL),
	(999, 'ישראלה', 'ברזיל', 'נקבה', NULL, NULL, 100),
    (100, 'ישראל', 'ברזיל', 'זכר', NULL, NULL, NULL);
    


-- Exercise 1: Creating a family tree

-- Creating a Relationships table that stores the relationships from first cousins
CREATE TABLE Relationships (
    Person_Id INT,
    Relative_Id INT,
    Connection_Type NVARCHAR(20) CHECK (Connection_Type IN ('אב', 'אם', 'אח', 'אחות', 'בן', 'בת', 'בן זוג', 'בת זוג')),
    PRIMARY KEY (Person_Id, Relative_Id),
    FOREIGN KEY (Person_Id) REFERENCES Persons(Person_Id),
    FOREIGN KEY (Relative_Id) REFERENCES Persons(Person_Id)
);


SELECT * FROM Persons;
SELECT * FROM Relationships;


