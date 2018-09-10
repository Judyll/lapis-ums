USE db_spud_092509
GO

SELECT
	sfl.sysid_feelevel AS sysid_feelevel,
	yli.year_level_description AS year_level_description,
	cg.group_description AS group_description
FROM
	ums.school_fee_level AS sfl
INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
WHERE
	sfi.sysid_schoolfee = 'SYSSCF021' AND
	cg.course_group_id = 'CG03'