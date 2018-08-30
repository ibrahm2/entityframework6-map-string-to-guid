CREATE PROCEDURE [dbo].[sp_InsertTable]
	@id varchar(36)
AS

INSERT INTO [Table] SELECT @id
