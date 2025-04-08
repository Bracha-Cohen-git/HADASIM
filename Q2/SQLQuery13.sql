-- Part II
CREATE DATABASE FamilyTree;

USE FamilyTree;

-- Create a Persons table
CREATE TABLE Persons (
� � Person_Id INT PRIMARY KEY,
� � Personal_Name NVARCHAR(20) NOT NULL,
� � Family_Name NVARCHAR(20) NOT NULL,
� � Gender NVARCHAR(10) CHECK (Gender IN ('���', '����')),
� � Father_Id INT NULL,
� � Mother_Id INT NULL,
� � Spouse_Id INT NULL,
� � FOREIGN KEY (Father_Id) REFERENCES Persons(Person_Id),
� � FOREIGN KEY (Mother_Id) REFERENCES Persons(Person_Id),
� � FOREIGN KEY (Spouse_Id) REFERENCES Persons(Person_Id)
);

-- Inserting values into the Persons table
INSERT INTO Persons (Person_Id, Personal_Name, Family_Name, Gender, Father_Id, Mother_Id, Spouse_Id)
VALUES 
� � (111, '���', '���', '���', NULL, NULL, 222),
� � (222, '���', '���', '����', NULL, NULL, 111),
� � (333, '���', '���', '���', 111, 222, NULL),
� � (444, '����', '���', '����', 111, 222, NULL),
� � (555, '���', '���', '���', NULL, NULL, 666),
	(666, '����', '���', '����', NULL, NULL, 555),
	(777, '���', '��', '���', NULL, NULL, 888),
� � (888, '�����', '��', '����', NULL, NULL, NULL),
	(999, '������', '�����', '����', NULL, NULL, 100),
� � (100, '�����', '�����', '���', NULL, NULL, NULL);
� � 


-- Exercise 1: Creating a family tree

-- Creating a Relationships table that stores the relationships from first cousins
CREATE TABLE Relationships (
� � Person_Id INT,
� � Relative_Id INT,
� � Connection_Type NVARCHAR(20) CHECK (Connection_Type IN ('��', '��', '��', '����', '��', '��', '�� ���', '�� ���')),
� � PRIMARY KEY (Person_Id, Relative_Id),
� � FOREIGN KEY (Person_Id) REFERENCES Persons(Person_Id),
� � FOREIGN KEY (Relative_Id) REFERENCES Persons(Person_Id)
);


SELECT * FROM Persons;
SELECT * FROM Relationships;


