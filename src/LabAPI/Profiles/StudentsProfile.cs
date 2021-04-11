using AutoMapper;
using LabAPI.Dtos;
using LabAPI.Models;

namespace LabAPI.Profiles{
    public class StudentProfile : Profile{
        public StudentProfile(){
            CreateMap<Student,StudentReadDto>();
        }
    }
}