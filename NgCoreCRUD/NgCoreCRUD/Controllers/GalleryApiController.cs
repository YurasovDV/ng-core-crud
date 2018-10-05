﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NgCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryApiController : Controller
    {
        // GET api/GalleryApi
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/GalleryApi/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/GalleryApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/GalleryApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/GalleryApi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
