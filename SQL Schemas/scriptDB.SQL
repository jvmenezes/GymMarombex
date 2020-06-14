CREATE DATABASE GymMarombex
GO

USE GymMarombex
GO

/*** Estrutura da tabela dbo.FormasPagmtos ***/

PRINT 'Criando tabela FormasPagmtos...'
CREATE TABLE dbo.FormasPagmtos (
FormaPagmtoID          INT IDENTITY(1,1) NOT NULL,
Descricao              VARCHAR(50)       NOT NULL	/* Dinheiro ou Cartão */
) ON [PRIMARY]

/*** Constraints (Primary Key/Unique Indexes) da tabela dbo.FormasPagmtos.CNS ***/
PRINT 'Criando chave primária PK_FormasPagmtos na tabela FormasPagmtos...'
ALTER TABLE dbo.FormasPagmtos ADD CONSTRAINT PK_FormasPagmtos
	PRIMARY KEY CLUSTERED (FormaPagmtoID) ON [PRIMARY]

/*** Estrutura da tabela dbo.Planos ***/

PRINT 'Criando tabela Planos...'
CREATE TABLE dbo.Planos (
PlanoID          INT IDENTITY(1,1)  NOT NULL,
Descricao        VARCHAR(50)  NOT NULL,
ValorTotal       FLOAT             NULL
) ON [PRIMARY] 

/*** Constraints (Primary Key/Unique Indexes) da tabela dbo.Planos.CNS ***/
PRINT 'Criando chave primária PK_Planos na tabela Planos...'
ALTER TABLE dbo.Planos ADD CONSTRAINT PK_Planos
	PRIMARY KEY CLUSTERED (PlanoID) ON [PRIMARY]
	
/*** Estrutura da tabela dbo.Alunos ***/

PRINT 'Criando tabela Alunos...'
CREATE TABLE dbo.Alunos (
AlunoID          INT IDENTITY(1,1)   NOT NULL, --Será usado como numero de matricula
Nome               VARCHAR(200)      NOT NULL,
CPF                VARCHAR(50)       NOT NULL,
RG                 VARCHAR(50)       NOT NULL,
Endereco           VARCHAR(200)      NOT NULL,
Login              VARCHAR(30)       NOT NULL,
Senha              VARCHAR(50)       NOT NULL,
DataCadastro       DATETIME          NOT NULL,
DataUltimoAcesso   DATETIME          NULL,
MelhorDiaMesPagmto  INT              NOT NULL, -- Dia 5 de todo mês
DataUltimoPagmto    DATETIME         NULL,  
DataProximoPagmto   DATETIME         NULL,  --05/03/2020
ValorTotalPago      FLOAT            NULL,   --0 Reais
QtdParcelas         INT              NULL,   -- 12 Meses
ValorParcela        FLOAT            NULL,	 -- 60 Reais
NumeroParcelaAtual  INT              NULL,   -- Num 1
FeriasDescricaoMotivo     VARCHAR(500)      NULL,
FeriasDataInicio          DATETIME          NULL,
FeriasDataFim             DATETIME          NULL,
Ativo				BIT				 NOT NULL DEFAULT 0,
PlanoID             INT              NOT NULL,
FormaPagmtoID       INT              NOT NULL
) ON [PRIMARY] 

/*** Constraints (Primary Key/Unique Indexes) da tabela dbo.Alunos.CNS ***/
PRINT 'Criando chave primária PK_Alunos na tabela Alunos...'
ALTER TABLE dbo.Alunos ADD CONSTRAINT PK_Alunos 
	PRIMARY KEY CLUSTERED (AlunoID) ON [PRIMARY]
 
 /*** Foreign Keys da tabela dbo.Alunos.FKS ***/
PRINT 'Criando ForeignKey FK_Alunos_to_Planos_via_PlanoID na tabela Alunos...'
ALTER TABLE dbo.Alunos ADD CONSTRAINT FK_Alunos_to_Planos_via_PlanoID 
	FOREIGN KEY (PlanoID) 
		REFERENCES dbo.Planos (PlanoID)

PRINT 'Criando ForeignKey FK_Alunos_to_FormasPagmtos_via_FormaPagmtoID na tabela Alunos...'
ALTER TABLE dbo.Alunos ADD CONSTRAINT FK_Alunos_to_FormasPagmtos_via_FormaPagmtoID 
	FOREIGN KEY (FormaPagmtoID) 
		REFERENCES dbo.FormasPagmtos (FormaPagmtoID)
		
/*** Índices e Estatísticas da tabela dbo.Alunos.IDX ***/
PRINT 'Criando índice IDX_NC_Login na tabela Alunos...'
CREATE NONCLUSTERED 
	INDEX IDX_NC_Login ON dbo.Alunos(Login) ON [PRIMARY]  



/*** Estrutura da tabela dbo.Perfis ***/

PRINT 'Criando tabela Perfis...'
CREATE TABLE dbo.Perfis (
PerfilID         INT IDENTITY(1,1) NOT NULL ,
Descricao        VARCHAR(50)       NOT NULL
) ON [PRIMARY] 

/*** Constraints (Primary Key/Unique Indexes) da tabela dbo.Perfis.CNS ***/
PRINT 'Criando chave primária PK_Perfis na tabela Perfis...'
ALTER TABLE dbo.Perfis ADD CONSTRAINT PK_Perfis
	PRIMARY KEY CLUSTERED (PerfilID) ON [PRIMARY]

/*** Estrutura da tabela dbo.Funcionarios ***/

PRINT 'Criando tabela Funcionarios...'
CREATE TABLE dbo.Funcionarios (
FuncionarioID      INT IDENTITY(1,1)  NOT NULL ,
Nome               VARCHAR(200)      NOT NULL,
CPF                VARCHAR(50)       NOT NULL,
RG                 VARCHAR(50)       NOT NULL,
Endereco           VARCHAR(200)      NOT NULL,
Login              VARCHAR(30)       NOT NULL,
Senha              VARCHAR(50)       NOT NULL,
DataCadastro       DATETIME          NOT NULL,
DataUltimoAcesso   DATETIME          NULL,
TiposDeAtividades  VARCHAR(500)      NOT NULL,
PerfilID           INT               NOT NULL
) ON [PRIMARY] 

/*** Constraints (Primary Key/Unique Indexes) da tabela dbo.Funcionarios.CNS ***/
PRINT 'Criando chave primária PK_Funcionarios na tabela Funcionarios...'
ALTER TABLE dbo.Funcionarios ADD CONSTRAINT PK_Funcionarios 
	PRIMARY KEY CLUSTERED (FuncionarioID) ON [PRIMARY]
		
/*** Foreign Keys da tabela dbo.Funcionarios.FKS ***/
PRINT 'Criando ForeignKey FK_Funcionarios_to_Perfis_via_PerfilID na tabela Funcionarios...'
ALTER TABLE dbo.Funcionarios ADD CONSTRAINT FK_Funcionarios_to_Perfis_via_PerfilID 
	FOREIGN KEY (PerfilID) 
		REFERENCES dbo.Perfis (PerfilID)
		
/*** Índices e Estatísticas da tabela dbo.Funcionarios.IDX ***/
PRINT 'Criando índice IDX_NC_Login na tabela Funcionarios...'
CREATE NONCLUSTERED 
	INDEX IDX_NC_Login ON dbo.Funcionarios(Login) ON [PRIMARY]
	

/*** Estrutura da tabela dbo.Aulas ***/

PRINT 'Criando tabela Aulas...'
CREATE TABLE dbo.Aulas (
AulaID         INT IDENTITY(1,1)  NOT NULL,
Descricao       VARCHAR(50)    NOT NULL,
HoraInicio      TIME           NOT NULL,
DuracaoMinutos  INT            NOT NULL,
DiasDaSemana    INT            NOT NULL,
InstrutorID     INT            NOT NULL 
) ON [PRIMARY]

/*** Constraints (Primary Key/Unique Indexes) da tabela dbo.Aulas.CNS ***/
PRINT 'Criando chave primária PK_Aulas na tabela Aulas...'
ALTER TABLE dbo.Aulas ADD CONSTRAINT PK_Aulas
	PRIMARY KEY CLUSTERED (AulaID) ON [PRIMARY]
	
 /*** Foreign Keys da tabela dbo.Aulas.FKS ***/
PRINT 'Criando ForeignKey FK_Aulas_to_Funcionarios_via_InstrutorID na tabela Aulas...'
ALTER TABLE dbo.Aulas ADD CONSTRAINT FK_Aulas_to_Funcionarios_via_InstrutorID
	FOREIGN KEY (InstrutorID) 
		REFERENCES dbo.Funcionarios (FuncionarioID)

/*** Estrutura da tabela dbo.AlunoAula ***/

PRINT 'Criando tabela AlunoAula...'
CREATE TABLE dbo.AlunoAula (
AlunoAulaID  INT IDENTITY(1,1)    NOT NULL,	
AulaID         INT                NOT NULL,
AlunoID      INT                  NOT NULL
) ON [PRIMARY]

/*** Constraints (Primary Key/Unique Indexes) da tabela dbo.AlunoAula.CNS ***/
PRINT 'Criando chave primária PK_AlunoAula na tabela AlunoAula...'
ALTER TABLE dbo.AlunoAula ADD CONSTRAINT PK_AlunoAula
	PRIMARY KEY CLUSTERED (AlunoAulaID) ON [PRIMARY]
 
 /*** Foreign Keys da tabela dbo.AlunoAula.FKS ***/
PRINT 'Criando ForeignKey FK_AlunoAula_to_Alunos_via_AlunoID na tabela AlunoAula...'
ALTER TABLE dbo.AlunoAula ADD CONSTRAINT FK_AlunoAula_to_Alunos_via_AlunoID
	FOREIGN KEY (AlunoID) 
		REFERENCES dbo.Alunos (AlunoID)		
 
PRINT 'Criando ForeignKey FK_AlunoAula_to_Aulas_via_AulaID na tabela AlunoAula...'
ALTER TABLE dbo.AlunoAula ADD CONSTRAINT FK_AlunoAula_to_Aulas_via_AulaID
	FOREIGN KEY (AulaID) 
		REFERENCES dbo.Aulas (AulaID)
		
/*** Estrutura da tabela dbo.Avaliacoes ***/

PRINT 'Criando tabela Avaliacoes...'
CREATE TABLE dbo.Avaliacoes (
AvaliacaoID            INT IDENTITY(1,1) NOT NULL,
InfoAnamnese           VARCHAR(5000)     NULL,
ExameDobrasCutaneas    VARCHAR(5000)     NULL,
ExameErgometrico       VARCHAR(5000)     NULL,
DataRealizacao         DATETIME          NOT NULL,
AlunoID                INT               NOT NULL,
FisioterapeutaID       INT               NOT NULL	
) ON [PRIMARY] 

/*** Constraints (Primary Key/Unique Indexes) da tabela dbo.Avaliacoes.CNS ***/
PRINT 'Criando chave primária PK_Avaliacoes na tabela Avaliacoes...'
ALTER TABLE dbo.Avaliacoes ADD CONSTRAINT PK_Avaliacoes
	PRIMARY KEY CLUSTERED (AvaliacaoID) ON [PRIMARY]

 /*** Foreign Keys da tabela dbo.Avaliacoes.FKS ***/
PRINT 'Criando ForeignKey FK_Avaliacoes_to_Alunos_via_AlunoID na tabela Avaliacoes...'
ALTER TABLE dbo.Avaliacoes ADD CONSTRAINT FK_Avaliacoes_to_Alunos_via_AlunoID
	FOREIGN KEY (AlunoID) 
		REFERENCES dbo.Alunos (AlunoID)

PRINT 'Criando ForeignKey FK_Avaliacoes_to_Funcionarios_via_FisioterapeutaID na tabela Avaliacoes...'
ALTER TABLE dbo.Avaliacoes ADD CONSTRAINT FK_Avaliacoes_to_Funcionarios_via_FisioterapeutaID
	FOREIGN KEY (FisioterapeutaID) 
		REFERENCES dbo.Funcionarios (FuncionarioID)

