USE DB_InLock;
GO

INSERT INTO TBL_TipoUsuario(TituloTipoUsuario)
	VALUES ('ADMINISTRADOR'), 
		   ('CLIENTE');

INSERT INTO TBL_Usuario(Email, Senha, FK_IdTipoUsuario)
	VALUES ('admin@admin.com', 'admin', 1),
		   ('cliente@cliente.com', 'cliente', 2);

INSERT INTO TBL_Estudio(NomeEstudio) 
	VALUES ('Blizzard'), 
		   ('Rockstar Studios'),
		   ('Square Enix');

INSERT INTO TBL_Jogo(NomeJogo, Descricao, DataLancamento, Valor, FK_IdEstudio)
	VALUES ('Diablo 3', 'É UM JOGO QUE CONTÉM BASTANTE AÇÃO E É VICIANTE, SEJA VOCÊ UM NOVATO OU UM FÂ', '2012-05-15', 99.00, 1),
		   ('Red Dead Redemption II', 'JOGO ELETRÔNICO DE AÇÃO-AVENTURA WESTERN', '2018-10-25', 120.00, 2);