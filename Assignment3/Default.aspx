<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment3.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body style="background-color:burlywood; text-align: center;">

    <h1 style = "font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; background-color: #00FFFF; display: color: #000000; font-style: italic; font-weight: bold; ">WELCOME TO SHERIDAN DEALER SHOP</h1>
    <form style ="margin-top: 200px; font-weight: bolder; clip: rect(auto, auto, auto, auto);" id="form1" runat="server">
        <div>
            
            <h3>Please, login!</h3>
            User Name:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="You must type your user name." BackColor="Black" ForeColor="Yellow"></asp:RequiredFieldValidator>
            <br />
            <br />
            Password:&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="You must type password." BackColor="Black" ForeColor="Yellow"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
        <asp:Label ID="Label1" runat="server" BackColor="Black" ForeColor="Yellow"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" BackColor="#0000CC" ForeColor="White" />
            <asp:Button ID="Button2" runat="server" Text="I am new here" OnClick="Button2_Click" BackColor="Orange" ForeColor="White" />
        </div>
    </form>
</body>
</html>
