<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Index.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="ExpenseTracker.Admin.Feedback" %>

<asp:Content ID="Feed" ContentPlaceHolderID="Admin1" runat="server">
    <asp:Label ID="allfeed" runat="server" Text="All Feedback Messages"></asp:Label>
    <asp:GridView
        ID="feeddata"
        runat="server"
        CssClass="grid"
        AutoGenerateColumns="false"
        ShowHeaderWhenEmpty="true"
        EmptyDataText="No record found"
        CellPadding="5"
        BorderWidth="1"
        DataKeyNames="feedback_id" 
        
        OnRowCancelingEdit="feed_canceledit" 
        OnRowDeleting="feed_delete" 
        OnRowUpdating="feed_rowupdate" 
        OnRowEditing="feed_rowedit" 
        UseAccessibleHeader="true" 
        GridLines="None">

             <Columns>
    <asp:BoundField DataField="feedback_id" HeaderText=" Feedback ID" />
    <asp:BoundField DataField="user_id" HeaderText="User ID" />
    <asp:BoundField DataField="name" HeaderText="Name" />
         <asp:BoundField DataField="email" HeaderText="Email" />
         <asp:BoundField DataField="msg" HeaderText="Feedback Message" />
         <asp:BoundField DataField="sent_at" HeaderText="Sent At" />
                 <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" HeaderText="Actions" />
</Columns>

    </asp:GridView>

</asp:Content>
