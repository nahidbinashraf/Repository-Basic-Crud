using BusinessLayer.ListTestRepository;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel;

namespace BusinessLayer.ListTestRepositoryImpl
{
    public class PersonalInformationRepoImpl : IPersonalInformationRepo
    {
        DataSet _dbContext = new DataSet();

        public IEnumerable<PersonalInformationModel> GetPersonalInformation()
        {

            var personalInformationList = _dbContext.PersonalInformations
            .Select(x => new PersonalInformationModel()
            {
                Id = x.Id,
                EnglishName = x.EnglishName,
                BanglaName = x.BanglaName,
                DepartmentId = x.DepartmentId,
                Departments = new DepartmentModel()
                {
                    DepartmentName = x.Departments.DepartmentName
                }

            })
            .ToList();
            return personalInformationList;

        }

        public PersonalInformationModel GetPersonalInformationById(int id)
        {
            var personalInformation = _dbContext.PersonalInformations
                .Where(x=>x.Id == id)
              .Select(x => new PersonalInformationModel()
              {
                  Id = x.Id,
                  EnglishName = x.EnglishName,
                  BanglaName = x.BanglaName,
                  DepartmentId = x.DepartmentId,
                  Departments = new DepartmentModel()
                  {
                      DepartmentName = x.Departments.DepartmentName
                  }

              }).FirstOrDefault();
              
            return personalInformation;

        }

        public bool SavePersonalInformation(PersonalInformationModel personalInformationModel)
        {
            try
            {
                PersonalInformation personalInformation = new PersonalInformation()
                {
                    EnglishName = personalInformationModel.EnglishName,
                    BanglaName = personalInformationModel.BanglaName,
                    //DepartmentId = personalInformationModel.Departments.Id,


                };
                if (personalInformationModel.Departments != null)
                {
                    personalInformation.Departments = new Department()
                    {
                        DepartmentName = personalInformationModel.Departments.DepartmentName
                    };
                }
                _dbContext.PersonalInformations.Add(personalInformation);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string val = ex.Message;
                return false;
            }
        }

        public bool UpdatePersonalInformation(PersonalInformationModel personalInformationModel)
        {
            try
            {
                var personalInformation = _dbContext.PersonalInformations.Find(personalInformationModel.Id);
                if (personalInformation != null)
                {
                    personalInformation.BanglaName = personalInformationModel.BanglaName;
                    personalInformation.EnglishName = personalInformationModel.EnglishName;
                    if(personalInformationModel.Departments!=null)
                    {
                        var department = _dbContext.Departments.Find(personalInformation.DepartmentId);
                        department.DepartmentName = personalInformationModel.Departments.DepartmentName;
                        //var department = _dbContext.Departments.Find(personalInformation.DepartmentId);
                        //personalInformation.Departments = new Department() {
                        //    Id = personalInformation.DepartmentId,
                        //    DepartmentName = personalInformationModel.Departments.DepartmentName
                        //};

                    }
                }
                _dbContext.Entry(personalInformation).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
