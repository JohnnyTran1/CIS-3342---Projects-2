using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilderLibrary
{
    public class RoofingMaterialOptions
    {
        private int roofMaterialOptionsID;
        private string materialName;
        private string durability;
        private float cost;
        private string installationEase;

        public RoofingMaterialOptions() 
        {
            this.roofMaterialOptionsID = 0;
            this.materialName = string.Empty; 
            this.durability = string.Empty;
            this.cost = 0;
            this.installationEase = string.Empty;
        }

        public RoofingMaterialOptions(int roofMaterialOptionsID, string materialName, string durability, float cost, string installationEase)
        {
            this.roofMaterialOptionsID = roofMaterialOptionsID;
            this.materialName = materialName;
            this.durability = durability;
            this.cost = cost;
            this.installationEase = installationEase;
        }

       public int RoofMaterialOptionsID
       {
            get { return roofMaterialOptionsID; }
            set { roofMaterialOptionsID = value; }
       }

        public string MaterialName
        {
            get { return materialName; }
            set { materialName = value; }
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
