using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeBuilderLibrary
{
    public class FlooringOptions
    {
        private int flooringOptionsID;
        private string flooringType;
        private string durability;
        private float cost;
        private string installationEase;
        

        public FlooringOptions() 
        {
            this.flooringOptionsID = 0;
            this.flooringType = string.Empty; 
            this.durability = string.Empty;
            this.cost = 0;
            this.installationEase = string.Empty;
        }
        public int FlooringOptionsID
        {
            get { return flooringOptionsID; }
            set { flooringOptionsID = value; }
        }

        public string FlooringType
        {
            get { return flooringType; }
            set { flooringType = value; }
        }

        public string Durability
        {
            get { return durability; }
            set { durability = value; }
        }

        public float Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public string InstallationEase
        {
            get { return installationEase; }
            set { installationEase = value; }
        }

    }
}
