CREATE PROCEDURE [dbo].[GetExamples]	
AS
	BEGIN
            SELECT TOP 14 Example         
            FROM 
                dbo.Examples WITH (NOLOCK)             
            ORDER BY Id DESC
	END
