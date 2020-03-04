USE DB_InLock;
GO

SELECT * FROM TBL_Usuario;
SELECT * FROM TBL_Estudio;
SELECT * FROM TBL_Jogo;

SELECT NomeJogo, Descricao, DataLancamento, Valor, NomeEstudio FROM TBL_Jogo
	INNER JOIN TBL_Estudio ON FK_IdEstudio = IdEstudio;

SELECT NomeEstudio, NomeJogo, Descricao, DataLancamento, Valor FROM TBL_Jogo
	RIGHT JOIN TBL_Estudio ON IdEstudio = FK_IdEstudio;

SELECT * FROM TBL_Usuario
	WHERE Email = 'admin@admin.com' AND Senha = 'admin';

SELECT * FROM TBL_Jogo
	WHERE IdJogo = 1;

SELECT * FROM TBL_Estudio
	WHERE IdEstudio = 1;
