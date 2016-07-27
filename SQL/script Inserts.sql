
Insert Into Categoria (Nome)
Values ('Fixo');

Insert Into Categoria (Nome)
Values ('Móvel');

Insert Into Categoria (Nome)
Values ('Fixo e Móvel');


Insert Into Operadora (Codigo, Nome, Categoria_ID, Preco)
Values (31, 
		'Oi', 
		(select Identificador from Categoria where Nome = 'Fixo e Móvel'),
		2);
		
Insert Into Operadora (Codigo, Nome, Categoria_ID, Preco)
Values (15, 
		'Vivo', 
		(select Identificador from Categoria where Nome = 'Fixo e Móvel'),
		1.5);
		
Insert Into Operadora (Codigo, Nome, Categoria_ID, Preco)
Values (41, 
		'Tim', 
		(select Identificador from Categoria where Nome = 'Móvel'),
		4.7);
		
Insert Into Operadora (Codigo, Nome, Categoria_ID, Preco)
Values (21, 
		'NET', 
		(select Identificador from Categoria where Nome = 'Fixo'),
		2);
		
		
Insert Into Telefone (Numero, Contato_ID, Operadora_ID)
Values (999451674,
	(select top 1 Identificador from Contato),
		(select Identificador from Operadora where Nome = 'Tim'));
		
		
Insert Into Contato (Nome, DataInclusao, Cor)
Values ('Josué Nunes',
		GETDATE(),
		'#01fabd');