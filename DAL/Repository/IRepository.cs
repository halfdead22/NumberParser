﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public interface IRepository
    {
        bool CreateInputOutputResult(InputOutputResultModel inputOutputResultModel);
    }
}
