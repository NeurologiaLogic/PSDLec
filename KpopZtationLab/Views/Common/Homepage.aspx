    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="KpopZtationLab.Views.Common.Homepage" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <title>Home</title>
            <link rel="stylesheet" href="../../Assets/css/homepage.css" type="text/css" />
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Artists</h2>
        <br />
        <% if (role == "ADMN")
            { %>
                <asp:Button ID="CreateArtist" runat="server" Text="Add New Artist" OnClick="CreateArtist_Click" />
                <div style="display: flex; flex-wrap: wrap; justify-content: flex-start;">
                    <asp:Repeater ID="AdminArtistsRepeater" runat="server" OnItemCommand="AdminArtistsRepeater_ItemCommand">
                        <ItemTemplate>
                            <div style="width: 300px; margin: 10px; padding: 10px; border: 1px solid #ccc; border-radius: 5px;">
                                <asp:Image ID="ArtistImage" runat="server" ImageUrl='<%# "../../"+Eval("ArtistImage") %>' style="width: 100%; height: 200px; object-fit: cover; border-radius: 5px;" />
                                <h2 style="margin-top: 10px; margin-bottom: 0;"><%# Eval("ArtistName") %></h2>
                                <div style="margin-top: 10px; display: flex; justify-content: flex-end;">
                                    <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("ArtistID") %>' style="margin-left: 5px;" />
                                    <asp:Button ID="DeleteButton" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("ArtistID") %>' style="margin-left: 5px;" />
                                    <asp:Button ID="SelectButton" runat="server" Text="Select" CommandName="Select" CommandArgument='<%# Eval("ArtistID") %>' style="margin-left: 5px;" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            <%} %>
        <%else{ %>
            <div class="card-deck" style="
                    display: flex;
                    flex-wrap: wrap;">
                <% foreach (var artist in artists) { %>
                    <div class="card" style="
                            width: 250px;
                            border: 1px solid #ccc;
                            border-radius: 4px;
                            margin: 10px;
                            padding: 10px;
                            background-color: #fff;
                            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);">
                        <img class="card-img-top" src='<%= "../../" + artist.ArtistImage %>' style="
                                width: 100%;
                                height: auto;"/>
                        <div class="card-body" style="padding: 10px;">
                            <h5 class="card-title"><%= artist.ArtistName %></h5>
                            <a href='<%="ArtistDetail.aspx?ID=" + artist.ArtistID %>' style="
                                padding: 10px;
                                text-align: right;">Select</a>
                        </div>
                    </div>
                <% } %>
            </div>


        <%} %>

    </asp:Content>
