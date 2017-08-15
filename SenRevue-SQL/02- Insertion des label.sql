--Insertion des labels
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'admin_home_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_home_title' ,1,'Adminstration: Accueil');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_home_title' ,2,'Adminstration: Home');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_home_title' ,3,'Adminstracion: Inició');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'admin_login_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_login_title' ,1,'Adminstration: Connexion');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_login_title' ,2,'Adminstration: Login');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_login_title' ,3,'Adminstracion: conexión');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'connexion_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('connexion_label' ,1,'Connexion');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('connexion_label' ,2,'Login');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('connexion_label' ,3,'Conexión');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'email_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('email_label' ,1,'Courrier électronique');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('email_label' ,2,'Email');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('email_label' ,3,'E-mail');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'password_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('password_label' ,1,'Mot de passe');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('password_label' ,2,'Password');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('password_label' ,3,'Contraseña');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'connect_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('connect_label' ,1,'Se connecter');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('connect_label' ,2,'Connect');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('connect_label' ,3,'Conectar');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'disconnect_label')
 BEGIN
	INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
	VALUES ('disconnect_label' ,1,'Se déconnecter');
	INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
	VALUES ('disconnect_label' ,2,'Disconnect');
	INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
	VALUES ('disconnect_label' ,3,'Desconectar');
  END	
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'hello_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('hello_label' ,1,'Bonjour');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('hello_label' ,2,'Hello');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('hello_label' ,3,'Hola');
	END
GO