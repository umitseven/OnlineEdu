using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController(IGenericService<Subscriber> _SubscriberService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var valuses = _SubscriberService.TGetList();
            return Ok(valuses);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _SubscriberService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult Create(CreateSubscriberDto createSubscriberDto)
        {
            var value = _mapper.Map<Subscriber>(createSubscriberDto);
            _SubscriberService.TCreate(value);
            return Ok("subscribe başarılı bir şekilde çoğaltıldı.");
        }
        [HttpPut]
        public IActionResult Update(UpdateSubscriberDto updateSubscriberDto)
        {
            var values = _mapper.Map<Subscriber>(updateSubscriberDto);
            _SubscriberService.TUpdate(values);
            return Ok("Güncelleme başarılı bir şekilde yapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _SubscriberService.TDelete(id);
            return Ok("başarılı bir şekilde takipçi silindi");
        }

    }
}
