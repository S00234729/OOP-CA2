using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //add lists
        List<Team> teams = new List<Team>();
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //call method
            GetData();
            //display items in listbox
            lbx_Teams.ItemsSource = teams;


        }

        

        public void GetData()
        {      
            //Make Teames
            Team t1 = new Team() { Name = "France" };
            Team t2 = new Team() { Name = "Italy" };
            Team t3 = new Team() { Name = "Spain" };
            //add teams to a list
            teams.Add(t1);
            teams.Add(t2);
            teams.Add(t3);

            //make Players
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

            //add the players to team 1
            t1.Player.Add(p1);
            t1.Player.Add(p2);
            t1.Player.Add(p3);

            //addplayers to team 2
            t2.Player.Add(p4);
            t2.Player.Add(p5);
            t2.Player.Add(p6);

            //addplayers to team 3
            t3.Player.Add(p7);
            t3.Player.Add(p8);
            t3.Player.Add(p9);
        }


    }
}
