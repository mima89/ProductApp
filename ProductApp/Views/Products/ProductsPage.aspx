<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsPage.aspx.cs" Inherits="ProductApp.Views.Products.ProductsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <ajaxToolkit:TabContainer ID="ProductTabContainer" runat="server" ActiveTabIndex="0">
                <ajaxToolkit:TabPanel runat="server" HeaderText="Show products from DB" ID="ProductListFromDB">
                    <ContentTemplate>
                        <asp:ListView id="productListDB" runat="server"
                        DataKeyNames="Id" ItemType="ProductApp.ViewModels.Products.ProductViewModel"
                        SelectMethod="GetProductsFromDatabase"
                        ItemPlaceholderID="itemPlaceholder">
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <p>No data was returned</p>
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
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Show products from JSON" ID="ProductListFromJSON">
                    <ContentTemplate>
                        <asp:ListView id="ProductListJSON" runat="server"
                        DataKeyNames="Id" ItemType="ProductApp.ViewModels.Products.ProductViewModel"
                        SelectMethod="GetProductsFromJSON"
                        ItemPlaceholderID="itemPlaceholderJSON">
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <p>No data was returned</p>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table id="productsTableJSON">
                                <tr>
                                    <th >Product Name</th>
                                    <th >Description</th>
                                    <th ">Category</th>
                                    <th ">Supplier</th>
                                    <th >Manufacturer</th>
                                    <th >Price</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholderJSON"/>
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
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
            
        </div>
    </form>
</body>
</html>
