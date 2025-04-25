using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStudentProcedureService
    {
        Task AddStudentAsync(string imie, string nazwisko, int grupaId);
    }

}
