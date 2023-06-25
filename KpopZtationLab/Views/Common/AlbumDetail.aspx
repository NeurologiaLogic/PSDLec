<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="KpopZtationLab.Views.Common.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content">
         <main>
             <div style="display:flex;flex-direction:column" runat="server">
                  <img src="<%=album.AlbumImage %>" alt="Alternate Text" width="250px" />
                <br />
                <h5>Clothing Category Name</h5>
                <br />
                <h2 class="artist-title"><%= album.AlbumName %></h2>
                <br />
                  <h3>Description</h3>
                <h3><%=album.AlbumDescription %></h3>
                <div class="flex">
                    <h3>Quantity</h3>
                    <div class="flex-group">
                        <%if (role == "CSTM" || role == "ADMN")
                            { %>
                                <asp:TextBox ID="QuantityTxt" runat="server" Text="0"></asp:TextBox>
                                <asp:Label ID="ErrorLbl" runat="server" Text="Label" Visible="false"></asp:Label>
                                <asp:Button ID="addToCartBtn" runat="server" Text="Add to cart" OnClick="addToCartBtn_Click"/>
                        <%} %>
                        <%else
                            { %>
                                <asp:TextBox ID="TextBox1" runat="server" Text="0" Enabled="false"></asp:TextBox>
                        <%} %>

                    </div>
                </div>

                    </div>
                </div>
            </div>
        </main>
    </div>
</asp:Content>
