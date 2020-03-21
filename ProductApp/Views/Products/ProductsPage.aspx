<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsPage.aspx.cs" Inherits="ProductApp.Views.Products.ProductsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView id="productList" runat="server"
                DataKeyNames="Id" ItemType="ProductApp.ViewModels.Products.ProductViewModel"
                SelectMethod="GetProducts"
                ItemPlaceholderID="itemPlaceholder">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            No data was returned
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table id="productsTable">
                        <tr>
                            <th >Product Name</th>
                            <th >Description</th>
                            <th ">Category</th>
                            <th ">Supplier</th>
                            <th >Manufacturer</th>
                            <th >Price</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"/>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("ProductName") %>
                        </td>
                        <td>
                            <%# Eval("Description") %>
                        </td>
                        <td>
                            <%# Eval("CategoryName") %>
                        </td>
                        <td>
                            <%# Eval("SupplierName") %> 
                        </td>
                        <td>
                            <%# Eval("ManufacturerName") %>
                        </td>
                        <td>
                            <%# Eval("Price") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
