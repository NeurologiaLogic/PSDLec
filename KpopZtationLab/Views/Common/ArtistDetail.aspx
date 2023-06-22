<%@ Page enableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="KpopZtationLab.Views.Common.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Assets/css/artistDetail.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div style="display:flex;flex-direction:column">
            <h5>Artist's Image</h5>
            <br />
            <img src="<%= "../../"+artist.ArtistImage %>" width="300" alt="no image found" />
            <br />
            <h5>Artis's Name</h5>
            <br />
            <h2 class="artist-title"><%= artist.ArtistName %></h2>
            <br />
        </div>
        <div class="right" runat="server">
            <%if (role == "ADMN") 
                { %>
                    <asp:Button ID="InsertAlbum" runat="server" Text="Insert New Album" OnClick="NavigateToInsertAlbum_Click" />
                    <div style="
                        display: flex;
                        flex-wrap: wrap;
                        justify-content: flex-start;">
                        <asp:Repeater ID="AdminAlbumsRepeater" runat="server" >
                            <ItemTemplate>
                                <div style="
                                    width: 300px; 
                                    margin: 10px; 
                                    padding: 10px; 
                                    border: 1px solid #ccc; 
                                    border-radius: 5px;">
                                    <asp:Image ID="AlbumImage" runat="server" ImageUrl='<%# "../../"+Eval("AlbumImage") %>' style="
                                        width: 100%; 
                                        height: 200px; 
                                        object-fit: cover; 
                                        border-radius: 5px;" />
                                    <h2 style="
                                        margin-top: 10px; 
                                        margin-bottom: 0;"><%# Eval("AlbumName") %></h2>
                                    <div style="
                                        margin-top: 10px; 
                                        display: flex; 
                                        justify-content: flex-end;">
                                        <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("AlbumID") %>' style="margin-left: 5px;" OnClick="EditButton_Click" />
                                        <asp:Button ID="DeleteButton" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("AlbumID") %>' style="margin-left: 5px;" OnClick="DeleteButton_Click" />
                                        <asp:Button ID="SelectButton" runat="server" Text="Select" CommandName="Select" CommandArgument='<%# Eval("AlbumID") %>' style="margin-left: 5px;" OnClick="SelectButton_Click"/>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
            <% }%>
            <% else { %>
                <div class="card-container" style="
                    display: flex; 
                    flex-wrap: wrap;">
                    <% foreach (var album in albums) { %>
                        <div class="card" style="
                            display: flex;
                            flex-direction:column;
                            gap: 5px;
                            width: 250px; 
                            border: 1px solid #ccc; 
                            border-radius: 4px; 
                            margin: 10px; 
                            padding: 10px; 
                            background-color: #fff; 
                            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);">

                            <img class="card-img-top" src='<%= "../../"+album.AlbumImage %>' style="
                                width: 100%; 
                                height: auto;" />
                            <div class="card-body" style="padding: 10px;">
                                <h5 class="card-title" style="margin-bottom: 10px;"><%= album.AlbumName %></h5>
                                <p class="card-text" style="margin-bottom: 10px;"><%= album.AlbumDescription %></p>
                                <p class="card-text" style="margin-bottom: 10px;">Price: <%= album.AlbumPrice %></p>
                                <a href="AlbumDetail.aspx?ID=<%= album.AlbumID %>" class="btn btn-primary" style="text-decoration: none; color: #fff; padding: 8px 12px; background-color: #007bff; border: none; border-radius: 4px;">Select</a>
                            </div>
                        </div>
                    <% } %>
                </div>
            <%} %>
        </div>
    </div>

</asp:Content>
