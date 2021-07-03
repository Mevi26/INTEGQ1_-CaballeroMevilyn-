<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingCart.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="UI.Product" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            
    <div style="float:left">
    <table>
                    
        <tr>
         <td>Product Code: </td>
         <td><asp:Label ID="lblcode" runat="server" Text="Auto Code"></asp:Label></td>
         </tr>
                     
        <tr>
        <td>Product Name: </td>
        <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        </tr>
                     
        <tr>
        <td>Product Status: </td>
        <td><asp:RadioButtonList ID="rbstatus" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">Active</asp:ListItem>
            <asp:ListItem Value="0">Deactive</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        </tr>
                    
        <tr>
                        <td>Product Price: </td>
                        <td>
                             <asp:TextBox ID="txtprice" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Product Category: </td>
                        <td>
                             <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                     
                     <tr>
                        <td>Product Image: </td>
                        <td>
                            <asp:FileUpload ID="fuimage" runat="server" />
                          <asp:Label ID="imgpath" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false"/>
                        </td>
                    </tr>

                </table>

            </div>
                <div  style="float:right">
                    <asp:GridView ID="gridProduct" runat="server" AutoGenerateColumns="False"  CellPadding="4" ForeColor="Black" OnRowEditing="gridProduct_RowEditing" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                        <Columns>
                            <asp:TemplateField HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:Label ID ="lblcode" runat="server" Text='<% #Eval("procode") %>' Visible="false"></asp:Label>
                                    <asp:Label ID ="lblname" runat="server" TText='<% #Eval("proname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Product Status">
                                <ItemTemplate>
                                    <asp:Label ID ="lblstatus" runat="server" Text='<% #Eval("prostatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Price">
                                <ItemTemplate>
                                    <asp:Label ID ="lblprice" runat="server" Text='<% #Eval("proprice") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Category">
                                <ItemTemplate>
                                    <asp:Label ID ="lblcat" runat="server" Text='<% #Eval("catname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Image">
                                <ItemTemplate>
                                    <asp:Image ID ="img" ImageUrl='<% #"~/ProductImages/" + Convert.ToString(Eval("proimage")) %>' Width="40px" Height="40px" runat="server" Text="Label"></asp:Image>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Events">
                                <ItemTemplate>
                                    <asp:Button ID ="btnEdit" runat="server" Text="Edit" CommandName="Edit" Width="100%"></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </div>

            

        <%--</ContentTemplate>
   </asp:UpdatePanel>--%>
</asp:Content>

