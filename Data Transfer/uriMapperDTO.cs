using System.Text.Json.Serialization;

namespace portfolioApi.Data_Transfer
{
    public class uriMapperDTO
    {
        public List<int> _skillIds {get; set;}
        public List<int> _informationIds {get; set;}
        public List<int> _eventIds {get; set;}
        public List<int> _projectIds {get; set;}

        [JsonConstructor]
        public uriMapperDTO(){}
    }
}