﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shoghlana.Core.Interfaces;
using Shoghlana.EF.Repository;
using System;

namespace Shoghlana.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public ApplicationDBContext context { get; }

        public IFreelancerRepository freelancerRepository { get; private set; }
        public IFreelancerSkillsRepository freelancerSkillsRepository { get; private set; }
        public IFreelancerNotificationRepository freelancerNotificationRepository { get; private set; }
        public IClientRepository clientRepository { get; private set; }
        public IClientNotificationRepository clientNotificationRepository { get; private set; }
        public ICategoryRepository categoryRepository { get; private set; }
        public IProjectRepository projectRepository { get; private set; }
        public IProjectImagesRepository projectImagesRepository { get; private set; }
        public IProjectSkillsRepository projectSkillsRepository { get; private set; }
        public IProposalRepository proposalRepository { get; private set; }
        public IProposalImageRepository proposalImageRepository { get; private set; }
        public ISkillRepository skillRepository { get; private set; }
        public IRateRepository rateRepository { get; private set; }
        public IDbContextTransaction transaction { get; private set; }
        public IJobRepository jobRepository { get; private set; }
        public IJobSkillsRepository jobSkillsRepository { get; private set; }

        public UnitOfWork
        (ApplicationDBContext context, IFreelancerRepository freelancerRepository,
        IFreelancerSkillsRepository freelancerSkillsRepository, IFreelancerNotificationRepository freelancerNotificationRepository,
        IClientRepository clientRepository, IClientNotificationRepository clientNotificationRepository, ICategoryRepository categoryRepository,
        IProjectRepository projectRepository, IProjectImagesRepository projectImagesRepository, IJobRepository jobRepository,
        IProjectSkillsRepository projectSkillsRepository, IProposalRepository proposalRepository, IJobSkillsRepository jobSkillsRepository,
        IProposalImageRepository proposalImageRepository, ISkillRepository skillRepository, IRateRepository rateRepository)
        {
            this.context = context;
            this.freelancerRepository = freelancerRepository;
            this.freelancerSkillsRepository = freelancerSkillsRepository;
            this.freelancerNotificationRepository = freelancerNotificationRepository;
            this.clientRepository = clientRepository;
            this.clientNotificationRepository = clientNotificationRepository;
            this.categoryRepository = categoryRepository;
            this.projectRepository = projectRepository;
            this.projectImagesRepository = projectImagesRepository;
            this.jobRepository = jobRepository;
            this.projectSkillsRepository = projectSkillsRepository;
            this.proposalRepository = proposalRepository;
            this.jobSkillsRepository = jobSkillsRepository;
            this.proposalImageRepository = proposalImageRepository;
            this.skillRepository = skillRepository;
            this.rateRepository = rateRepository;
        }

        // returns num of affected entities in db
        public int Save()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
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