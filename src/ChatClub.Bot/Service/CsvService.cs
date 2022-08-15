using ChatClub.Bot.Interface;
using ChatClub.Bot.Model;
using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace ChatClub.Bot.Service
{
    public class CsvService : ICsvService
    {
        private readonly IMessageBroker _message;

        public CsvService(IMessageBroker message)
        {
            _message = message;
        }

        public async Task ParseCsv(string message)
        {
            var client = new HttpClient();
            var url = $"https://stooq.com/q/l/?s={message}&f=sd2t2ohlcv&h&e=csv";

        
            using (var resp =  await client.GetAsync(url))
            {
                resp.EnsureSuccessStatusCode();

                using (var s = await resp.Content.ReadAsStreamAsync())
                using (var sr = new StreamReader(s))
                using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Csv>();
                    _message.Produce();

                }
            }
            
        }
    }
}
