using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Infrastructure.AviationStack.Models
{
    public class PaginatedList<T>
    {
        public Pagination pagination { get; set; }
        public IEnumerable<T> data { get; set; }
    }

    public class Pagination
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}
