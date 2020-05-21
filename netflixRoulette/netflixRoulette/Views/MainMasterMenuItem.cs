using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflixRoulette
{

	public class MainMasterMenuItem
	{
		public MainMasterMenuItem()
		{
			TargetType = typeof(MainMasterMenuItem);
		}
		public int Id { get; set; }
		public string Title { get; set; }

		public Type TargetType { get; set; }
	}
}