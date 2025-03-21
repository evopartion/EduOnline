﻿using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Concrete
{
    public interface ICourseRegisterRepository : IRepository<CourseRegister>
    {
        List<CourseRegister> GetAllWithCourseAndCategory(Expression<Func<CourseRegister, bool>> filter);
    }
}
