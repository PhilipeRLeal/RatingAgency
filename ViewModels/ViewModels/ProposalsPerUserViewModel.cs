﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ViewModels
{
    public class ProposalsPerUserViewModel
    {
        public IEnumerable<Proposal> Proposals { get; set; }
    }
}
