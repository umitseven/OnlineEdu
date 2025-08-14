using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController(IGenericService<CourseCategory> _CourseCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _CourseCategoryService.TGetList();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _CourseCategoryService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            var values = _mapper.Map<CourseCategory>(createCourseCategoryDto);
            _CourseCategoryService.TCreate(values);
            return Ok("Kategori oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var value = _mapper.Map<CourseCategory>(updateCourseCategoryDto);
            _CourseCategoryService.TUpdate(value);
            return Ok("Kategori güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _CourseCategoryService.TDelete(id);
            return Ok("Başarılı bir şekilde Kurs Kategorisi Silindi.");
        }

    }
}
