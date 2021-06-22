CREATE TABLE tbTutor(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	Adress VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL
);
	
CREATE TABLE tbHosting(
	Id INT PRIMARY KEY IDENTITY,
	Status BIT NOT NULL
);

CREATE TABLE tbAnimal(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR (50) NOT NULL,
	InternationMotive VARCHAR (250) NOT NULL,
	Status INT NOT NULL,
	IdTutor INT NOT NULL,
	IdHosting INT NOT NULL,
	DeletedAt DATETIME NULL,
	FOREIGN KEY (IdTutor) REFERENCES tbTutor (Id),
	FOREIGN KEY (IdHosting) REFERENCES tbHosting (Id)	
);

INSERT INTO tbHosting ([Status]) VALUES (0)
