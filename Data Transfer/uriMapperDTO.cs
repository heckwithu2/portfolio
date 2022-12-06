namespace portfolioApi.Data_Transfer
{
    public class uriMapperDTO
    {
        public List<int> _skillIds {get; set;}
        public List<int> _informationIds {get; set;}
        public List<int> _eventIds {get; set;}
        public List<int> _projectIds {get; set;}

        public uriMapperDTO( List<int> skillIds,
                                 List<int> informationIds,
                                  List<int> eventIds,
                                   List<int> projectIds) {
            _skillIds = skillIds;
            _informationIds = informationIds;
            _eventIds = eventIds;
            _projectIds = projectIds;
        }
    }
}