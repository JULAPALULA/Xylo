<%@ Page Language="vb" MasterPageFile="~/Root.master" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Xylo._Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="login">
        <h1>LOGIN</h1>
        <label for="email">Email:</label><br>
        <asp:TextBox runat="server" id="InputEmail" name="email-input" /><br>
        <label for="password">Password:</label><br>
        <asp:TextBox runat="server" id="InputPassword" name="password-input" /><br>
        <asp:Button Text="Login" ID="btnLogin" runat="server" OnClick="btnLogin_Click" UseSubmitBehavior="true" />
        <label runat="server" id="er1" />
        <br />
        <p>¿No cuenta?</p>
        <asp:Button Text="Play as guest" ID="btnPlayAsGuest" runat="server" OnClick="btnPlayAsGuest_Click" UseSubmitBehavior="true" CausesValidation="false" />
    </div>
</asp:Content>
