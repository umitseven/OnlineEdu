using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Dto.Dtos.CourseCategoryDtos
{
    public class CreateCourseCategoryDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Despription { get; set; }
        public bool IsShown { get; set; }
        
    }
}
