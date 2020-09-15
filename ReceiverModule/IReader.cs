using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiverModule
{
    interface IReader
    {
        public List<string> ReadProcessedData();
    }
}
