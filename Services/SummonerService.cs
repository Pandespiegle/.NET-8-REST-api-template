
using LolAppWS.Interfaces;
using LolAppWS.Models;
using LolAppWS.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; 

namespace LolAppWS.Service
{
    public class SummonerService(IConfiguration configuration) : BaseService(configuration), ISummonerService
    {
        public string? getPuuid(string name, string tag)
        {
            string path = "https://europe.api.riotgames.com/riot/account/v1/accounts/by-riot-id/" + name + "/" + tag;
            string jsonResponse = GetRequest(path).Result;

            Summoner? summoner = JsonConvert.DeserializeObject<Summoner>(jsonResponse);

            if (summoner == null)
            {
                return null;
            }

            return summoner.Puuid;
        }

        public Summoner? getAccount(string name, string tag)
        {
            string? puuid = getPuuid(name, tag);

            if(puuid == null)
            {
                return null;
            }

            string path = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/" + puuid;

            string jsonResponse = GetRequest(path).Result;

            Summoner? summoner = JsonConvert.DeserializeObject<Summoner>(jsonResponse);

            return summoner;

        }


    }
}
