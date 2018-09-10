USE db_spud_092509
GO

SELECT
	sec.sysid_enrolmentcourse,
	sec.course_id,
	sec.sysid_schoolfee,
	sec.sysid_semester,
	sec.is_current_course,
	ci.course_title
FROM
	ums.student_information AS si
INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = si.sysid_student
INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
WHERE
	si.student_id = 'M2010-205'
ORDER BY
	is_current_course DESC