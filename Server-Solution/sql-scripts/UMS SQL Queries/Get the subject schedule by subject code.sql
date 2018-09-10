USE db_spud_092509
GO

SELECT
	sci.sysid_schedule AS sysid_schedule,
	sci.year_id AS year_id,
	sci.sysid_semester AS sysid_semester,
	si.subject_code AS subject_code,
	si.descriptive_title AS descriptive_title,
	si.lecture_units AS lecture_units,
	si.lab_units AS lab_units,
	si.no_hours AS no_hours
FROM
	ums.schedule_information AS sci
INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
WHERE
--	sci.year_id = '' AND
	sci.sysid_semester = 'SYSSEM0029' AND
	si.subject_code LIKE '%ACC 402b%'