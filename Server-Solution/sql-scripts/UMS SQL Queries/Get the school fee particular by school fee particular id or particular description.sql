USE db_spud_092509
GO

SELECT
	sfp.sysid_feeparticular AS sysid_feeparticular,
	sfp.particular_description AS particular_description,
	sfc.category_description AS category_description
FROM
	ums.school_fee_particular AS sfp
INNER JOIN ums.school_fee_category AS sfc ON sfc.fee_category_id = sfp.fee_category_id
WHERE
	sfp.sysid_feeparticular = 'SYSFPR085'


SELECT
	sfp.sysid_feeparticular AS sysid_feeparticular,
	sfp.particular_description AS particular_description,
	sfc.category_description AS category_description
FROM
	ums.school_fee_particular AS sfp
INNER JOIN ums.school_fee_category AS sfc ON sfc.fee_category_id = sfp.fee_category_id
WHERE
	sfp.particular_description LIKE '%Recollection%'