<%@ Page Title="CartPage" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cartpage.aspx.cs" Inherits="KpopZtationLab.Views.Pages.Cartpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cart</h1>
    <div class="left">
         <asp:GridView ID="CartGridView" 
             runat="server" 
             OnRowDeleting="CartGridView_RowDeleting" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Clothing ID" DataField="Album.AlbumID" />
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Album.AlbumImage") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Clothing Name" DataField="Album.AlbumName" />
                <asp:BoundField HeaderText="Quantity" DataField="Qty" />
                <asp:BoundField HeaderText="Clothing Price" DataField="Album.AlbumPrice" />
                <asp:CommandField HeaderText="Actions" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="CheckOutBtn" runat="server" Text="Checkout Cart" OnClick="CheckOutBtn_Click" />
    </div>
</asp:Content>
