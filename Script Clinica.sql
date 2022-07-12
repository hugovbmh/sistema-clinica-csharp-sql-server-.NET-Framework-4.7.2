----------------------------------------------------------------------
-- BASE DE DATOS : SysMedic
----------------------------------------------------------------------
Use Master
go
if exists (select name from master..sysdatabases where name='SysMedic')   	
	Drop Database SysMedic	
go
Create Database SysMedic
go
Use SysMedic
go
if exists (select * from sysobjects where type='U' and name='Distrito')
	drop table Distrito
go
create table Distrito
(id_dis int not null Primary key identity(1,1),
nom_dis varchar(25) not null)
go

insert into Distrito values ('Lince'),('Ate'),('Los Olivos'),('Pueblo Libre'),('Rimac'),('Surquillo'),('SJL'),('Pueblo Libre'),('Independencia'),('SJM'),
('Pachacamac'),('Lurin'),('VMT'),('San Borja'),('la Victoria'),('La Molina')
go
create table Especialidad
(id_esp int not null Primary key identity(1,1),
nom_esp varchar(25) not null)
go
insert into Especialidad values ('Pediatría'),('Geriatría'),('Dermatología'),('Ginecología'),('Medicina Interna'),('Traumatología'),('Medicina General'),('Nutrición'),('Enfermeria')
go
create table Consultorio
(id_con int not null Primary key identity(1,1),
nro_con int not null,
id_esp int references Especialidad)
go
insert Consultorio values (200,1),(201,1),(203,2),(204,3),(301,3)
go
create table Medico
(id_med int not null Primary key identity(1,1),
nom_med varchar(25) not null,
ape_med varchar(25) not null,
dni_med char(8) not null UNIQUE,
id_dis int references Distrito,
id_esp int references Especialidad,
nro_col char(8) not null UNIQUE,
cel_med char(9) not null,
est_med char(1) not null check (est_med='A' or est_med='X'));
go
insert Medico values ('Alberto','Huarcaya Troncos','78965412',1,2,'56389','895632145','A')
insert Medico values ('Samuel','Mamani Sanchez','38965412',1,1,'356389','995632145','A')
insert Medico values ('Luis','Alva Huarcaya','56965412',1,1,'116389','995646145','A')
insert Medico values ('Juan','Guillen Huarcaya','46965412',1,1,'416389','945646145','A')

go
--Lista consultorio
create proc usp_ListaConsultorios
as
select c.id_con,c.nro_con,e.nom_esp
from consultorio c inner join especialidad e on c.id_esp=e.id_esp
order by 1
go

create proc usp_busConsultorio @bus int
as
select c.id_con,c.nro_con,e.nom_esp
from consultorio c inner join especialidad e on c.id_esp=e.id_esp
where c.nro_con like '%'+ltrim(str(@bus))+'%'
order by 2
go

usp_busConsultorio 3
go

create proc usp_ingCon @nro int, @esp int
as
insert Consultorio values (@nro,@esp)
go


create proc usp_modcon @id int, @nro int, @esp int
as
update consultorio set nro_con=@nro, id_esp=@esp
where id_con=@id
go

-- Lista todos los médicos
create proc usp_ListaMedicos
as
Select m.id_med,m.ape_med,m.nom_med,m.dni_med,m.cel_med,d.nom_dis,e.nom_esp,m.nro_col,m.est_med
from Medico m inner join Distrito d on m.id_dis=d.id_dis
inner join Especialidad e on m.id_esp= e.id_esp
order by 2
go

create proc usp_BuscaMedicos @ape varchar(25)
as
Select m.id_med,m.ape_med,m.nom_med,m.dni_med,m.cel_med,d.nom_dis,e.nom_esp,m.nro_col,m.est_med
from Medico m inner join Distrito d on m.id_dis=d.id_dis
inner join Especialidad e on m.id_esp= e.id_esp
where m.ape_med like @ape + '%'
order by 2
go

usp_BuscaMedicos 'b'
go

create proc usp_BuscaMed @bus varchar(25), @tipo char(1)
as
Declare @sql as varchar(500)
select @sql ='Select m.id_med,m.ape_med,m.nom_med,m.dni_med,m.cel_med,d.nom_dis,e.nom_esp,m.nro_col,m.est_med
from Medico m inner join Distrito d on m.id_dis=d.id_dis
inner join Especialidad e on m.id_esp= e.id_esp'
if @tipo='0' -- Busca por apellido
	Begin
		Select @sql = @sql + ' where m.ape_med like ' +char(39)+ @bus + '%'+char(39)+' order by 2'
	End
else
	if @tipo='1' -- Busca por DNI
		Begin
			Select @sql = @sql + ' where m.dni_med like ' +char(39)+ @bus + '%'+char(39)+' order by 2'
		End
	else
		Begin
			Select @sql = @sql + ' where m.nro_col like ' +char(39)+ @bus + '%'+char(39)+' order by 2'
		End
Exec (@sql);
go

create proc usp_EliMed @id int
as
Delete from Medico where id_med=@id
go	

-- previa

Select m.nom_med, m.ape_med, d.nom_dis, e.nom_esp
from Medico m inner join Distrito d on m.id_dis=d.id_dis
inner join Especialidad e on e.id_esp=m.id_esp
where m.ape_med like 'B%'

Select m.nom_med, m.ape_med,m.dni_med, d.nom_dis, e.nom_esp
from Medico m inner join Distrito d on m.id_dis=d.id_dis
inner join Especialidad e on e.id_esp=m.id_esp
where m.dni_med = '78965412'

Select m.nom_med, m.ape_med,m.dni_med,m.nro_col, d.nom_dis, e.nom_esp
from Medico m inner join Distrito d on m.id_dis=d.id_dis
inner join Especialidad e on e.id_esp=m.id_esp
where m.nro_col like '56389'
go

create proc usp_BuscarMedic @dato varchar(30), @tipo int
as
declare @sql varchar(500)
set @sql='Select m.nom_med, m.ape_med,m.dni_med,m.nro_col, d.nom_dis, e.nom_esp
from Medico m inner join Distrito d on m.id_dis=d.id_dis
inner join Especialidad e on e.id_esp=m.id_esp'
if (@tipo=1) -- Buscar por apellido
	Begin
		set @sql = @sql + ' where m.ape_med like '+char(39) + @dato + '%'+ char(39)
	end
else 
   if (@tipo=2) -- Busca por DNI
	Begin
		set @sql = @sql + ' where m.dni_med like ' +char(39) + @dato + '%'+ char(39)
	end
else	
   if (@tipo=3) -- Busca por Nro de colegiatura
	Begin
		set @sql = @sql + ' where m.nro_col like ' +char(39) + @dato + '%'+ char(39)
	end
exec (@sql)
go
usp_BuscarMedic 'B', 1 -- Por Apellido
go
usp_BuscarMedic '38', 2 -- Por DNI
go
usp_BuscarMedic '35', 3 -- Por Nro de Colegiatura
go

create proc usp_ListaEspecialidad
as
Select id_esp, nom_esp
from Especialidad
go

create proc usp_ListaDistrito
as
Select id_dis, nom_dis
from Distrito
go

---------------------------------------------------
-- E S P E C I A L I D A D
---------------------------------------------------
create procedure usp_IngEsp @nom varchar(25)
as
insert Especialidad values (@nom)
go

create procedure usp_ModEsp @id int, @nom varchar(25)
as
update Especialidad set nom_esp = @nom 
where id_esp=@id
go

create procedure usp_EliEsp @id int
as
delete from Especialidad
where id_esp=@id
go

create proc usp_BusEsp @nom varchar(25)
as
select * from Especialidad
where nom_esp like @nom+'%'
go

usp_busEsp 'C'
go

-- Procedimiento Insertar médico
create proc usp_ingMed @nom_med varchar(25),
						@ape_med varchar(25),
						@dni_med char(8),
						@id_dis int,
						@id_esp int,
						@nro_col char(8),
						@cel_med char(9)
						as
insert Medico values (@nom_med,@ape_med,@dni_med,@id_dis,@id_esp,
						@nro_col,@cel_med,'A')
go
create proc usp_modMed  @id_med int,
						@nom_med varchar(25),
						@ape_med varchar(25),
						@dni_med char(8),
						@id_dis int,
						@id_esp int,
						@nro_col char(8),
						@cel_med char(9)
as
update Medico set nom_med= @nom_med, ape_med= @ape_med, dni_med= @dni_med,
						id_dis=@id_dis, id_esp=@id_esp, nro_col=@nro_col,
						cel_med= @cel_med 
where id_med = @id_med
go

create proc usp_BusMedicoPorID @id_med int
as
select m.id_med,m.nom_med,m.ape_med, m.dni_med, d.nom_dis,
e.nom_esp, m.nro_col,m.cel_med,m.est_med
from medico m inner join distrito d on m.id_dis=d.id_dis
inner join especialidad e on e.id_esp=m.id_esp
where m.id_med = @id_med
go
usp_BusMedicoPorID 1
go



-- Procedimiento Modidicar médico

--------------------------------------------
-- S E G U R I D A D
--------------------------------------------
create table cargo
(id_cargo int not null primary key identity (1,1),
nom_cargo varchar(30) not null)
go
insert cargo values ('Cajero'),('Asistente contable'),('Contador'),('Asistente'),('Programador'),('Analista de Sistemas'),('Jefe de Seguridad'),('Digitador'),('Operador'),
('Jefe de logística'),('Kardista'),('Almacenero'),('Mecánico')
go

create table Empleado
(id_emp int not null primary key identity (1,1),
nom_emp varchar(25) not null,
ape_emp varchar(25) not null,
id_cargo int references cargo,
dni_emp char(8) not null UNIQUE,
foto_emp image,
est_emp char(1) not null)
go
insert Empleado values ('Remigio','Huarcaya Almeyda',1,'12345678',null,'A')
insert Empleado values ('Christian','Chumpitaz',1,'72345678',null,'A')
insert Empleado values ('Luis','Estrada',2,'82345672',null,'A')
insert Empleado values ('Juan','Perez Garcia',3,'02345672',null,'A')

go
create table roles
(id_rol int not null primary key identity (1,1),
nom_rol varchar(20) not null)
go
insert roles values ('Digitador'),('Operador'),('Supervisor'),('Administrador')
go

create table usuario
(id_usu int not null primary key identity (1,1),
id_emp int references Empleado,
nom_usu varchar(25) not null,
con_usu varchar(50) not null,
id_rol int references roles,
fec_cre date not null,
est_usu char(1))
go
insert into usuario values (1, 'admin', 'MQAyADMANAA1ADYANwA4ADkA', 4 , '2017/09/12', 'A')
insert into usuario values (2, 'super', 'MQAyADMANAA1ADYANwA4ADkA', 3 , '2017/05/12', 'A')
insert into usuario values (3, 'lestrada', 'MQAyADMANAA1ADYANwA4ADkA', 1 , '2017/09/12', 'A')
insert into usuario values (4, 'administrador','123456789',4,'2017/11/12','A')
go
select * from usuario
create proc usp_ListaEmpleado
as
select id_emp, nomemp= nom_emp+ ' '+ape_emp 
from empleado
go

create proc verifica_login @usu varchar(25), 
							@con varchar(50)
as
Select u.nom_usu, e.nom_emp, e.ape_emp,r.id_rol, r.nom_rol
from usuario u inner join empleado e on e.id_emp=u.id_emp
inner join roles r on r.id_rol=u.id_rol
where u.nom_usu=@usu and con_usu=@con
go

exec verifica_login 'administrador','123456789'

create proc usp_ingUsuario @id_emp int,
							@nom_usu varchar(25),
							@con_usu varchar(50),
							@id_rol int,
							@fec_cre date
as
insert usuario values (@id_emp,@nom_usu,@con_usu,@id_rol,@fec_cre,'A')
go

create proc usp_modUsuario  @id_usu int,
							@id_emp int,
							@nom_usu varchar(25),
							@con_usu varchar(50),
							@id_rol int,
							@fec_cre date,
							@est_usu char(1)
as
update usuario set id_emp=@id_emp,nom_usu=@nom_usu,con_usu=@con_usu,
	id_rol=@id_rol,fec_cre= @fec_cre,est_usu = @est_usu
where id_usu=@id_usu
go


create proc usp_ListaRol
as
select * from Roles
go

create proc usp_listaUsuarios
as
Select u.id_usu, nomemp=e.nom_emp+ ' '+ e.ape_emp, u.nom_usu,u.con_usu, r.nom_rol,
u.fec_cre,u.est_usu
From Empleado e inner join usuario u on e.id_emp=u.id_emp
inner join roles r on u.id_rol=r.id_rol
go

-------------------------------------------
-- S E R V I C I O S
-------------------------------------------

create table servicio
(id_serv int not null primary key identity (1,1),
des_serv varchar(45) not null,
cos_ser smallmoney not null,
est_ser char(1) not null)
go
insert servicio values ('Servicio de Alojamiento',450,'A')
insert servicio values ('Pediatría',150,'A')
insert servicio values ('Medicina general',130,'A')
insert servicio values ('Servicio de ambulancia',180,'A')
insert servicio values ('Alojamiento',150,'A')
insert servicio values ('Tópico',150,'A')
insert servicio values ('Reumatología',150,'A')
insert servicio values ('Curación dental',100,'A')
insert servicio values ('Extracción dental',50,'A')
go

create table tipo_seguro
(id_tipseg int not null primary key identity (1,1),
des_tipseg varchar(35) not null)
go
insert tipo_seguro values ('Seguro pacífico'),('Seguro SENATI'),('Plan A'),('Ambulatorio')
go
create table paciente
(id_pac int not null primary key identity (1,1),
nom_pac varchar(25) not null,
ape_pac varchar(25) not null,
dni_pac char(8) not null UNIQUE,
id_dis int references distrito,
id_tipseg int references tipo_seguro,
foto image,
fec_nac date not null,
est_pac char(1) not null)
go
insert paciente values ('Angel','Barreda','78965423',1,1,null,'1990/04/10','A')
insert paciente values ('Thatiana','Arrese','48965423',1,2,null,'2000/07/20','A')
insert paciente values ('Roberto','Luna','68965423',2,2,null,'1980/12/10','A')
go

create table tip_doc
(id_tipdoc int not null primary key identity (1,1),
des_tipdoc varchar(25) not null,
des_abr char(5) not null,
nro_tipdoc char(7) not null)
go
insert tip_doc values ('Factura de Venta','FAC','0000005')
insert tip_doc values ('Boleta de Venta','BOL','0000003')
insert tip_doc values ('Recibo Honorario','RHE','0000001')
insert tip_doc values ('Nota de Abono','N/A','0000001')
insert tip_doc values ('Nota de Crédito','N/C','0000001')
insert tip_doc values ('Guía de Ingreso','N/C','0000001')
insert tip_doc values ('Guía de Salida','N/C','0000001')
insert tip_doc values ('Guía de Remisión','N/C','0000001')


create table Comprobante
(id_comp int not null primary key identity (1,1),
id_tipdoc int references tip_doc,
nro_comp char(7) not null,
fec_comp date not null,
id_emp int references empleado,
id_pac int references paciente,
tot_comp smallmoney not null,
est_comp char(1) not null check (est_comp in ('A','X')))
go

insert Comprobante values (1,'0000001','2017/01/01',1,1,650,'A')
insert Comprobante values (1,'0000002','2017/02/01',1,2,50,'A')
insert Comprobante values (2,'0000001','2017/03/01',1,2,150,'A')
insert Comprobante values (1,'0000003','2017/04/01',1,1,250,'A')
insert Comprobante values (1,'0000004','2017/05/01',1,1,100,'A')
insert Comprobante values (2,'0000002','2017/06/01',1,2,100,'A')
go
create table Detalle
(id_det int not null primary key identity (1,1),
id_comp int not null references comprobante,
id_serv int references Servicio,
cos_serv smallmoney not null)
go

insert Detalle values (1,1,150)
insert Detalle values (1,2,250)
insert Detalle values (1,3,150)

insert Detalle values (2,2,350)

insert Detalle values (3,1,250)
insert Detalle values (3,3,150)
insert Detalle values (3,4,150)
insert Detalle values (3,5,250)

insert Detalle values (4,1,250)
insert Detalle values (4,3,150)

insert Detalle values (5,3,150)

insert Detalle values (6,3,258)
insert Detalle values (6,6,150)
go


create proc usp_ListaPaciente
as
Select id_pac,nompac= nom_pac + ' '+ape_pac
from paciente 
go

create proc usp_ListaServicios
as
Select id_serv, des_serv, cos_ser
from servicio 
go

create proc usp_BusServicio @id int
as
select id_serv, des_serv, cos_ser
From servicio
where id_serv = @id
go

create proc usp_ListaTipDoc
as
Select id_tipdoc, des_tipdoc, nro_tipdoc
from tip_doc
go

usp_BusServicio 2
go


create proc usp_CompFecha @fecDesde date,
						 @fecHasta date
as
Select c.id_comp as ID,c.nro_comp as [Nº Comprobante],t.des_abr as ABRV,c.fec_comp as Fecha,nompac=p.nom_pac+ ' '+p.ape_pac,
c.tot_comp as Total, c.est_comp as E
from Comprobante C inner join Paciente p on c.id_pac=p.id_pac
inner join tip_doc t on t.id_tipdoc= c.id_tipdoc
where fec_comp between @fecDesde and @fecHasta
go

usp_CompFecha '2017/01/01','2017/04/01'
go

create proc usp_EstServ @año int
as
Select s.id_serv as ID, s.des_serv as Servicio, sum(d.cos_serv) as Importe
from Comprobante c inner join Detalle d on c.id_comp=d.id_comp
inner join servicio s on s.id_serv = d.id_serv
where year(c.fec_comp)= @año
Group by s.id_serv, s.des_serv
order by 2
go

usp_EstServ 2017
go

create proc usp_TotalFecha @fecDesde date,
						 @fecHasta date
as
Select sum(tot_comp) as total
from Comprobante  
where est_comp='A' and (fec_comp between @fecDesde and @fecHasta)
go

usp_TotalFecha '2017/01/01','2017/04/01'
go

create table menu
(id_menu int not null primary key identity (1,1),
des_menu varchar(35) not null,
id_rol int references roles)
go

insert menu values ('Registro de Cita',1)
insert menu values ('Estadística de Citas',2)
insert menu values ('Historia de Paciente',2)
insert menu values ('Registro de médico',3)
insert menu values ('programación  de Medicos',3)
insert menu values ('Comprobante',2)
insert menu values ('Especialidad',4)
insert menu values ('Consultorio',4)
insert menu values ('Distrito',4)
insert menu values ('Empleado',4)
insert menu values ('Usuario',4)
insert menu values ('Nivel de acceso',4)
insert menu values ('Roles',4)
insert menu values ('Copia de Seguridad',4)
insert menu values ('Reindexado de BD',4)
go

Create proc usp_ListaMenu
as
Select * from menu
go

-------------------------------------
-- C I T A S 
-------------------------------------

create table Citas
(id_cita int not null primary key identity(1,1),
id_pac int references paciente,
fec_cita date not null,
hor_cita time not null,
id_med int references medico,
id_con int references consultorio, 
est_cita char(1) not null)
go

create proc usp_CitasMed @id_med int
as 
select c.id_cita, c.fec_cita,c.hor_cita,
nompac=p.nom_pac+' ' +p.ape_pac,nommed= m.nom_med+' '+m.ape_med,
c.est_cita
from citas c inner join medico m on c.id_med = m.id_med
inner join paciente p on p.id_pac=c.id_pac
where c.id_med = @id_med
go

insert citas values (1,'2017/10/01','10:20:00 am',1,1,'P')
insert citas values (1,'2017/10/01','10:30:00 pm',2,2,'P')
insert citas values (2,'2017/10/02','08:20:00 am',2,3,'C')
insert citas values (3,'2017/10/03','09:20:00 am',3,3,'P')
insert citas values (3,'2017/10/03','09:20:00 am',3,3,'P')
go
usp_CitasMed 2

go

create proc usp_MedEsp @id_esp int
as
select id_med, nommed=nom_med +' '+ape_med 
from medico
where id_esp = @id_esp
go



create proc usp_CitasMed2 @idmed int 
as 
select p.dni_pac , c.fec_cita, c.hor_cita, n.nro_con, c.est_cita
from citas c inner join paciente p on p.id_pac = c.id_pac
inner join consultorio n on n.id_con = c.id_con
where id_med = @idmed

order by c.fec_cita desc , c.hor_cita
go

usp_CitasMed2 2
go

create proc usp_ListaPaciente2
as
select p.id_pac as ID , p.nom_pac as Nombres , p.ape_pac as Apellidos, p.dni_pac as DNI,
t.des_tipseg as Seguro, p.foto as Foto, p.fec_nac as 'F.Nacimiento', p.est_pac as Estado
from paciente p inner join tipo_seguro t on p.id_tipseg= t.id_tipseg 
go 
	
create proc usp_BuscarPaciente @nom varchar (35)
as
select p.id_pac as ID , p.nom_pac as Nombres , p.ape_pac as Apellidos, p.dni_pac as DNI,
t.des_tipseg as Seguro, p.foto as Foto, p.fec_nac as 'F.Nacimiento', p.est_pac as Estado
from paciente p inner join tipo_seguro t on p.id_tipseg= t.id_tipseg 
where nom_pac like '%'+@nom+'%'
go 

create proc usp_BuscarPacDNI @dni varchar (20)
as
select p.id_pac as ID , p.nom_pac as Nombres , p.ape_pac as Apellidos, p.dni_pac as DNI,
t.des_tipseg as Seguro, p.foto as Foto, p.fec_nac as 'F.Nacimiento', p.est_pac as Estado
from paciente p inner join tipo_seguro t on p.id_tipseg= t.id_tipseg 
where dni_pac like '%'+@dni+'%'
go 

create proc usp_ingComp @idcomp int output,
						@idtipdoc int, @feccomp date,
						@idemp int,	@idpac int,	@totcomp smallmoney
as
declare @nrocomp varchar(7)
Select @nrocomp = nro_tipdoc from tip_doc where id_tipdoc=@idtipdoc

insert Comprobante 
values (@idtipdoc,@nrocomp,@feccomp,@idemp,@idpac,@totcomp,'A')
set @idcomp = @@identity

--Grabar el nuevo número
Update tip_doc 
set nro_tipdoc = RIGHT('0000000'+ ltrim(str( Cast(nro_tipdoc as int)+1)),7)
where id_tipdoc=@idtipdoc

return @idcomp
go

Create proc usp_detaComp @idcomp int,
						 @idserv int,
						 @cos_serv smallmoney
as
Insert Detalle values (@idcomp,@idserv,@cos_serv)
go


create proc usp_detComp @idcomp int, @idserv int, @cosserv decimal
as
insert Detalle values (@idcomp, @idserv, @cosserv)
go


create table proveedor 
(id_prov int not null primary key identity(1,1),
nom_prov varchar(25),
ruc_prov char(11),
direc_prov varchar(20),
telf_prov char(9),
est_prov char(1))
go
insert into  proveedor values ('Hersil',12345678912,'Av.28 de Julio',987654123,'A') 
insert into  proveedor values ('PMFARMA',12345678789,'Av.Mexico ',987654456,'A') 
go


create table guia
(idguia int not null primary key identity(1,1),
id_tipdoc int references tip_doc,
nro_guia char(7) not null,
fec_guia date not null default getdate(),
id_prov int references proveedor,
id_emp int references empleado,
est_guia char(1) check(est_guia='A' or est_guia='X')
)
go
create table laboratorio
(id_lab int primary key identity(1,1),
nom_lab varchar(25) not null,
con_lab varchar(35) not null,
tel_lab char(7) not null)
go

insert laboratorio values ('Blufstein','Luis Estrada','7548125')
go

create proc usp_ListaLab
as
select id_lab,nom_lab from laboratorio
go


create table Unidad
(id_uni int primary key identity(1,1),
nom_uni varchar(25) not null)
go

insert Unidad values ('Caja'),('Bolsa'),('Rollo')
go

create proc uss_ListaUnidad
as
select id_uni,nom_uni from unidad
go

create table Modo_uso
(id_modo int primary key identity(1,1),
nom_uni varchar(25)not null)
go

insert Modo_uso values ('Vía oral'),('Vía Intravenoso')
insert Modo_uso values ('Vía Intramuscular')
go

create proc usp_ListaModo
as
select  id_modo,nom_uni from Modo_uso
go
create table Presentación
(id_pres int primary key identity(1,1),
nom_pres varchar(15) not null)
go

insert Presentación values ('Capsula'),('Jarabe'),('Pastilla')
go

create proc usp_ListaPre
as
select id_pres,nom_pres from Presentación
go

create table producto
(id_pro int primary key identity(1,1),
nom_pro varchar(45)not null,
id_lab int references laboratorio,
id_uni int references Unidad,
id_modo int references Modo_uso,
id_pres int references Presentación,
pre_pro decimal (7,2) not null,
pre_sug decimal (7,2) not null, -- Precio Sugerido
stock_pro int not null, -- Stock actual
stock_max int not null, -- Stock maximo
stock_seg int not null, -- Stock seguridad
foto_pro image,
est_pro char(1)not null)
go

insert producto values ('Paracetamol',1,1,1,1,50.00,45.00,40,100,100,NULL,'A')
go

create proc usp_ingPro (@nom varchar(25),@lab int,@uni int,@modo int,@pres int,@pre_pro decimal(7,2),@pre_sug decimal(7,2),@stock int,@stockmax int,@stockseg int,@foto image)
as
insert producto values (@nom,@lab,@uni,@modo,@pres,@pre_pro,@pre_sug,@stock,@stockmax,@stockseg,@foto,'A')
go
select * from producto
go
create proc usp_ListaProducto
as
select p.nom_pro,l.nom_lab,u.nom_uni,m.nom_uni,pr.nom_pres,p.pre_pro,p.pre_sug,p.stock_pro,p.stock_max,p.stock_seg,p.foto_pro,p.est_pro from producto p inner join laboratorio l on p.id_lab=l.id_lab inner join unidad u on p.id_uni=u.id_uni inner join Modo_uso m on p.id_modo=m.id_modo inner join Presentación pr on p.id_pres=pr.id_pres 
go

create table detalleguiapro 
(id_det int primary key identity(1,1),
idguia int references guia,
id_pro int references producto,
can_pro int not null)
go


create proc usp_ingGuia @idguia int output,
						@idtipdoc int,@fecguia date,
						@idprov int,@idemp int
as
declare @nroguia varchar(7)
Select @nroguia = nro_tipdoc from tip_doc where id_tipdoc=@idtipdoc
insert guia
values (@idtipdoc,@nroguia,@fecguia,@idprov,@idemp,'A')
set @idguia = @@identity


--Grabar el nuevo número
Update tip_doc 
set nro_tipdoc = RIGHT('0000000'+ ltrim(str( Cast(nro_tipdoc as int)+1)),7)
where id_tipdoc=@idtipdoc

return @idguia
go


create proc usp_detaGuia @idguia int,
						 @idpro int,
						 @canpro int
as
Insert detalleguiapro values (@idguia,@idpro,@canpro)

update producto set stock_pro = stock_pro + @canpro
where id_pro=@idpro
go


--
create proc usp_GuiaFecha @fecDesde date,
						 @fecHasta date
as
Select c.idguia as ID,c.nro_guia as [Nº Guia],t.des_abr as ABRV,c.fec_guia as Fecha,p.nom_prov, c.est_guia as E
from guia C inner join proveedor p on c.id_prov=p.id_prov
inner join tip_doc t on t.id_tipdoc= c.id_tipdoc
where fec_guia between @fecDesde and @fecHasta
go


insert guia values(6,'0000001','2017/10/24',1,1,'A')
go

create proc usp_listaprov
as
select * from proveedor
go 


create proc usp_ListaPro
as 
select p.id_pro,p.nom_pro,l.nom_lab,p.pre_pro,p.stock_pro,p.est_pro from producto p inner join laboratorio l on p.id_lab=l.id_lab
go

create proc uso_Buspro  @nom varchar(25)
as 
select p.id_pro,p.nom_pro,l.nom_lab,p.pre_pro,p.stock_pro,p.est_pro from producto p inner join laboratorio l on p.id_lab=l.id_lab
where p.nom_pro like   @nom + '%'
go



create table enfermedades
(id_en int  not null primary key identity(1,1),
des_enf varchar(100), --descripcion
ori_enf varchar(100),--origen
vac_enf char(1),--
sin_enf varchar(200))--sintimas
go

insert into enfermedades values('Es una enfermedad muy grave','Nariz','1','Alergia')
insert into enfermedades values('a','a','a','a')
go



create procedure ingresar @des varchar(100),@ori varchar(100), @vac char(1),@sin varchar(100)
as
insert into enfermedades values (@des,@ori,@vac,@sin)
go

exec ingresar 'sasd','sdasda','a','asdas'
go

create procedure usp_listar 
as
select  id_en,des_enf,ori_enf,vac_enf,sin_enf from enfermedades
go

select * from enfermedades
go

create procedure buscar @id int
as
select id_en,des_enf,ori_enf,vac_enf,sin_enf from  enfermedades where id_en=@id
go

create procedure actualizar @id int,@des varchar(100),@ori varchar(100), @vac char(1),@sin varchar(100)
as
update enfermedades set des_enf=@des,ori_enf=@ori,vac_enf=@vac,sin_enf=@sin where id_en=@id
go


create procedure eliminar @id int
as
delete from enfermedades where id_en=@id
go
