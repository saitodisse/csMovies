USE [master]

-- Enable Integrated Security=False
GO
EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'LoginMode', REG_DWORD, 2
GO

-- Create the 'qweasd' user
DECLARE @SID VARBINARY(85);
SELECT @SID = sid FROM dbo.syslogins WHERE name = 'ourMoviesUser'
SELECT @SID

IF @SID IS NULL
BEGIN
	--Cria usuário FOAPP na base de dados
	CREATE LOGIN [qweasd] WITH PASSWORD=N'ourMoviesPass123456789', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF

	--Libera permissão para Roles dos Servers
	exec sp_addsrvrolemember 'ourMoviesUser', sysadmin
END