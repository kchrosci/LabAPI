using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LabAPI.Models;
using LabAPI.Data;

namespace LabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly IStudentAPIRepo _repository;
        public LabController(IStudentAPIRepo repository){
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var students = _repository.GetAllStudents();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);
            if(student== null){
                return NotFound();
            }
            return Ok(student);
        }
    }
}