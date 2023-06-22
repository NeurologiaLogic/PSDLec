<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="KpopZtationLab.Views.Common.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content">
         <main>
              <div class="left">
                  <img src="<%=album.AlbumImage %>" alt="Alternate Text" />
            </div>
            <div class="right">
                <div class="flex">
                     <div class="column">
                          <h1><%=album.AlbumName %></h1>
                         <h2>$ <%=album.AlbumPrice %></h2>
                         <h3>Stock: <%=album.AlbumStock %></h3>
                    </div>
                </div>
                <h3>Description</h3>
                <h3><%=album.AlbumDescription %></h3>
                <div class="flex">
                    <h3>Quantity</h3>
                    <div class="flex-group">
                        <%--- 0 +--%>
                        <%if (role == "CSTM" || role == "ADMN")
                            { %>
                              <asp:TextBox ID="QuantityTxt" runat="server" Text="0"></asp:TextBox>
                              <asp:Label ID="ErrorLbl" runat="server" Text="Label" Visible="false"></asp:Label>


                        <%} %>
                        <%else
                            { %>
                               <asp:TextBox ID="TextBox1" runat="server" Text="0" Enabled="false"></asp:TextBox>
                        <%} %>
                    </div>
                </div>
                <h1><%= role %></h1>
                <%if (role == "CSTM" || role == "ADMN")
                    { %>
                <div class="flex">
                    <asp:Button ID="addToCartBtn" runat="server" Text="Add to cart" OnClick="addToCartBtn_Click"/>
                </div>
                <%} %>
            </div>
        </main>
    </div>
</asp:Content>
