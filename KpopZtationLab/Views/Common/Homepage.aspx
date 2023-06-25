    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="KpopZtationLab.Views.Common.Homepage" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <title>Home</title>
            <link rel="stylesheet" href="../../Assets/css/homepage.css" type="text/css" />
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <% if (role == "ADMN")
            { %>
                <asp:Button ID="CreateArtist" runat="server" Text="Add New Clothing Category" OnClick="CreateArtist_Click" />
                <div class="container">
                    <h2>Kategori Baju</h2>
                    <br />
                    <div style="display: flex; flex-wrap: wrap; justify-content: flex-start;" class="container">
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
                </div>
            <%} %>
        <%else{ %>
              <div class="container">
                     <h2>Kategori Baju</h2>
                    <br />
                    <div style="display: flex; flex-wrap: wrap; justify-content: flex-start;">
                        <asp:Repeater ID="CustomerArtistsRepeater" runat="server" OnItemCommand="Admin2ArtistsRepeater_ItemCommand">
                            <ItemTemplate>
                                <div style="width: 300px; margin: 10px; padding: 10px; border: 1px solid #ccc; border-radius: 5px;">
                                    <asp:Image ID="ArtistImage" runat="server" ImageUrl='<%# "../../"+Eval("ArtistImage") %>' style="width: 100%; height: 200px; object-fit: cover; border-radius: 5px;" />
                                    <h2 style="margin-top: 10px; margin-bottom: 0;"><%# Eval("ArtistName") %></h2>
                                    <div style="margin-top: 10px; display: flex; justify-content: flex-end;">
                                        <asp:Button ID="SelectButton" runat="server" Text="Select" CommandName="Select" CommandArgument='<%# Eval("ArtistID") %>' style="margin-left: 5px;" />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

        <%} %>
        </div>

    </asp:Content>
