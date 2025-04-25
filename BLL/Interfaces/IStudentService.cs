using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetAsync(int id);
        Task AddAsync(StudentDto dto);
        Task UpdateAsync(StudentDto dto);
        Task DeleteAsync(int id);
    }

}
