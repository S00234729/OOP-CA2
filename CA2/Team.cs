using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    
    public class Team : IComparable
    {
        //create vars and lists
        public string Name { get; set; }
        public int TeamPoints { get; set; }

        public List<Player> Player  = new List<Player>();

        //methods
        public override string ToString()
        {
            //change the names of teams to strings
            return $"{Name.ToString()}-{TeamPoints}";
            
        }
        public int CompareTo(object obj)
        {
            Team that = obj as Team;

            if (this.TeamPoints > that.TeamPoints )
                return -1;
            else if (this.TeamPoints < that.TeamPoints)
                return 1;
            else
                return this.TeamPoints.CompareTo(that.TeamPoints);
        }


    }
    

}
