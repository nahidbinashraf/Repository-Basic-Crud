using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PersonalInformationModel
    {
        public int Id { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        public string BanglaName { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentModel Departments { get; set; }

    }
}
