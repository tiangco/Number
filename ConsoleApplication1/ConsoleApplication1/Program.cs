﻿using ConsoleApplication1.Models;
using Newtonsoft.Json;
using System;

namespace ConsoleApplication1 {
	class Program {
		static void Main(string[] args) {

			const string START_PARAMETER = "-start:";
			const string END_PARAMETER = "-end:";

			bool isValid = true;
			int? startNumber = null;
			int? endNumber = null;

			foreach (string arg in args) {
				ExtractArgument(arg, START_PARAMETER, ref startNumber, ref isValid);
				ExtractArgument(arg, END_PARAMETER, ref endNumber, ref isValid);
			}

			if (startNumber == null) {
				isValid = false;
				Console.WriteLine($"{START_PARAMETER} argument is required.");
			}
			if (endNumber == null) {
				isValid = false;
				Console.WriteLine($"{END_PARAMETER} argument is required.");
			}

			if (isValid && startNumber > endNumber) {
				isValid = false;
				Console.WriteLine($"{START_PARAMETER} {startNumber} must be less than the {END_PARAMETER} {endNumber}.");
			}

			if (!isValid) {
				Console.WriteLine( "Usage:");
				Console.WriteLine($" Number {START_PARAMETER}(startingInteger) {END_PARAMETER}(endingInteger)");
				Console.WriteLine( "     startingInteger  The starting integer of the range (inclusive).");
				Console.WriteLine( "     endingInteger    The ending integer of the range (inclusive).");
				Console.WriteLine();
				Console.WriteLine($" Example: Number {START_PARAMETER}4 {END_PARAMETER}40");
			}
			else {
				string configListString = Utility.RequiredAppSetting("configList");
				var inputConfiguration = JsonConvert.DeserializeObject<InputConfiguration>(configListString);

				var proc = new NumberProcessor();
				proc.Process(startNumber.Value, endNumber.Value, inputConfiguration);
			}

			Console.WriteLine();
			Console.WriteLine("by Noel Tiangco. Press [Enter] to end.");
			Console.ReadLine();
			return;
		}

		private static void ExtractArgument(string arg, string prefix, ref int? target, ref bool isValid) {
			if (arg.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase)) {
				int number;
				var x = arg.ToLowerInvariant().Replace(prefix, string.Empty);
				if (int.TryParse(x, out number)) {
					target = number;
				}
				else {
					isValid = false;
					Console.WriteLine($"{prefix} argument {arg} must be a valid integer.");
				}
			}
			return;
		}
	}
}
