using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilderLibrary
{
    public class HomeAdditions
    {
        private int homeAdditionsID;
        private string name;
        private string durability;
        private float cost;
        private string installationEase;
        private bool availability;

        public HomeAdditions()
        {
            this.homeAdditionsID = 0;
            this.name = string.Empty;
            this.durability = string.Empty;
            this.cost = 0;
            this.installationEase = string.Empty;
            this.availability = false;
        }

        public HomeAdditions(int homeAdditionsID, string name, string durability, float cost, string installationEase, bool availability)
        {
            this.homeAdditionsID = homeAdditionsID;
            this.name = name;
            this.durability = durability;
            this.cost = cost;
            this.installationEase = installationEase;
            this.availability = availability;
        }

        public int HomeAdditionsID
        {
            get { return this.homeAdditionsID; }
            set {  this.homeAdditionsID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
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

        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }
    }
}
