using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Patient> list = await _patientRepository.GetAll();

            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {

            if (ModelState.IsValid)
            {
                await _patientRepository.Create(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return View();
            }
            var result = await _patientRepository.GetById(id);
            return View(result);
        }
        
        public async Task<IActionResult> Delete(Patient patient)
        {
          
            if (ModelState.IsValid)
            {
                await _patientRepository.Delete(patient.PatientId);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return View();
            }
            var result = await _patientRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Patient patient)
        {
            if (patient.PatientId != null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _patientRepository.Update(patient.PatientId, patient);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}

