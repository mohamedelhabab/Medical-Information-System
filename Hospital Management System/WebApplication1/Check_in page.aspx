<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Check_in page.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 101%;
            height: 694px;
        }
        .auto-style2 {
            width: 198px;
            text-align: left;
        }
        .auto-style3 {
            width: 198px;
            height: 32px;
            text-align: left;
        }
        .auto-style4 {
            height: 32px;
        }
        .auto-style5 {
            width: 271px;
        }
        .auto-style6 {
            height: 32px;
            width: 271px;
        }
        .auto-style7 {
            width: 198px;
            height: 63px;
            text-align: left;
        }
        .auto-style8 {
            width: 271px;
            height: 63px;
        }
        .auto-style9 {
            height: 63px;
        }
        .auto-style10 {
            font-weight: bold;
        }
        .auto-style11 {
            text-align: left;
        }
        .auto-style12 {
            text-align: center;
        }
        .auto-style13 {
            width: 198px;
            text-align: left;
            height: 38px;
        }
        .auto-style14 {
            width: 271px;
            height: 38px;
        }
        .auto-style15 {
            height: 38px;
        }
    </style>
</head>
<body style="background-color: #33CC33">
    <form id="form1" runat="server">
    <div class="auto-style11">
    
        <div class="auto-style12">
            <asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #FF0066; font-size: xx-large" Text="Check In/Out System"></asp:Label>
        </div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style13">&nbsp;&nbsp;&nbsp; Dept</td>
                <td class="auto-style14">
                    <asp:DropDownList ID="Drpdept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Drpdept_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="auto-style15"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp; ID.No&nbsp;</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtid_no" runat="server" Width="179px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp; Name&nbsp;</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtname" runat="server" Width="179px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;&nbsp;&nbsp; Age&nbsp;</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtage" runat="server" Height="26px" Width="179px"></asp:TextBox>
                </td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp; Address&nbsp;</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtadress" runat="server" Width="179px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp; Phone Number&nbsp;</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtphone_number" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;&nbsp;&nbsp; Available Room&nbsp;</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="drpavailable_room" runat="server" AutoPostBack="True">
                        <asp:ListItem>No.</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp; Fees&nbsp;</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtfees" runat="server" Width="176px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp; Full Fee Paid</td>
                <td class="auto-style5">
                    <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="True" OnCheckedChanged="chkbox_CheckedChanged" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp; Current Paid</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtcurrent_pid" runat="server" AutoPostBack="True" OnTextChanged="txtcurrent_pid_TextChanged" Width="174px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;&nbsp; &nbsp;Remaining Fees are</td>
                <td class="auto-style14">
                    <asp:Label ID="lblrest_fees" runat="server"></asp:Label>
                </td>
                <td class="auto-style15"></td>
            </tr>

              <tr>
                <td class="auto-style2">&nbsp;&nbsp; &nbsp;Date</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtdate" runat="server" Width="176px"></asp:TextBox>
                </td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                  </td>
            </tr>

            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style14">
                    <asp:Label ID="lblconfirm" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
                </td>
                <td class="auto-style15"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnSubmit" runat="server" Height="42px" Text="SUBMIT" Width="104px" CssClass="auto-style10" OnClick="BtnSubmit_Click" />
                </td>
                <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnSearch" runat="server" Height="42px" Text="Search" Width="100px" CssClass="auto-style10" OnClick="BtnSearch_Click" />
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnUpdate" runat="server" Height="46px" Text="Update" Width="113px" CssClass="auto-style10" OnClick="BtnUpdate_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7"><center>
                    <asp:Button ID="Button1" runat="server" Height="35px" style="text-align: center; font-weight: 700;" Text="Clear" Width="96px" OnClick="Button1_Click" />
               </center> </td>
                <td class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnCheck_out" runat="server" Height="42px" Text="Check-Out" Width="100px" CssClass="auto-style10" OnClick="BtnCheck_out_Click" />
                </td>
                <td class="auto-style9"></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
