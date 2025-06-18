	Create database TestEFCore
	go

	use TestEFCore
	go

	Create table [User]
	(
	   UserID BIGINT PRIMARY KEY IDENTITY(1,1),
	   UserName NVARCHAR(100) NOT NULL,
	   Password NVARCHAR(100) NOT NULL,
	   IsActive BIT NOT NULL
	)


	INSERT INTO [User] (UserName, Password, IsActive) VALUES ('AliceSmith', 'password123', 1);
	INSERT INTO [User] (UserName, Password, IsActive) VALUES ('BobJones', 'securePass456', 1);
	INSERT INTO [User] (UserName, Password, IsActive) VALUES ('CharlieBrown', 'charliePwd', 0);
	INSERT INTO [User] (UserName, Password, IsActive) VALUES ('DanaWhite', 'pass789', 1);
	INSERT INTO [User] (UserName, Password, IsActive) VALUES ('EvelynStone', 'ev3lynPwd!', 0);
	INSERT INTO [User] (UserName, Password, IsActive) VALUES ('FrankMiller', 'frankieSecure', 1);
	INSERT INTO [User] (UserName, Password, IsActive) VALUES ('GraceHopper', 'graceRules', 1);
	INSERT INTO [User] (UserName, Password, IsActive) VALUES ('HarryPotts', 'harryPass', 0);
	INSERT INTO [User] (UserName, Password, IsActive) VALUES ('IvyGreen', 'greenLeaf$', 1);
	INSERT INTO [User] (UserName, Password, IsActive) VALUES ('JackBlack', 'jackJack', 1);
