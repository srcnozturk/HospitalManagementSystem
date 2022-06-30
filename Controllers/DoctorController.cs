using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Doctor> list = await _doctorRepository.GetAll();

            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {

            if (ModelState.IsValid)
            {
                await _doctorRepository.Create(doctor);
                return RedirectToAction("Index");

            }
            return View(doctor);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return View();
            }
            var result = await _doctorRepository.GetById(id);
            return View(result);
        }

        public async Task<IActionResult> Delete(Doctor doctor)
        {

            if (ModelState.IsValid)
            {
                await _doctorRepository.Delete(doctor.DoctorId);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return View();
            }
            var result = await _doctorRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor)
        {
            if (doctor.DoctorId != doctor.DoctorId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _doctorRepository.Update(doctor.DoctorId, doctor);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}