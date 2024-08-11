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
    public class MeasurementController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public MeasurementController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select MeasurmentId, Temperature , Humidity ,
                            Light , CO2 , timestamp , greenHouseId
                            
                            from [dbo].[Measurement]
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

        [HttpPost]
        public JsonResult Post(Measurement measurement)
        {
            string query = @"
                           insert into [dbo].[Measurement]
                           (MeasurementId, Temperature , Humidity ,
                            Light , CO2 , timestamp , greenHouseId )
                           values (@MeasurementId, @Temperature , @Humidity ,
                            @Light , @CO2 , @timestamp ,@greenHouseId)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MeasurementId", measurement.MeasurementId);
                    myCommand.Parameters.AddWithValue("@Temperature", measurement.Temperature);
                    myCommand.Parameters.AddWithValue("@Humidity", measurement.Humidity);
                    myCommand.Parameters.AddWithValue("@Light", measurement.Light);
                    myCommand.Parameters.AddWithValue("@CO2", measurement.CO2);
                    myCommand.Parameters.AddWithValue("@timestamp", measurement.timestamp);
                    myCommand.Parameters.AddWithValue("@greenHouseId", measurement.greenHouseId);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Measurement measurement)
        {
            string query = @"
                           update [dbo].[Measurement]
                           set MeasurementId= @MeasurementId 
                               Temperature= @Temperature,
                               Humidity= @Humidity ,
                               Light= @Light , 
                               CO2= @CO2 , 
                               timestamp= @timestamp , 
                               greenHouseId= @greenHouseId 

                               
                            where MeasurementId=@MeasurementId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MeasurementId", measurement.MeasurementId);
                    myCommand.Parameters.AddWithValue("@Temperature", measurement.Temperature);
                    myCommand.Parameters.AddWithValue("@Humidity", measurement.Humidity);
                    myCommand.Parameters.AddWithValue("@Light", measurement.Light);
                    myCommand.Parameters.AddWithValue("@CO2", measurement.CO2);
                    myCommand.Parameters.AddWithValue("@timestamp", measurement.timestamp);
                    myCommand.Parameters.AddWithValue("@greenHouseId", measurement.greenHouseId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from [dbo].[Measurement] 
                            where MeasurementId=@MeasurementId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MeasurementId ", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

    }
}
