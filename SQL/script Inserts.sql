
Insert Into Categoria (Nome)
Values ('Fixo');

Insert Into Categoria (Nome)
Values ('M�vel');

Insert Into Categoria (Nome)
Values ('Fixo e M�vel');


Insert Into Operadora (Codigo, Nome, Categoria_ID, Preco)
Values (31, 
		'Oi', 
		(select Identificador from Categoria where Nome = 'Fixo e M�vel'),
		2);
		
Insert Into Operadora (Codigo, Nome, Categoria_ID, Preco)
Values (15, 
		'Vivo', 
		(select Identificador from Categoria where Nome = 'Fixo e M�vel'),
		1.5);
		
Insert Into Operadora (Codigo, Nome, Categoria_ID, Preco)
Values (41, 
		'Tim', 
		(select Identificador from Categoria where Nome = 'M�vel'),
		4.7);
		
Insert Into Operadora (Codigo, Nome, Categoria_ID, Preco)
Values (21, 
		'NET', 
		(select Identificador from Categoria where Nome = 'Fixo'),
		2);
		
		
Insert Into Telefone (Numero, Operadora_ID)
Values (999451674,
		(select Identificador from Operadora where Nome = 'Tim'));
		
		
Insert Into Contato (Nome, Telefone_ID, DataInclusao, Cor)
Values ('Marcos',
		(select top 1 Identificador from Telefone),
		GETDATE(),
		'#01fabd');