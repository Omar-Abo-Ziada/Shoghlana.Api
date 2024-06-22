using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Enums
{
    public enum ExperienceLevel
    { 
        Beginner = 0 , 

        Intermediate = 1 ,

        Professional = 2 ,
    }

    public enum JobStatus
    {
        Active = 0,

        Closed = 1,

        completed = 2,

        All = 3,
    }

    public enum ProposalStatus
    {
        Approved = 0,

        Waiting = 1 ,

        Rejected = 2,
    }

    public enum OrderWay
    {
        Ascending = 1,

        Descending = 2,
    }

    public enum UserRole
    {
        Freelancer = 0,

        Client = 1
    }
}