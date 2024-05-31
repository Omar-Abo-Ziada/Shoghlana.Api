﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.DTO
{
    public class JobDTO
    {
        public string Title { get; set; }
        public DateTime PostTime { get; set; }
        public string Description { get; set; }
        public decimal MinBudget { get; set; }
        public decimal MaxBudget { get; set; }
    }
}