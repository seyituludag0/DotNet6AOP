using AutoMapper;
using Business.Abstracts;
using Business.Dtos;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [LogAspect(typeof(FileLogger))]
        [ExceptionLogAspect(typeof(FileLogger))]
        public void Add(Category category)
        {
            Category ctgry = new();
            ctgry.CategoryName = category.CategoryName;

            _categoryDal.Add(null);
        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        //[LogAspect(typeof(FileLogger))]
        //[ExceptionLogAspect(typeof(FileLogger))]
        public List<Category> GetAll()
        {
            var result = _categoryDal.GetList();
            return result.ToList();
            //throw new Exception("Special Exception");
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
