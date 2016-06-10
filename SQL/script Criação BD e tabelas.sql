CREATE DATABASE ListaTelefonica_DB
GO

USE ListaTelefonica_DB 
GO

CREATE TABLE Contato(
	Identificador BigInt Identity(1,1) not null,
	Nome Varchar(100) not null,
	Telefone_ID BigInt not null,
	DataInclusao Date not null,
	Cor Varchar(30) not null
)

CREATE TABLE Telefone(
	Identificador Bigint Identity(1,1) not null,
	Numero BigInt not null,
	Operadora_ID BigInt not null
)

CREATE TABLE Categoria(
	Identificador Bigint Identity(1,1) not null,
	Nome Varchar(30) not null
)

CREATE TABLE Operadora(
	Identificador BigInt Identity(1,1) not null,
	Codigo Int not null,
	Nome Varchar(50) not null,
	Categoria_ID BigInt not null,
	Preco Decimal not null
)
