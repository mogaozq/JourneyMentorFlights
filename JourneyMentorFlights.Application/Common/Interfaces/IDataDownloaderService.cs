﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Application.Common.Interfaces
{
    public interface IDataDownloaderService
    {
        Task DownloadAndSaveAirports();
        Task DownloadAndSaveFlights(int limit, int offset);
    }
}
