﻿using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHistoriaProcedureService
    {
        Task<List<HistoriaDto>> GetPagedAsync(int page, int pageSize);
    }

}
