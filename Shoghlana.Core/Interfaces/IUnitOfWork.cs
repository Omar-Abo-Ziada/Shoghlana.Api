using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFreelancerRepository freelancerRepository { get; }
        IFreelancerNotificationRepository freelancerNotificationRepository { get; }
        IFreelancerSkillsRepository freelancerSkillsRepository { get; }

        ICategoryRepository categoryRepository { get; }

        IClientRepository clientRepository { get; }
        IClientNotificationRepository clientNotificationRepository { get; }

        IJobRepository jobRepository { get; }
        IJobSkillsRepository jobSkillsRepository { get; }

        IProjectRepository projectRepository { get; }
        IProjectImagesRepository projectImagesRepository { get; }
        IProjectSkillsRepository projectSkillsRepository { get; }

        IProposalRepository proposalRepository { get; }
        IProposalImageRepository proposalImageRepository { get; }

        ISkillRepository skillRepository { get; }

        IRateRepository rateRepository { get; }

        //------------------------------------------------------

        public int Save();

        public  Task<int> SaveAsync();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}