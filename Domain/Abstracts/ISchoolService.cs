using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts
{
    public interface ISchoolService
    {
        (string Message, bool IsSuccess) Insert(SchoolModel model);
        (string Message, bool IsSuccess) Update(SchoolModel model);
        (string Message, bool IsSuccess) Delete(int Id);
        List<SchoolModel> GetAll();
        SchoolModel GetById(int id);
    }
}
