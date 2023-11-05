using JourneyMentorFlights.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Application.Flights.Commands
{
    public class SyncFlightsCommand : IRequest<Unit>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    public class SyncFlightsCommandHandler : IRequestHandler<SyncFlightsCommand, Unit>
    {
        private readonly IDataSyncronizerService _dataSyncronizerService;

        public SyncFlightsCommandHandler(IDataSyncronizerService dataSyncronizerService)
        {
            _dataSyncronizerService = dataSyncronizerService;
        }

        public async Task<Unit> Handle(SyncFlightsCommand request, CancellationToken cancellationToken)
        {
            await _dataSyncronizerService.DownloadAndSaveFlights(request.Limit, request.Offset);

            return Unit.Value;
        }
    }
}
