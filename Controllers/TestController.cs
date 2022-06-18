using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreReact.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CoreReact.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TestController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "mono","di","tri","tetra"
        };

    [HttpGet]
    public IEnumerable<Test> Get()
    {
      var rng = new Random();

      return Enumerable.Range(1, 5).Select(index => new Test
      {
        Date = DateTime.Now.AddDays(index)
      })
      .ToArray();
    }

  }

  [ApiController]
  [Route("controller")]
  public class TestIOController : ControllerBase {

    private readonly IConfiguration _configuration;
    public TestIOController(IConfiguration configuration) {
      _configuration = configuration;
    }

    [HttpGet]
    public JsonResult Get()
    {
      string query = @"select count from dbo.TestTable";

      DataTable table = new DataTable();
      string sqlDataSource = _configuration.GetConnectionString("CoreReactAppCon");
      SqlDataReader myReader;
      using (SqlConnection myCon = new SqlConnection(sqlDataSource)) {
        myCon.Open();
        using (SqlCommand myCommand = new SqlCommand(query, myCon)) { 
          myReader = myCommand.ExecuteReader();
          table.Load(myReader);
          myReader.Close();
          myCon.Close();
        }
      }

      return new JsonResult(table);
    }

    [HttpPost]
    public JsonResult Post(TestCount testCount)
    {
      string query = @"insert into dbo.TestTable values (@count)";

      DataTable table = new DataTable();
      string sqlDataSource = _configuration.GetConnectionString("CoreReactAppCon");
      SqlDataReader myReader;
      using (SqlConnection myCon = new SqlConnection(sqlDataSource))
      {
        myCon.Open();
        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        {
          myCommand.Parameters.AddWithValue("@count", testCount.Count);
          myReader = myCommand.ExecuteReader();
          table.Load(myReader);
          myReader.Close();
          myCon.Close();
        }
      }

      return new JsonResult(table);
    }

    [HttpPut]
    public JsonResult Put(TestCount testCount)
    {
      string query = @"update dbo.TestTable set count = @count where count=@count";

      DataTable table = new DataTable();
      string sqlDataSource = _configuration.GetConnectionString("CoreReactAppCon");
      SqlDataReader myReader;
      using (SqlConnection myCon = new SqlConnection(sqlDataSource))
      {
        myCon.Open();
        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        {
          myCommand.Parameters.AddWithValue("@count", testCount.Count);
          myReader = myCommand.ExecuteReader();
          table.Load(myReader);
          myReader.Close();
          myCon.Close();
        }
      }

      return new JsonResult(table);
    }

  }
}