using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
            using IDbConnection con = new SqlConnection(Program.ConnectionString);
            return Ok(con.GetAll<Todo>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using IDbConnection con = new SqlConnection(Program.ConnectionString);
            return Ok(con.Get<Todo>(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Todo value)
        {
            using IDbConnection con = new SqlConnection(Program.ConnectionString);
            return Ok(con.Insert(value));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Todo value)
        {
            using IDbConnection con = new SqlConnection(Program.ConnectionString);
            return Ok(con.Update(value));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using IDbConnection con = new SqlConnection(Program.ConnectionString);
            return Ok(con.Delete(new Todo { ID = id }));
        }
        public static Todo GetTodo(this object o)
        {

            return new Todo();
        }
    }
}
