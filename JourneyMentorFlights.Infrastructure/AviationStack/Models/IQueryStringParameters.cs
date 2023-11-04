using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Infrastructure.AviationStack.Models
{
    public interface IQueryStringParameters
    {
        string ToQueryString();
    }
}
