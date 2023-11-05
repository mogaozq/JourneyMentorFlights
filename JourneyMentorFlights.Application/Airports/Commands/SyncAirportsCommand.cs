using JourneyMentorFlights.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Application.Airports.Commands
{
    public class SyncAirportsCommand : IRequest<Unit>
    {
    }

    public class SyncAirportsCommandHandler : IRequestHandler<SyncAirportsCommand, Unit>
    {
        private readonly IDataSyncronizerService _dataSyncronizerService;

        public SyncAirportsCommandHandler(IDataSyncronizerService dataSyncronizerService)
        {
            _dataSyncronizerService = dataSyncronizerService;
        }

        public async Task<Unit> Handle(SyncAirportsCommand request, CancellationToken cancellationToken)
        {
            await _dataSyncronizerService.DownloadAndSaveAirports();

            return Unit.Value;
        }
    }
}
