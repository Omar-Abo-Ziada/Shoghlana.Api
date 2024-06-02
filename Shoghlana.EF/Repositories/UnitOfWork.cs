using Shoghlana.Core.Interfaces;
using System;

namespace Shoghlana.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
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
        public IClientNotificationRepository clientNotification { get; private set; }
        public IFreelancerNotificationRepository freelancerNotification { get; private set; }

        public UnitOfWork(ApplicationDBContext _context)
        {
            context = _context;
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
            clientNotification = new ClientNotificationRepository(context);
            freelancerNotification = new FreelancerNotificationRepository(context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
