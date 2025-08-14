using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.MessageDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController(IGenericService<Message> _MessageService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _MessageService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Create(CreateMessageDto createMessageDto)
        {
            var values = _mapper.Map<Message>(createMessageDto);
            _MessageService.TCreate(values);
            return Ok("yeni mesaj oluşturuldu.");
        }
        [HttpPut]
        public IActionResult Update(UpdateMessageDto updateMessageDto)
        {
            var valu = _mapper.Map<Message>(updateMessageDto);
            _MessageService.TUpdate(valu);
            return Ok("Mesaj güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _MessageService.TDelete(id);
            return Ok("Mesaj silindi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var valu = _MessageService.TGetById(id);
            return Ok(valu);
        }

    }
}
