﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_server
{
    interface IParser
    {
        Task<T> ParseString<T>(string response);
    }
}
