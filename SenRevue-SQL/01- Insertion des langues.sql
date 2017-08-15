--Insertion des langues
IF NOT EXISTS(SELECT * FROM language WHERE lng_code = 'fr')
	INSERT INTO [dbo].[language]([lng_code],[lng_libelle],[lng_image_name],[lng_image_path],[lng_active])
     VALUES('fr' ,'Français','fr_flag','../Content/Flags/fr_flags.png',1)
GO
IF NOT EXISTS(SELECT * FROM language WHERE lng_code = 'en')
	INSERT INTO [dbo].[language]([lng_code],[lng_libelle],[lng_image_name],[lng_image_path],[lng_active])
     VALUES('en' ,'English','en_flag','../Content/Flags/en_flags.png',1)
GO
IF NOT EXISTS(SELECT * FROM language WHERE lng_code = 'es')
	INSERT INTO [dbo].[language]([lng_code],[lng_libelle],[lng_image_name],[lng_image_path],[lng_active])
     VALUES('es' ,'Spanish','es_flag','../Content/Flags/es_flags.png',0)
GO
