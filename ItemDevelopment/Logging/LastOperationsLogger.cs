using ItemDevelopment.Logging.Models;
using ItemDevelopment.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemDevelopment.Logging
{
    public class LastOperationsLogger : ILogger
    {
        private readonly Form _form;
        private readonly Control _lastOperationsControl;
        public LastOperationsLogger(Form form, Control lastOperationsControl)
        {
            _form = form;
            _lastOperationsControl = lastOperationsControl;
        }

        public void Add(string msg)
        {
            ControlInvoker.SetControlText(_form, _lastOperationsControl, new LastOperationsLogItem(msg).ToString(), true);
        }
    }
}
