USE [GymMarombex]
GO
SET IDENTITY_INSERT [dbo].[FormasPagmtos] ON 

INSERT [dbo].[FormasPagmtos] ([FormaPagmtoID], [Descricao]) 
VALUES (1, N'À vista')
INSERT [dbo].[FormasPagmtos] ([FormaPagmtoID], [Descricao]) 
VALUES (2, N'A prazo')
SET IDENTITY_INSERT [dbo].[FormasPagmtos] OFF

SET IDENTITY_INSERT [dbo].[Planos] ON 
INSERT [dbo].[Planos] ([PlanoID], [Descricao], [ValorTotal]) 
VALUES (1, N'Mensal', 60)
INSERT [dbo].[Planos] ([PlanoID], [Descricao], [ValorTotal]) 
VALUES (2, N'Anual', 600)
SET IDENTITY_INSERT [dbo].[Planos] OFF

SET IDENTITY_INSERT [dbo].[Alunos] ON 
INSERT [dbo].[Alunos] ([AlunoID], [Nome], [CPF], [RG], [Endereco], [Login], [Senha], [DataCadastro], [DataUltimoAcesso], [MelhorDiaMesPagmto], [DataUltimoPagmto], [DataProximoPagmto], [ValorTotalPago], [QtdParcelas], [ValorParcela], [NumeroParcelaAtual], [FeriasDescricaoMotivo], [FeriasDataInicio], [FeriasDataFim], [Ativo], [PlanoID], [FormaPagmtoID])
VALUES (1, N'Jorge Gomez', N'358.845.752.12', N'33.258.759-88', N'Av. Juliao Radames Nº 56', N'JGOMEZ', N'654321', CAST(N'2012-08-01T00:00:00.000' AS DateTime), CAST(N'2020-02-09T00:00:00.000' AS DateTime), 4, CAST(N'2019-08-04T00:00:00.000' AS DateTime), CAST(N'2020-05-04T00:00:00.000' AS DateTime), 500, 12, 50, 10, '', CAST(N'2020-05-04T00:00:00.000' AS DateTime), CAST(N'2020-05-04T00:00:00.000' AS DateTime), 1, 2, 2)
INSERT [dbo].[Alunos] ([AlunoID], [Nome], [CPF], [RG], [Endereco], [Login], [Senha], [DataCadastro], [DataUltimoAcesso], [MelhorDiaMesPagmto], [DataUltimoPagmto], [DataProximoPagmto], [ValorTotalPago], [QtdParcelas], [ValorParcela], [NumeroParcelaAtual], [FeriasDescricaoMotivo], [FeriasDataInicio], [FeriasDataFim], [Ativo], [PlanoID], [FormaPagmtoID])
VALUES (2, N'Paulo de Aquino', N'955.125.052.08', N'85.258.759-88', N'Rua Augusta de Aquino Nº 56', N'PAQUINO', N'654321', CAST(N'2012-08-01T00:00:00.000' AS DateTime), CAST(N'2020-02-09T00:00:00.000' AS DateTime), 4, CAST(N'2019-08-04T00:00:00.000' AS DateTime), CAST(N'2020-05-04T00:00:00.000' AS DateTime), 500, 12, 50, 10, null, null, null, 1, 2, 2)
SET IDENTITY_INSERT [dbo].[Alunos] OFF


SET IDENTITY_INSERT [dbo].[Perfis] ON 
INSERT [dbo].[Perfis] ([PerfilID], [Descricao]) 
VALUES (0, N'Gerente')
INSERT [dbo].[Perfis] ([PerfilID], [Descricao]) 
VALUES (1, N'Professor')
INSERT [dbo].[Perfis] ([PerfilID], [Descricao]) 
VALUES (2, N'Fisioterapeuta')
INSERT [dbo].[Perfis] ([PerfilID], [Descricao]) 
VALUES (3, N'Recepcionista')
SET IDENTITY_INSERT [dbo].[Perfis] OFF


SET IDENTITY_INSERT [dbo].[Funcionarios] ON
INSERT [dbo].[Funcionarios] ([FuncionarioID], [Nome], [CPF], [RG], [Endereco], [Login], [Senha], [DataCadastro], [DataUltimoAcesso], [TiposDeAtividades], [PerfilID]) 
VALUES (0, N'Jonathan Menezes', N'119.585.547-90', N'78.569.847-9', N'Rua do Vidigal', N'JMENEZES', N'654321', CAST(N'2019-10-01T00:00:00.000' AS DateTime), CAST(N'2020-02-01T00:00:00.000' AS DateTime), N'Gerenciar Academia', 0)
INSERT [dbo].[Funcionarios] ([FuncionarioID], [Nome], [CPF], [RG], [Endereco], [Login], [Senha], [DataCadastro], [DataUltimoAcesso], [TiposDeAtividades], [PerfilID]) 
VALUES (1, N'Silas Malafaia', N'456.789.456-85', N'33.569.847-9', N'Rua Catedral', N'SMALAFAIA', N'654321', CAST(N'2019-10-01T00:00:00.000' AS DateTime), CAST(N'2020-02-01T00:00:00.000' AS DateTime), N'Musculação, Jiu-jítsu', 1)
INSERT [dbo].[Funcionarios] ([FuncionarioID], [Nome], [CPF], [RG], [Endereco], [Login], [Senha], [DataCadastro], [DataUltimoAcesso], [TiposDeAtividades], [PerfilID]) 
VALUES (2, N'Amanda Ferreti', N'584.874.896-87', N'54.854.897-88', N'Rua Silveiras N 24', N'AFERRETI', N'654321', CAST(N'2017-01-20T00:00:00.000' AS DateTime), CAST(N'2020-05-20T00:00:00.000' AS DateTime), N'Atender o público', 3)
INSERT [dbo].[Funcionarios] ([FuncionarioID], [Nome], [CPF], [RG], [Endereco], [Login], [Senha], [DataCadastro], [DataUltimoAcesso], [TiposDeAtividades], [PerfilID]) 
VALUES (3, N'Natalia Rodrigues', N'417.877.588-83', N'25.847.874-71', N'Rua Alcantaras N63', N'NRODRIGUES', N'654321', CAST(N'2012-01-20T00:00:00.000' AS DateTime), CAST(N'2020-03-20T00:00:00.000' AS DateTime), N'Ginástica Elaboral', 1)
INSERT [dbo].[Funcionarios] ([FuncionarioID], [Nome], [CPF], [RG], [Endereco], [Login], [Senha], [DataCadastro], [DataUltimoAcesso], [TiposDeAtividades], [PerfilID]) 
VALUES (4, N'Rafael Tobias', N'658.887.211-54', N'66.854.852-11', N'Av. Delgado N25', N'RTOBIAS', N'654321', CAST(N'2015-01-20T00:00:00.000' AS DateTime), CAST(N'2020-04-25T00:00:00.000' AS DateTime), N'Fisio', 2)
INSERT [dbo].[Funcionarios] ([FuncionarioID], [Nome], [CPF], [RG], [Endereco], [Login], [Senha], [DataCadastro], [DataUltimoAcesso], [TiposDeAtividades], [PerfilID]) 
VALUES (5, N'Gessica Moura', N'015.877.588-99', N'58.847.874-01', N'Rua Gomes de Olveira N5487', N'GMOURA', N'654321', CAST(N'2012-01-20T00:00:00.000' AS DateTime), CAST(N'2020-03-20T00:00:00.000' AS DateTime), N'Aerobica, Fit Dance, Zumba', 1)
SET IDENTITY_INSERT [dbo].[Funcionarios] OFF

SET IDENTITY_INSERT [dbo].[Aulas] ON 
INSERT [dbo].[Aulas] ([AulaID], [Descricao], [HoraInicio], [DuracaoMinutos], [DiasDaSemana], [InstrutorID]) 
VALUES (1, N'Jiu-jítsu', CAST(N'20:00:00' AS Time), 120, 21, 1)
INSERT [dbo].[Aulas] ([AulaID], [Descricao], [HoraInicio], [DuracaoMinutos], [DiasDaSemana], [InstrutorID]) 
VALUES (2, N'Musculação', CAST(N'18:00:00' AS Time), 120, 18, 1)
INSERT [dbo].[Aulas] ([AulaID], [Descricao], [HoraInicio], [DuracaoMinutos], [DiasDaSemana], [InstrutorID]) 
VALUES (3, N'Fit Dance', CAST(N'18:00:00' AS Time), 60, 15, 5)
SET IDENTITY_INSERT [dbo].[Aulas] OFF