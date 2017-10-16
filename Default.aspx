<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .grdCss { font-size: 18px;}
        .errorMsg { color: red;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left:50px;">
            <div style="font-size:18px;">
                <h2>Entity Framework Sample Project
                </h2>
                SEARCH:<br />
                First Name :
                <asp:TextBox ID="txtSrchFirstName" runat="server"></asp:TextBox>
                &emsp;
    City :
                <asp:TextBox ID="txtSrchCity" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="false" />
                <br />
                <br />
                Select Employee :
                <asp:DropDownList ID="ddlEmployee" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                </asp:DropDownList>
                <br /><br />
                <hr />
                <div style="display: inline; width: 100px; float: left;">HR Emp ID :</div>
                <asp:TextBox ID="txtHREmpId" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtHREmpId" runat="server" ErrorMessage="Please fill out this field!" CssClass="errorMsg"></asp:RequiredFieldValidator>
                <br />
                <div style="display: inline; width: 100px; float: left;">First Name :</div>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtFirstName" runat="server" ErrorMessage="Please fill out this field!" CssClass="errorMsg"></asp:RequiredFieldValidator>
                <br />
                <div style="display: inline; width: 100px; float: left;">Last Name :</div>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtLastName" runat="server" ErrorMessage="Please fill out this field!" CssClass="errorMsg"></asp:RequiredFieldValidator>
                <br />
                <div style="display: inline; width: 100px; float: left;">Address :</div>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddress" runat="server" ErrorMessage="Please fill out this field!" CssClass="errorMsg"></asp:RequiredFieldValidator>
                <br />
                <div style="display: inline; width: 100px; float: left;">City :</div>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtCity" runat="server" ErrorMessage="Please fill out this field!" CssClass="errorMsg"></asp:RequiredFieldValidator>
                <br /> <br /> <br />
                <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" />
                <br />
                <br />

                <hr />

                <asp:GridView ID="grdEmployees" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" CssClass="grdCss">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
