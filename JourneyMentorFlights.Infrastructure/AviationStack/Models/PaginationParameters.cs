using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Infrastructure.AviationStack.Models
{
    public class PaginationParameters : IQueryStringParameters
    {
        public int limit { get; set; } = 100;
        public int offset { get; set; } = 0;

        public string ToQueryString()
        {
            throw new NotImplementedException();
        }
    }
}
