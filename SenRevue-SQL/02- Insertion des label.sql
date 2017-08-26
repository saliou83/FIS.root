--Insertion des labels
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'admin_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_title' ,1,'Adminstration');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_title' ,2,'Adminstration');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_title' ,3,'Administración');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'admin_home_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_home_title' ,1,'Accueil');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_home_title' ,2,'Home');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_home_title' ,3,'Inició');
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
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'admin_register_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_register_title' ,1,'Inscription');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_register_title' ,2,'Registration');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_register_title' ,3,'Inscripción');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'admin_register_explain_text')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_register_explain_text' ,1,'Créer un nouveau compte.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_register_explain_text' ,2,'Create a new account.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('admin_register_explain_text' ,3,'Crear une nueva cuenta.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'confirm_password_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('confirm_password_label' ,1,'Confirmer le mot de passe');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('confirm_password_label' ,2,'Confirm password');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('confirm_password_label' ,3,'Confirmar la contraseña');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'save_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('save_label' ,1,'Sauvegarder');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('save_label' ,2,'Save');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('save_label' ,3,'Guardar');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'register_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('register_label' ,1,'Enregistrer');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('register_label' ,2,'Register');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('register_label' ,3,'Registrar');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'no_correspondence_password_error')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('no_correspondence_password_error' ,1,'Le mot de passe et le mot de passe de confirmation ne correspondent pas.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('no_correspondence_password_error' ,2,'The password and confirmation password do not match.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('no_correspondence_password_error' ,3,'La contraseña y la contraseña de confirmación no coinciden.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'email_required_error')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('email_required_error' ,1,'Le courrier électronique est obligatoire.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('email_required_error' ,2,'The email is required.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('email_required_error' ,3,'Se requiere e-mail.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'email_invalid_error')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('email_invalid_error' ,1,'Le courrier électronique est invalide.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('email_invalid_error' ,2,'The email is not valid.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('email_invalid_error' ,3,'E-mail no es válido.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'password_required_error')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('password_required_error' ,1,'Le mot de passe est obligatoire.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('password_required_error' ,2,'The password is required.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('password_required_error' ,3,'Se requiere la contraseña.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'confirm_password_required_error')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('confirm_password_required_error' ,1,'La confirmation du mot de passe est obligatoire.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('confirm_password_required_error' ,2,'Password confirmation is required.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('confirm_password_required_error' ,3,'Se requiere confirmación de la contraseña.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'password_minlength_error')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('password_minlength_error' ,1,'La mot de passe doit contenir au moins {0} caratères.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('password_minlength_error' ,2,'The password must be at least {0} characters long.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('password_minlength_error' ,3,'La contraseña debe tener al menos {0} caracteres.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'role_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('role_label' ,1,'Role');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('role_label' ,2,'Role');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('role_label' ,3,'Rol');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'Admin')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('Admin' ,1,'Adminstrateur');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('Admin' ,2,'Manager');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('Admin' ,3,'Adminstrador');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'Editor')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('Editor' ,1,'Editeur');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('Editor' ,2,'Editor');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('Editor' ,3,'Editor');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'select_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('select_label' ,1,'Sélectionner');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('select_label' ,2,'Select');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('select_label' ,3,'Seleccionar');
	END
GO	
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'role_required_error')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('role_required_error' ,1,'Le role est obligatoire.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('role_required_error' ,2,'Role is required.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('role_required_error' ,3,'El rol es obligatorio.');
	END
GO	
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'mail_confirm_mail_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('mail_confirm_mail_title' ,1,'Confirmation du courrier électronique');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('mail_confirm_mail_title' ,2,'Confirm email');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('mail_confirm_mail_title' ,3,'Confirmar correo electrónico');
	END
GO	
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'page_confirm_mail_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_title' ,1,'SenRevue.com : Confirmez votre compte');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_title' ,2,'SenRevue.com : Confirm your account');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_title' ,3,'SenRevue.com : Confirmar su cuenta');
	END
GO	
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'page_confirm_mail_content')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_content' ,1,'Confirmez votre compte en cliquant <a href=''{0}''>ici</a>');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_content' ,2,'Confirm your account by clicking <a href=''{0}''>here</a>');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_content' ,3,'Confirme su cuenta haciendo clic en <a href=''{0}''>aquí</a>');
	END
GO	
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'confirm_user_created_message')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('confirm_user_created_message' ,1,'Le compte a bien été créé et un email a été envoyé à {0}. ');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('confirm_user_created_message' ,2,'The account was successfully created and an email was sent to {0}.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('confirm_user_created_message' ,3,'La cuenta se creó correctamente y se envió un correo electrónico a {0}.');
	END
GO	
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'page_confirm_mail_message_1')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_message_1' ,1,'Merci d''avoir confirmé votre e-mail.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_message_1' ,2,'Thank you for confirming your e-mail.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_message_1' ,3,'Gracias por confirmar su e-mail.');
	END
GO	
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'page_confirm_mail_message_2')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_message_2' ,1,'Veuillez cliquer ici pour changer votre mot de passe avant de vous connecter.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_message_2' ,2,'Please click here to change your password before logging in.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('page_confirm_mail_message_2' ,3,'Haga clic aquí para cambiar su contraseña antes de iniciar sesión.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'forgot_password_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_title' ,1,'Changer le mot de passe ');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_title' ,2,'Change the password');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_title' ,3,'Cambiar contraseña');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'forgot_password_content_1')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_content_1' ,1,'Pour changer votre mot de passe');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_content_1' ,2,'To change your password');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_content_1' ,3,'Para cambiar su contraseña');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'forgot_password_content_2')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_content_2' ,1,'Entrez une adresse de messagerie.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_content_2' ,2,'Enter an email address.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_content_2' ,3,'Ingrese una dirección de mensajería.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'forgot_password_btn_link')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_btn_link' ,1,'Lien de courrier électronique');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_btn_link' ,2,'E-mail Link');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('forgot_password_btn_link' ,3,'Enlace de Correo Electrónico');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'reset_password_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('reset_password_title' ,1,'Réinitialisez votre mot de passe');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('reset_password_title' ,2,'Reset your password');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('reset_password_title' ,3,'Restablezca su contraseña');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'reset_password_confirmation_message_1')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('reset_password_confirmation_message_1' ,1,'Votre mot de passe a été réinitialisé.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('reset_password_confirmation_message_1' ,2,'Your password has been reset.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('reset_password_confirmation_message_1' ,3,'Su contraseña se ha restablecido.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'reset_password_confirmation_message_2')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('reset_password_confirmation_message_2' ,1,'Veuillez cliquer ici pour vous connecter.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('reset_password_confirmation_message_2' ,2,'Please click here to login.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('reset_password_confirmation_message_2' ,3,'Haga clic aquí para iniciar sesión.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'user_account_already_exist')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('user_account_already_exist' ,1,'L''adresse email {0} est déjà utilisée.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('user_account_already_exist' ,2,'The email address {0} is already in use.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('user_account_already_exist' ,3,'La dirección de correo electrónico {0} ya está en uso.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'login_fail')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('login_fail' ,1,'Tentative de connexion non valide.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('login_fail' ,2,'Invalid connection attempt.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('login_fail' ,3,'Intentos de conexión no válidos.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'new_user_account')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('new_user_account' ,1,'Nouveau compte');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('new_user_account' ,2,'New account');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('new_user_account' ,3,'Nueva cuenta');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'new_user_account_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('new_user_account_title' ,1,'Créer nouveau compte d''administration.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('new_user_account_title' ,2,'Create a new admin account.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('new_user_account_title' ,3,'Crear nueva cuenta de administración.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'manage_account_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('manage_account_title' ,1,'Gérer votre compte.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('manage_account_title' ,2,'Manage your account.');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('manage_account_title' ,3,'Administra tu cuenta.');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'home_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('home_label' ,1,'Accueil');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('home_label' ,2,'Home');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('home_label' ,3,'Recepción');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'article_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('article_label' ,1,'Articles');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('article_label' ,2,'Articles');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('article_label' ,3,'Artículo');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'article_admin_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('article_admin_title' ,1,'Voir la liste des articles');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('article_admin_title' ,2,'See the list of articles');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('article_admin_title' ,3,'Ver la lista de artículos');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'rubrique_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('rubrique_label' ,1,'Rubriques');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('rubrique_label' ,2,'Rubrics');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('rubrique_label' ,3,'Rúbricas');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'rubrique_admin_title')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('rubrique_admin_title' ,1,'Voir la liste des rubriques');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('rubrique_admin_title' ,2,'See list of topics');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('rubrique_admin_title' ,3,'Ver lista de temas');
	END
GO
IF NOT EXISTS(SELECT * FROM label WHERE lbl_code = 'economy_label')
	BEGIN
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('economy_label' ,1,'Économie');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('economy_label' ,2,'Economy');
		INSERT INTO [dbo].[label]([lbl_code],[lng_id],[lbl_libelle]) 
		VALUES ('economy_label' ,3,'Economía');
	END
GO