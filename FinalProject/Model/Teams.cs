using System;
using Microsoft.Extensions.Hosting;

namespace FinalProject.Model
{
	public class Teams
	{
		public int? TeamsId { get; set; }
		public string? Name { get; set; }
		public string? Stadium { get; set; }
        public int Founded { get; set; }

    }
}

