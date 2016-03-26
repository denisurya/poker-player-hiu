using Newtonsoft.Json.Linq;
using System;
using System.IO;
namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Default C# folding player";


        static int counter = 0;

		public static int BetRequest(JObject gameState)
		{
			//TODO: Use this method to return the value You want to bet


            string toLog = counter++.ToString() + Environment.NewLine + gameState.ToString() + Environment.NewLine;


            Console.WriteLine(toLog);
			
            return 1000;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

