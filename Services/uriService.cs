using portfolioApi.Data_Transfer;
using portfolioApi.Models;

namespace portfolioApi.Services
{

    public class uriService
    {
        private readonly portfolioApiContext _context;
        private readonly int _uriMapperId;
        private readonly string _events = "event";
        private readonly string _skills = "skill";
        private readonly string _information = "information";
        private readonly string _projects = "project";


        //probably don't need this constructor, might be implicit. So many things done in the background with this language!
        public uriService(portfolioApiContext context, int uriMapperId){
            _context = context;
            _uriMapperId = uriMapperId;
        }
        public async Task uriMapper(uriMapperDTO _uriMapperDTO) {
            if (_uriMapperDTO._eventIds.Any()) saveUriMappings(validateUniqueEntry(_uriMapperDTO._eventIds, _events),_events);
            if (_uriMapperDTO._skillIds.Any()) saveUriMappings(validateUniqueEntry(_uriMapperDTO._skillIds, _skills), _skills);
            if (_uriMapperDTO._informationIds.Any()) saveUriMappings(validateUniqueEntry(_uriMapperDTO._informationIds, _information), _information);
            if (_uriMapperDTO._projectIds.Any()) saveUriMappings(validateUniqueEntry(_uriMapperDTO._projectIds, _projects), _projects);
        }

        private List<int> validateUniqueEntry(List<int> listOfIds, string identifier) {
            switch(identifier) 
            {
                case "event": 
                    var eventHasUriEntries = _context.eventHasUri.ToList();
                    if (eventHasUriEntries.Any()) 
                        for (int x = 0;x < listOfIds.Count; x++) {
                            if (eventHasUriEntries
                                .Exists(l => l.eventId == listOfIds[x] && l.uriId == _uriMapperId)) listOfIds.RemoveAt(x);
                        }   
                    break;
                case "skill":
                    var skillHasUriEntries = _context.uriHasSkill.ToList();
                    if (skillHasUriEntries.Any()) 
                        for (int x = 0;x < listOfIds.Count; x++) {
                            if (skillHasUriEntries
                                .Exists(l => l.skillId == listOfIds[x] && l.uriId == _uriMapperId)) listOfIds.RemoveAt(x);
                        }
                    break;
                case "information": 
                    var informationHasUriEntries = _context.informationHasUri.ToList();
                    if (informationHasUriEntries.Any()) 
                        for (int x = 0;x < listOfIds.Count; x++) {
                            if (informationHasUriEntries
                                .Exists(l => l.informationId == listOfIds[x] && l.uriId == _uriMapperId)) listOfIds.RemoveAt(x);
                        } 
                    break;
                case "project": 
                    var projectHasUriEntries = _context.projectHasUri.ToList();
                    if (projectHasUriEntries.Any()) 
                        for (int x = 0;x < listOfIds.Count; x++) {
                            if (projectHasUriEntries
                                .Exists(l => l.projectId == listOfIds[x] && l.uriId == _uriMapperId)) listOfIds.RemoveAt(x);
                        } 
                    break;
            } 
            return listOfIds;
        }
        private void saveUriMappings(List<int> listOfIds, string identifier) {
            switch(identifier) 
                {
                case "event":
                    eventHasUri eventHasUri = new eventHasUri();
                    foreach(int id in listOfIds)
                    {
                        eventHasUri.uriId = _uriMapperId;
                        eventHasUri.eventId = id; 
                        _context.Add(eventHasUri);
                        _context.SaveChanges();
                    }
                    break;
                case "skill":
                    uriHasSkill skillHasUri = new uriHasSkill();
                    foreach(int id in listOfIds)
                    {
                        skillHasUri.uriId = _uriMapperId;
                        skillHasUri.skillId = id; 
                        _context.Add(skillHasUri);
                        _context.SaveChanges();
                    }
                    break;
                case "information":
                    informationHasUri informationHasUri = new informationHasUri();
                    foreach(int id in listOfIds)
                    {
                        informationHasUri.uriId = _uriMapperId;
                        informationHasUri.informationId = id; 
                        _context.Add(informationHasUri);
                        _context.SaveChanges();
                    }
                    break;
                case "project":
                    projectHasUri projectHasUri = new projectHasUri();
                    foreach(int id in listOfIds)
                    {
                        projectHasUri.uriId = _uriMapperId;
                        projectHasUri.projectId = id; 
                        _context.Add(projectHasUri);
                        _context.SaveChanges();
                    }
                    break;
                }
        }
    }
}