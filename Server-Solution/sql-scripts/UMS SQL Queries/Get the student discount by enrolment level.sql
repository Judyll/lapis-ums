USE db_spud_092509
GO

SELECT
	std.discount_id AS discount_id,
	std.discount_date AS discount_date,
	std.amount AS amount,
	sci.scholarship_description AS scholarship_description
FROM
	ums.student_discounts AS std
INNER JOIN ums.student_scholarship AS sts ON sts.sysid_studentscholarship = std.sysid_studentscholarship
INNER JOIN ums.scholarship_information AS sci ON sci.sysid_scholarship = sts.sysid_scholarship
WHERE
	sts.sysid_enrolmentlevel = 'SYSELV000006655'
ORDER BY
	std.discount_date ASC