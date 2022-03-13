using Models;
using System.Collections.Generic;

namespace Domain.Abstracts
{
    public interface IClassRoomService
    {
        (string Message, bool IsSuccess) Insert(ClassRoomModel model);
        (string Message, bool IsSuccess) Update(ClassRoomModel model);
        (string Message, bool IsSuccess) Delete(int Id);
        List<ClassRoomModel> GetAll();
        ClassRoomModel GetById(int id);
        ClassRoomModel GetNewModelForCreate();
    }
}
