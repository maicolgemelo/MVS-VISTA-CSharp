CREATE TABLE TblContacto( 
	Id int NOT NULL PRIMARY KEY,
	Nombre varchar(50) null,
	Telefono varchar(20) null
)
insert into dbo.TblContacto(Id,Nombre,Telefono)
values (3,'Sebastian','1224168')

select * from dbo.TblContacto

CREATE PROC SPContacto
	@opc int,
	@Id int = null,
	@Nombre varchar(50) = null,
	@Telefono varchar(20) = null
AS

if @opc = 1
begin
	select * from TblContacto
end
go





