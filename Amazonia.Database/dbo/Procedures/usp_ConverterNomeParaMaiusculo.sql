CREATE PROCEDURE [dbo].[usp_ConverterNomeParaMaiusculo]
	@param1 VARCHAR(50) = 0     --Parâmetro de Entrada
AS
	SELECT UPPER(@param1)
RETURN 0
