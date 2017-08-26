----------------------------------------------------------------------------
-- Ce script permet de mettre à jour un label
----------------------------------------------------------------------------
--Paramètres
DECLARE @lbl_code VARCHAR(255), @lbl_fr VARCHAR(255), @lbl_en VARCHAR(255),  @lbl_es VARCHAR(255) 
SET @lbl_code = 'rubrique_label'
SET @lbl_fr = 'Rubriques'
SET @lbl_en = 'Rubrics'
SET @lbl_es = 'Rúbricas'
----------------------------------------------------------------------------

SELECT *
FROM label
WHERE lbl_code = @lbl_code

UPDATE label
SET lbl_libelle =@lbl_fr
WHERE lbl_code=@lbl_code AND lng_id = 1 
UPDATE label
SET lbl_libelle =@lbl_en
WHERE lbl_code=@lbl_code AND lng_id = 2 
UPDATE label
SET lbl_libelle =@lbl_es
WHERE lbl_code=@lbl_code AND lng_id = 3 

SELECT *
FROM label
WHERE lbl_code = @lbl_code
