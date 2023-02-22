create database EmployeePayrollADO;

-Creating UserTable

create table AdminTable 
(
	AdminId int primary key identity(1,1) not null,
	FullName varchar(200) not null,
	Email varchar(200) not null,
	Password varchar(100) not null,
	MobileNumner bigint 
)

select * from AdminTable;

--creating Stored Procedure for the Login

create procedure SPRegistration
	@FullName varchar(200),@Email varchar(200),@Password varchar(100),@MobileNumber bigint
as
	begin
		insert into AdminTable values(@FullName,@Email,@Password,@MobileNumber)
	end

--Creating stored procedure for the Login

create procedure SPLogin
	@Email varchar(50),
	@Password varchar(100)
as
	begin
		select Email, Password from AdminTable where Email=@Email and Password=@Password
	end


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

-- Creating Stored Procedure for the Delete Employee

create procedure SPDeleteEmployee @EmployeeId int
as
	begin
		delete from EmployeeTable where EmployeeId=@EmployeeId
	end


--Creating Store Procedure for the Update Employee

create procedure SPUpdateEmployee
( 
	@EmployeeId int,
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
		update EmployeeTable set 
				EmployeeName=@EmployeeName,
				ProfileImg=@ProfileImg,
				Gender=@Gender,
				Department=@Department,
				Salary=@Salary,
				StartDate=@StartDate,
				Notes=@Notes
				where EmployeeId=@EmployeeId
	end