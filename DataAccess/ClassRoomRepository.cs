using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IClassRoomRepository
    {
        (string Message, bool IsSuccess) Insert(ClassRoom model);
        (string Message, bool IsSuccess) Update(ClassRoom model);
        (string Message, bool IsSuccess) Delete(int Id);
        List<ClassRoom> GetAll();
        ClassRoom GetById(int id);
    }
    public class ClassRoomRepository: IClassRoomRepository
    {
        private readonly AppDbContext _appDbContext;
        public ClassRoomRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<ClassRoom> GetAll()
        {
            var data = _appDbContext.ClassRooms.Include(x=>x.School).ToList();
            return data;
        }

        public ClassRoom GetById(int id)
        {
            return _appDbContext.ClassRooms.FirstOrDefault(x => x.Id == id);
        }
        public (string Message, bool IsSuccess) Insert(ClassRoom model)
        {
            try
            {
                _appDbContext.ClassRooms.Add(model);
                var saveResult = _appDbContext.SaveChanges();
                if (saveResult > 0)
                    return ("Success done!", true);
            }
            catch (Exception ex)
            {

            }
            return ("Failed!", false);
        }

        public (string Message, bool IsSuccess) Update(ClassRoom model)
        {
            try
            {
                var old = _appDbContext.ClassRooms.FirstOrDefault(x => x.Id == model.Id);
                if (old != null)
                {
                    _appDbContext.ClassRooms.Update(model);
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("Success done!", true);
                }
                else
                {
                    return ("Entity Not Found!", false);
                }

            }
            catch (Exception ex)
            {

            }
            return ("Failed!", false);
        }

        public (string Message, bool IsSuccess) Delete(int Id)
        {
            try
            {
                var old = _appDbContext.ClassRooms.FirstOrDefault(x => x.Id == Id);
                if (old != null)
                {
                    _appDbContext.ClassRooms.Remove(old);
                    var saveResult = _appDbContext.SaveChanges();
                    if (saveResult > 0)
                        return ("Success done!", true);
                }
                else
                {
                    return ("Entity Not Found!", false);
                }

            }
            catch (Exception ex)
            {

            }
            return ("Failed!", false);
        }
    }
}
