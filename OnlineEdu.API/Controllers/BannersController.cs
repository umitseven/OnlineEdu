using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _bannerService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _bannerService.TGetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bannerService.TDelete(id);
            return Ok("Banner silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateBannerDto createBannerDto)
        {
            var values = _mapper.Map<Banner>(createBannerDto);
            _bannerService.TCreate(values);
            return Ok("yeni Banner Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateBannerDto updateBannerDto)
        {
            var value = _mapper.Map<Banner>(updateBannerDto);
            _bannerService.TUpdate(value);
            return Ok("Banner güncellendi");
        }
    }
}
