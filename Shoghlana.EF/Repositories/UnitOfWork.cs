using Microsoft.EntityFrameworkCore.Storage;
using Shoghlana.Core.Interfaces;
using System;

namespace Shoghlana.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDBContext context;

        private IDbContextTransaction transaction;

        public ICategoryRepository category { get; private set; }

        public IClientRepository client { get; private set; }

        public IFreelancerRepository freelancer { get; private set; }

        public IJobRepository job { get; private set; }

        public IJobSkillsRepository jobSkills { get; private set; }

        public IProjectImagesRepository projectImages { get; private set; }

        public IProjectRepository project { get; private set; }

        public IProjectSkillsRepository projectSkills { get; private set; }

        public IProposalRepository proposal { get; private set; }

        public IProposalImageRepository proposalImage { get; private set; }

        public IRateRepository rate { get; private set; }

        public ISkillRepository skill { get; private set; }

        public IClientNotificationRepository clientNotification { get; private set; }

        public IFreelancerNotificationRepository freelancerNotification { get; private set; }

        public IFreelancerSkillsRepository freelancerSkills { get; private set; }


        public UnitOfWork(ApplicationDBContext context, ICategoryRepository categoryRepository, IClientRepository clientRepository,
            IFreelancerRepository freelancerRepository, IJobRepository jobRepository, IProjectImagesRepository projectImagesRepository,
            IProjectRepository projectRepository, IProjectSkillsRepository projectSkillsRepository, IRateRepository rateRepository,
            ISkillRepository skillRepository, IProposalRepository proposalRepository, IJobSkillsRepository jobSkillsRepository,
            IClientNotificationRepository clientNotificationRepository, IFreelancerNotificationRepository freelancerNotificationRepository
            , IProposalImageRepository proposalImageRepository, IFreelancerSkillsRepository freelancerSkillsRepository)
        {
            this.context = context;

            category = categoryRepository;
            client = clientRepository;
            freelancer = freelancerRepository;

            job = jobRepository;
            jobSkills = jobSkillsRepository;

            project = projectRepository;
            projectImages = projectImagesRepository;
            projectSkills = projectSkillsRepository;

            proposal = proposalRepository;
            proposalImage = proposalImageRepository;

            rate = rateRepository;

            skill = skillRepository;
            freelancerSkills = freelancerSkillsRepository;

            clientNotification = clientNotificationRepository;
            freelancerNotification = freelancerNotificationRepository;
        }


        // returns num of affected entities in db

        public int Save()
        {
            return context.SaveChanges();
        }


        // as destructor >> called automatic when this request connection ends "if registered using addscoped"
        // >> release unmanaged resources like connection with db "like garbage collector but for unmanaged resources"
        public void Dispose()
        {
            context.Dispose();
        }


        public void BeginTransaction()
        {
            if (transaction == null)
            {
                transaction = context.Database.BeginTransaction();
            }
        }

        public void Commit()
        {
            try
            {
                context.SaveChanges();
                transaction?.Commit();
            }
            catch
            {
                Rollback();
                throw; // Re-throw exception to propagate it
            }
        }

        public void Rollback()
        {
            transaction?.Rollback();
            transaction = null;
        }
    }
}
