CREATE PROCEDURE [dbo].[AddExample]
	@example nvarchar(50) 	
AS
	BEGIN
        INSERT INTO Examples(Example) values (@example)
	END
