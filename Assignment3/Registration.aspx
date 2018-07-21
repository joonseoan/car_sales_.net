<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Assignment3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style = "background-color: burlywood; text-align: center;">
    <div>

    
        <form id="form1" runat="server">

    
        <div>

            <h1>Customer Registration</h1>

        </div>
            <div style="font-weight: bold; background-color: #008080; width: 635px; text-align : center; margin-left: auto; margin-right:auto;">
                <asp:Label style="margin-top: 50px;" ID="Label1" runat="server" Text="User Name"></asp:Label>
                :
                <asp:TextBox style="margin-top: 50px;" ID="TextBox1" runat="server" Width="207px"></asp:TextBox>
                <br />
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Please, enter user name." BackColor="Black" ForeColor="Yellow"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>
                :
                <asp:TextBox ID="TextBox2" runat="server" Width="206px"></asp:TextBox>
                <br />
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Please, enter your address." BackColor="Black" ForeColor="Yellow"></asp:RequiredFieldValidator>
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label12" runat="server" Text="Alphbetical Letter must be upper letters." Font-Italic="True" Font-Size="X-Small"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Postal Code"></asp:Label>
                :
                <asp:TextBox ID="TextBox3" runat="server" Width="34px" MaxLength="3"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox8" runat="server" Width="32px" MaxLength="3"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Please, enter your postal code." BackColor="Black" ForeColor="Yellow"></asp:RequiredFieldValidator>
&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox8" Display="Dynamic" ErrorMessage="Please, enter your postal code." BackColor="Black" ForeColor="Yellow"></asp:RequiredFieldValidator>
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label10" runat="server" Text="Ex) xxx-xxx-xxxx" Font-Italic="True" Font-Size="X-Small"></asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Phone Number"></asp:Label>
                :
                <asp:TextBox ID="TextBox4" runat="server" Width="103px" MaxLength="12"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="Please, enter your telephone number." BackColor="Black" ForeColor="Yellow"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="Enter a correct number." ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" BackColor="Black" ForeColor="Yellow"></asp:RegularExpressionValidator>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
                :
                <asp:TextBox ID="TextBox5" runat="server" Width="201px"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="Please, enter your email." BackColor="Black" ForeColor="Yellow"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="You must type an email!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" BackColor="Black" ForeColor="Yellow"></asp:RegularExpressionValidator>
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Email (Confirmation)"></asp:Label>
                :
                <asp:TextBox ID="TextBox6" runat="server" Width="201px"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" Display="Dynamic" ErrorMessage="Please, enter your email again!" BackColor="Black" ForeColor="Yellow"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox6" Display="Dynamic" ErrorMessage="You must type an email!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" BackColor="Black" ForeColor="Yellow"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox5" ControlToValidate="TextBox6" Display="Dynamic" ErrorMessage="You must type a same email as above" BackColor="Black" ForeColor="Yellow"></asp:CompareValidator>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label9" runat="server" Text="It must be 8 - 12 any characters." Font-Italic="True" Font-Size="X-Small"></asp:Label>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Password"></asp:Label>
                :
                <asp:TextBox ID="TextBox7" runat="server" Width="64px" MaxLength="12" TextMode="Password"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox7" Display="Dynamic" ErrorMessage="Please, enter a password." BackColor="Black" ForeColor="Yellow"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;<br />
                &nbsp;<br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" BackColor="Black" ForeColor="Yellow" Font-Bold="True"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="#0000CC"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button style="margin-bottom: 50px;" ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" BackColor="#000066" ForeColor="White" Font-Bold="True" />
                <asp:Button style="margin-bottom: 50px;" ID="Button2" runat="server" OnClick="Button2_Click" Text="Back to Login" BackColor="#CC0000" ForeColor="White" Font-Bold="True" />
            </div>
        </form>
    </div>
    
</body>
</html>
