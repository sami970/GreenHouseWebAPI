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
    public class UserController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select userId, firstName , lastName ,
                            password , age , country , sex
                            from [dbo].[User]
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
        public JsonResult Post(User user)
        {
            string query = @"
                           insert into [dbo].[User]
                           (userId, firstName , lastName ,
                            password , age , country , sex)
                           values (@userId ,@firstName , @lastName ,
                            @password , @age , @country , @sex)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@userId", user.userId);
                    myCommand.Parameters.AddWithValue("@firstName", user.firstName);
                    myCommand.Parameters.AddWithValue("@lastName", user.lastName);
                    myCommand.Parameters.AddWithValue("@password", user.password);
                    myCommand.Parameters.AddWithValue("@age", user.age);
                    myCommand.Parameters.AddWithValue("@country", user.country);
                    myCommand.Parameters.AddWithValue("@sex", user.sex);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(User user)
        {
            string query = @"
                           update [dbo].[User]
                           set 
                               userId = @userId, 
                               firstName= @firstName,
                               lastName= @lastName ,
                               password= @password , 
                               age= @age , 
                               country= @country , 
                               sex= @sex
                            where userId=@userId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@userId", user.userId);
                    myCommand.Parameters.AddWithValue("@firstName", user.firstName);
                    myCommand.Parameters.AddWithValue("@lastName", user.lastName);
                    myCommand.Parameters.AddWithValue("@password", user.password);
                    myCommand.Parameters.AddWithValue("@age", user.age);
                    myCommand.Parameters.AddWithValue("@country", user.country);
                    myCommand.Parameters.AddWithValue("@sex", user.sex);
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
                           delete from [dbo].[User]
                            where userId=@userId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("GreenhouseAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@userId", id);

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

