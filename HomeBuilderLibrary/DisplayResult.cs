using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilderLibrary
{
    public class DisplayResult
    {
        private string name;
        private float cost;

        public DisplayResult()
        {
            this.name = string.Empty;
            this.cost = 0;
        }

        public DisplayResult(string name, float cost)
        {
            this.name = name;
            this.cost = cost;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public float Cost
        {
            get { return this.cost; }
            set { this.cost = value; }
        }
    }
}
