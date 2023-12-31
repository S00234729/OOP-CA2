﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
using static System.Net.Mime.MediaTypeNames;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Link To Github https://github.com/S00234729/OOP-CA2
    public partial class MainWindow : Window
    {
        //add lists
        List<Team> teams = new List<Team>();
        //Make Teames
        Team t1 = new Team() { Name = "France", TeamPoints = 0 };
        Team t2 = new Team() { Name = "Italy", TeamPoints = 0 };
        Team t3 = new Team() { Name = "Spain", TeamPoints = 0 };
        //make Players
        //French players
            Player p1 = new Player() { Name = "Marie", ResultRecord = "WWDDL", score = 0 };
        Player p2 = new Player() { Name = "Claude", ResultRecord = "DDDLW", score = 0 };
        Player p3 = new Player() { Name = "Antoine", ResultRecord = "LWDLW", score = 0 };

        //Italian players
        Player p4 = new Player() { Name = "Marco", ResultRecord = "WWDLL", score = 0 };
        Player p5 = new Player() { Name = "Giovanni", ResultRecord = "LLLLD", score = 0 };
        Player p6 = new Player() { Name = "Valentina", ResultRecord = "DLWWW", score = 0 };

        //Spanish players
        Player p7 = new Player() { Name = "Maria", ResultRecord = "WWWWW", score = 0 };
        Player p8 = new Player() { Name = "Jose", ResultRecord = "LLLLL", score = 0 };
        Player p9 = new Player() { Name = "Pablo", ResultRecord = "DDDDD", score = 0 };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //call method
            GetData();

            //sort teams
            teams.Sort();
            //display items in listbox
            lbx_Teams.ItemsSource = teams;

            img_star_1.Source = new BitmapImage(new Uri("staroutline.png", UriKind.Relative));
            img_star_2.Source = new BitmapImage(new Uri("staroutline.png", UriKind.Relative));
            img_Star_3.Source = new BitmapImage(new Uri("staroutline.png", UriKind.Relative));


        }

        

        public void GetData()
        {      
            ;
            //add teams to a list
            teams.Add(t1);
            teams.Add(t2);
            teams.Add(t3);

            

            //calculate score for each player
            p1.score = CalculateScore(p1.ResultRecord);
            p2.score = CalculateScore(p2.ResultRecord);
            p3.score = CalculateScore(p3.ResultRecord);
            p4.score = CalculateScore(p4.ResultRecord);
            p5.score = CalculateScore(p5.ResultRecord);
            p6.score = CalculateScore(p6.ResultRecord);
            p7.score = CalculateScore(p7.ResultRecord);
            p8.score = CalculateScore(p8.ResultRecord);
            p9.score = CalculateScore(p9.ResultRecord);

            //get team points
            t1.TeamPoints = p1.score + p2.score + p3.score;
            t2.TeamPoints = p4.score + p5.score + p6.score;
            t3.TeamPoints = p7.score + p8.score + p9.score;

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

        private void lbx_Teams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //to display the selected teams players
            Team selected = lbx_Teams.SelectedItem as Team;
            //display the players 
            if (selected != null)
            {

                lbx_players.ItemsSource = selected.Player;

                
            }
            else
            {
                lbx_players.ItemsSource = null;
            }
            
        }
        
        public void RefreshScreen()
        {
            

            //to display the selected teams players
            Team selected = lbx_Teams.SelectedItem as Team;
            //display the players 
            if (selected != null)
            {
                //update display of players and teams
                lbx_players.Items.Clear();
                lbx_players.ItemsSource = selected.Player;

                teams.Sort();

                lbx_Teams.ItemsSource = null;
                lbx_Teams.ItemsSource = teams;


            }
            
        }
        public int CalculateScore(string RecordedResult)
        {
            //make vars for score and chars for the letters to search
            int score = 0;
            char W = 'W';
            char D = 'D';
            

            //calculate how many of each letter there is
            int noOfW = count(RecordedResult, W);
            int noOfD = count(RecordedResult, D);

            //add up the scores
            if (noOfW >=1)
            {
                score = score + (noOfW * 3);
            }
            if (noOfD >=1)
            {
                score = score + noOfD;
            }
            



            
            
            return score;
        }

        public int CalculateTeamScore()
        {
            Team team = lbx_Teams.SelectedItem as Team;

            int teamscore;

            
                if (team == t1)
                {
                    teamscore = p1.score + p2.score + p3.score;
                return teamscore;

            }
                else if (team == t2)
                {
                    teamscore = p4.score + p5.score + p6.score;
                return teamscore;
            }
                else
                {
                    teamscore = p7.score + p8.score + p9.score;
                return teamscore;
            }  

        }


        int count(string s, char c)
        {
            // Count variable
            int res = 0;

            for (int i = 0; i < s.Length; i++)

                // checking character in string
                if (s[i] == c)
                    res++;

            return res;
        }

        public string NewRecord(string OldRecord, string input)
        {
            //remove first char in string
            //add new char
            string NewRecord1 = OldRecord.Remove(0, 1);
            string NewRecord2 = NewRecord1.Insert(4, input);


            return NewRecord2;
        }

        private void btn_Win_Click(object sender, RoutedEventArgs e)
        {
            Team team = lbx_Teams.SelectedItem as Team;
            Player selected = lbx_players.SelectedItem as Player;
            string Win = "W";



            if (selected != null)
            {
                 string NewScore  = NewRecord(selected.ResultRecord, Win);

                selected.ResultRecord = NewScore;

                selected.score = CalculateScore(selected.ResultRecord);


                lbx_players.ItemsSource = null;


                team.TeamPoints = CalculateTeamScore();
                
                RefreshScreen();

                
               

            }

            
            

        }

        private void btn_Lose_Click(object sender, RoutedEventArgs e)
        {
            Team team = lbx_Teams.SelectedItem as Team;
            Player selected = lbx_players.SelectedItem as Player;
            string Win = "L";



            if (selected != null)
            {
                string NewScore = NewRecord(selected.ResultRecord, Win);

                selected.ResultRecord = NewScore;

                selected.score = CalculateScore(selected.ResultRecord);


                lbx_players.ItemsSource = null;


                team.TeamPoints = CalculateTeamScore();
                RefreshScreen();



            }
        }

        private void btn_Draw_Click(object sender, RoutedEventArgs e)
        {
            Team team = lbx_Teams.SelectedItem as Team;
            Player selected = lbx_players.SelectedItem as Player;
            string Win = "D";



            if (selected != null)
            {
                string NewScore = NewRecord(selected.ResultRecord, Win);

                selected.ResultRecord = NewScore;

                selected.score = CalculateScore(selected.ResultRecord);


                lbx_players.ItemsSource = null;


                team.TeamPoints = CalculateTeamScore();
                RefreshScreen();



            }
        }
        
        private void lbx_players_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Player player = lbx_players.SelectedItem as Player;
            if (player != null)
            {
                if (player.score <= 0)
                {
                    img_star_1.Source = new BitmapImage(new Uri("staroutline.png", UriKind.Relative));
                    img_star_2.Source = new BitmapImage(new Uri("staroutline.png", UriKind.Relative));
                    img_Star_3.Source = new BitmapImage(new Uri("staroutline.png", UriKind.Relative));
                }
                else if (player.score >= 1 && player.score <= 5)
                {
                    img_star_1.Source = new BitmapImage(new Uri("starsolid.png", UriKind.Relative));
                    img_star_2.Source = new BitmapImage(new Uri("staroutline.png", UriKind.Relative));
                    img_Star_3.Source = new BitmapImage(new Uri("staroutline.png", UriKind.Relative));
                }
                else if (player.score >= 6 && player.score <= 10)
                {
                    img_star_1.Source = new BitmapImage(new Uri("starsolid.png", UriKind.Relative));
                    img_star_2.Source = new BitmapImage(new Uri("starsolid.png", UriKind.Relative));
                    img_Star_3.Source = new BitmapImage(new Uri("staroutline.png", UriKind.Relative));
                }
                else if (player.score >= 11 && player.score <= 15)
                {
                    img_star_1.Source = new BitmapImage(new Uri("starsolid.png", UriKind.Relative));
                    img_star_2.Source = new BitmapImage(new Uri("starsolid.png", UriKind.Relative));
                    img_Star_3.Source = new BitmapImage(new Uri("starsolid.png", UriKind.Relative));
                }
            }

        }
        
    }
}
