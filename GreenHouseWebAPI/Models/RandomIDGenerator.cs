using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace GreenHouseWebAPI.Models
{

    public class RandomIDGenerator
    {
        public static int Generate(int size)
        {
            Random r = new Random();
            // Decide how long the string will be
            int strLength = r.Next(size, size);

            var sb = new StringBuilder();

            for (int i = 0; i < strLength; i++)
            {
                
                        sb.Append((char)(48 + r.Next(0, 10)));
                        break;
                
            }

            return int.Parse(sb.ToString());
            
        }
    }
    }
