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
                        <div>
                            <asp:Button ID="AddProductToDB" Text="Add Product" PostBackUrl="~/Views/Products/DbImplementation/CreateProductPage.aspx" runat="server" />
                        </div>
                        <div>
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
                                        <td>
                                            <asp:LinkButton runat="server" Text="Edit" PostBackUrl='<%# "~/Views/Products/DbImplementation/EditProductPage.aspx?Id=" + Eval("Id")  %>' />  
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Show products from JSON" ID="ProductListFromJSON">
                    <ContentTemplate>
                        <div>
                            <asp:Button ID="AddToJSON" Text="Add Product" PostBackUrl="~/Views/Products/JSONImplementation/CreateProductPage.aspx" runat="server" />
                        </div>

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
                                 <td>
                                    <asp:LinkButton runat="server" Text="Edit" PostBackUrl='<%# "~/Views/Products/JSONImplementation/EditProductPage.aspx?Id=" + Eval("Id")  %>' />  
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
