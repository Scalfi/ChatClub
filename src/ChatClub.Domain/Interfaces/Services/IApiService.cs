using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClub.Domain.Interfaces.Services
{
    public interface IApiService
    {
        Task GetAsync(string param);
    }
}
