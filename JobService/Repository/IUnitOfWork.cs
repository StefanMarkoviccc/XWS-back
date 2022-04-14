﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Repository
{
    interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
