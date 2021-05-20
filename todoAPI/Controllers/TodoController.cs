using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using todoAPI.Helper;
using todoAPI.Models;

namespace todoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using IDbConnection con = TodoDbFactory.Singleton.OpenConnection();
            DynamicParameters dynamicParameters = new DynamicParameters();
            return Ok(con.GetAll<Todo>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using IDbConnection con = TodoDbFactory.Singleton.OpenConnection();
            return Ok(con.Get<Todo>(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Todo value)
        {
            using IDbConnection con = TodoDbFactory.Singleton.OpenConnection();
            var TodoID = con.Insert(value);
            value.ID = (int)TodoID;
            return Ok(value);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Todo value)
        {
            using IDbConnection con = TodoDbFactory.Singleton.OpenConnection();
            return Ok(con.Update(value));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using IDbConnection con = TodoDbFactory.Singleton.OpenConnection();
            return Ok(con.Delete(new Todo { ID = id }));
        }
    }
}
