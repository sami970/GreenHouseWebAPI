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
    public class ThresHoldController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public ThresHoldController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select ThresholdId, CO2min , CO2max ,
                            TempMin , TempMax , HumidityMin , HumidityMax ,
                            LightMin , LightMax
                            from [dbo].[ThresHold]
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
        public JsonResult Post(ThresHold thresHold)
        {
            string query = @"
                           insert into [dbo].[ThresHold]
                           (ThresholdId, CO2min , CO2max ,
                            TempMin , TempMax , HumidityMin , HumidityMax ,
                            LightMin , LightMax)
                           values (@ThresholdId, @CO2min , @CO2max ,
                            @TempMin , @TempMax , @HumidityMin , @HumidityMax,
                            @LightMin , @LightMax)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ThresholdId", thresHold.ThresholdId);
                    myCommand.Parameters.AddWithValue("@CO2min", thresHold.CO2min);
                    myCommand.Parameters.AddWithValue("@CO2max", thresHold.CO2max);
                    myCommand.Parameters.AddWithValue("@TempMin", thresHold.TempMin);
                    myCommand.Parameters.AddWithValue("@TempMax", thresHold.TempMax);
                    myCommand.Parameters.AddWithValue("@HumidityMin", thresHold.HumidityMin);
                    myCommand.Parameters.AddWithValue("@HumidityMax", thresHold.HumidityMax);
                    myCommand.Parameters.AddWithValue("@LightMin", thresHold.LightMin);
                    myCommand.Parameters.AddWithValue("@LightMax", thresHold.LightMax);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(ThresHold thresHold)
        {
            string query = @"
                           update [dbo].[ThresHold]
                           set ThresholdId= @ThresholdId,
                               CO2min= @CO2min,
                               CO2max= @CO2max ,
                               TempMin= @TempMin , 
                               TempMax= @TempMax , 
                               HumidityMin= @HumidityMin , 
                               HumidityMax= @HumidityMax ,
                               LightMin= @LightMin , 
                               LightMax= @LightMax
                            where ThresholdId=@ThresholdId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ThresholdId", thresHold.ThresholdId);
                    myCommand.Parameters.AddWithValue("@CO2min", thresHold.CO2min);
                    myCommand.Parameters.AddWithValue("@CO2max", thresHold.CO2max);
                    myCommand.Parameters.AddWithValue("@TempMin", thresHold.TempMin);
                    myCommand.Parameters.AddWithValue("@TempMax", thresHold.TempMax);
                    myCommand.Parameters.AddWithValue("@HumidityMin", thresHold.HumidityMin);
                    myCommand.Parameters.AddWithValue("@HumidityMax", thresHold.HumidityMax);
                    myCommand.Parameters.AddWithValue("@LightMin", thresHold.LightMin);
                    myCommand.Parameters.AddWithValue("@LightMax", thresHold.LightMax); ;
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
                           delete from [dbo].[ThresHold] 
                            where ThresholdId=@ThresholdId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ThresholdId", id);

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
