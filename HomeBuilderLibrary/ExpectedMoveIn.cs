using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilderLibrary
{
    public class ExpectedMoveIn
    {
        private String expectedMoveInDate;

        public ExpectedMoveIn()
        {
            expectedMoveInDate = string.Empty;
        }

        public ExpectedMoveIn(string expectedMoveInDate)
        {
            this.expectedMoveInDate = expectedMoveInDate; 
        }

        public string ExpectedMoveInDate
        {
            get { return expectedMoveInDate; }
            set { expectedMoveInDate = value; }
        }
    }
}
