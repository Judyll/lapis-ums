-- spu.year_level_information
-- is used for the grade and year level information (IS REFERENCES BY THE STRUCT YearLevelId)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV01', 'CG01', 'Nursery', 1, 'I', 'A', 1)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV02', 'CG01', 'Kinder 1', 1, 'I', 'A', 2)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV03', 'CG01', 'Kinder 2', 0, 'II', 'B', 3)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV04', 'CG01', 'Grade 1', 1, 'I', 'C', 4)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV05', 'CG01', 'Grade 2', 0, 'II', 'D', 5)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV06', 'CG01', 'Grade 3', 0, 'III', 'E', 6)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV07', 'CG01', 'Grade 4', 0, 'IV', 'F', 7)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV08', 'CG01', 'Grade 5', 0, 'V', 'G', 8)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV09', 'CG01', 'Grade 6', 0, 'VI', 'H', 9)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV10', 'CG02', '1st Year', 1, '1', 'I', 10)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV11', 'CG02', '2nd Year', 0, '2', 'J', 11)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV12', 'CG02', '3rd Year', 0, '3', 'K', 12)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV13', 'CG02', '4th Year', 0, '4', 'L', 13)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV14', 'CG03', '1st Year', 1, '1', 'M', 14)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV15', 'CG03', '2nd Year', 0, '2', 'N', 15)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV16', 'CG03', '3rd Year', 0, '3', 'O', 16)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV17', 'CG03', '4th Year', 0, '4', 'P', 17)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV18', 'CG03', '5th Year', 0, '5', 'U', 18)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV19', 'CG04', 'Masteral', 0, '', 'Q', 19)
INSERT INTO spu.year_level_information(year_level_id, course_group_id, year_level_description, is_entry_level, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV20', 'CG04', 'Doctorate', 0, '', 'Q', 20)

GO
--spu.school_fee_particular
--TUITION FEE CATEGORY
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR001', 'FCID01', 'Per Year', 0, 0, 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR002', 'FCID01', 'Per Unit', 0, 0, 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--MISCELLANEOUS
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR003', 'FCID02', 'Registration', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR004', 'FCID02', 'Medical and Dental', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR005', 'FCID02', 'Library', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR006', 'FCID02', 'Guidance and Counselling', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR007', 'FCID02', 'School Publication', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR008', 'FCID02', 'Development', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR009', 'FCID02', 'Test Papers', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR010', 'FCID02', 'School Activities', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR011', 'FCID02', 'Cultural', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR012', 'FCID02', 'Athletic', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR013', 'FCID02', 'Audio-Visual', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR014', 'FCID02', 'Science Lab (GS/HS)', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR015', 'FCID02', 'Computer Lab (GS/HS)', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR016', 'FCID02', 'Speech Lab (GS/HS)', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR017', 'FCID02', 'School Journal', 1, 0, 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--OTHER FEES
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR018', 'FCID03', 'ID', 1, 0, 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR019', 'FCID03', 'Insurance', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR020', 'FCID03', 'Recollection', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR021', 'FCID03', 'Membership', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR022', 'FCID03', 'P.E. T-Shirts', 1, 0, 1,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR023', 'FCID03', 'P.E. Shorts', 1, 0, 1,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR024', 'FCID03', 'P.E. Jogging Pants', 1, 0, 1,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR025', 'FCID03', 'Intrams T-shirt', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR026', 'FCID03', 'Handbook', 1, 0, 1,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR027', 'FCID03', 'Magazine', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR028', 'FCID03', 'First Communion', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR029', 'FCID03', 'Student Activity', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR030', 'FCID03', 'Graduation', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR031', 'FCID03', 'Yearbook', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR032', 'FCID03', 'Pictures', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR033', 'FCID03', 'Alumni', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR034', 'FCID03', 'Diskettes', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR035', 'FCID03', 'HSSCC', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR036', 'FCID03', 'Cufflinks/Clip, Tie', 1, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR037', 'FCID03', 'SAO T-Shirts', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--LABORATORY FEES
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR038', 'FCID04', 'Science Lab', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR039', 'FCID04', 'Typing Lab (3 Units)', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR040', 'FCID04', 'Typing Lab (5 Units)', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR041', 'FCID04', 'Computer Lab (3 Units)', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR042', 'FCID04', 'Computer Lab (1 Unit)', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR043', 'FCID04', 'Nursing Lab', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR044', 'FCID04', 'Speech Lab', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR045', 'FCID04', 'Internet', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR046', 'FCID04', 'Swimming with Swimwear', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR047', 'FCID04', 'Swimming w/o Swimwear', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

----OTHER FEES
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR048', 'FCID03', 'J/P Shorts', 1, 0, 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR049', 'FCID03', 'Practice Test', 0, 0, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR050', 'FCID03', 'Toga', 0, 0, 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--LABORATORY FEES
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR051', 'FCID04', 'Typing Lab', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeParticular 'SYSFPR052', 'FCID04', 'Computer Lab', 1, 1, 0,'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--spu.school_fee_information
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF001', 'SY20002001', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF002', 'SY20002001SUMMER', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF003', 'SY20012002', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF004', 'SY20012002SUMMER', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF005', 'SY20022003', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF006', 'SY20022003SUMMER', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF007', 'SY20032004', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF008', 'SY20032004SUMMER', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF009', 'SY20042005', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF010', 'SY20042005SUMMER', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF011', 'SY20052006', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF012', 'SY20052006SUMMER', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF013', 'SY20062007', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF014', 'SY20062007SUMMER', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF015', 'SY20072008', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF016', 'SY20072008SUMMER', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF017', 'SY20082009', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE spu.InsertSchoolFeeInformation 'SYSSCF018', 'SY20082009SUMMER', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'


--spu.school_fee_level
--SCHOOL YEAR 2008 - 2009
--NURSERY (YRLV01)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000001', 'SYSSCF017', 'YRLV01', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--KINDER 1 (YRLV02)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000002', 'SYSSCF017', 'YRLV02', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--KINDER 2 (YRLV03)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000003', 'SYSSCF017', 'YRLV03', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GRADE 1 (YRLV04)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000004', 'SYSSCF017', 'YRLV04', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GRADE 2 (YRLV05)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000005', 'SYSSCF017', 'YRLV05', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GRADE 3 (YRLV06)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000006', 'SYSSCF017', 'YRLV06', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GRADE 4 (YRLV07)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000007', 'SYSSCF017', 'YRLV07', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GRADE 5 (YRLV08)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000008', 'SYSSCF017', 'YRLV08', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GRADE 6 (YRLV09)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000009', 'SYSSCF017', 'YRLV09', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--1ST YEAR (YRLV10)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000010', 'SYSSCF017', 'YRLV10', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--2ND YEAR (YRLV11)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000011', 'SYSSCF017', 'YRLV11', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--3RD YEAR (YRLV12)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000012', 'SYSSCF017', 'YRLV12', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--4TH YEAR (YRLV13)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000013', 'SYSSCF017', 'YRLV13', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--1ST YEAR (YRLV14)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000014', 'SYSSCF017', 'YRLV14', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--2ND YEAR (YRLV15)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000015', 'SYSSCF017', 'YRLV15', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--3RD YEAR (YRLV16)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000016', 'SYSSCF017', 'YRLV16', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--4TH YEAR (YRLV17)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000017', 'SYSSCF017', 'YRLV17', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--Graduate School (YRLV19)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000018', 'SYSSCF017', 'YRLV19', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--Doctorate (YRLV20)
EXECUTE spu.InsertSchoolFeeLevel 'SYSFLV000019', 'SYSSCF017', 'YRLV20', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--spu.school_fee_details
--SY 20082009
--GRADE SCHOOL (CG01)
--NURSERY (SYSFLV000001)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000001', 'SYSFLV000001', 'SYSFPR001', 0, 16472.98, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000002', 'SYSFLV000001', 'SYSFPR003', 0, 443.96, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000003', 'SYSFLV000001', 'SYSFPR004', 0, 232.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000004', 'SYSFLV000001', 'SYSFPR005', 0, 585.27, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000005', 'SYSFLV000001', 'SYSFPR006', 0, 133.01, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000006', 'SYSFLV000001', 'SYSFPR007', 0, 221.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000007', 'SYSFLV000001', 'SYSFPR008', 0, 554.20, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000008', 'SYSFLV000001', 'SYSFPR009', 0, 341.40, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000009', 'SYSFLV000001', 'SYSFPR010', 0, 110.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000010', 'SYSFLV000001', 'SYSFPR011', 0, 69.51, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000011', 'SYSFLV000001', 'SYSFPR012', 0, 133.01, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000012', 'SYSFLV000001', 'SYSFPR018', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000013', 'SYSFLV000001', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000014', 'SYSFLV000001', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000015', 'SYSFLV000001', 'SYSFPR022', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000016', 'SYSFLV000001', 'SYSFPR023', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000017', 'SYSFLV000001', 'SYSFPR026', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--GRADE SCHOOL (CG01)
--KINDER 1 (SYSFLV000002)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000018', 'SYSFLV000002', 'SYSFPR001', 0, 16472.98, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000019', 'SYSFLV000002', 'SYSFPR003', 0, 443.96, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000020', 'SYSFLV000002', 'SYSFPR004', 0, 232.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000021', 'SYSFLV000002', 'SYSFPR005', 0, 585.27, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000022', 'SYSFLV000002', 'SYSFPR006', 0, 133.01, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000023', 'SYSFLV000002', 'SYSFPR007', 0, 221.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000024', 'SYSFLV000002', 'SYSFPR008', 0, 554.20, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000025', 'SYSFLV000002', 'SYSFPR009', 0, 341.40, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000026', 'SYSFLV000002', 'SYSFPR010', 0, 110.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000027', 'SYSFLV000002', 'SYSFPR011', 0, 69.51, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000028', 'SYSFLV000002', 'SYSFPR012', 0, 133.01, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000029', 'SYSFLV000002', 'SYSFPR018', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000030', 'SYSFLV000002', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000031', 'SYSFLV000002', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000032', 'SYSFLV000002', 'SYSFPR022', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000033', 'SYSFLV000002', 'SYSFPR023', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000034', 'SYSFLV000002', 'SYSFPR026', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--GRADE SCHOOL (CG01)
--KINDER 2 (SYSFLV000003)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000035', 'SYSFLV000003', 'SYSFPR001', 0, 16472.98, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000036', 'SYSFLV000003', 'SYSFPR003', 0, 443.96, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000037', 'SYSFLV000003', 'SYSFPR004', 0, 232.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000038', 'SYSFLV000003', 'SYSFPR005', 0, 585.27, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000039', 'SYSFLV000003', 'SYSFPR006', 0, 133.01, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000040', 'SYSFLV000003', 'SYSFPR007', 0, 221.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000041', 'SYSFLV000003', 'SYSFPR008', 0, 554.20, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000042', 'SYSFLV000003', 'SYSFPR009', 0, 341.40, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000043', 'SYSFLV000003', 'SYSFPR010', 0, 110.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000044', 'SYSFLV000003', 'SYSFPR011', 0, 69.51, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000045', 'SYSFLV000003', 'SYSFPR012', 0, 133.01, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000046', 'SYSFLV000003', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000047', 'SYSFLV000003', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000048', 'SYSFLV000003', 'SYSFPR022', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000049', 'SYSFLV000003', 'SYSFPR023', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000050', 'SYSFLV000003', 'SYSFPR026', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000051', 'SYSFLV000003', 'SYSFPR030', 0, 1000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000052', 'SYSFLV000003', 'SYSFPR031', 0, 2000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000053', 'SYSFLV000003', 'SYSFPR032', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--GRADE SCHOOL (CG01)
--GRADE 1 (SYSFLV000004)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000054', 'SYSFLV000004', 'SYSFPR001', 0, 17364.96, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000055', 'SYSFLV000004', 'SYSFPR003', 0, 399.04, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000056', 'SYSFLV000004', 'SYSFPR004', 0, 232.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000057', 'SYSFLV000004', 'SYSFPR005', 0, 538.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000058', 'SYSFLV000004', 'SYSFPR006', 0, 155.19, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000059', 'SYSFLV000004', 'SYSFPR007', 0, 221.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000060', 'SYSFLV000004', 'SYSFPR008', 0, 443.37, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000061', 'SYSFLV000004', 'SYSFPR009', 0, 317.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000062', 'SYSFLV000004', 'SYSFPR010', 0, 110.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000063', 'SYSFLV000004', 'SYSFPR011', 0, 120.92, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000064', 'SYSFLV000004', 'SYSFPR012', 0, 133.01, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000065', 'SYSFLV000004', 'SYSFPR013', 0, 40.33, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000066', 'SYSFLV000004', 'SYSFPR014', 0, 46.35, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000067', 'SYSFLV000004', 'SYSFPR018', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000068', 'SYSFLV000004', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000069', 'SYSFLV000004', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000070', 'SYSFLV000004', 'SYSFPR022', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000071', 'SYSFLV000004', 'SYSFPR023', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000072', 'SYSFLV000004', 'SYSFPR025', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000073', 'SYSFLV000004', 'SYSFPR026', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000074', 'SYSFLV000004', 'SYSFPR027', 0, 750.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000075', 'SYSFLV000004', 'SYSFPR029', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--GRADE SCHOOL (CG01)
--GRADE 2 (SYSFLV000005)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000076', 'SYSFLV000005', 'SYSFPR001', 0, 15786.33, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000077', 'SYSFLV000005', 'SYSFPR003', 0, 362.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000078', 'SYSFLV000005', 'SYSFPR004', 0, 211.60, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000079', 'SYSFLV000005', 'SYSFPR005', 0, 489.71, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000080', 'SYSFLV000005', 'SYSFPR006', 0, 141.08, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000081', 'SYSFLV000005', 'SYSFPR007', 0, 201.53, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000082', 'SYSFLV000005', 'SYSFPR008', 0, 403.06, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000083', 'SYSFLV000005', 'SYSFPR009', 0, 288.18, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000084', 'SYSFLV000005', 'SYSFPR010', 0, 110.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000085', 'SYSFLV000005', 'SYSFPR011', 0, 109.93, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000086', 'SYSFLV000005', 'SYSFPR012', 0, 120.92, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000087', 'SYSFLV000005', 'SYSFPR013', 0, 36.66, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000088', 'SYSFLV000005', 'SYSFPR014', 0, 42.14, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000089', 'SYSFLV000005', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000090', 'SYSFLV000005', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000091', 'SYSFLV000005', 'SYSFPR022', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000092', 'SYSFLV000005', 'SYSFPR023', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000093', 'SYSFLV000005', 'SYSFPR025', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000094', 'SYSFLV000005', 'SYSFPR026', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000095', 'SYSFLV000005', 'SYSFPR027', 0, 750.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000096', 'SYSFLV000005', 'SYSFPR029', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--GRADE SCHOOL (CG01)
--GRADE 3 (SYSFLV000006)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000097', 'SYSFLV000006', 'SYSFPR001', 0, 14753.58, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000098', 'SYSFLV000006', 'SYSFPR003', 0, 339.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000099', 'SYSFLV000006', 'SYSFPR004', 0, 197.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000100', 'SYSFLV000006', 'SYSFPR005', 0, 457.67, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000101', 'SYSFLV000006', 'SYSFPR006', 0, 131.85, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000102', 'SYSFLV000006', 'SYSFPR007', 0, 188.35, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000103', 'SYSFLV000006', 'SYSFPR008', 0, 376.69, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000104', 'SYSFLV000006', 'SYSFPR009', 0, 269.33, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000105', 'SYSFLV000006', 'SYSFPR010', 0, 110.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000106', 'SYSFLV000006', 'SYSFPR011', 0, 102.74, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000107', 'SYSFLV000006', 'SYSFPR012', 0, 113.01, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000108', 'SYSFLV000006', 'SYSFPR013', 0, 34.26, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000109', 'SYSFLV000006', 'SYSFPR014', 0, 39.38, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000110', 'SYSFLV000006', 'SYSFPR015', 0, 2149.86, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000111', 'SYSFLV000006', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000112', 'SYSFLV000006', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000113', 'SYSFLV000006', 'SYSFPR022', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000114', 'SYSFLV000006', 'SYSFPR023', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000115', 'SYSFLV000006', 'SYSFPR025', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000116', 'SYSFLV000006', 'SYSFPR026', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000117', 'SYSFLV000006', 'SYSFPR027', 0, 750.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000118', 'SYSFLV000006', 'SYSFPR028', 0, 1000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000119', 'SYSFLV000006', 'SYSFPR029', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--GRADE SCHOOL (CG01)
--GRADE 4 (SYSFLV000007)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000120', 'SYSFLV000007', 'SYSFPR001', 0, 13788.39, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000121', 'SYSFLV000007', 'SYSFPR003', 0, 316.85, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000122', 'SYSFLV000007', 'SYSFPR004', 0, 184.82, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000123', 'SYSFLV000007', 'SYSFPR005', 0, 427.73, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000124', 'SYSFLV000007', 'SYSFPR006', 0, 123.22, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000125', 'SYSFLV000007', 'SYSFPR007', 0, 176.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000126', 'SYSFLV000007', 'SYSFPR008', 0, 352.05, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000127', 'SYSFLV000007', 'SYSFPR009', 0, 251.71, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000128', 'SYSFLV000007', 'SYSFPR010', 0, 110.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000129', 'SYSFLV000007', 'SYSFPR011', 0, 96.02, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000130', 'SYSFLV000007', 'SYSFPR012', 0, 105.62, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000131', 'SYSFLV000007', 'SYSFPR013', 0, 32.02, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000132', 'SYSFLV000007', 'SYSFPR014', 0, 36.80, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000133', 'SYSFLV000007', 'SYSFPR015', 0, 2149.86, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000134', 'SYSFLV000007', 'SYSFPR016', 0, 581.90, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000135', 'SYSFLV000007', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000136', 'SYSFLV000007', 'SYSFPR020', 0, 600.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000137', 'SYSFLV000007', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000138', 'SYSFLV000007', 'SYSFPR022', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000139', 'SYSFLV000007', 'SYSFPR024', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000140', 'SYSFLV000007', 'SYSFPR025', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000141', 'SYSFLV000007', 'SYSFPR026', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000142', 'SYSFLV000007', 'SYSFPR027', 0, 1000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000143', 'SYSFLV000007', 'SYSFPR029', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--GRADE SCHOOL (CG01)
--GRADE 5 (SYSFLV000008)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000144', 'SYSFLV000008', 'SYSFPR001', 0, 12534.90, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000145', 'SYSFLV000008', 'SYSFPR003', 0, 316.85, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000146', 'SYSFLV000008', 'SYSFPR004', 0, 184.82, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000147', 'SYSFLV000008', 'SYSFPR005', 0, 427.73, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000148', 'SYSFLV000008', 'SYSFPR006', 0, 123.22, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000149', 'SYSFLV000008', 'SYSFPR007', 0, 176.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000150', 'SYSFLV000008', 'SYSFPR008', 0, 352.05, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000151', 'SYSFLV000008', 'SYSFPR009', 0, 251.71, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000152', 'SYSFLV000008', 'SYSFPR010', 0, 110.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000153', 'SYSFLV000008', 'SYSFPR011', 0, 96.02, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000154', 'SYSFLV000008', 'SYSFPR012', 0, 105.62, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000155', 'SYSFLV000008', 'SYSFPR013', 0, 32.02, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000156', 'SYSFLV000008', 'SYSFPR014', 0, 36.80, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000157', 'SYSFLV000008', 'SYSFPR015', 0, 2149.86, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000158', 'SYSFLV000008', 'SYSFPR016', 0, 581.90, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000159', 'SYSFLV000008', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000160', 'SYSFLV000008', 'SYSFPR020', 0, 600.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000161', 'SYSFLV000008', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000162', 'SYSFLV000008', 'SYSFPR022', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000163', 'SYSFLV000008', 'SYSFPR024', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000164', 'SYSFLV000008', 'SYSFPR025', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000165', 'SYSFLV000008', 'SYSFPR026', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000166', 'SYSFLV000008', 'SYSFPR027', 0, 1000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000167', 'SYSFLV000008', 'SYSFPR029', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--GRADE SCHOOL (CG01)
--GRADE 6 (SYSFLV000009)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000168', 'SYSFLV000009', 'SYSFPR001', 0, 12534.90, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000169', 'SYSFLV000009', 'SYSFPR003', 0, 316.85, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000170', 'SYSFLV000009', 'SYSFPR004', 0, 184.82, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000171', 'SYSFLV000009', 'SYSFPR005', 0, 427.73, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000172', 'SYSFLV000009', 'SYSFPR006', 0, 123.22, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000173', 'SYSFLV000009', 'SYSFPR007', 0, 176.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000174', 'SYSFLV000009', 'SYSFPR008', 0, 352.05, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000175', 'SYSFLV000009', 'SYSFPR009', 0, 251.71, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000176', 'SYSFLV000009', 'SYSFPR010', 0, 110.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000177', 'SYSFLV000009', 'SYSFPR011', 0, 96.02, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000178', 'SYSFLV000009', 'SYSFPR012', 0, 105.62, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000179', 'SYSFLV000009', 'SYSFPR013', 0, 32.02, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000180', 'SYSFLV000009', 'SYSFPR014', 0, 36.80, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000181', 'SYSFLV000009', 'SYSFPR015', 0, 2149.86, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000182', 'SYSFLV000009', 'SYSFPR016', 0, 581.90, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000183', 'SYSFLV000009', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000184', 'SYSFLV000009', 'SYSFPR020', 0, 1750.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000185', 'SYSFLV000009', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000186', 'SYSFLV000009', 'SYSFPR022', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000187', 'SYSFLV000009', 'SYSFPR024', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000188', 'SYSFLV000009', 'SYSFPR025', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000189', 'SYSFLV000009', 'SYSFPR026', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000190', 'SYSFLV000009', 'SYSFPR027', 0, 1000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000191', 'SYSFLV000009', 'SYSFPR029', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000192', 'SYSFLV000009', 'SYSFPR030', 0, 1000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000193', 'SYSFLV000009', 'SYSFPR031', 0, 2000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000194', 'SYSFLV000009', 'SYSFPR032', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000195', 'SYSFLV000009', 'SYSFPR033', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--HIGH SCHOOL (CG02)
--1ST YEAR (SYSFLV000010)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000196', 'SYSFLV000010', 'SYSFPR001', 0, 17364.96, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000197', 'SYSFLV000010', 'SYSFPR003', 0, 399.04, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000198', 'SYSFLV000010', 'SYSFPR004', 0, 243.86, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000199', 'SYSFLV000010', 'SYSFPR012', 0, 155.19, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000200', 'SYSFLV000010', 'SYSFPR005', 0, 431.08, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000201', 'SYSFLV000010', 'SYSFPR007', 0, 221.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000202', 'SYSFLV000010', 'SYSFPR013', 0, 115.87, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000203', 'SYSFLV000010', 'SYSFPR009', 0, 365.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000204', 'SYSFLV000010', 'SYSFPR011', 0, 92.70, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000205', 'SYSFLV000010', 'SYSFPR006', 0, 177.35, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000206', 'SYSFLV000010', 'SYSFPR015', 0, 2828.92, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000207', 'SYSFLV000010', 'SYSFPR008', 0, 332.53, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000208', 'SYSFLV000010', 'SYSFPR014', 0, 310.35, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000209', 'SYSFLV000010', 'SYSFPR016', 0, 666.21, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000210', 'SYSFLV000010', 'SYSFPR018', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000211', 'SYSFLV000010', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000212', 'SYSFLV000010', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000213', 'SYSFLV000010', 'SYSFPR020', 0, 600.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000214', 'SYSFLV000010', 'SYSFPR022', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000215', 'SYSFLV000010', 'SYSFPR023', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000216', 'SYSFLV000010', 'SYSFPR024', 0, 400.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000217', 'SYSFLV000010', 'SYSFPR026', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000218', 'SYSFLV000010', 'SYSFPR027', 0, 750.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000219', 'SYSFLV000010', 'SYSFPR034', 0, 75.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000220', 'SYSFLV000010', 'SYSFPR035', 0, 100.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--HIGH SCHOOL (CG02)
--2ND YEAR (SYSFLV000011)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000221', 'SYSFLV000011', 'SYSFPR001', 0, 15786.33, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000222', 'SYSFLV000011', 'SYSFPR003', 0, 362.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000223', 'SYSFLV000011', 'SYSFPR004', 0, 221.69, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000224', 'SYSFLV000011', 'SYSFPR012', 0, 141.08, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000225', 'SYSFLV000011', 'SYSFPR005', 0, 391.89, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000226', 'SYSFLV000011', 'SYSFPR007', 0, 201.53, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000227', 'SYSFLV000011', 'SYSFPR013', 0, 105.34, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000228', 'SYSFLV000011', 'SYSFPR009', 0, 332.51, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000229', 'SYSFLV000011', 'SYSFPR011', 0, 84.27, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000230', 'SYSFLV000011', 'SYSFPR006', 0, 161.23, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000231', 'SYSFLV000011', 'SYSFPR015', 0, 2828.92, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000232', 'SYSFLV000011', 'SYSFPR008', 0, 302.30, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000233', 'SYSFLV000011', 'SYSFPR014', 0, 282.14, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000234', 'SYSFLV000011', 'SYSFPR016', 0, 666.21, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000235', 'SYSFLV000011', 'SYSFPR018', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000236', 'SYSFLV000011', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000237', 'SYSFLV000011', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000238', 'SYSFLV000011', 'SYSFPR020', 0, 600.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000239', 'SYSFLV000011', 'SYSFPR022', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000240', 'SYSFLV000011', 'SYSFPR023', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000241', 'SYSFLV000011', 'SYSFPR024', 0, 400.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000242', 'SYSFLV000011', 'SYSFPR026', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000243', 'SYSFLV000011', 'SYSFPR027', 0, 750.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000244', 'SYSFLV000011', 'SYSFPR034', 0, 75.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000245', 'SYSFLV000011', 'SYSFPR035', 0, 100.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--HIGH SCHOOL (CG02)
--3RD YEAR (SYSFLV000012)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000246', 'SYSFLV000012', 'SYSFPR001', 0, 14753.58, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000247', 'SYSFLV000012', 'SYSFPR003', 0, 339.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000248', 'SYSFLV000012', 'SYSFPR004', 0, 207.19, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000249', 'SYSFLV000012', 'SYSFPR012', 0, 131.85, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000250', 'SYSFLV000012', 'SYSFPR005', 0, 366.25, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000251', 'SYSFLV000012', 'SYSFPR007', 0, 188.35, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000252', 'SYSFLV000012', 'SYSFPR013', 0, 98.45, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000253', 'SYSFLV000012', 'SYSFPR009', 0, 310.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000254', 'SYSFLV000012', 'SYSFPR011', 0, 78.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000255', 'SYSFLV000012', 'SYSFPR006', 0, 150.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000256', 'SYSFLV000012', 'SYSFPR015', 0, 2828.92, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000257', 'SYSFLV000012', 'SYSFPR008', 0, 282.52, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000258', 'SYSFLV000012', 'SYSFPR014', 0, 263.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000259', 'SYSFLV000012', 'SYSFPR016', 0, 622.63, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000260', 'SYSFLV000012', 'SYSFPR018', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000261', 'SYSFLV000012', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000262', 'SYSFLV000012', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000263', 'SYSFLV000012', 'SYSFPR020', 0, 600.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000264', 'SYSFLV000012', 'SYSFPR022', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000265', 'SYSFLV000012', 'SYSFPR023', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000266', 'SYSFLV000012', 'SYSFPR024', 0, 400.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000267', 'SYSFLV000012', 'SYSFPR026', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000268', 'SYSFLV000012', 'SYSFPR027', 0, 750.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000269', 'SYSFLV000012', 'SYSFPR034', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000270', 'SYSFLV000012', 'SYSFPR035', 0, 100.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--HIGH SCHOOL (CG02)
--4TH YEAR (SYSFLV000013)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000271', 'SYSFLV000013', 'SYSFPR001', 0, 13788.39, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000272', 'SYSFLV000013', 'SYSFPR003', 0, 316.85, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000273', 'SYSFLV000013', 'SYSFPR004', 0, 193.64, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000274', 'SYSFLV000013', 'SYSFPR012', 0, 123.22, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000275', 'SYSFLV000013', 'SYSFPR005', 0, 342.29, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000276', 'SYSFLV000013', 'SYSFPR007', 0, 176.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000277', 'SYSFLV000013', 'SYSFPR013', 0, 92.01, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000278', 'SYSFLV000013', 'SYSFPR009', 0, 308.04, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000279', 'SYSFLV000013', 'SYSFPR011', 0, 73.61, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000280', 'SYSFLV000013', 'SYSFPR006', 0, 140.82, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000281', 'SYSFLV000013', 'SYSFPR015', 0, 3478.75, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000282', 'SYSFLV000013', 'SYSFPR008', 0, 264.04, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000283', 'SYSFLV000013', 'SYSFPR014', 0, 246.43, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000284', 'SYSFLV000013', 'SYSFPR016', 0, 581.90, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000285', 'SYSFLV000013', 'SYSFPR018', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000286', 'SYSFLV000013', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000287', 'SYSFLV000013', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000288', 'SYSFLV000013', 'SYSFPR020', 0, 1750.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000289', 'SYSFLV000013', 'SYSFPR022', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000290', 'SYSFLV000013', 'SYSFPR023', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000291', 'SYSFLV000013', 'SYSFPR024', 0, 400.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000292', 'SYSFLV000013', 'SYSFPR026', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000293', 'SYSFLV000013', 'SYSFPR027', 0, 750.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000294', 'SYSFLV000013', 'SYSFPR034', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000295', 'SYSFLV000013', 'SYSFPR035', 0, 100.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000296', 'SYSFLV000013', 'SYSFPR030', 0, 1000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000297', 'SYSFLV000013', 'SYSFPR031', 0, 2000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000298', 'SYSFLV000013', 'SYSFPR032', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000299', 'SYSFLV000013', 'SYSFPR033', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--COLLEGE (CG03)
--1ST YEAR (SYSFLV000014)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000300', 'SYSFLV000014', 'SYSFPR002', 0, 435.27, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000301', 'SYSFLV000014', 'SYSFPR003', 0, 443.37, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000302', 'SYSFLV000014', 'SYSFPR004', 0, 243.86, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000303', 'SYSFLV000014', 'SYSFPR012', 0, 144.08, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000304', 'SYSFLV000014', 'SYSFPR005', 0, 642.86, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000305', 'SYSFLV000014', 'SYSFPR007', 0, 221.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000306', 'SYSFLV000014', 'SYSFPR013', 0, 125.29, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000307', 'SYSFLV000014', 'SYSFPR009', 0, 332.53, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000308', 'SYSFLV000014', 'SYSFPR011', 0, 92.70, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000309', 'SYSFLV000014', 'SYSFPR006', 0, 177.35, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000310', 'SYSFLV000014', 'SYSFPR008', 0, 354.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000311', 'SYSFLV000014', 'SYSFPR018', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000312', 'SYSFLV000014', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000313', 'SYSFLV000014', 'SYSFPR020', 0, 600.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000314', 'SYSFLV000014', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000315', 'SYSFLV000014', 'SYSFPR036', 0, 350.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000316', 'SYSFLV000014', 'SYSFPR022', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000317', 'SYSFLV000014', 'SYSFPR023', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000318', 'SYSFLV000014', 'SYSFPR024', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000319', 'SYSFLV000014', 'SYSFPR037', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000320', 'SYSFLV000014', 'SYSFPR026', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000321', 'SYSFLV000014', 'SYSFPR038', 0, 842.40, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000322', 'SYSFLV000014', 'SYSFPR039', 0, 1058.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000323', 'SYSFLV000014', 'SYSFPR040', 0, 1763.40, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000324', 'SYSFLV000014', 'SYSFPR041', 0, 3174.11, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000325', 'SYSFLV000014', 'SYSFPR042', 0, 1587.06, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000326', 'SYSFLV000014', 'SYSFPR043', 0, 443.37, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000327', 'SYSFLV000014', 'SYSFPR044', 0, 806.13, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000328', 'SYSFLV000014', 'SYSFPR045', 0, 332.52, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000329', 'SYSFLV000014', 'SYSFPR046', 0, 1500.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000330', 'SYSFLV000014', 'SYSFPR047', 0, 1200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--COLLEGE (CG03)
--2ND YEAR (SYSFLV000015)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000331', 'SYSFLV000015', 'SYSFPR002', 0, 395.70, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000332', 'SYSFLV000015', 'SYSFPR003', 0, 403.06, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000333', 'SYSFLV000015', 'SYSFPR004', 0, 221.69, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000334', 'SYSFLV000015', 'SYSFPR012', 0, 130.98, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000335', 'SYSFLV000015', 'SYSFPR005', 0, 584.42, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000336', 'SYSFLV000015', 'SYSFPR007', 0, 201.53, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000337', 'SYSFLV000015', 'SYSFPR013', 0, 113.90, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000338', 'SYSFLV000015', 'SYSFPR009', 0, 302.30, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000339', 'SYSFLV000015', 'SYSFPR011', 0, 84.27, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000340', 'SYSFLV000015', 'SYSFPR006', 0, 161.23, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000341', 'SYSFLV000015', 'SYSFPR008', 0, 322.44, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000342', 'SYSFLV000015', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000343', 'SYSFLV000015', 'SYSFPR020', 0, 600.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000344', 'SYSFLV000015', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000345', 'SYSFLV000015', 'SYSFPR036', 0, 350.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000346', 'SYSFLV000015', 'SYSFPR022', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000347', 'SYSFLV000015', 'SYSFPR023', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000348', 'SYSFLV000015', 'SYSFPR024', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000349', 'SYSFLV000015', 'SYSFPR037', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000350', 'SYSFLV000015', 'SYSFPR026', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000351', 'SYSFLV000015', 'SYSFPR038', 0, 765.82, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000352', 'SYSFLV000015', 'SYSFPR039', 0, 1058.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000353', 'SYSFLV000015', 'SYSFPR040', 0, 1763.40, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000354', 'SYSFLV000015', 'SYSFPR041', 0, 3174.11, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000355', 'SYSFLV000015', 'SYSFPR042', 0, 1587.06, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000356', 'SYSFLV000015', 'SYSFPR043', 0, 403.06, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000357', 'SYSFLV000015', 'SYSFPR044', 0, 806.13, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000358', 'SYSFLV000015', 'SYSFPR045', 0, 302.29, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000359', 'SYSFLV000015', 'SYSFPR046', 0, 1500.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000360', 'SYSFLV000015', 'SYSFPR047', 0, 1200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--COLLEGE (CG03)
--3RD YEAR (SYSFLV000016)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000361', 'SYSFLV000016', 'SYSFPR002', 0, 369.81, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000362', 'SYSFLV000016', 'SYSFPR003', 0, 376.69, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000363', 'SYSFLV000016', 'SYSFPR004', 0, 207.19, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000364', 'SYSFLV000016', 'SYSFPR012', 0, 122.41, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000365', 'SYSFLV000016', 'SYSFPR005', 0, 546.19, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000366', 'SYSFLV000016', 'SYSFPR007', 0, 188.35, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000367', 'SYSFLV000016', 'SYSFPR013', 0, 106.45, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000368', 'SYSFLV000016', 'SYSFPR009', 0, 282.52, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000369', 'SYSFLV000016', 'SYSFPR011', 0, 78.76, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000370', 'SYSFLV000016', 'SYSFPR006', 0, 150.68, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000371', 'SYSFLV000016', 'SYSFPR008', 0, 301.35, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000372', 'SYSFLV000016', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000373', 'SYSFLV000016', 'SYSFPR020', 0, 600.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000374', 'SYSFLV000016', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000375', 'SYSFLV000016', 'SYSFPR036', 0, 350.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000376', 'SYSFLV000016', 'SYSFPR022', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000377', 'SYSFLV000016', 'SYSFPR023', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000378', 'SYSFLV000016', 'SYSFPR024', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000379', 'SYSFLV000016', 'SYSFPR037', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000380', 'SYSFLV000016', 'SYSFPR026', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000381', 'SYSFLV000016', 'SYSFPR038', 0, 715.72, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000382', 'SYSFLV000016', 'SYSFPR039', 0, 988.81, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000383', 'SYSFLV000016', 'SYSFPR040', 0, 1648.04, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000384', 'SYSFLV000016', 'SYSFPR041', 0, 2966.46, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000385', 'SYSFLV000016', 'SYSFPR042', 0, 1483.23, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000386', 'SYSFLV000016', 'SYSFPR043', 0, 376.69, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000387', 'SYSFLV000016', 'SYSFPR044', 0, 753.39, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000388', 'SYSFLV000016', 'SYSFPR045', 0, 282.51, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000389', 'SYSFLV000016', 'SYSFPR046', 0, 1500.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000390', 'SYSFLV000016', 'SYSFPR047', 0, 1200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--COLLEGE (CG03)
--4TH YEAR (SYSFLV000017)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000391', 'SYSFLV000017', 'SYSFPR002', 0, 345.62, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000392', 'SYSFLV000017', 'SYSFPR003', 0, 352.05, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000393', 'SYSFLV000017', 'SYSFPR004', 0, 193.64, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000394', 'SYSFLV000017','SYSFPR012',  0, 114.40, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000395', 'SYSFLV000017', 'SYSFPR005', 0, 510.46, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000396', 'SYSFLV000017', 'SYSFPR007', 0, 176.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000397', 'SYSFLV000017', 'SYSFPR013', 0, 99.49, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000398', 'SYSFLV000017', 'SYSFPR009', 0, 264.04, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000399', 'SYSFLV000017', 'SYSFPR011', 0, 73.61, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000400', 'SYSFLV000017', 'SYSFPR006', 0, 140.82, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000401', 'SYSFLV000017', 'SYSFPR008', 0, 281.64, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000402', 'SYSFLV000017', 'SYSFPR019', 0, 50.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000403', 'SYSFLV000017', 'SYSFPR020', 0, 1750.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000404', 'SYSFLV000017', 'SYSFPR021', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000405', 'SYSFLV000017', 'SYSFPR036', 0, 350.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000406', 'SYSFLV000017', 'SYSFPR022', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000407', 'SYSFLV000017', 'SYSFPR023', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000408', 'SYSFLV000017', 'SYSFPR024', 0, 300.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000409', 'SYSFLV000017', 'SYSFPR037', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000410', 'SYSFLV000017', 'SYSFPR026', 0, 200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000411', 'SYSFLV000017', 'SYSFPR030', 0, 1000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000412', 'SYSFLV000017', 'SYSFPR031', 0, 2000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000413', 'SYSFLV000017', 'SYSFPR032', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000414', 'SYSFLV000017', 'SYSFPR033', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000415', 'SYSFLV000017', 'SYSFPR038', 0, 688.90, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000416', 'SYSFLV000017', 'SYSFPR039', 0, 924.12, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000417', 'SYSFLV000017', 'SYSFPR040', 0, 1540.22, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000418', 'SYSFLV000017', 'SYSFPR041', 0, 2772.39, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000419', 'SYSFLV000017', 'SYSFPR042', 0, 1386.20, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000420', 'SYSFLV000017', 'SYSFPR043', 0, 352.06, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000421', 'SYSFLV000017', 'SYSFPR044', 0, 704.10, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000422', 'SYSFLV000017', 'SYSFPR045', 0, 264.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000423', 'SYSFLV000017', 'SYSFPR046', 0, 1500.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000424', 'SYSFLV000017', 'SYSFPR047', 0, 1200.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--Graduate School / Doctorate (CG04)
--Graduate School (SYSFLV000018)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000425', 'SYSFLV000018', 'SYSFPR002', 0, 526.45, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000426', 'SYSFLV000018', 'SYSFPR003', 0, 497.23, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000427', 'SYSFLV000018', 'SYSFPR005', 0, 683.69, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000428', 'SYSFLV000018', 'SYSFPR017', 0, 279.70, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

--SY 20082009
--Graduate School / Doctorate (CG04)
--Doctorate (SYSFLV000019)
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000429', 'SYSFLV000019', 'SYSFPR002', 0, 588.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000430', 'SYSFLV000019', 'SYSFPR003', 0, 497.23, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000431', 'SYSFLV000019', 'SYSFPR005', 0, 683.69, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE spu.InsertSchoolFeeDetails 'SYSFDL000000432', 'SYSFLV000019', 'SYSFPR017', 0, 279.70, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'