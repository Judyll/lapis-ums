USE db_spud_092509
GO

SELECT
	sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
	yli.year_level_description AS year_level_description,
	cg.group_description AS group_description,
	ci.course_title AS course_title,
	sel.is_entry_level AS is_entry_level,
	sel.is_marked_deleted AS is_marked_deleted,
	sel.is_graduate_student AS is_graduate_student,
	sy.year_description AS year_description,
	ss.semester_description AS semester_description,
	sfl.sysid_feelevel AS sysid_feelevel
FROM
	ums.student_enrolment_level AS sel
INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id
INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
WHERE
	sec.sysid_enrolmentcourse = 'SYSECR000001729'