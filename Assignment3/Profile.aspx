<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Assignment3.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    

        <div>
            <h1>Welcome!, <asp:Label ID="Label1" runat="server"></asp:Label></h1>
            
        </div>

        <asp:Table ID="Table1" runat="server" Height="61px" Width="733px" GridLines="Both" BorderColor ="blue">
            
            <asp:TableRow>
                <asp:TableCell ID="TableCell1" runat="server" Text="Customer Name">
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server" Text="Address">
                </asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server" Text="Postal Code">
                </asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server" Text="Phone">
                </asp:TableCell>
                <asp:TableCell ID="TableCell5" runat="server" Text="Email">
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell ID="TableCell6" runat="server" Text="">
                </asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="server" Text="">
                </asp:TableCell>
                <asp:TableCell ID="TableCell8" runat="server" Text="">
                </asp:TableCell>
                <asp:TableCell ID="TableCell9" runat="server" Text="">
                </asp:TableCell>
                <asp:TableCell ID="TableCell10" runat="server" Text="">
                </asp:TableCell>
            </asp:TableRow>
        
        </asp:Table>
    <br />
    <form id="form1" runat="server">
        <div>


            <h1>Sheridan Car Sales</h1>Customer ID:&nbsp;
            <asp:Label ID="Label4" runat="server"></asp:Label>
&nbsp;<br />
            Brand:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Model:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Year:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Colour:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Price($):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            User Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Order" OnClick="Button1_Click" />


        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back to Login" />


        </div>
        <p>
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
        <div>
            <asp:Button ID="Button3" runat="server" Text="View Sales History" OnClick="Button3_Click" />

            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="185px" Width="552px" ></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        </div>
        
    </form>
</body>
</html>
