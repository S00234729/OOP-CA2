using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public class Player
    {
        //set up vars
        public string Name { get; set; }
        public string ResultRecord { get; set; }

        public int score { get; set; }

        //constructors


        public override string ToString()
        {
            //change the names of teams to strings
            return $"{Name.ToString()} {ResultRecord.ToString()} {score}";
            
        }

    }
}
