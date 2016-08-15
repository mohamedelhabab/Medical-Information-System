using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {//HELLO HABBAB THIS IS ME !!!

        SqlConnection conn = new SqlConnection("data source=LENOVOZ51\\SQLEXPRESS;initial catalog=hospital;integrated security=true");
        SqlConnection conn2 = new SqlConnection("data source=LENOVOZ51\\SQLEXPRESS;initial catalog=hospital2;integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn.Open();

            string str = "select * from dept";

            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    
                    Drpdept.Items.Add(sdr.GetString(2));

                }
                

            }

            sdr.Close();
            conn.Close();
            txtdate.Text = DateTime.Today.Date.ToShortDateString();
            }
            
            
        
            }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            conn.Open();

            string str3 = "insert into patient(dept,id_number,name,age,address,phone,room,date) values((select dept_id from dept where name='" + Drpdept.SelectedValue + "'),'" + txtid_no.Text + "','" + txtname.Text + "','" + txtage.Text + "','" + txtadress.Text + "','" + txtphone_number.Text + "','" + drpavailable_room.SelectedValue + "','" +txtdate.Text + "')";
            SqlCommand cmd3 = new SqlCommand(str3, conn);
            cmd3.ExecuteNonQuery();


            string str4 = "update room set available='false' where dept_id=(select dept_id from dept where name='" + Drpdept.SelectedValue + "') And room='"+drpavailable_room.SelectedValue+"'";

            SqlCommand cmd4 = new SqlCommand(str4, conn);
            cmd4.ExecuteNonQuery();
            


            string str5 = "insert into fees(id_numbr,total_fees,fees_paid,remaining_fees,paid,dept,room) values('" + txtid_no.Text + "','" + txtfees.Text + "','" + txtcurrent_pid.Text + "','" + lblrest_fees.Text + "','" + chkbox.Checked + "',(select dept_id from dept where name='" + Drpdept.SelectedItem.ToString() + "'),'" + drpavailable_room.SelectedValue + "')";
            SqlCommand cmd5 = new SqlCommand(str5, conn);
            cmd5.ExecuteNonQuery();

lblconfirm.Text = "Data Has Been Successfully Saved...!";
            conn.Close();

        }

        protected void Drpdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpavailable_room.Items.Clear();

            conn.Open();

            string str2 = "select room from room where dept_id=(select dept_id from dept where name='"+Drpdept.SelectedItem.ToString()+"') And available='true'";

            SqlCommand cmd2 = new SqlCommand(str2, conn);
            SqlDataReader sdr2 = cmd2.ExecuteReader();

            if (sdr2.HasRows)
            {
                while (sdr2.Read())
                {
                    drpavailable_room.Items.Add(sdr2.GetString(0));




                }


            }

            sdr2.Close();
            conn.Close();
        }

        protected void chkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox.Checked)
            {
                txtcurrent_pid.Enabled = false;
                lblrest_fees.Text = "0";
            }
            else
            {
                txtcurrent_pid.Enabled = true;
                lblrest_fees.Text = "";

            }
        }

        protected void txtcurrent_pid_TextChanged(object sender, EventArgs e)
        {
            lblrest_fees.Text = (int.Parse(txtfees.Text) - int.Parse(txtcurrent_pid.Text)).ToString();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdate.Text = Calendar1.SelectedDate.ToString();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
             conn.Open();

            string str6 = "select * from patient where id_number='"+txtid_no.Text+"'";

            SqlCommand cmd6 = new SqlCommand(str6, conn);
            SqlDataReader sdr6 = cmd6.ExecuteReader();

            if (sdr6.HasRows)
            {
                while (sdr6.Read())
                {
                    txtid_no.Text=sdr6.GetString(2);
                    txtname.Text=sdr6.GetString(3);
                        txtage.Text=sdr6.GetString(4);
                        txtadress.Text=sdr6.GetString(5);
                        txtphone_number.Text=sdr6.GetString(6);
                     //   drpavailable_room.SelectedValue=sdr6.GetString(7);
                        txtdate.Text=sdr6.GetString(8);
                }
                

            }

            sdr6.Close();

            string str7 = "select name from dept where dept_id=(select dept_id from patient where id_number='"+txtid_no.Text+"')";

            SqlCommand cmd7 = new SqlCommand(str7, conn);
            SqlDataReader sdr7 = cmd7.ExecuteReader();

            if (sdr7.HasRows)
            { 

                while (sdr7.Read())
                {
                 
 Drpdept.SelectedValue = sdr7.GetString(0);
                }


            }

            sdr7.Close();


            string str8 = "select * from fees where id_numbr='" + txtid_no.Text + "'";

            SqlCommand cmd8 = new SqlCommand(str8, conn);
            SqlDataReader sdr8 = cmd8.ExecuteReader();

            if (sdr8.HasRows)
            {
              
                while (sdr8.Read())
                { 
                 ListItem l = new ListItem();
                l.Value = sdr8.GetString(7);
               
                    txtfees.Text = sdr8.GetDouble(2).ToString();
                    txtcurrent_pid.Text = sdr8.GetDouble(3).ToString();
                    lblrest_fees.Text = sdr8.GetDouble(4).ToString();

                    chkbox.Checked = sdr8.GetBoolean(5);
                    if (drpavailable_room.Items.Contains(l))
                    {
                        drpavailable_room.SelectedValue = sdr8.GetString(7).ToString();


                    }
                    else
                    {
                        drpavailable_room.Items.Add(sdr8.GetString(7).ToString());
                        drpavailable_room.SelectedValue = sdr8.GetString(7).ToString();


                    }

                }


            }

            sdr8.Close();
            conn.Close();
           
            }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();

         

            string str9 = "update patient set name='"+txtname.Text+ "',age='" +txtage.Text + "',address='" + txtadress.Text + "',phone='" + txtphone_number.Text + "',room='" + drpavailable_room.SelectedValue + "',date='" + txtdate.Text+ "' where id_number='" + txtid_no.Text + "'";
            string str10 = "UPDATE fees SET total_fees ='" + txtfees.Text + "' ,fees_paid ='" + txtcurrent_pid.Text + "'  ,remaining_fees='" + lblrest_fees.Text + "'  ,paid='" + chkbox.Checked + "'  where id_numbr='" + txtid_no.Text + "'";
            SqlCommand cmd9 = new SqlCommand(str9, conn);
            cmd9.ExecuteNonQuery();

            SqlCommand cmd10 = new SqlCommand(str10, conn);
            cmd10.ExecuteNonQuery();




            lblconfirm.Text = "Data Has Been Successfully Updated...!";
            conn.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtadress.Text = txtage.Text = txtcurrent_pid.Text = txtfees.Text = txtid_no.Text = txtname.Text = txtphone_number.Text =txtdate.Text= "";

            drpavailable_room.SelectedIndex = Drpdept.SelectedIndex = 0;
            lblconfirm.Text = lblrest_fees.Text = "";
            chkbox.Checked = false;

        }

        protected void BtnCheck_out_Click(object sender, EventArgs e)
        {
            conn2.Open();

            conn.Open();
            #region BackUp

            string str3 = "insert into patient(dept,id_number,name,age,address,phone,room,date) values((select dept_id from dept where name='" + Drpdept.SelectedValue + "'),'" + txtid_no.Text + "','" + txtname.Text + "','" + txtage.Text + "','" + txtadress.Text + "','" + txtphone_number.Text + "','" + drpavailable_room.SelectedValue + "','" + txtdate.Text + "')";
            SqlCommand cmd3 = new SqlCommand(str3, conn2);
            cmd3.ExecuteNonQuery();


                  string str4 = "update room set available='true' where dept_id=(select dept_id from dept where name='" + Drpdept.SelectedValue + "') And room='" + drpavailable_room.SelectedValue + "'";
     //       string str4 = "update room set available='true' where dept_id='1'And room='1'";

            SqlCommand cmd4 = new SqlCommand(str4, conn);
            cmd4.ExecuteNonQuery(); //does'nt matter in backup DataBase 



            string str5 = "insert into fees(id_numbr,total_fees,fees_paid,remaining_fees,paid,dept,room) values('" + txtid_no.Text + "','" + txtfees.Text + "','" + txtcurrent_pid.Text + "','" + lblrest_fees.Text + "','" + chkbox.Checked + "',(select dept_id from dept where name='" + Drpdept.SelectedItem.ToString() + "'),'" + drpavailable_room.SelectedValue + "')";
            SqlCommand cmd5 = new SqlCommand(str5, conn2);
            cmd5.ExecuteNonQuery();

            string str6 = "delete from patient where id_number='"+txtid_no.Text+"' ";
            SqlCommand cmd6 = new SqlCommand(str6, conn);
            cmd6.ExecuteNonQuery();

            string str7 = "delete from fees where id_numbr='" + txtid_no.Text + "' ";
            SqlCommand cmd7 = new SqlCommand(str7, conn);
            cmd7.ExecuteNonQuery();

            lblconfirm.Text = "Patient Have been Checked Out Successfully...!";
            #endregion

            conn.Close();

            conn2.Close();

        }
    }
    }
