<%@ Page Language="vb" MasterPageFile="~/Root.master" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="Xylo.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="register">
        <h1>REGISTER</h1>
        <label for="username">Username:</label><br>
        <asp:TextBox type="text" id="InputUsername" name="username" runat="server" /><br>
        <label for="email">Email:</label><br>
        <asp:TextBox type="email" id="InputEmail" name="email" runat="server" /><br>
        <label for="password">Password:</label><br>
        <asp:TextBox type="password" id="InputPassword" name="password" runat="server" /><br>
        <label id="er1" runat="server" />
        <asp:Button Text="Register" ID="btnRegister" runat="server" OnClick="btnRegister_Click" UseSubmitBehavior="true" />

        <br />
        <p>Already have an account? <a href="Default.aspx">Login here</a>.</p>
    </div>
</asp:Content>
