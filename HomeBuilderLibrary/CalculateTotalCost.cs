using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeBuilderLibrary;
using System.Data;
using System.Diagnostics.PerformanceData;

namespace HomeBuilderLibrary
{
    public class CalculateTotalCost
    {
        private List<HomePlans> homePlans;
        private List<RoofingMaterialOptions> roofingMaterialOptions;
        private List<FlooringOptions> flooringOptions;
        private List<HomeAdditions> additions;
        private List<CountertopOptions> countertops;
        public CalculateTotalCost(List<HomePlans> homePlans, List<RoofingMaterialOptions> roofingMaterialOptions, List<FlooringOptions> flooringOptions, List<HomeAdditions> additions, List<CountertopOptions> countertops)
        {
            this.homePlans = homePlans;
            this.roofingMaterialOptions = roofingMaterialOptions;
            this.flooringOptions = flooringOptions;
            this.additions = additions;
            this.countertops = countertops;
        }

        //Method will loop each class object to retreive it's value and add the totalcost
        public float GetTotalCost()
        {
            float totalCost = 0;

            foreach (HomePlans plan in homePlans)
            {
                totalCost += plan.Price;
                foreach (FlooringOptions flooring in flooringOptions)
                {
                    totalCost += flooring.Cost*plan.SquareFootage;
                }
            }
            foreach (RoofingMaterialOptions roofing in roofingMaterialOptions)
            {
                totalCost += roofing.Cost;
            }
            foreach (HomeAdditions addition in additions)
            {
                totalCost += addition.Cost;
            }
            foreach (CountertopOptions countertop in countertops)
            {
                totalCost += countertop.Cost;
            }

            return totalCost;
        }


        //convert the value into a string, to be display in the gridveiw
        public string DisplayTotalCost()
        {
            float totalCost = GetTotalCost();
            return $"{totalCost:C}";
        }
    }
}

