use ShoghlanaDB

select * from Skills

select * from Freelancers

select * from freelancerSkills

-- get freelancers who have skills
select F.Name , S.Title
from Freelancers F
inner join freelancerSkills FS on F.Id = FS.FreelancerId
inner join Skills S on FS.SkillId = S.Id
