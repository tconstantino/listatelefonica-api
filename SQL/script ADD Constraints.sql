
ALTER TABLE Contato
ADD Constraint Contato_PK
Primary Key (Identificador);

ALTER TABLE Telefone
ADD Constraint Telefone_PK
Primary Key (Identificador);

ALTER TABLE Categoria
ADD Constraint Categoria_PK
Primary Key (Identificador);

ALTER TABLE Operadora
ADD Constraint Operadora_ID
Primary Key (Identificador);


ALTER TABLE Telefone
ADD Constraint Telefone_Contato_FK
Foreign Key (Contato_ID)
References Contato;

ALTER TABLE Telefone
ADD Constraint Telefone_Operadora_FK
Foreign Key (Operadora_ID)
References Operadora;

ALTER TABLE Operadora
ADD Constraint Operadora_Categoria_FK
Foreign Key (Categoria_ID)
References Categoria;