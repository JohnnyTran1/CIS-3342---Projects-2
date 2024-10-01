using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilderLibrary
{
    public class HomePlans
    {
        private int homePlansID;
        private string name;
        private string description;
        private int numberOfBedrooms;
        private int numberOfBathrooms;
        private float squareFootage;
        private float price;
        private string homeImage;
        private string floorPlanImage;

        public HomePlans()
        {

            this.homePlansID = 0;
            this.name = string.Empty;
            this.description = string.Empty;
            this.numberOfBedrooms = 0;
            this.numberOfBathrooms = 0;
            this.squareFootage = 0;
            this.price = 0;
            this.homeImage = string.Empty;
            this.floorPlanImage = string.Empty;
        }

        public HomePlans(int homePlansID, string name, string description, int numberOfBedrooms, int numberOfBathrooms, float squareFootage, float price, string homeImage, string floorPlanImage)
        {
            this.homePlansID = homePlansID;
            this.name = name;
            this.description = description;
            this.numberOfBedrooms = numberOfBedrooms;
            this.numberOfBathrooms = numberOfBathrooms;
            this.squareFootage = squareFootage;
            this.price = price;
            this.homeImage = homeImage;
            this.floorPlanImage = floorPlanImage;
        }

        public int HomePlansID
        {
            get { return this.homePlansID; }
            set { this.homePlansID = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public int NumberOfBedrooms
        {
            get { return this.numberOfBedrooms; }
            set { this.numberOfBedrooms = value; }
        }

        public int NumberOfBathrooms
        {
            get { return this.numberOfBathrooms; }
            set { this.numberOfBathrooms = value; }
        }

        public float SquareFootage
        {
            get { return this.squareFootage; }
            set { this.squareFootage = value; }
        }

        public float Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public string HomeImage
        {
            get { return this.homeImage; }
            set { this.homeImage = value; }
        }

        public string FloorPlanImage
        {
            get { return this.floorPlanImage; }
            set { this.floorPlanImage = value; }
        }
    }
}
