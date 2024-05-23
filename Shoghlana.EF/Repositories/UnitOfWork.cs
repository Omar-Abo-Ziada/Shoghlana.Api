using Shoghlana.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {

        private readonly ApplicationDBContext context;
        public ICategoryRepository category { get; private set; }  
        public IClientRepository client { get; private set; } 
        public IFreelancerRepository freelancer { get; private set; } 
        public IJobRepository job { get; private set; } 
        public IJobSkillsRepository jobSkills { get; private set; }
        public IProjectImagesRepository projectImages { get; private set; } 
        public IProjectRepository project { get; private set; } 
        public IProjectSkillsRepository projectSkills { get; private set; } 
        public IProposalRepository proposal { get; private set; }
        public IRateRepository rate { get; private set; }
        public ISkillRepository skill { get; private set; }

        public UnitOfWork(ApplicationDBContext _context)
        {
            this.context = _context;
            category = new CategoryRepository(context);
            client = new ClientRepository(context);
            freelancer = new FreelancerRepository(context);
            job = new JobRepository(context);
            projectImages = new ProjectImagesRepository(context);
            project = new ProjectRepository(context);
            projectSkills = new ProjectSkillsRepository(context);
            rate = new RateRepository(context);
            skill = new SkillRepository(context);
            proposal = new ProposalRepository(context);
            jobSkills = new JobSkillsRepository(context);
        }

        public int save() 
        {
           return context.SaveChanges();        // num of affected entities in db
        }

        public void Dispose()  // as destructor >> called automatic when this request connection ends "if registered using addscoped" >> release unmanaged resources like connection with db "like garbage collector but for unmanaged resources"
        {
            context.Dispose();
        }
    }
}
