USE db_spud_092509
GO

SELECT
	stp.payment_id AS payment_id,
	stp.payment_date AS payment_date,
	stp.receipt_no AS receipt_no,
	stp.remarks AS remarks,
	stp.is_downpayment AS is_downpayment,
	stp.amount AS amount,
	stp.discount_amount AS discount_amount
FROM
	ums.student_information AS si
INNER JOIN ums.student_payments AS stp ON stp.sysid_student = si.sysid_student
WHERE
	si.student_id = 'M2010-513'