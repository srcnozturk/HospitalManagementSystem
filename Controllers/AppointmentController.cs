using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Appointment> list = await _appointmentRepository.GetAll();

            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        //public async IActionResult GetPatients()
        //{

        //    return Json();
        //}
        //[HttpGet]
        //public async IActionResult GetDoctors()
        //{
        //    return Json();
        //}
        [HttpPost]
        public async Task<IActionResult> Create([Bind("appointment")] Appointment appointment)
        {

            if (ModelState.IsValid)
            {
                await _appointmentRepository.Create(appointment);
            }
            return View(appointment);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _appointmentRepository.Delete(id);
            return RedirectToAction("Index");
        }
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return View();
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(int did, [Bind("doctorFirstName,doctorLastName,doctorAddress,doctorPhone")] Doctor doctor)
        //{
        //    if (did != doctor.DoctorId)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        await _appointmentRepository.Update(did, doctor);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
}
