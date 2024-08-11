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
    public class GreenHouseController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public GreenHouseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select greenHouseId, location , ThresholdId ,
                            userId 
                            from [dbo].[GreenHouse]
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
        public JsonResult Post(GreenHouse greenHouse)
        {
            string query = @"
                           insert into [dbo].[GreenHouse]
                           (greenHouseId, location , ThresholdId , userId)
                           values (
                           @greenHouseId, @location , @ThresholdId, @userId)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@greenHouseId", greenHouse.greenHouseId);
                    myCommand.Parameters.AddWithValue("@location", greenHouse.location);
                    myCommand.Parameters.AddWithValue("@ThresholdId", greenHouse.ThresholdId);
                    myCommand.Parameters.AddWithValue("@userId", greenHouse.userId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(GreenHouse greenHouse)
        {
            string query = @"
                           update [dbo].[GreenHouse]
                           set 
                               greenHouseId= @greenHouseId,
                               location= @location,
                               ThresholdId= @ThresholdId,
                               userId= @userId 
                               
                               
                            where greenHouseId=@greenHouseId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@greenHouseId", greenHouse.greenHouseId);
                    myCommand.Parameters.AddWithValue("@location", greenHouse.location);
                    myCommand.Parameters.AddWithValue("@ThresholdId", greenHouse.ThresholdId );
                    myCommand.Parameters.AddWithValue("@userId", greenHouse.userId);
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
                           delete from [dbo].[GreenHouse]
                            where greenHouseId=@greenHouseId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@greenHouseId", id);

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
