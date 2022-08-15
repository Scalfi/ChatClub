using ChatClub.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClub.Application.Services
{
    public class ApiService : IApiService
    {
        public async Task GetAsync(string param)
        {
            var texts = param.Split('=');
            var text = texts[1];
            var client = new HttpClient();
            var url = "http://chatclubbot:80/api/bot?param=" + text;
            await client.GetAsync(url);
        }
    }
}
