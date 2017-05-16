using ConsoleApplication1.Models;
using System;

namespace ConsoleApplication1 {
	public class NumberProcessor {

		public void Process(int startNumber, int endNumber, InputConfiguration inputconfiguration) {
			for (int i = startNumber; i < endNumber+1; i++) {
				string outputString = null;
				foreach (NumberConfig config in inputconfiguration.ConfigList) {
					if (i % config.Divisor == 0) {
						outputString += config.Replacement;
					}
				}
				Console.WriteLine(outputString ?? i.ToString());
			}

		}
	}
}
