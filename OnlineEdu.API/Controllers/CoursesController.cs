using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(IGenericService<Course> _courseServices, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseServices.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _courseServices.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseServices.TDelete(id);
            return Ok("Kurs Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var newValue = _mapper.Map<Course>(createCourseDto);
            _courseServices.TCreate(newValue);
            return Ok("Kurs Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var value = _mapper.Map<Course>(updateCourseDto);
            _courseServices.TUpdate(value);
            return Ok("Kurs Alanı Güncellendi");

        }
    }
}
