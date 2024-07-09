-- Active: 1719345925143@@bf8pqrhfk7rng1wmgo8p-mysql.services.clever-cloud.com@3306
CREATE TABLE Users(
    id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255),
    Email VARCHAR(255)  UNIQUE,
    Password VARCHAR(255)
);

CREATE TABLE Folders(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId INT,
    ParentFolderId INT,
    Name VARCHAR(255),
    CreationDate Date,
    Status ENUM("Active","Inactive")
);

CREATE TABLE Documents(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId INT,
    Name VARCHAR(255),
    Type VARCHAR(20),
    CreationDate Date,
    FolderId INT,
    Status ENUM("Active","Inactive")
);

ALTER TABLE `Folders` ADD FOREIGN KEY (ParentFolderId) REFERENCES Folders(Id);
ALTER TABLE `Folders` ADD FOREIGN KEY (UserId) REFERENCES Users(Id);
ALTER TABLE `Documents` ADD FOREIGN KEY (UserId) REFERENCES Users(Id);
ALTER TABLE `Documents` ADD FOREIGN KEY (FolderId) REFERENCES Folders(Id);