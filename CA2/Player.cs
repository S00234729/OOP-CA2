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
        string Name;
        string ResultRecord;

        //French players
        Player p1 = new Player() { Name = "Marie", ResultRecord = "WWDDL" };
        Player p2 = new Player() { Name = "Claude", ResultRecord = "DDDLW" };
        Player p3 = new Player() { Name = "Antoine", ResultRecord = "LWDLW" };

        //Italian players
        Player p4 = new Player() { Name = "Marco", ResultRecord = "WWDLL" };
        Player p5 = new Player() { Name = "Giovanni", ResultRecord = "LLLLD" };
        Player p6 = new Player() { Name = "Valentina", ResultRecord = "DLWWW" };

        //Spanish players
        Player p7 = new Player() { Name = "Maria", ResultRecord = "WWWWW" };
        Player p8 = new Player() { Name = "Jose", ResultRecord = "LLLLL" };
        Player p9 = new Player() { Name = "Pablo", ResultRecord = "DDDDD" };

    }
}
