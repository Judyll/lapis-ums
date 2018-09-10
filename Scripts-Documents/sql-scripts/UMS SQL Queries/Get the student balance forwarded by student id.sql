USE db_spud_092509
GO

SELECT
	sbf.balance_id AS balance_id,
	sbf.amount AS amount
FROM
	ums.student_information AS si
INNER JOIN ums.student_balance_forwarded AS sbf ON sbf.sysid_student = si.sysid_student
WHERE
	si.student_id = 'Q2008-086'