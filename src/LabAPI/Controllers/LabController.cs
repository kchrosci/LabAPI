using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LabAPI.Models;
using LabAPI.Data;
using AutoMapper;
using LabAPI.Dtos;

namespace LabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly ILabAPIRepo _repository;
        private readonly IMapper _mapper;
        public LabController(ILabAPIRepo repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>> GetAllStudents()
        {
            var students = _repository.GetAllStudents();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
        }
        [HttpGet("{id}")]
        public ActionResult<StudentReadDto> GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);
            if(student== null){
                return NotFound();
            }
            return Ok(_mapper.Map<StudentReadDto>(student));
        }
    }
}