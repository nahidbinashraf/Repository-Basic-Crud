using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLayer.ListTestRepository
{
    public interface IPersonalInformationRepo
    {
        IEnumerable<PersonalInformationModel> GetPersonalInformation();
        PersonalInformationModel GetPersonalInformationById(int id);
        bool SavePersonalInformation(PersonalInformationModel personalInformationModel);
        bool UpdatePersonalInformation(PersonalInformationModel personalInformationModel);
        bool DeletePersonalInformation(int id);
    
    }
}
