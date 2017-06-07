USE NEGOCIOS2017
GO

CREATE PROCEDURE USP_LISTADOPAIS
AS
SELECT * FROM TB_CLIENTES
GO


				 
CREATE PROCEDURE USP_AGREGARCLIENTE( @id as varchar(5) ,@nom as varchar(40),@dir as varchar(60),@pais as char(3),@tel as varchar(24))
AS
INSERT INTO TB_CLIENTES VALUES(@id,@nom,@dir,@pais,@tel)
go


CREATE PROCEDURE USP_ACTUALIZARCLIENTE (@id as varchar(5) ,@nom as varchar(40),@dir as varchar(60),@pais as char(3),@tel as varchar(24))
AS
UPDATE TB_CLIENTES SET nombrecia=@nom,
						direccion=@dir,
						idpais=@pais,
						telefono=@tel
						where idcliente=@id
go




CREATE PROCEDURE USP_ELIMINARCLIENTE (@id as varchar(5)) 
AS
DELETE FROM TB_CLIENTES 
WHERE IDCLIENTE=@id
go


