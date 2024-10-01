using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilderLibrary
{
    public class CountertopOptions
    {
        private int countertopOptionsId;
        private string countertopTypes;
        private string durability;
        private float cost;
        private string installationEase;

        public CountertopOptions() 
        {
            this.countertopOptionsId = 0;
            this.countertopTypes = string.Empty; 
            this.durability = string.Empty;
            this.cost = 0;
            this.installationEase = string.Empty;
        }

        public CountertopOptions(int countertopOptionsId, string countertopTypes, string durability, float cost, string installationEase)
        {
            this.countertopOptionsId = countertopOptionsId;
            this.countertopTypes = countertopTypes;
            this.durability = durability;
            this.cost = cost;
            this.installationEase = installationEase;
        }

        public int CountertopOptionsId 
        { 
            get {  return this.countertopOptionsId; } 
            set { this.countertopOptionsId = value;}
        }

        public string CountertopType
        { 
            get { return this.countertopTypes;} 
            set { this.countertopTypes = value;}
        }

        public string Durability
        {
            get { return this.durability;}
            set { this.durability = value;}
        }

        public float Cost
        {
            get { return this.cost; }
            set { this.cost = value; }
        }

        public string InstallationEase
        {
            get { return this.installationEase; }
            set { this.installationEase = value;}
        }
    }
}
