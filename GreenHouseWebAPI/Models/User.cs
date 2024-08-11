using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;


namespace GreenHouseWebAPI.Models
{
    public class User
    {
        public User()
        {
            firstName = String.Empty;
            lastName = String.Empty;
            password = String.Empty;
            age = 0;
            country = String.Empty;
            sex = 'M';
        }


        [Key]
        public int userId { get; set; } = RandomIDGenerator.Generate(8);
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public string country { get; set; }
        public char sex { get; set; }

    }

}
