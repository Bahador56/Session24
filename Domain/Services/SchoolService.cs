using AutoMapper;
using DataAccess;
using DataAccess.Entity;
using Domain.Abstracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class SchoolService : ISchoolService
    {
        #region [ctor]
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        public SchoolService(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]
        public List<SchoolModel> GetAll() =>
         _mapper.Map<List<SchoolModel>>(_schoolRepository.GetAll());

        public SchoolModel GetById(int id) =>
            _mapper.Map<SchoolModel>(_schoolRepository.GetById(id));


        public (string Message, bool IsSuccess) Insert(SchoolModel model)
        {
            var entity = _mapper.Map<School>(model);
            entity.CreatedAt= DateTime.Now;
           return _schoolRepository.Insert(entity);
        }
            



        public (string Message, bool IsSuccess) Delete(int Id) =>
            _schoolRepository.Delete(Id);

        public (string Message, bool IsSuccess) Update(SchoolModel model)
        {
            if (model.Id <= 0)
                return ("Id Is Not Valid!", false);
            var result = _schoolRepository.Update(_mapper.Map<School>(model));
            return result;
        } 
        #endregion

    }
}
