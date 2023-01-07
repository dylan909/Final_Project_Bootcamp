using System;
using FinalProject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace FinalProject.Data
{
	public class Dbinitializer
	{
        public static void Initialize(FinalProjectContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Continents.

            if (context.teams.Any() && context.allplayers.Any())
            {
                return;   // DB has been seeded
            }
            var AllTeams = new Teams[]
            {
                new Teams{Name="Arsenal", Stadium="Emeriates", Founded=1932},
                new Teams{Name="Tottenham", Stadium="White Heart Lane", Founded=1912},
                new Teams{Name="Man United", Stadium="Old Trafford", Founded=1892},
            };

            var AllPlayers = new Players[]
            {
                new Players{PlayersId=1, Name="Dylan", Age=21, OnForm=true, Position="GK", Goals=22},
                new Players{PlayersId=2,Name="Rachel", Age=21, OnForm=true, Position="CB", Goals=2},
                new Players{PlayersId=3,Name="Bilal", Age=21, OnForm=true, Position="CB", Goals=8},
                new Players{PlayersId=4,Name="Kevin", Age=21, OnForm=true, Position="MD", Goals=19},
                new Players{PlayersId=5,Name="Kalim", Age=21, OnForm=false, Position="MD", Goals=13},
                new Players{PlayersId=6,Name="Anji", Age=21, OnForm=true, Position="ST", Goals=15},
                new Players{PlayersId=7,Name="Alexandra", Age=27, OnForm=false, Position="ST", Goals=11},
                new Players{PlayersId=8,Name="Alex", Age=19, OnForm=false, Position="ST", Goals=11},
            };


            foreach (Players z in AllPlayers)
            {
                context.allplayers.Add(z);
            }

            foreach (Teams s in AllTeams)
            {
                context.teams.Add(s);
            }

            context.SaveChanges();
        }
    }
}

