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
            string[] array = new string[1];
            dbConnect t = new dbConnect("mydb", "nicky246", "localhost", "root");
            if(!t.connect())
            {
                array[0] = "Conexión exitosa";
            }
            else
            {
                array[0] = "Conexión fallida";
            }

            return array;
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

        public string databaseName { get; set; }
        private string password { get; set; }
        public string host { get; set; }
        private string user { get; set; }
       
        public dbConnect (string database, string password, string host, string user) => (databaseName, password, host, user) = (database, password, host, user);

        public Boolean connect()
        {
            Boolean error = false;
            try
            {
                string conn = "SERVER=localhost; DATABASE=mydb; UID=root; password=nicky246;";
                MySqlConnection conDb = new MySqlConnection(conn);
                conDb.Open();

            }
            catch (Exception e)
            {
                error = true;
            }

            return error;
        }
    }
}
