<%@ Page MaintainScrollPositionOnPostback="true" Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Assignment3.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:burlywood; text-align: center;">
    

        <div>
            <h1>Welcome!, <asp:Label ID="Label1" runat="server"></asp:Label></h1>
            
        </div>

        <asp:Table style="margin-left: auto; margin-right:auto;" ID="Table1" runat="server" Height="61px" Width="733px" GridLines="Both" BorderColor ="blue">
            
            <asp:TableRow BackColor="#99CCFF" Font-Bold="True" Font-Italic="True" ForeColor="#000099">
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
        <div style="font-weight: bold">


            <h1>Sheridan Car Sales</h1>Customer ID:&nbsp;
            <asp:Label ID="Label4" runat="server"></asp:Label>
&nbsp;<br />
            <br />
            Brand: 
            <asp:DropDownList ID="DropDownList1" runat="server"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            Model: <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Year: 
            <asp:DropDownList ID="DropDownList4" runat="server" >
            </asp:DropDownList>
            <br />
            <br />
            Colour: <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Ex)xxxxx.xx"></asp:Label>
            <br />
            Price($):
            <asp:TextBox ID="TextBox5" runat="server" MaxLength="8" Width="82px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="Black" ControlToValidate="TextBox5" ErrorMessage="Please, enter this price." ForeColor="Yellow"></asp:RequiredFieldValidator>
            
            <br />
            
            <br />
            User Name:
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" BackColor="Black" ForeColor="Yellow"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" ForeColor="#000066"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Order" OnClick="Button1_Click" BackColor="#000099" ForeColor="White" Font-Bold="True" />
            &nbsp;&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back to Login" BackColor="#CC0000" ForeColor="White" Font-Bold="True" />


            <br />
            <br />
            <br />


        </div>
        <div>
            <br />
            <asp:Button ID="Button3" runat="server" Text="View Sales History" OnClick="Button3_Click" Font-Bold="True" />

            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="ListBox1" runat="server" Height="185px" Width="391px" AutoPostBack="True" ></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        </div>
        
    </form>
</body>
</html>
