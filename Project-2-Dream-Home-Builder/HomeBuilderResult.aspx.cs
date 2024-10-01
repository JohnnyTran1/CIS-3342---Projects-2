using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HomeBuilderLibrary;
using Utilities;
using System.Data;
using System.Drawing;
using System.Diagnostics.PerformanceData;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.OleDb;

namespace Project_2_Dream_Home_Builder
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CalculateTotalCost totalCost;
        DBConnect dBConnect = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                String firstName = Session["FirstName"].ToString();

                String lastName = Session["lastName"].ToString();

                String suffix = Session["Suffix"].ToString();

                String emailAddress = Session["EmailAddress"].ToString();

                String Address = Session["Address"].ToString();

                String phoneNumber = Session["Phonenumber"].ToString();

                String employmentInformation = Session["EmploymentInformation"].ToString();

                String income = Session["Income"].ToString();

                String expectedToMoveIn = Session["ExpectedToMovieIn"].ToString();

                String readyToMoveIn = Session["ReadyToMovieIn"].ToString();

                Buyer buyer = new Buyer(firstName, lastName, suffix, emailAddress, Address, phoneNumber, employmentInformation, income);

                ExpectedMoveIn expectedMoveInDate = new ExpectedMoveIn(expectedToMoveIn);

                ReadyToMoveIn readyToMoveInDate = new ReadyToMoveIn(readyToMoveIn);

                List<HomePlans> selectedHomePlans = Session["SelectedHomePlans"] as List<HomePlans>;

                int homeID = Convert.ToInt32(Session["SelectedHomePlansID"]);
                string name = Session["SelectedHomePlansName"].ToString();
                string description =Session["SelectedHomePlansDescription"].ToString();
                int numberOfBedrooms = Convert.ToInt32(Session["SelectedHomePlansNumberOfBedrooms"].ToString());
                int numberOfBathrooms = Convert.ToInt32(Session["SelectedHomePlansNumberOfBathrooms"].ToString());
                int squareFootage = Convert.ToInt32(Session["SelectedHomePlansSquareFootage"].ToString());
                float price = Convert.ToInt32(Session["SelectedHomePlansPrice"]);
                string homeImage =Session["SelectedHomePlansHomeImage"].ToString();
                string floorPlanImage = Session["SelectedHomePlansFloorPlanImage"].ToString();

                HomePlans home = new HomePlans(homeID, name,description,numberOfBedrooms,numberOfBathrooms,squareFootage,price,homeImage,floorPlanImage);

                List<RoofingMaterialOptions> roofingMaterialOptions = Session["SelectedRoofingMaterialOptions"] as List<RoofingMaterialOptions>;

                List<HomeAdditions> homeAdditions = Session["SelectedHomeAdditions"] as List<HomeAdditions>;

                List<CountertopOptions> countertops = Session["SelectedCounterTopOptions"] as List<CountertopOptions>;

                List<FlooringOptions> flooring = Session["SelectedFlooringOptions"] as List<FlooringOptions>;

                //I created 5 list that are object to their classes and have a list thats an object to the DispalyResult class that merge all the lists into one
                //We are only getting the values of name and price to add to the list.
                List<DisplayResult> displayItems = new List<DisplayResult>();
                foreach (HomePlans plans in selectedHomePlans)
                {
                    DisplayResult displayResult = new DisplayResult();
                    displayResult.Name = plans.Name;
                    displayResult.Cost = plans.Price;
                    displayItems.Add(displayResult);


                }
                
                foreach (HomePlans plans in selectedHomePlans)
                {
                    DisplayResult displayResult = new DisplayResult();
                    foreach (FlooringOptions floor in flooring)
                    {

                        displayResult.Name = floor.FlooringType;
                        displayResult.Cost = floor.Cost * plans.SquareFootage;
                        displayItems.Add(displayResult);
                    }
                }
                foreach (RoofingMaterialOptions roofing in roofingMaterialOptions)
                {
                    DisplayResult displayResult = new DisplayResult();
                    displayResult.Name = roofing.MaterialName;
                    displayResult.Cost = roofing.Cost;
                    displayItems.Add(displayResult);
                }
                foreach (HomeAdditions additions in homeAdditions)
                {
                    DisplayResult displayResult = new DisplayResult();
                    displayResult.Name = additions.Name;
                    displayResult.Cost = additions.Cost;
                    displayItems.Add(displayResult);
                }
                foreach (CountertopOptions top in countertops)
                {
                    DisplayResult displayResult = new DisplayResult();
                    displayResult.Name = top.CountertopType;
                    displayResult.Cost = top.Cost;
                    displayItems.Add(displayResult);
                }

                //The object of the DisplayResult will bind the gridview to display all the names of the selected options and their cost
                gvDisplayResult.DataSource = displayItems;
                gvDisplayResult.DataBind();
                CalculateTotalCost calculator = new CalculateTotalCost(selectedHomePlans, roofingMaterialOptions, flooring, homeAdditions, countertops);
                //float totalCost = CalculateTotalCost.GetTotalCost(selectedHomePlans, roofingMaterialOptions, flooring, homeAdditions, countertops);
                //string costDisplay = CalculateTotalCost.DisplayTotalCost(totalCost);
                string costDisplay = calculator.DisplayTotalCost();
                float getCost = calculator.GetTotalCost();



                gvDisplayResult.Columns[0].FooterText = "Totals:";
                gvDisplayResult.Columns[1].FooterText = costDisplay;
                gvDisplayResult.Columns[0].FooterStyle.ForeColor = Color.Red;
                gvDisplayResult.Columns[1].FooterStyle.ForeColor = Color.Red;
                //RoofingMaterialOptions roof = new RoofingMaterialOptions(roofMaterialOptionsID,materialName,durability,cost,installationEase);
                gvDisplayResult.DataBind();


                lblDisplayName.Text = $"Name: {buyer.Suffix} {buyer.FirstName} {buyer.LastName}<br>";

                lblDisplayEmailAddress.Text = $"Email address: {buyer.EmailAddress} <br>";

                lblDisplayPhoneNumber.Text = $"Phone number: {buyer.PhoneNumber} <br>";

                lblDisplayAddress.Text = $"Address: {buyer.Address} <br>";

                lblDisplayEmploymentInformation.Text = $"Employment information: {buyer.EmploymentInformation} <br>";

                lblDisplayIncome.Text = $"Income: {buyer.Income} <br>";

                lblDisplayExpectedToMoveInDate.Text = $"Expected move in date: {expectedMoveInDate.ExpectedMoveInDate} <br>";

                lblDisplayReadyToMovieInDate.Text = $"Ready to move in date: {readyToMoveInDate.ReadyToMoveInDate} <br>";

                int getHomeID = home.HomePlansID;
                int count = 1;

                UpdateTotalCount(getHomeID, count);

                UpdateTotalRevenues(getHomeID, getCost);

                //I was struggling with updating my database table homeSales and I couldnt figured out why and used one of my label to see my ID one
                //Helped me figured out why ID value was zero the whole time
                //lblDisplayEmailAddress.Text = $"Email address: {getHomeID} <br>";


            }

        }

        //Nadia helped me during the lab, doing two methods and each of them updates the total cost and other do total number of homes sold
        private void UpdateTotalCount(int getHomeID, int count)
        {
            //dBConnect.GetDataSet("SELECT")
            string sql;
            //sql = dBConnect.DoUpdate("UPDATE HomeSales SET TotalRevenues = TotalRevenues + @getCost WHERE HomeSalesId = @getHomeID ");
            sql = "UPDATE HomeSales SET TotalHomesSold = TotalHomesSold +" + count + " WHERE HomeSalesId = +" + getHomeID;
            dBConnect.DoUpdate(sql);

        }
        private void UpdateTotalRevenues(int getHomeID, float getCost)
        {
            //dBConnect.GetDataSet("SELECT")
            string sql;
            //sql = dBConnect.DoUpdate("UPDATE HomeSales SET TotalRevenues = TotalRevenues + @getCost WHERE HomeSalesId = @getHomeID ");
            sql = "UPDATE HomeSales SET TotalRevenues = TotalRevenues +" + getCost  + " WHERE HomeSalesId = +" + getHomeID;
            dBConnect.DoUpdate(sql);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeBuilder.aspx");
        }
    }
}