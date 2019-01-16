using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class dbConnect
    {
        private MySqlConnection connection = new MySqlConnection();
        public string databaseName { get; set; }
        private string password { get; set; }
        public string host { get; set; }
        private string user { get; set; }
       
        public dbConnect (string database, string password, string host, string user) => (databaseName, password, host, user) = (database, password, host, user);

        public Boolean connect()
        {
            Boolean result = false;
            try
            {
                connection.ConnectionString = $"server = {host}; database = {databaseName}; uid = {user}; pwd = {password}";
                connection.Open();
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }
    }
}
