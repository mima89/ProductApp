<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProductPage.aspx.cs" Inherits="ProductApp.Views.Products.DbImplementation.CreateProductPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>         
                    <asp:Label runat="server" Text="Product Name:" /> <asp:TextBox id="ProductNameTextBox" runat="server" /> <br />
                    <asp:RequiredFieldValidator ID="ProductNameValidator" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="ProductNameTextBox" ForeColor="Red"></asp:RequiredFieldValidator>  <br />
                    <asp:Label runat="server" text="Product Description:" /> <asp:TextBox id="ProductDescriptionTextBox" runat="server"  /><br />
                    <asp:Label runat="server" Text="Category:" /> <asp:DropDownList ID="CategoryDropDownList" runat="server" /><br />
                    <asp:Label runat="server" Text="Supplier:" /> <asp:DropDownList ID="SupplierDropDownList" runat="server" /><br />
                    <asp:Label runat="server" Text="Manufacturer:" /> <asp:DropDownList ID="ManufacturerDropDownList" runat="server" /><br />
                    <asp:Label runat="server" Text="Price:" /><asp:TextBox ID="PriceTextBox" runat="server" /><br />
                    <asp:RegularExpressionValidator ID="PriceRegex" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
                                ControlToValidate="PriceTextBox" /><br />
                    <asp:RequiredFieldValidator ID="PriceValidator" runat="server" ErrorMessage="Price cannot be blank" ControlToValidate="PriceTextBox" ForeColor="Red"></asp:RequiredFieldValidator>  <br />
                    <asp:Button ID="AddProductButton" runat="server" Text="Submit" OnClick="AddProductButtonClick" />
        </div>
    </form>
</body>
</html>
