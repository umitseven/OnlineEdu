using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.SocialMediaDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController(IGenericService<SocialMedia> _socialMediaServer, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var value = _socialMediaServer.TGetList();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _socialMediaServer.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult Create(CreateSocialMediaDto createSocialMediaDto)
        {
            var values = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaServer.TCreate(values);
            return Ok("Yeni medya alanı oluşturuldu.");
        }
        [HttpPut]
        public IActionResult Update (UpdateSocialMediaDto updateSocialMediaDto)
        {
            var valu = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaServer.TUpdate(valu);
            return Ok("Sosyal medya alanı güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _socialMediaServer.TDelete(id);
            return Ok("Sosyal medya alanı silindi");
        }

    }
}
