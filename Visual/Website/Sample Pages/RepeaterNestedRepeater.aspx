<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RepeaterNestedRepeater.aspx.cs" Inherits="Sample_Pages_RepeaterNestedRepeater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <br />
    <div class="col-sm-6">
    <!--inside a Repeater yo need as a minimum an ItemTemplate
        other Template include HeaderTemplate, FooterTemplate, AlternatingItemTemplate
        
        outer repeater will display flat fields from the DTO Class
        outer repeater will gets its data source from the ODS Control(DataSourceID)

        inner repeater will display flat fields from the POCO class
        inner Repeater gets its Datasource from the List<T> field of the DTO class
        (DataSource)-->
    <asp:Repeater ID="ArtistAlbumReleaseList" runat="server" 
        DataSourceID="ArtistAlbumReleaseODS">
       <HeaderTemplate>
           <h3>Album Releases For Artists</h3>
       </HeaderTemplate>
        <ItemTemplate>
            <strong><%# Eval("Artist") %></strong><br />
            <asp:Repeater ID="Albums" runat="server"
                DataSource='<%# Eval("Albums") %>'>
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Year</th>
                            <th>Label</th>
                            <th>Title</th>
                        </tr>

                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("RYear") %></td>
                        <td><%# Eval("Label") %></td>
                        <td><%# Eval("Title") %></td>
                    </tr>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
        </div>


     <div class="col-sm-6">
    <!--inside a Repeater yo need as a minimum an ItemTemplate
        other Template include HeaderTemplate, FooterTemplate, AlternatingItemTemplate
        
        outer repeater will display flat fields from the DTO Class
        outer repeater will gets its data source from the ODS Control(DataSourceID)

        inner repeater will display flat fields from the POCO class
        inner Repeater gets its Datasource from the List<T> field of the DTO class
        (DataSource)
        
        use of the ItemType Parameter on the repeater allows you to use 
        object instance referencing(instance.property) for fields instead of Eval("XXX") refrencing
        -->
    <asp:Repeater ID="ArtistAlbumReleasesB" runat="server" 
        DataSourceID="ArtistAlbumReleaseODS"
        ItemType="Chinook.Data.DTOs.ArtistAlbumReleases">
       <HeaderTemplate>
           <h3>Album Releases For Artists</h3>
       </HeaderTemplate>
        <ItemTemplate>
            <strong><%# Item.Albums %></strong><br />
            <asp:Repeater ID="AlbumsB" runat="server"
                 DataSource='<%# Item.Albums %>'>
                ItemType="'Chinook.Data.POCOs.AlbumRelease">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Year</th>
                            <th>Label</th>
                            <th>Title</th>
                        </tr>

                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# %></td>
                        <td><%# Item.Label %></td>
                        <td><%# Item.Title %></td>
                    </tr>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
        </div>
    <asp:ObjectDataSource ID="ArtistAlbumReleaseODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="ArtistAlbumReleases_List"
        TypeName="ChinookSystem.BLL.AlbumController">

    </asp:ObjectDataSource>
</asp:Content>

