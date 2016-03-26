using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Default C# folding player";

        const string ourName = "Hiu";

        static int counter = 0;

		public static int BetRequest(JObject gameState)
		{

            try
            {
                GameState state = Newtonsoft.Json.JsonConvert.DeserializeObject<GameState>(gameState.ToString());

                Player us = state.players.Find(p => p.name == ourName);
                if (us != null)
                {
                    Console.WriteLine("Our cards: {0}", ShowCards(us.hole_cards));
                    Console.WriteLine("Community cards: {0}", ShowCards(state.community_cards));
                    return state.current_buy_in - us.bet;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error {0}", ex.Message);
            }
            
            
            return 1000;
		}

		public static void ShowDown(JObject gameState)
		{
            try
            {
                Console.WriteLine("Showdown");
            }
            catch (Exception ex)
            {
                
            }
		}


        static string ShowCards(List<HoleCard> lstCommCards)
        {
            string ret = "";

            foreach (var card in lstCommCards)
            {
                ret += card.rank + card.suit + ",";
            }

            if (ret != "")
                return ret.Substring(0, ret.Length - 2);
            else
                return "nocards";
        }
	}
}

