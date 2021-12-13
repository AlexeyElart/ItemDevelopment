using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDevelopment.Logging.Models
{
    class LastOperationsLogItem
    {
        private readonly string _message;

        public LastOperationsLogItem(string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"[{DateTime.Now}] -> {_message}\n";
        }
    }
}
