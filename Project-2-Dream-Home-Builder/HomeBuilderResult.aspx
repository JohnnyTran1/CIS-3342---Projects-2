<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeBuilderResult.aspx.cs" Inherits="Project_2_Dream_Home_Builder.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/HomeBuilderResult.css" rel="stylesheet" />
    <link rel ="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="titleNav">
            <img src="Image/BobTheBuilder.png" alt="Logo"/>
            <h1>Order Confirmation </h1>
        </div>
        <div>
            <div class ="grid_item">
                <h2>Personal Information: </h2>
                <asp:Label ID="lblDisplayName" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblDisplayEmailAddress" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblDisplayAddress" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblDisplayPhoneNumber" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblDisplayEmploymentInformation" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblDisplayIncome" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblDisplayExpectedToMoveInDate" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblDisplayReadyToMovieInDate" runat="server" Text="Label"></asp:Label>
            </div>
            <div class ="grid_item">
                <h2>Home Options and cost: </h2>
                <asp:GridView ID="gvDisplayResult" runat="server" AutoGenerateColumns="False" ShowFooter="True">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Cost" HeaderText="Cost" DataFormatString="{0:C}" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="button">            
                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="Button1_Click" Height="37px" Width="104px" />
            </div>
        </div>
         <div id="footer">
            <p>Thank you for your submission!</p>
        </div>
    </form>
</body>
</html>
