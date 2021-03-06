USE [AgendaTreinoBarreto]
GO
/****** Object:  Table [dbo].[eventos]    Script Date: 12/03/2022 00:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eventos](
	[idEventos] [int] IDENTITY(1,1) NOT NULL,
	[NomeEvento] [varchar](45) NOT NULL,
	[descrição] [varchar](150) NULL,
	[Data] [date] NOT NULL,
	[local] [varchar](45) NOT NULL,
	[participantes] [int] NOT NULL,
	[Tipo] [varchar](15) NULL,
	[criadorEvento] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEventos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[login]    Script Date: 12/03/2022 00:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login](
	[idLogin] [int] IDENTITY(1,1) NOT NULL,
	[NomeLogin] [varchar](45) NOT NULL,
	[SenhaLogin] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[eventos] ADD  DEFAULT (NULL) FOR [descrição]
GO
ALTER TABLE [dbo].[eventos] ADD  DEFAULT ('compartilhado') FOR [Tipo]
GO
/****** Object:  StoredProcedure [dbo].[buscaEventos]    Script Date: 12/03/2022 00:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[buscaEventos](@criador varchar(45)) as 
SELECT * from eventos where criadorEvento = @criador or Tipo ='Compartilhado';
GO
/****** Object:  StoredProcedure [dbo].[buscaEventosEdit]    Script Date: 12/03/2022 00:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[buscaEventosEdit](@criador varchar(45),@idEvento int) as 
SELECT * from eventos where criadorEvento = @criador and idEventos = @idEvento;
GO
/****** Object:  StoredProcedure [dbo].[buscaEventosPorCampo]    Script Date: 12/03/2022 00:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[buscaEventosPorCampo](@criador varchar(45),@campoBusca varchar(45)) as 
SELECT * from eventos where nomeEvento=@campoBusca and (criadorEvento = @criador or Tipo ='Compartilhado');
GO
/****** Object:  StoredProcedure [dbo].[eventosInserir]    Script Date: 12/03/2022 00:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[eventosInserir](@idEvento varchar(20), @nomeEvento varchar(150),
@descricao varchar(150),@data date, @local varchar(60),@participantes int,@tipo varchar(50),@criador varchar(50))as
if(@idEvento='')
Insert into eventos values (@nomeEvento,@descricao,@data,@local,@participantes,@tipo,@criador)
else
update eventos set  nomeEvento=@nomeEvento,descrição=@descricao,Data=@data,local=@local,participantes=@participantes,
Tipo=@tipo where idEventos = @idEvento and criadorEvento=@criador
GO
/****** Object:  StoredProcedure [dbo].[loginAgenda]    Script Date: 12/03/2022 00:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[loginAgenda](@usuario varchar(20),@senha varchar(10)) as
select count(*) from login where NomeLogin =@usuario and SenhaLogin = @senha

GO
