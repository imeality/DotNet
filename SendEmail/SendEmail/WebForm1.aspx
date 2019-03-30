<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SendEmail.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
           <table>
                <tr>
                   <td>From</td>
                   <td><asp:TextBox ID="txtFrom" runat="server"></asp:TextBox></td></tr>
                <tr>
                   <td>Password</td>
                   <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td></tr>
               

               <tr>
                   <td>To</td>
                   <td><asp:TextBox ID="txtTo" runat="server"></asp:TextBox></td></tr>
               <tr>
                   <td>Subject</td>
                   <td><asp:TextBox ID="txtSubject" runat="server"></asp:TextBox></td></tr>
                <tr>
                   <td>Body</td>
                   <td><asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine"></asp:TextBox></td></tr>
               <tr>   
                <td >   
                    Attachment:</td>   
                <td >   
                    <asp:FileUpload ID="FileUpload1" runat="server" />   
                </td>   
                   </tr>
                <tr>   
                <td class="style1">   
                    <asp:Label ID="lbmsg" runat="server"></asp:Label>   
                </td>   
                <tr>
                  
                   <td colspan="2"><asp:Button ID="btnSend" runat="server" Text="send" OnClick="btnSend_Click" /></td></tr>
               </table>
           </div>
    </form>
</body>
</html>
