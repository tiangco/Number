using System.Collections.Generic;

namespace ConsoleApplication1.Models {
	public class InputConfiguration {
		public List<NumberConfig> ConfigList { get; set; }
	}

	public class NumberConfig {
		public int Divisor { get; set; }
		public string Replacement { get; set; }
	}
}
