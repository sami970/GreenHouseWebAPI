using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using GreenHouseWebAPI.Models;

namespace GreenHouseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactMeasurementsController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public FactMeasurementsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //api/FactMeasurements
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select MeasurementId,UserId,Date_ID, Temperature , Humidity ,
                            Light , CO2 , timestamp 
                            
                            from [edw].[FactMeasurements]
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
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
