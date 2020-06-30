﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public interface IPassengerRepository
    {
        Passenger GetPassengerByEmail(string email);
        void SaveChanges();
    }
}