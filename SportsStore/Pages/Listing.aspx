<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="/Pages/Store.Master" CodeBehind="Listing.aspx.vb" Inherits="SportsStore.Listing" %>
<%@ Import Namespace="SportsStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <asp:Repeater ID="Repeater1" ItemType="SportsStore.Product" SelectMethod="GetProducts" runat="server">
            <ItemTemplate>
                <div class="item">
                    <h3><%# Item.Name %></h3>
                    <%# Item.Description %>
                    <h4><%# Item.Price.ToString("c") %></h4>
                    <button name="add" type="submit"value="<%# Item.ProductID %>">Add to Cart</button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pager">
        <asp:Button cssclass="nav-button" Text="Previous" runat="server" onclick="PreviousButtonOnClick" />
        <asp:Button cssclass="nav-button" Text="Next" runat="server" onclick="NextButtonOnClick" />
    </div>
    <div>
        <asp:Button cssclass="nav-button" Text="Checkout" runat="server" onclick="CheckoutButtonOnClick" />
    </div>
</asp:Content>
