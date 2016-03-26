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
                    if (AllIn(us.hole_cards))
                    {
                        Console.WriteLine("We go all in");
                        return us.stack;
                    }
                    else
                    {
                        Console.WriteLine("We check/fild");
                        return 0;
                    }

                    //Console.WriteLine("Community cards: {0}", ShowCards(state.community_cards));
                    //return state.current_buy_in - us.bet;
                }
                else
                {
                    Console.WriteLine("We are null");
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


        static bool AllIn(List<HoleCard> holeCards)
        {
            if (CRS(holeCards[0].rank) > 7 && CRS(holeCards[1].rank) > 7)
                return true;
            else
                return false;
        }

        static int CRS(string cardRank)
        {
            switch (cardRank)
            {
                case "2":
                    return 1;
                case "3":
                    return 2;
                case "4":
                    return 3;
                case "5":
                    return 4;
                case "6":
                    return 5;
                case "7":
                    return 6;
                case "8":
                    return 7;
                case "9":
                    return 8;
                case "10":
                    return 9;
                case "J":
                    return 10;
                case "Q":
                    return 11;

                case "K":
                    return 12;
                case "A":
                    return 13;

                default:
                    break;
            }


            return -1;
        }
	}
}

