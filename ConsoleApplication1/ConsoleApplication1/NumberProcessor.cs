using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
	public class NumberProcessor {

		public void Process(int startNumber, int endNumber, InputConfiguration inputconfiguration) {
			for (int i = startNumber; i < endNumber+1; i++) {
				string outputString = string.Empty;
				foreach (NumberConfig config in inputconfiguration.ConfigList) {
					if (i % config.Divisor == 0) {
						outputString += config.Replacement;
					}
				}

				if (outputString == string.Empty) {
					outputString = i.ToString();
				}

				Console.WriteLine(outputString);
			}

		}
	}
}
