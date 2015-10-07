<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerListPage.aspx.cs" Inherits="WebApp.CustomerListPage" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer List</title>
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="300px" />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Gender"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server" Width="50px">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="M"></asp:ListItem>
                        <asp:ListItem Value="F"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="200px" OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label3" runat="server" Text="City" />
                </td>
                <td >
                    <asp:DropDownList ID="ddlCity" runat="server" Width="300px" />
                </td>
                <td >
                    <asp:Label ID="Label4" runat="server" Text="Region" />
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlRegion" runat="server" Width="300px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="btnCLearFields" runat="server" Text="Clear Fields" Width="200px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Last Purchase" />
                </td>
                <td colspan="3">
                    <table>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlLastPurchase1" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="until" />
                            </td>
                            <td>
                                
                                <asp:DropDownList ID="ddlLastPurchase2" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Classification" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlClassification" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <br /></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="grvClients" runat="server" AutoGenerateColumns="False" BorderColor="#000000" BorderStyle="Solid" 
                        BorderWidth="1px" CellPadding="4" DataKeyNames="ClientId" ForeColor="#333333" 
                        GridLines="Both" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="ClassificationName" HeaderText="Classification" SortExpression="ClassificationName" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                            <asp:BoundField DataField="CityName" HeaderText="City" SortExpression="CityName" />
                            <asp:BoundField DataField="RegionName" HeaderText="Region" SortExpression="RegionName" />
                            <asp:BoundField DataField="LastPurchase" HeaderText="LastPurchase" SortExpression="LastPurchase" />
                            <asp:BoundField DataField="RegionId" HeaderText="RegionId" Visible="false" />
                            <asp:BoundField DataField="ClientId" HeaderText="ClientId" ReadOnly="True" Visible="false" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    
                </td>
            </tr>

        </table>
    </form>
</body>
</html>
