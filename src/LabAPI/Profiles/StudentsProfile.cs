using AutoMapper;
using LabAPI.Dtos;
using LabAPI.Models;

namespace LabAPI.Profiles{
    public class StudentProfile : Profile{
        public StudentProfile()
        {
            //source -> Target
            CreateMap<Student,StudentReadDto>();
            CreateMap<StudentCreateDto,Student>();
            CreateMap<StudentUpdateDto,Student>();
            CreateMap<Student,StudentUpdateDto>();
        }
    }
}