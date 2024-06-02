use ShoghlanaDB

select * from Skills

select * from Freelancers

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


