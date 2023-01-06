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

            if (context.teams.Any() && context.players.Any())
            {
                return;   // DB has been seeded
            }
            var Teams = new Teams[]
            {
                new Teams{Name="Arsenal", Stadium="Emeriates", Founded=1932},
                new Teams{Name="Tottenham", Stadium="White Heart Lane", Founded=1912},
                new Teams{Name="Man United", Stadium="Old Trafford", Founded=1892},
            };

            var Players = new Players[]
            {
                new Players{Name="Dylan", Age=21, OnForm=true, Position="GK", Goals=22},
                new Players{Name="Rachel", Age=21, OnForm=true, Position="CB", Goals=2},
                new Players{Name="Bilal", Age=21, OnForm=true, Position="CB", Goals=8},
                new Players{Name="Kevin", Age=21, OnForm=true, Position="MD", Goals=19},
                new Players{Name="Kalim", Age=21, OnForm=false, Position="MD", Goals=13},
                new Players{Name="Anji", Age=21, OnForm=true, Position="ST", Goals=15},
                new Players{Name="Alexandra", Age=27, OnForm=false, Position="ST", Goals=11},
            };


            foreach (Players s in Players)
            {
                context.players.Add(s);
            }

            foreach (Teams s in Teams)
            {
                context.teams.Add(s);
            }

            context.SaveChanges();
        }
    }
}

