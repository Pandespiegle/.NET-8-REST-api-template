using LolAppWS.Models;

namespace LolAppWS.Interfaces
{
    public interface ISummonerService
    {
        string? getPuuid(string name, string tag);
        public Summoner? getAccount(string name, string tag);


    }
}
