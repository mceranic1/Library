using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Models;
using Library_DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected UnitOfWork _unit = new UnitOfWork();
        protected ModelFactory _factory = new ModelFactory();

        public UnitOfWork Unit => _unit ?? (_unit = new UnitOfWork());
        public ModelFactory Factory => _factory ?? (_factory = new ModelFactory());
    }
}