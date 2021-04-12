using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LabAPI.Models;
using LabAPI.Data;
using AutoMapper;
using LabAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpGet("{id}", Name="GetStudentById")]
        public ActionResult<StudentReadDto> GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);
            if(student== null){
                return NotFound();
            }
            return Ok(_mapper.Map<StudentReadDto>(student));
        }

        [HttpPost]
        public ActionResult<StudentReadDto> CreateStudent(StudentCreateDto studCreateDto)
        {
            var studentModel = _mapper.Map<Student>(studCreateDto);
            _repository.CreateStudent(studentModel);
            _repository.SaveChanges();

            var studentReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return CreatedAtRoute(nameof(GetStudentById),new {Id = studentReadDto.Id},studentReadDto);
        }


        [HttpPut("{id}")]
        public ActionResult<StudentReadDto> UpdateStudent(int id,StudentCreateDto studUpdateDto)
        {
            var studentModelRepo = _repository.GetStudentById(id);

            if(studentModelRepo == null){
                return NotFound();
            }
            _mapper.Map(studUpdateDto,studentModelRepo);

            _repository.UpdateStudent(studentModelRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PatchStudent(int id, JsonPatchDocument<StudentUpdateDto> studPatch)
        {
            var studentModelRepo = _repository.GetStudentById(id);
             if(studentModelRepo == null){
                return NotFound();
            }
            var studentToPatch = _mapper.Map<StudentUpdateDto>(studentModelRepo);
            studPatch.ApplyTo(studentToPatch,ModelState);

            if(!TryValidateModel(studentToPatch)){
                return ValidationProblem(ModelState);
            }
            _mapper.Map(studentToPatch,studentModelRepo);

            _repository.UpdateStudent(studentModelRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var studentModelRepo = _repository.GetStudentById(id);
            if(studentModelRepo == null){
                return NotFound();
            }

            _repository.DeleteStudent(studentModelRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}