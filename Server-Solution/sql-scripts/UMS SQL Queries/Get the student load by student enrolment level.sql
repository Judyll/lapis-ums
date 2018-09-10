USE db_spud_092509
GO

SELECT
	sl.load_id AS load_id,
	sci.sysid_schedule AS sysid_schedule,
	si.subject_code AS subject_code,
	si.descriptive_title AS descriptive_title,
	sl.lecture_units AS lecture_units,
	sl.lab_units AS lab_units,
	sl.no_hours AS no_hours,
	sl.is_premature_deloaded AS is_premature_deloaded,
	sl.load_date AS load_date,
	sl.deload_date AS deload_date
FROM
	ums.student_load AS sl
INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
WHERE
	sl.sysid_enrolmentlevel = 'SYSELV000001841'
ORDER BY
	si.subject_code ASC