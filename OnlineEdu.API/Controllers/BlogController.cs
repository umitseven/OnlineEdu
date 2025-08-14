﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController(IGenericService<Blog> _blogService,IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _blogService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var values = mapper.Map<Blog>(createBlogDto);
            _blogService.TCreate(values);
            return Ok("Yeni Blog Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var value = mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(value);
            return Ok("bloglar güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.TDelete(id);
            return Ok("Blog silindi");
        }
    }
}
