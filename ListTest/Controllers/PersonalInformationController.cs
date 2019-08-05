using System;
using System.Web.Mvc;
using BusinessLayer.ListTestRepository;
using BusinessLayer.ListTestRepositoryImpl;
using ViewModel;

namespace ListTest.Controllers
{
    public class PersonalInformationController : Controller
    {
        IPersonalInformationRepo _personalInformationRepo = null;
        public PersonalInformationController()
        {
            _personalInformationRepo = new PersonalInformationRepoImpl();
        }
        // GET: PersonalInformation
        [HttpGet]
        public ActionResult Index()
        {
            var PersonalInformationData = _personalInformationRepo.GetPersonalInformation();
            
            return View(PersonalInformationData);
        }
        public ActionResult Details(int id)
        {
            if (id > 0)
            {
                var PersonalInforData = _personalInformationRepo.GetPersonalInformationById(id);
                return View(PersonalInforData);
            }
            ViewBag.DetailsError = "ID Cannot be 0 or Null";
            return View();
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PersonalInformationModel personalInformationModel)
        {
            if (ModelState.IsValid & personalInformationModel!=null)
            {
               
               bool insert =  _personalInformationRepo.SavePersonalInformation(personalInformationModel);
                if (insert)
                {
                    TempData["PersonalInformationSuccess"] = "Successfully Save";
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.PersonalInformationSuccess = "Not Save";
                    return View();
                }

            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var PersonalInforData = _personalInformationRepo.GetPersonalInformationById(id);
                return View(PersonalInforData);
            }
            ViewBag.EditError = "ID Cannot be 0 or Null";
            return View();

        }
        [HttpPost]
        public ActionResult Edit(PersonalInformationModel personalInformationModel)
        {

            if (ModelState.IsValid & personalInformationModel != null)
            {

                bool update = _personalInformationRepo.UpdatePersonalInformation(personalInformationModel);
                if (update)
                {
                    TempData["PersonalInformationUpdate"] = "Successfully Update";
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.PersonalInformationUpdate = "Not Save";
                    return View();
                }
                
            }
            return View();
        }
    }
}