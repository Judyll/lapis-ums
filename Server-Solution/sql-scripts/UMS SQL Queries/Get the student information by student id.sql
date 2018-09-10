USE db_spud_092509
GO

SELECT
	si.sysid_student AS sysid_student,
	si.student_id AS student_id,
	si.card_number AS card_number,
	si.scholarship AS scholarship,
	si.is_international AS is_international,
	si.is_no_downpayment_required AS is_no_downpayment_required,
	pri.last_name AS last_name,
	pri.first_name AS first_name,
	pri.middle_name AS middle_name
FROM
	ums.student_information AS si
INNER JOIN ums.person_information AS pri ON pri.sysid_person = si.sysid_person
WHERE
	si.student_id = 'Q2010-039'