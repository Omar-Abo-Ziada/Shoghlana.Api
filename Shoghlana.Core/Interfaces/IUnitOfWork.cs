﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository category { get; }

        IClientRepository client { get; }

        IFreelancerRepository freelancer { get; }

        IJobRepository job { get; }

        IJobSkillsRepository jobSkills { get; }

        IProjectImagesRepository projectImages { get; }

        IProjectRepository project { get; }

        IProjectSkillsRepository projectSkills { get; }

        IProposalRepository proposal { get; } 
        iProposalImageRepository proposalImage { get; }

        IRateRepository rate { get; }

        ISkillRepository skill { get; }

        public int Save();

        //public void Dispose();
    }
}