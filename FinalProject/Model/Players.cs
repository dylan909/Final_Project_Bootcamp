using System;
using System.Reflection.Metadata;

namespace FinalProject.Model
{
	public class Players
	{
		public int PlayersId { get; set; }
		public string? Name { get; set; }
		public int Age { get; set; }
		public bool OnForm { get; set; }
		public string? Position { get; set; }
		public int Goals { get; set; }

        public static implicit operator Players?(Teams? v)
        {
            throw new NotImplementedException();
        }
    }
}