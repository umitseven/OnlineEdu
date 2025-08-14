using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(IGenericService<Course> _courseService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var valu = _courseService.TGetList();
            return Ok(valu);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var valu = _courseService.TGetById(id);
            return Ok(valu);
        }
        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var values = _mapper.Map<Course>(createCourseDto);
            _courseService.TCreate(values);
            return Ok("Kurs oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var value = _mapper.Map<Course>(updateCourseDto);
            _courseService.TUpdate(value);
            return Ok("Kurs güncellendi");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var vules = _courseService.TGetById(id);
            return Ok(vules);
        }

    }
}
