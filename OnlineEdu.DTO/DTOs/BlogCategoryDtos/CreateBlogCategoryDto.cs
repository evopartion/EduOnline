﻿using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.BlogCategoryDtos
{
    public class CreateBlogCategoryDto
    {
        public string Name { get; set; }
        public List<ResultBlogCategoryDto> Blogs { get; set; }
    }
}
