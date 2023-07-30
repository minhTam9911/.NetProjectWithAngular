create database HealthInsuranceSystem
go

use HealthInsuranceSystem
go


create table Account(
id bigint identity primary key,
UserName varchar(500) not null,
[Password] varchar(500) not null,
email varchar(150) not null,
securityCode varchar(10) null,
[status] bit null,
[role] varchar(50) null
)
go

create table AdminLogin(
UserName varchar(50) primary key,
[Password] varchar(50) not null,
email varchar(150) not null,
securityCode varchar(10) null
)
go

create table CompanyDetails(
CompanyId int identity primary key,
CompanyName varchar(50) not null,
[Address] varchar(150) null,
Phone varchar(20) null,
CompanyURL varchar(50) null
)
go

create table Policies(
policyid int identity primary key,
policyname varchar(50)  null,
policydesc text null,
amount money null,
Emi money null,
companyid int,
medicalid bigint null
)
go 

create table HospitalInfo(
HospitalId int identity primary key,
HospitalName varchar(50)  null,
PhoneNo varchar(50) null,
[Location] varchar(50) null,
[Url] varchar(50) null
)
go

create table EmpRegister(
empno int identity primary key,
designation varchar(50) null default('customer'),
joindate datetime null,
salary money null,
firstname varchar(50) null,
lastname varchar(50) null,
username varchar(500) null,
[password] varchar(500) null,
[address] varchar(150) null,
contactno varchar(50) null,
[state] varchar(50) null,
country varchar(50) null,
city varchar(50) null,
rolename varchar(5) default('user'),
accountStatus bit default(null),
securityCode varchar(10),
email varchar(200),
)
go



create table PoliciesonEmployees(
id bigint identity primary key,
empno int not null,
policyid int not null,
policyname varchar(50) not null,
policystatus bit null,
policyamount money not null,
policyduration decimal(7,2) not null,
emi decimal(7,2)  not null,
companyid int not null,
companyname varchar(50) not null,
)
go


create table PolicyApprovalDetails(
PolicyId int  not null primary key,
RequestId int null,
[Date] datetime null,
Amount money null,
[Status] bit null,
Reason text null
)
go



create table PolicyRequestDetails(
RequestId int identity primary key,
RequestDate	 datetime null,
Empno int not null,
PolicyId int null,
Policyname varchar(50) null,
PolicyAmount money null,
Emi money null,
CompanyId int null,
CompanyName varchar(50) null,
[Status] varchar(50) null
)
go


create table PolicyTotalDescription(
id bigint identity primary key,
policyid int not null,
policyname varchar(50) null,
policydesc varchar(250) null,
policyamount money null,
EMI money null,
policydurationinMonths int null,
CompanyName varchar(50) not null,
medicalname varchar(50) null
)
go

ALTER TABLE Policies
ADD CONSTRAINT FK_CompanyDetails_Policies FOREIGN KEY (companyId)
REFERENCES CompanyDetails(CompanyId);

ALTER TABLE Policies
ADD CONSTRAINT FK_Hospital_Policies FOREIGN KEY (medicalid)
REFERENCES HospitalInfo(HospitalId);

ALTER TABLE Policiesonemployees
ADD CONSTRAINT FK_Policiesonemployees_Policies FOREIGN KEY (policyid)
REFERENCES Policies(policyid);

ALTER TABLE Policiesonemployees
ADD CONSTRAINT FK_Policiesonemployees_EmpRegister FOREIGN KEY (empno)
REFERENCES EmpRegister(empno);

ALTER TABLE PolicyApprovalDetails
ADD CONSTRAINT FK_PolicyRequestDetails_PolicyApprovalDetails FOREIGN KEY (RequestId)
REFERENCES PolicyRequestDetails(RequestId);

ALTER TABLE PolicyApprovalDetails
ADD CONSTRAINT FK_PolicyApprovalDetails_Policies FOREIGN KEY (PolicyId)
REFERENCES Policies (policyid);

ALTER TABLE PolicyRequestDetails
ADD CONSTRAINT FK_EmpRegister_PolicyRequestDetails FOREIGN KEY (Empno)
REFERENCES EmpRegister(empno);


ALTER TABLE PolicyTotalDescription
ADD CONSTRAINT FK_PolicyTotalDescription_Policies FOREIGN KEY (policyid)
REFERENCES Policies (policyid);

