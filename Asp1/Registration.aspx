  <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Asp1.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
   
    <title>STUDENT REGISTRATION FORM </title>
    
</head>

<body>
    <form id="form1" runat="server" >
        <div id=" div1" >
         <h2 align=" center">STUDENT REGISTRATION FORM</h2>
           
            <table class =" auto-style " align ="center" >
                
 
             
                            <tr><td>FIRST NAME :</td>
                              <td>
                                  <asp:TextBox ID ="FNAME" runat="server"></asp:TextBox></td></tr>
                        <tr><td>LAST NAME :</td>
                              <td>
                                  <asp:TextBox ID ="LNAME" runat="server"></asp:TextBox></td></tr>
                        
                         <tr><td>DATE OF BIRTH :</td>
                              <td>
                                  <asp:TextBox ID ="DOB" runat="server" TextMode=" DATE"></asp:TextBox></td></tr>
                         <tr><td>FATHER'S NAME  :</td>
                              <td>
                                  <asp:TextBox ID ="FATHERNAME" runat="server"></asp:TextBox></td></tr>
                           <tr><td>MOTHER'S NAME :</td>
                              <td>
                                  <asp:TextBox ID ="MOTHERNAME" runat="server"></asp:TextBox></td></tr>
                          
                          <tr><td>BRANCH :</td>
                              <td>
                                  <asp:DropDownList ID="BRANCH" runat="server">  
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>  
                                        <asp:ListItem Value ="Cse">Computer Science</asp:ListItem>  
                                        <asp:ListItem Value="csm">Aitifcal intelligence</asp:ListItem> 
                                          <asp:ListItem value = "ml">Machine leraning</asp:ListItem> 
                                        <asp:ListItem Value="cic">Cyber security</asp:ListItem>  
                                        <asp:ListItem value="cds">Data science</asp:ListItem> 
                                          <asp:ListItem value="cba">Big data</asp:ListItem> 
                                        <asp:ListItem>London</asp:ListItem>  
                                    </asp:DropDownList> 
                        </td></tr>
                <tr><td>GENDER :</td>
                    <td>
                        <asp:RadioButtonList ID="GENDER" runat="server">
                            <asp:ListItem Value="M">MALE</asp:ListItem>
                            <asp:ListItem Value="F">FEMALE</asp:ListItem>
                            <asp:ListItem Value="O">OTHER</asp:ListItem>
                          </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please select a gender.<br />"
                        ControlToValidate="GENDER" runat="server" ForeColor="Red" Display="Dynamic" />
                   

                        </td>
                    </tr>
                        <tr> <td>EMAIL :</td>    
                          <td>
                              <asp:TextBox ID="EMAIL" runat="server" onfocus="WaterMarkBlur(this,'@xyz.com')" onblur="WaterMarkBlur(this,'@XYZ.COM')"
                                  ForeColor="gray" WaterMarkText="@xyz.com"></asp:TextBox>
                           </td>
                      </tr>
                    <tr>
                        <td>HOBBIES :</td>
                        <td>
                            <asp:CheckBoxList runat="server" ID="checkboxlist1">
                                <asp:ListItem>Reading</asp:ListItem>
                                <asp:ListItem>Broswing</asp:ListItem>
                                <asp:ListItem>Sports</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                        <tr><td>PHONE NUMBER: </td>
                            <td>
                                  <asp:TextBox ID ="PHNO" runat="server" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr> 
                                 <td colspan="2" align ="center" >
                                     <asp:HiddenField ID="hdnStudentId" runat="server" />
                            <asp:Button id="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" /> 
                                    &nbsp; <asp:Button ID="btnreset" runat="server" Text="RESET" OnClick="btnreset_Click" />
                                    &nbsp; <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" OnClick="btnUpdate_Click" Visible ="false" />
                                     &nbsp; <asp:Button ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" Visible ="false" />
                                 </td></tr>
               
                   <tr></tr><tr></tr>
                <tr>
                    <td colspan="2" style="text-align : center">
                        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

            </table>
            <table align="center">
                <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" CellPadding="6"
                    ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="true">
                    <%--OnRowEditing="GridView1_RowEditing">--%>
                    <%--DataSourceID="SqlDataSource1" DataKeyNames="studentid" AutoGenerateEditButton="True">--%>
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />

                    <Columns>
                         <asp:BoundField DataField="Sno" HeaderText ="StudentId"/>
                        <asp:BoundField DataField="fname" HeaderText="FirstName"/>
                        <asp:BoundField DataField="lname" HeaderText="LastName" />
                        <asp:BoundField DataField="dob" HeaderText="Dateofbirth" />
                        <asp:BoundField DataField="father_name" HeaderText="Father" />
                        <asp:BoundField DataField="mother_name" HeaderText="Mother" />
                        <asp:BoundField DataField="branch" HeaderText="Branch" />
                        <asp:BoundField DataField="gender" HeaderText="Gender" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:BoundField DataField="phno" HeaderText="Phone" />
                        <asp:BoundField DataField="hobbies" HeaderText="Hobbies" />
                        <asp:BoundField DataField="createddate" HeaderText="CREATEDDATE" />
                       
                           <%-- <asp:TemplateField>
            <ItemTemplate>
                <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>--%>
                       <%-- <asp:CommandField ShowEditButton="True" ButtonType="Button" ></asp:CommandField>--%>
                    </Columns>
                </asp:GridView>
                </table>
                </div>
                </form>
                </body>
                </html>
