using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ICT13570045EndB.Helpers
{
	public class Product
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[NotNull]
		[MaxLength(200)]
		public string Type { get; set; }

		[NotNull]
		[MaxLength(200)]
		public string Brand { get; set; }

		[NotNull]
		[MaxLength(200)]
		public string Generation { get; set; }

		public int Year { get; set; }

		public int Mile { get; set; }

		[NotNull]
		[MaxLength(200)]
		public string Colour { get; set; }

		public Boolean Dealer { get; set; }

		[MaxLength(200)]
		public string Detail { get; set; }

		public int Price { get; set; }

		[NotNull]
		[MaxLength(200)]
		public string Province { get; set; }

		public int Phone { get; set; }
	}
}