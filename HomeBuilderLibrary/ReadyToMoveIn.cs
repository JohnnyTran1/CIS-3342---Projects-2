using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilderLibrary
{
    public class ReadyToMoveIn
    {
        private string readyToMoveInDate;

        public ReadyToMoveIn()
        {
            this.readyToMoveInDate = string.Empty;
        }

        public ReadyToMoveIn(string readyToMoveIn)
        {
            this.readyToMoveInDate = readyToMoveIn;
        }

        public string ReadyToMoveInDate
        {
            get { return readyToMoveInDate;  }
            set { readyToMoveInDate = value; }
        }
    }
}
