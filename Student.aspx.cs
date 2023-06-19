using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace com.project
{
    public partial class Student : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select * from Country";
                SqlConnection cn = new SqlConnection(@"Data Source=Akku;Initial Catalog=Company;Integrated Security=True");
                cn.Open();
                SqlCommand cmd = new SqlCommand(s, cn);
                SqlDataAdapter da = new SqlDataAdapter(s, cn);
                DataTable data = new DataTable();
                da.Fill(data);
                DropDownList1.DataSource = data;
                DropDownList1.DataTextField = "C_Name";
                DropDownList1.DataValueField = "C_id";
                DropDownList1.DataBind();

            }
            string password = TextBox3.Text;
            TextBox3.Attributes.Add("value", password);
            string password1 = TextBox4.Text;
            TextBox4.Attributes.Add("value", password);


        } 
        void Empty()
        {
            //Data clear
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox19.Text = string.Empty;
            TextBox20.Text = string.Empty;
            TextBox21.Text = string.Empty;
            TextBox9.Text = string.Empty;
            TextBox10.Text = string.Empty;
            TextBox11.Text = string.Empty;
            TextBox12.Text = string.Empty;
            TextBox22.Text = string.Empty;
            TextBox17.Text = string.Empty;
            TextBox15.Text = string.Empty;
            TextBox16.Text = string.Empty;

        }



        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                string s = "select * from City where S_id='" + DropDownList2.SelectedValue + "'";
                SqlConnection cn = new SqlConnection(@"Data Source=Akku;Initial Catalog=Company;Integrated Security=True");
                cn.Open();
                SqlCommand cmd = new SqlCommand(s, cn);
                SqlDataAdapter da = new SqlDataAdapter(s, cn);
                DataTable data = new DataTable();
                da.Fill(data);
                DropDownList3.DataSource = data;
                DropDownList3.DataTextField = "City_Name";
                DropDownList3.DataValueField = "City_id";
                DropDownList3.DataBind();


            
        }

        protected void TextBox20_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(TextBox10.Text) > float.Parse(TextBox20.Text) && float.Parse(TextBox20.Text) > 0)
                {

                    TextBox16.Text = (float.Parse(TextBox20.Text) / float.Parse(TextBox10.Text) * 100).ToString();
                }
                else
                {
                    TextBox16.Text = "0";
                }
            }
            catch
            {

            }
        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(TextBox9.Text) > float.Parse(TextBox12.Text) && float.Parse(TextBox12.Text) > 0)
                {


                    TextBox15.Text = (float.Parse(TextBox12.Text) / float.Parse(TextBox9.Text) * 100).ToString();
                }
                else
                {
                    TextBox15.Text = "0";
                }
            }
            catch
            {

            }
        }

        protected void TextBox21_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(TextBox11.Text) > float.Parse(TextBox21.Text) && float.Parse(TextBox21.Text) > 0)
                {
                    TextBox17.Text = (float.Parse(TextBox21.Text) / float.Parse(TextBox11.Text) * 100).ToString();
                }
                else
                {
                    TextBox17.Text = "0";
                }
            }
            catch
            {

            }
            try
            {
                TextBox22.Text = (float.Parse(TextBox15.Text) + float.Parse(TextBox16.Text) + float.Parse(TextBox17.Text) / 3).ToString();
            }
            catch
            {

            }
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string[] dobs = TextBox5.Text.Split('-');
                string adob = dobs[2] + "/" + dobs[1] + "/" + dobs[0];

                DateTime dob = Convert.ToDateTime(adob);
                int age = (DateTime.Now.Subtract(dob).Days) / 365;
                TextBox19.Text = age.ToString();
                    
            }
            catch
            {

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "select * from State where C_id='" + DropDownList1.SelectedValue + "'";
            SqlConnection cn = new SqlConnection(@"Data Source=Akku;Initial Catalog=Company;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            SqlDataAdapter da = new SqlDataAdapter(s, cn);
            DataTable data = new DataTable();
            da.Fill(data);
            DropDownList2.DataSource = data;
            DropDownList2.DataTextField = "S_Name";
            DropDownList2.DataValueField = "S_id";
            DropDownList2.DataBind();
        }

      

        protected void Button2_Click(object sender, EventArgs e)
        {
            String s = "Insert into Student_full_data(Stu_Name,Stu_Email,Password,Date_of_Birth,Age,Country,State,City) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "','" + TextBox19.Text + "','" + DropDownList1.SelectedItem + "','" + DropDownList2.SelectedItem + "','" + DropDownList3.SelectedItem + "')";
            SqlConnection sq = new SqlConnection(@"Data Source=Akku;Initial Catalog=Company;Integrated Security=True");
            sq.Open();

            SqlCommand sc = new SqlCommand(s, sq);
            int i = sc.ExecuteNonQuery();

            if (i > 0)
            {
                Response.Write("<script>alert('Data and Marks Inserted successfully.....')</script>");
            }
            else
            {
                Response.Write("<script>alert('Data and Marks not Inserted successfully.....')</script>");
            }
            
            sq.Close();

            String q = "insert into Course(Courses, Obtaining, Obtained, Percentage, Average) values('HighSchhol','" + TextBox9.Text + "','" + TextBox12.Text + "','" + TextBox15.Text + "','" + TextBox22.Text + "')," +
               "('Intermediate','" + TextBox10.Text + "','" + TextBox20.Text + "','" + TextBox16.Text + "','" + TextBox22.Text + "')," +
              "('Graduation','" + TextBox11.Text + "','" + TextBox21.Text + "','" + TextBox17.Text + "','" + TextBox22.Text + "')";

            SqlConnection cn = new SqlConnection(@"Data Source=Akku;Initial Catalog=Company;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand(q, cn);

            int c = cmd.ExecuteNonQuery();

            //if (c > 0)
            //{
            //    Response.Write("Marks inserted Successfully..........");
            //}
            //else
            //{
            //    Response.Write("Marks Not inserted.......");
            //}


            Empty();

        }
    }
}

        
    