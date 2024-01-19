﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetAPP.Core.Entities;

namespace TimesheetAPP.Core.Interfaces
{
    public interface IDbContext
    {
        public DbSet<Intervenant> Intervenants { get; set; }
        Task<int> SaveChangesAsync();
    }
}
