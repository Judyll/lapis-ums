USE db_spud_092509
GO

SELECT
	scm.memo_id AS memo_id,
	scm.memo_date AS memo_date,
	scm.remarks AS remarks,
	scm.amount AS amount,
	scm.is_downpayment AS is_downpayment
FROM
	ums.student_information AS si
INNER JOIN ums.student_credit_memo AS scm ON scm.sysid_student = si.sysid_student
WHERE
	si.student_id = 'I2007-048'