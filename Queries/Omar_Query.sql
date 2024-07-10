use ShoghlanaDB

select * from Skills

select * from AspNetUsers

select * from AspNetUserRoles

select * from AspNetRoles

--delete  from AspNetUsers

select * from Freelancers

select * from Clients

select * from freelancerSkills

-- get freelancers who have skills
select F.Name , S.Title
from Freelancers F
inner join freelancerSkills FS on F.Id = FS.FreelancerId
inner join Skills S on FS.SkillId = S.Id

SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ClientNotification';

SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'FreelancerNotification';

select * from projects

select * from projectImages

select * from Proposals

select * from ProposalImages

select * from RefreshToken

select * from freelancers

SELECT * FROM __EFMigrationsHistory;

select * from ProjectImages

select * from Projects

select * from skills

select * from projects

select * from projectSkills

select * from AspNetRoles

select * from Jobs

--delete from RefreshToken
--go
--delete from AspNetUserRoles
--go
--delete from AspNetUsers


