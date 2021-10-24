using ExpressoApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        ExpressoDbContext _expressoDbContext;
        public MenusController(ExpressoDbContext expressoDbContext)
        {
            _expressoDbContext = expressoDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_expressoDbContext.Menus.Include("SubMenus"));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_expressoDbContext.Menus.Include("SubMenus").FirstOrDefault(x=>x.Id == id));
        }
    }
}
