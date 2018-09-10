USE db_spud_092509
GO

SELECT
	srb.reimbursement_id AS reimbursement_id,
	srb.reimbursement_date AS reimbursement_date,
	srb.remarks AS remarks,
	srb.amount AS amount,
	srb.is_downpayment AS is_downpayment
FROM
	ums.student_information AS si
INNER JOIN ums.student_reimbursements AS srb ON srb.sysid_student = si.sysid_student
WHERE
	si.student_id = 'M2009-156'