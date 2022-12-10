using portfolioApi.Data_Transfer;

namespace portfolioApi.Services
{
    public class uriService
    {
        public async Task uriMapper(uriMapperDTO _uriMapperDTO) {
            Console.WriteLine("Hello" + _uriMapperDTO._eventIds[0]);
        }
    }
}