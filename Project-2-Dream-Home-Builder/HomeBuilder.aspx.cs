using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using HomeBuilderLibrary;
using System.Data;
using System.EnterpriseServices;
using System.Collections;
using System.Data.SqlClient;

namespace Project_2_Dream_Home_Builder
{
    public partial class HomeBuilder : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        List<HomePlans> selectedHomePlans = new List<HomePlans>();
        List<RoofingMaterialOptions> selectedRoofingMaterialOption = new List<RoofingMaterialOptions>();
        List<HomeAdditions> selectedHomeAdditions = new List<HomeAdditions>();
        List<CountertopOptions> selectedCountertopOptions = new List<CountertopOptions>();
        List<FlooringOptions> selectedFlooringOptions = new List<FlooringOptions>();
        DBConnect objDB = new DBConnect();

        SqlCommand objCommand = new SqlCommand();

        string strSQL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //HideColumnsInGridView();


                DataSet myDataHomePlans = dBConnect.GetDataSet("SELECT * FROM HomePlans");
                gvHomePlans.DataSource = myDataHomePlans;
                gvHomePlans.DataBind();

                String strSQLRoofingMaterialOptions = "SELECT * FROM RoofingMaterialOptions";
                ddlRoofingMaterialOptions.DataSource = dBConnect.GetDataSet(strSQLRoofingMaterialOptions);
                ddlRoofingMaterialOptions.DataTextField = "MaterialName";
                ddlRoofingMaterialOptions.DataValueField = "RoofMaterialOptionsId";
                ddlRoofingMaterialOptions.DataBind();

                //DataSet myDataCounterTopOptions = dBConnect.GetDataSet("SELECT * FROM CounterTopOptions");
                //gvCountertopOptions.DataSource = myDataCounterTopOptions;
                //gvCountertopOptions.DataBind();

                String strSQLCountertopOptions = "SELECT * FROM CountertopOptions";
                ddlCountertopOptions.DataSource = dBConnect.GetDataSet(strSQLCountertopOptions);
                ddlCountertopOptions.DataTextField = "CountertopTypes";
                ddlCountertopOptions.DataValueField = "CountertopOptionsId";
                ddlCountertopOptions.DataBind();

                //DataSet myDataFlooringOptions = dBConnect.GetDataSet("SELECT * FROM FlooringOptions");
                //gvFlooringOptions.DataSource = myDataFlooringOptions;
                //gvFlooringOptions.DataBind();

                String strSQLFlooringOptions = "SELECT * FROM FlooringOptions";
                ddlFlooringOptions.DataSource = dBConnect.GetDataSet(strSQLFlooringOptions);
                ddlFlooringOptions.DataTextField = "FlooringType";
                ddlFlooringOptions.DataValueField = "FlooringOptionsId";
                ddlFlooringOptions.DataBind();

                DataSet myDataHomeAdditions = dBConnect.GetDataSet("SELECT * FROM HomeAdditions");
                gvHomeAdditions.DataSource = myDataHomeAdditions;
                gvHomeAdditions.DataBind();

                //String strSQLHomeAdditions = "SELECT * FROM HomeAdditions";
                //ddlHomeAdditions.DataSource = dBConnect.GetDataSet(strSQLHomeAdditions);
                //ddlHomeAdditions.DataTextField = "Name";
                //ddlHomeAdditions.DataValueField = "HomeAdditionsId";
                //ddlHomeAdditions.DataBind();

           
                //gvHomePlans.DataTextField = "CustomerName";
                //gvHomePlans.DataValueField = "HomePlansID";
                //gvHomePlans.DataBind();
            }

        }


        protected void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        public void ShowHomeAdditions(String theName)
        {
            String strSQLHomeAdditions = "SELECT * FROM HomeAdditions WHERE HomeAdditionsId = '" + theName + "'";
            gvHomeAdditions.DataSource = dBConnect.GetDataSet(strSQLHomeAdditions);
            gvHomeAdditions.DataBind();
        }

        public void ShowRoofingMaterialOptions(String theName)
        {
            String strSQLRoofingMaterialOptions = "SELECT * FROM RoofingMaterialOptions WHERE RoofMaterialOptionsId = '" + theName + "'";
            gvRoofingMaterialOptions.DataSource = dBConnect.GetDataSet(strSQLRoofingMaterialOptions);
            gvRoofingMaterialOptions.DataBind();
        }

        public void ShowCountertopOptions(String theName)
        {
            String strSQLCountertopOptions = "SELECT * FROM CountertopOptions WHERE CountertopOptionsId = '" + theName + "'";
            gvCountertopOptions.DataSource = dBConnect.GetDataSet(strSQLCountertopOptions);
            gvCountertopOptions.DataBind();
        }

        public void ShowFlooringOptions(String theName)
        {
            String strSQLFlooringOptions = "SELECT * FROM FlooringOptions WHERE FlooringOptionsId = '" + theName + "'";
            gvFlooringOptions.DataSource = dBConnect.GetDataSet(strSQLFlooringOptions);
            gvFlooringOptions.DataBind();
        }

        //For my gridview, I was hiding my columns this way initial rather than doing it on the css style. I wanted to show it i did this way as well
        private void HideColumnsInGridView()
        {
            gvHomePlans.Columns[0].Visible = false;
            gvHomePlans.Columns[7].Visible = false;
            gvHomePlans.Columns[8].Visible = false;

            gvRoofingMaterialOptions.Columns[0].Visible = false;
            gvCountertopOptions.Columns[0].Visible = false;
            gvFlooringOptions.Columns[0].Visible = false;
            gvHomeAdditions.Columns[0].Visible = false;
        }
        private void ListRoofingMaterialOptions()
        {
            RoofingMaterialOptions roofingMaterial = new RoofingMaterialOptions
            {
                RoofMaterialOptionsID = Convert.ToInt32(gvRoofingMaterialOptions.SelectedRow.Cells[0].Text),
                MaterialName = gvRoofingMaterialOptions.SelectedRow.Cells[1].Text,
                Durability = gvRoofingMaterialOptions.SelectedRow.Cells[2].Text,
                Cost = Convert.ToInt32(gvRoofingMaterialOptions.SelectedRow.Cells[3].Text),
                InstallationEase = gvRoofingMaterialOptions.SelectedRow.Cells[4].Text,

            };
            selectedRoofingMaterialOption.Add(roofingMaterial);

            Session["SelectedRoofingMaterialOptions"] = selectedRoofingMaterialOption;
        }

        private void ListCountertopOptions()
        {
            CountertopOptions countertop = new CountertopOptions
            {
                CountertopOptionsId = Convert.ToInt32(gvCountertopOptions.SelectedRow.Cells[0].Text),
                CountertopType = gvCountertopOptions.SelectedRow.Cells[1].Text,
                Durability = gvCountertopOptions.SelectedRow.Cells[2].Text,
                Cost = Convert.ToInt32(gvCountertopOptions.SelectedRow.Cells[3].Text),
                InstallationEase = gvCountertopOptions.SelectedRow.Cells[4].Text,

            };
            selectedCountertopOptions.Add(countertop);

            Session["SelectedCounterTopOptions"] = selectedCountertopOptions;
        }

        private void ListFlooringOptions()
        {
            FlooringOptions floor = new FlooringOptions
            {
                FlooringOptionsID = Convert.ToInt32(gvFlooringOptions.SelectedRow.Cells[0].Text),
                FlooringType = gvFlooringOptions.SelectedRow.Cells[1].Text,
                Durability = gvFlooringOptions.SelectedRow.Cells[2].Text,
                Cost = Convert.ToInt32(gvFlooringOptions.SelectedRow.Cells[3].Text),
                InstallationEase = gvFlooringOptions.SelectedRow.Cells[4].Text,

            };
            selectedFlooringOptions.Add(floor);

            Session["SelectedFlooringOptions"] = selectedFlooringOptions;
        }

        private void ListHomeAdditions()
        {
            //Pascucci's website: https://cis-iis2.temple.edu/users/pascucci/cis3342/GridViewExample2_codebehind.htm

            foreach (GridViewRow row in gvHomeAdditions.Rows)
            {
                CheckBox chkAddsOn = (CheckBox)row.FindControl("chkAddsOn");
                if (chkAddsOn.Checked)
                {
                    int homeAdditionsID = Convert.ToInt32(gvHomeAdditions.DataKeys[row.RowIndex].Value);
                    string name = row.Cells[1].Text;
                    string durability = row.Cells[2].Text;
                    int cost = Convert.ToInt32(row.Cells[3].Text);
                    string installationEase = row.Cells[4].Text;
                    bool availability = bool.Parse(row.Cells[5].Text);
                    HomeAdditions homeAdditions = new HomeAdditions
                    {
                        HomeAdditionsID = homeAdditionsID,
                        Name = name,
                        Durability = durability,
                        Cost = cost,
                        InstallationEase = installationEase,
                        Availability = availability
                    };
                    selectedHomeAdditions.Add(homeAdditions);
                }
            }
            Session["SelectedHomeAdditions"] = selectedHomeAdditions;
        }
        private void ListHomePlans() {
            HomePlans plan = new HomePlans
            {
                HomePlansID = Convert.ToInt32(gvHomePlans.SelectedRow.Cells[0].Text),
                Name = gvHomePlans.SelectedRow.Cells[1].Text,
                Description = gvHomePlans.SelectedRow.Cells[2].Text,
                NumberOfBedrooms = Convert.ToInt32(gvHomePlans.SelectedRow.Cells[3].Text),
                NumberOfBathrooms = Convert.ToInt32(gvHomePlans.SelectedRow.Cells[4].Text),
                SquareFootage = float.Parse(gvHomePlans.SelectedRow.Cells[5].Text),
                Price = float.Parse(gvHomePlans.SelectedRow.Cells[6].Text),
                HomeImage = gvHomePlans.SelectedRow.Cells[7].Text,
                FloorPlanImage = gvHomePlans.SelectedRow.Cells[8].Text,
            };
            selectedHomePlans.Add(plan);

            Session["SelectedHomePlans"] = selectedHomePlans;

            Session["SelectedHomePlansID"] = Convert.ToInt32(gvHomePlans.SelectedRow.Cells[0].Text);
            Session["SelectedHomePlansName"] = gvHomePlans.SelectedRow.Cells[1].Text;
            Session["SelectedHomePlansDescription"] = gvHomePlans.SelectedRow.Cells[2].Text;
            Session["SelectedHomePlansNumberOfBedrooms"] = Convert.ToInt32(gvHomePlans.SelectedRow.Cells[3].Text);
            Session["SelectedHomePlansNumberOfBathrooms"] = Convert.ToInt32(gvHomePlans.SelectedRow.Cells[4].Text);
            Session["SelectedHomePlansSquareFootage"] = float.Parse(gvHomePlans.SelectedRow.Cells[5].Text);
            Session["SelectedHomePlansPrice"] = float.Parse(gvHomePlans.SelectedRow.Cells[6].Text);
            Session["SelectedHomePlansHomeImage"] = gvHomePlans.SelectedRow.Cells[7].Text;
            Session["SelectedHomePlansFloorPlanImage"] = gvHomePlans.SelectedRow.Cells[8].Text;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //After the page isvalid, the sessions will occured and save the data being transfer to the next aspx page
            //Page.Validate();
            if (Page.IsValid)
            {

                Session["FirstName"] = txtFirstName.Text;

                Session["LastName"] = txtLastName.Text;

                Session["Suffix"] = ddlSuffix.SelectedItem.Text;

                Session["EmailAddress"] = txtEmailAddress.Text;

                Session["Address"] = txtAddress.Text;

                Session["PhoneNumber"] = txtPhoneNumber.Text;

                Session["EmploymentInformation"] = txtEmploymentInformation.Text;

                Session["Income"] = txtIncome.Text;

                Session["ExpectedToMovieIn"] = calExpectedMoveInDate.SelectedDate.ToString();

                Session["ReadyToMovieIn"] = calReadyToMoveIn.SelectedDate.ToString();

                ListRoofingMaterialOptions();
                ListHomeAdditions();
                ListCountertopOptions();
                ListFlooringOptions();
                ListHomePlans();

                Response.Redirect("HomeBuilderResult.aspx");

            }
            else
            {
                return;
            }
        }

        //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
        //Name only contains letters
        protected void rfvName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text, @"^[a-zA-Z]+$");

        }

        protected void gvHomePlans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Event handler when the user selected on the gridview
            imgDisplayHomeImage.ImageUrl = gvHomePlans.SelectedRow.Cells[7].Text;
            imgDisplayFloorPlan.ImageUrl = gvHomePlans.SelectedRow.Cells[8].Text;
            //lblAddress.Text = gvHomePlans.SelectedRow.Cells[7].Text.ToString();
            imgDisplayHomeImage.Visible = true;
            
            imgDisplayFloorPlan.Visible = true;
        }

        protected void valEmailAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrWhiteSpace(txtEmailAddress.Text);
        }

        protected void vadAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrWhiteSpace(txtAddress.Text);
        }

        //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
        //Only contains 10 digits numbers
        protected void valPhoneNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtPhoneNumber.Text, @"^\d{10}$");
        }

        protected void valEmploymentInformation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrWhiteSpace(txtEmploymentInformation.Text);
        }

        //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
        //Income obsivouly, you need to have an input between 0-9 and it must be postive
        protected void valIncome_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtIncome.Text, @"^[0-9]+$");
        }

        //user must selected a date on the calendar and also cant pick a date before the present time
        //Cant go back in time and schedule a day to do it, physiically impossble
        protected void valMoveInDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = calExpectedMoveInDate.SelectedDate != DateTime.MinValue &&
                   calExpectedMoveInDate.SelectedDate.Date >= DateTime.Now.Date;
        }

        //user must selected a date on the calendar and also cant pick a date before the present time
        //Cant go back in time and schedule a day to do it, physiically impossble
        protected void valReadyToMoveIn_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = calReadyToMoveIn.SelectedDate != DateTime.MinValue &&
                   calReadyToMoveIn.SelectedDate.Date >= DateTime.Now.Date;
        }

        protected void valHomePlans_ServerValidate(object source, ServerValidateEventArgs args)
        {
           args.IsValid = gvHomePlans.SelectedValue != null;
        }

        protected void ddlRoofingMaterialOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowRoofingMaterialOptions(ddlRoofingMaterialOptions.SelectedValue);

        }

        protected void ddlCountertopOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCountertopOptions(ddlCountertopOptions.SelectedValue);            
        }

        protected void ddlFlooringOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowFlooringOptions(ddlFlooringOptions.SelectedValue);
        }

        //protected void ddlHomeAdditions_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowHomeAdditions(ddlHomeAdditions.SelectedValue);
        //}

        protected void valRoofingMaterialOptions_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = gvRoofingMaterialOptions.SelectedValue != null;

        }

        protected void valCountertopOptions_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = gvCountertopOptions.SelectedValue != null;
        }

        protected void valFlooringOption_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = gvFlooringOptions.SelectedValue != null;
        }

        protected void valLastName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //I used the mircosoft learn and copy their patterns 
            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=net-8.0
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(txtLastName.Text, @"^[a-zA-Z]+$");

        }


    }
} 