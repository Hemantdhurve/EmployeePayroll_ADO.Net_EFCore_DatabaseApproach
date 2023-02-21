create database EmployeePayrollADO;

--create Table of employee 

create table EmployeeTable
(
	EmployeeId int primary key identity(1,1) not null,
	EmployeeName varchar(200) not null,
	ProfileImg varchar(max),
	Gender varchar(50) not null,
	Department varchar(max),
	Salary bigint not null,
	StartDate datetime,
	Notes varchar(max)
);

select * from EmployeeTable

--Creating Stored Procedure for the AddEmployee

create procedure SPAddEmployee
(
	@EmployeeName varchar(200),
	@ProfileImg varchar(max),
	@Gender varchar(50),
	@Department varchar(max),
	@Salary bigint,
	@StartDate DateTime,
	@Notes varchar(max)
)
	as
		begin 
			insert into EmployeeTable values
			(
				@EmployeeName,
				@ProfileImg,
				@Gender,
				@Department,
				@Salary ,
				@StartDate,
				@Notes
			)
		end

--Creating Stored Proedure for the Retrive All Employees

create procedure SPRetriveALLEmployee
as
	begin
		select * from EmployeeTable
	end
