using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IGenericService<Contact> _contactService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _contactService.TGetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.TDelete(id);
            return Ok("İletişim alanı silindi"); 

        }
        [HttpPost]
        public IActionResult Create(CreateContactDto createContactDto)
        {
            var values = _mapper.Map<Contact>(createContactDto);
            _contactService.TCreate(values);
            return Ok("İletişim alanı oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("İletişim alanı güncellendi");
        }
    }
}
