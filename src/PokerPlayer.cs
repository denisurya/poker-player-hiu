using Newtonsoft.Json.Linq;
using System;
using System.IO;
namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Default C# folding player";

		public static int BetRequest(JObject gameState)
		{
			//TODO: Use this method to return the value You want to bet
		
            Console.WriteLine(gameState.ToString());
			return 1000; //fold
            //1000 chips
            //
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

