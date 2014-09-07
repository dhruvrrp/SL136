Create PROCEDURE [dbo].[spUpdateStaffInfo]
	@staff_id varchar(20),
	@email varchar(64),
	@password varchar(64)

	as 
	begin

	update staff
	set
		email = @email,
		password = @password
	where
		staff_id = @staff_id
	end

Create PROCEDURE [dbo].[spGetStaffInfo]
	@staff_id varchar(20)

	as begin

	select * from staff
	where staff_id = @staff_id

	end

ALTER PROCEDURE [dbo].[spGetEnrolledClasses]
@student_id varchar(20)
as
begin

select c.*
from enrollment e, course_schedule s, course c
where
e.student_id = @student_id
and
e.schedule_id = s.schedule_id
and
c.course_id = s.course_id


end

Create PROCEDURE [dbo].[spScheduleQuartersFull]
as
begin
	select
		DISTINCT cs.quarter
	from
		course_schedule cs
end


Create PROCEDURE [dbo].[spScheduleYears]
as
begin

	select
		DISTINCT cs.year
	from
		course_schedule cs

end

Create PROCEDURE [dbo].[spScheduleQuarters]
	@year int
as
begin

	select
		DISTINCT cs.quarter
	from
		course_schedule cs
	where
		cs.year = @year;

end

CREATE PROCEDURE [dbo].[assign_ta_to_class]
	@taID int,
	@scheduleID int
as
begin
INSERT ta_assignment
(
ta_id,
schedule_id
)
SELECT 
@taID,
@scheduleID
end

CREATE PROCEDURE [dbo].[calculate_gpa]
	@studentID varchar(50)
as
begin
SELECT grade
FROM enrollment
WHERE student_id = @studentID
end

CREATE PROCEDURE [dbo].[delete_ta]
	@taID int
as
begin
DELETE from 
ta_assignment
where
ta_id = @taID

DELETE from
teaching_assistant 
where
ta_id = @taID
end

CREATE PROCEDURE [dbo].[insert_ta]
	@taID int,
	@firstname varchar(50),
	@lastname varchar(50)
as
begin
INSERT teaching_assistant
(
ta_id,
first_name,
last_name
)
SELECT 
@taID,
@firstname,
@lastname

end

CREATE PROCEDURE [dbo].[remove_ta_from_class]
	@taID int,
@scheduleID int
as
begin
DELETE from 
ta_assignment
where
ta_id = @taID
AND
Schedule_id = @scheduleID 
end

CREATE PROCEDURE [dbo].[spDeleteCourse]
	@course_id varchar(20)
as
begin

	delete from
		enrollment
	where exists (
		select * 
		from enrollment e, course_schedule cs
		where e.schedule_id = cs.schedule_id AND
		cs.course_id = @course_id);

	delete from 
		course_schedule
	where
		course_id = @course_id;

	delete from
		course
	where
		course_id = @course_id;
	
end

CREATE PROCEDURE [dbo].[spDeleteCourseSchedule]
	@course_id varchar(20)
as
begin

	delete from 
		course_schedule
	where
		course_id = @course_id
end

CREATE PROCEDURE [dbo].[spDeleteEnrollment]
	@course_id varchar(20)
as
begin

	delete from
		enrollment
	where exists (
		select * 
		from enrollment e, course_schedule cs
		where e.schedule_id = cs.schedule_id AND
		cs.course_id = @course_id
	)
	
end

CREATE PROCEDURE [dbo].[spInsertCourse]
	@course_id varchar(20),
	@course_title varchar(100),
	@course_level varchar(10),
	@course_description varchar(max)
as
begin

	insert course (
		course_id,
		course_title,
		course_level,
		course_description
	)
	select
		@course_id,
		@course_title,
		@course_level,
		@course_description
	
end

CREATE PROCEDURE [dbo].[spInsertCourseSchedule]
	@schedule_id varchar(20),
	@course_id int,
	@year int,
	@quarter varchar(50),
	@session varchar(50),
	@schedule_day_id int,
	@schedule_time_id int,
	@instructor_id int
as
begin

	insert course_schedule (
		schedule_id,
		course_id,
		year,
		quarter,
		session,
		schedule_day_id,
		schedule_time_id,
		instructor_id
	)
	select
		@schedule_id,
		@course_id,
		@year,
		@quarter,
		@session,
		@schedule_day_id,
		@schedule_time_id,
		@instructor_id
	
end

CREATE PROCEDURE [dbo].[spInsertStudentSchedule]
	@student_id varchar(25),
	@schedule_id int
as
begin

	insert enrollment
	(
		student_id,
		schedule_id
	)
	select
		@student_id,
		@schedule_id
end

CREATE PROCEDURE [dbo].[spUpdateCourse]
	@course_id varchar(20),
	@course_title varchar(100),
	@course_level varchar(10),
	@course_description varchar(max)
as
begin

	update 
		course 
	set 
		course_title = @course_title,
		course_level = @course_level,
		course_description= @course_description
	where
		course_id = @course_id
	
end

CREATE PROCEDURE [dbo].[spUpdateCourseSchedule]
	@schedule_id varchar(20),
	@course_id int,
	@year int,
	@quarter varchar(50),
	@session varchar(50),
	@schedule_day_id int,
	@schedule_time_id int,
	@instructor_id int
as
begin

	update 
		course_schedule 
	set 
		course_id = @course_id,
		year = @year,
		quarter = @quarter,
		session = @session,
		schedule_day_id = @schedule_day_id,
		schedule_time_id = @schedule_time_id,
		instructor_id = @instructor_id

	where
		schedule_id = @schedule_id
	
end

CREATE PROCEDURE [dbo].[update_ta]
	@taID int,
	@firstname varchar(50),
	@lastname varchar(50)
as
begin
UPDATE teaching_assistant
set
first_name = @firstname,
last_name = @lastname
where
ta_id = @taID

end

CREATE PROCEDURE [dbo].[view_all_tas]
as
begin
SELECT *
FROM teaching_assistant
end


CREATE PROCEDURE [dbo].[view_tas_for_class]
	@scheduleID int
as
begin
SELECT first_name, last_name, teaching_assistant.ta_id
from teaching_assistant, ta_assignment
where ta_assignment.schedule_id = @scheduleID
end


CREATE PROCEDURE spViewInstructor
@instructor_id int
as
begin
SELECT *
FROM instructor
WHERE instructor_id = @instructor_id
end

CREATE PROCEDURE spUpdateInstructor
@instructor_id int,
@first_name varchar(50),
@last_name varchar(50),
@title varchar(50)
as
begin
UPDATE instructor
SET first_name = @first_name,
last_name = @last_name,
title = @title
WHERE instructor_id = @instructor_id
end

CREATE PROCEDURE spInsertInstructor
@instructor_id int,
@first_name varchar(50),
@last_name varchar(50),
@title varchar(50)
as
begin
INSERT instructor
(
instructor_id,
first_name,
last_name,
title
)
SELECT
@instructor_id,
@first_name,
@last_name,
@title
end
