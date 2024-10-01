<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeBuilder.aspx.cs" Inherits="Project_2_Dream_Home_Builder.HomeBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Builder</title>
    <link href="Style/HomeBuilder.css" rel="stylesheet" />
    <link rel="icon" type="image/x-icon" href="Image/HouseEmoji.png"/>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

        <div class="titleNav">
            <img src="Image/BobTheBuilder.png" alt="Logo"/>
            <h1>Home Builder </h1>
        </div>

        <div class ="Questions">
        <h2>Enter your information</h2>
            <div>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <!-- Pascucci's website Validators Example 2: it's used customvalidator-->
                <asp:CustomValidator ID="valFirstName" runat="server" 
                    ErrorMessage="First name is required (Letters only)." ForeColor="Red" 
                    OnServerValidate="rfvName_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            </div>

            <div>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <!-- Pascucci's website Validators Example 2: it's used customvalidator-->
                <asp:CustomValidator ID="valLastName" runat="server" 
                    ErrorMessage="Last name is required Letter only)." ForeColor="Red" 
                    OnServerValidate="valLastName_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            </div>

            <div>
                <asp:Label ID="lblSuffix" runat="server" Text="Suffix: "></asp:Label>
                <asp:DropDownList ID="ddlSuffix" runat="server">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                    <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                    <asp:ListItem Text="Ms." Value="Ms."></asp:ListItem>
                    <asp:ListItem Text="Dr." Value="Dr."></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address: "></asp:Label>
                <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
        <!-- Pascucci's website Validators Example 2: it's used customvalidator-->
                <asp:CustomValidator ID="valEmailAddress" runat="server"
                    ErrorMessage="Email Address is required." ForeColor="Red" 
                    OnServerValidate="valEmailAddress_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            </div>

            <div>
                <asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                <!-- Pascucci's website Validators Example 2: it's used customvalidator-->
                <asp:CustomValidator ID="vadAddress" runat="server"
                    ErrorMessage="Address is required." ForeColor="Red" 
                    OnServerValidate="vadAddress_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            </div>

            <div>
                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number: "></asp:Label>
                <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
            <!-- Pascucci's website Validators Example 2: it's used customvalidator-->
                <asp:CustomValidator ID="valPhoneNumber" runat="server" 
                    ErrorMessage="Phone number is required (Accept 10 digits numbers)." ForeColor="Red"
                    OnServerValidate="valPhoneNumber_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            </div>

            <div>
                <asp:Label ID="lblEmploymentInformation" runat="server" Text="Employment Information: "></asp:Label>
                <asp:TextBox ID="txtEmploymentInformation" runat="server"></asp:TextBox>
         <!-- Pascucci's website Validators Example 2: it's used customvalidator-->
                <asp:CustomValidator ID="valEmploymentInformation" runat="server"
                    ErrorMessage="Employment information is required." ForeColor="Red" 
                    OnServerValidate="valEmploymentInformation_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            </div>

            <div>
                <asp:Label ID="lblIncome" runat="server" Text="Income: "></asp:Label>
                <asp:TextBox ID="txtIncome" runat="server"></asp:TextBox>
                <!-- Pascucci's website Validators Example 2: it's used customvalidator-->
                <asp:CustomValidator ID="valIncome" runat="server"
                    ErrorMessage="Income is required (0-9 only)." ForeColor="Red" 
                    OnServerValidate="valIncome_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            </div>
        </div>

        <div class ="Calendar">
            <div>
                <asp:Label ID="lblMoveInDate" runat="server" Text="Select the expected move-in date: "></asp:Label>
            <!-- Calendar doesnt have an autopostback propteries I found this on stackoverflow to avoid doing a postback everything someone clicks a day https://stackoverflow.com/questions/20581764/calendar-control-without-postback-->
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Calendar ID="calExpectedMoveInDate" runat="server"></asp:Calendar>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                <!-- Pascucci's website Validators Example 2: it's used customvalidator-->
                    <asp:CustomValidator ID="valMoveInDate" runat="server" 
                    ErrorMessage="A valid present or future day for expected move-in date is required." ForeColor="Red" 
                    OnServerValidate="valMoveInDate_ServerValidate"></asp:CustomValidator>
            </div>

            <div>
                <asp:Label ID="lblReadyToMoveIn" runat="server" Text="Select the ready to move-in date: "></asp:Label>
            <!-- Calendar doesnt have an autopostback propteries I found this on stackoverflow to avoid doing a postback everything someone clicks a day https://stackoverflow.com/questions/20581764/calendar-control-without-postback-->
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                <asp:Calendar ID="calReadyToMoveIn" runat="server"></asp:Calendar>
                    </ContentTemplate>
                </asp:UpdatePanel>
         <!-- Pascucci's website Validators Example 2: it's used customvalidator-->
                <asp:CustomValidator ID="valReadyToMoveIn" runat="server" 
                    ErrorMessage="A valid present or future day for ready to move-in date is required." ForeColor="Red" 
                    OnServerValidate="valReadyToMoveIn_ServerValidate"></asp:CustomValidator>
            </div>
        </div>

        <div class="HomePlans">
            <h2>Select a home plan: </h2>
            <asp:GridView ID="gvHomePlans" runat="server" AutoGenerateColumns="False" DataKeyNames="HomePlansId" OnSelectedIndexChanged="gvHomePlans_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="HomePlansId" HeaderText="ID" HeaderStyle-CssClass="hiddenColumn" ItemStyle-CssClass="hiddenColumn" >
                    </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="NumberOfBedrooms" HeaderText="Number of bedrooms" />
                        <asp:BoundField DataField="NumberOfBathrooms" HeaderText="Number of bathrooms" />
                        <asp:BoundField DataField="SquareFootage" HeaderText="Square footage" />
                        <asp:BoundField DataField="Cost" HeaderText="Price" />
                        <asp:BoundField DataField="HomeImage" HeaderText="Home image" HeaderStyle-CssClass="hiddenColumn" ItemStyle-CssClass="hiddenColumn" >
                        </asp:BoundField>
                            <asp:BoundField DataField="FloorPlanImage" HeaderText="Floor plan image"  HeaderStyle-CssClass="hiddenColumn" ItemStyle-CssClass="hiddenColumn">
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Button" HeaderText="Select" ShowHeader="True" ShowSelectButton="True"/>
                </Columns>
            </asp:GridView>
            <asp:CustomValidator ID="valHomePlans" runat="server" 
                ErrorMessage="Select a home plan." ForeColor="Red" 
                OnServerValidate="valHomePlans_ServerValidate">
            </asp:CustomValidator>
            <div class="HomeImages">
                <div class="desc">Images</div>
                 <asp:Image ID="imgDisplayHomeImage" runat="server" OnDataBinding="gvHomePlans_SelectedIndexChanged" />
                <div class="desc">Home image</div>
                <asp:Image ID="imgDisplayFloorPlan" runat="server" Visible="false" />
                <div class="desc">Home floor plan image</div>
            </div>
        </div>

        <div class ="dropdownList">
            <div>
                <asp:Label ID="lblRoofingMaterialOptions" runat="server" Text="Select a roofing material options: "></asp:Label>
                <asp:DropDownList ID="ddlRoofingMaterialOptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoofingMaterialOptions_SelectedIndexChanged">
                </asp:DropDownList>

                <asp:GridView ID="gvRoofingMaterialOptions" runat="server" AutoGenerateColumns="False" DataKeyNames="RoofMaterialOptionsId">
                    <Columns>
                        <asp:BoundField DataField="RoofMaterialOptionsId" HeaderText="False" HeaderStyle-cssClass="hiddenColumn" ItemStyle-CssClass="hiddenColumn" />
                        <asp:BoundField DataField="MaterialName" HeaderText="Name" />
                        <asp:BoundField DataField="Durability" HeaderText="Durability" />
                        <asp:BoundField DataField="Cost" HeaderText="Cost" />
                        <asp:BoundField DataField="InstallationEase" HeaderText="Installation Ease" />
                        <asp:CommandField ButtonType="Button" HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                     ControlToValidate="ddlRoofingMaterialOptions"
                     ErrorMessage="Select a roofing material option." ForeColor="Red" 
                     OnServerValidate="valRoofingMaterialOptions_ServerValidate" 
                     ValidateEmptyText="True"></asp:CustomValidator>
            </div>

            <div>
                <asp:Label ID="lblCountertopOptions" runat="server" Text="Select a countertop option: "></asp:Label>
                <asp:DropDownList ID="ddlCountertopOptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountertopOptions_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:GridView ID="gvCountertopOptions" runat="server" AutoGenerateColumns="False" DataKeyNames="CountertopOptionsId" >
                    <Columns>
                        <asp:BoundField DataField="CountertopOptionsId" HeaderText="ID" HeaderStyle-CssClass="hiddenColumn" ItemStyle-CssClass="hiddenColumn"/>
                        <asp:BoundField DataField="CountertopTypes" HeaderText="Name" />
                        <asp:BoundField DataField="Durability" HeaderText="Durability" />
                        <asp:BoundField DataField="Cost" HeaderText="Price" />
                        <asp:BoundField DataField="InstallationEase" HeaderText="Installation Ease" />
                        <asp:CommandField ButtonType="Button" HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:CustomValidator ID="valCountertopOptions" runat="server" 
                    ErrorMessage="Select a countertop option." ForeColor="Red" 
                    OnServerValidate="valCountertopOptions_ServerValidate">
                </asp:CustomValidator>
            </div>

            <div>
                <asp:Label ID="lblFlooringOptions" runat="server" Text="Select a flooring option: "></asp:Label>
                <asp:DropDownList ID="ddlFlooringOptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFlooringOptions_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:GridView ID="gvFlooringOptions" runat="server" AutoGenerateColumns="False" DataKeyNames="FlooringOptionsId" >
                    <Columns>
                        <asp:BoundField DataField="FlooringOptionsId" HeaderText="ID" HeaderStyle-CssClass="hiddenColumn" ItemStyle-CssClass="hiddenColumn"/>
                        <asp:BoundField DataField="FlooringType" HeaderText="Name" />
                        <asp:BoundField DataField="Durability" HeaderText="Durability" />
                        <asp:BoundField DataField="Cost" HeaderText="Price" />
                        <asp:BoundField DataField="InstallationEase" HeaderText="Installation Ease" />
                        <asp:CommandField ButtonType="Button" HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:CustomValidator ID="valFlooringOption" runat="server" 
                    ErrorMessage="Select a flooring option." ForeColor="Red" 
                    OnServerValidate="valFlooringOption_ServerValidate">
                </asp:CustomValidator>
                <asp:Label ID="lblfloorInfo" runat="server" Text="Floor's cost times Home plans' square footage for real cost "></asp:Label>
            </div>
        </div>

        <div class = "HomeAdditions">
            <h2>Select a home additions option: </h2>
            <asp:GridView ID="gvHomeAdditions" runat="server" AutoGenerateColumns="False" DataKeyNames="HomeAdditionsId" >
                <Columns>
                    <asp:BoundField DataField="HomeAdditionsId" HeaderText="ID" HeaderStyle-CssClass="hiddenColumn" ItemStyle-CssClass="hiddenColumn">
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Durability" HeaderText="Durability" />
                    <asp:BoundField DataField="Cost" HeaderText="Price" />
                    <asp:BoundField DataField="InstallationEase" HeaderText="Installation Ease" />
                    <asp:BoundField DataField="Availability" HeaderText="Availability" HeaderStyle-CssClass="hiddenColumn" ItemStyle-CssClass="hiddenColumn"/>
                    <asp:TemplateField HeaderText="Select Adds on">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAddsOn" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class ="button">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Height="43px" Width="96px"/>
        </div>

        <div id="footer">
            <p>Home Builder</p>
        </div>
    </form>
</body>
</html>
