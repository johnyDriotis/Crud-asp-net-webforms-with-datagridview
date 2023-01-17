
create database empresa

USE empresa

create table GrupoMusical(
	IdGrupoMusical int not null primary key identity(1,1),
	Nombre nvarchar(200) not null,
	Epoca nvarchar(100) not null,
	Genero nvarchar(100) not null
)

CREATE TABLE Usuario(
	IdUsuario int identity(1,1) NOT NULL primary key,
	Nombre nvarchar(100) not null,
	Apellidos nvarchar(100) not null,
	Edad int not null,
	Sexo nvarchar(2) not null,
	IdGrupoMusical int not null foreign key references GrupoMusical(IdGrupoMusical)
);

insert into grupomusical values('Bonanza', 'Epoca de los 80', 'Musica cristiana')
insert into grupomusical values('Linkin Park', 'Epoca de los 90', 'Rock en Ingles')
insert into grupomusical values('Avril Lavigne', 'Epoca de los 90', 'Rock en Ingles')
insert into grupomusical values('Merengue', 'Merengue', 'Merengue')
insert into grupomusical values('Banda Colegio Lourdes', 'Banda de paz', 'Musica mixta')
insert into grupomusical values('Grupo Niche', 'Cumbia/Merengue', 'Cumbia/Merengue')
insert into grupomusical values('Daftpunk', 'Electronica de los 90', 'Daftpunk')
insert into grupomusical values('Armin Van Buueren', 'Electronica', 'Electronica')
insert into grupomusical values('Aniceto Molina', 'Cumbia Sampuesana', 'Cumbia Sampuesana')
insert into grupomusical values('Los angeles azules', 'Cumbia', 'Cumbia')

insert into usuario values('Johny','Driotis', 24, 'M', 10) 

select * from GrupoMusical
select * from Usuario

select U.IdUsuario, U.Nombre, U.Apellidos, U.Edad, GM.Nombre as 'Nombre grupo musical', GM.Genero as 'Genero musical', GM.Epoca from Usuario U
	inner join grupomusical GM on U.IdGrupoMusical = GM.IdGrupoMusical

select U.IdUsuario, U.Nombre, U.Apellidos, U.Edad, GM.Nombre, GM.Genero, GM.Epoca from Usuario U
	inner join grupomusical GM on U.IdGrupoMusical = GM.IdGrupoMusical

select idgrupomusical, concat(nombre,' - ',genero) as 'Genero musical' from grupomusical

select U.*,GM.Genero, GM.Epoca from usuario U
	inner join grupomusical GM on U.idgrupomusical = GM.IdGrupoMusical; 