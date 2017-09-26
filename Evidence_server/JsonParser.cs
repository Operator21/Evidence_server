﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Evidence_server
{
    class JsonParser : IParser
    {
        public async Task<T> ParseString<T>(string response)
        {
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response));
        }
    }
}
