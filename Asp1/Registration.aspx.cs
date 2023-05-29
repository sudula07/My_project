using System;
using System.Collections;
using System.Collections.Generic;

using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;


namespace Asp1
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                studentGridBind();
            }
        }
        private void studentGridBind()
        {
            GridView1.DataSource = StudentDAL.GetStudents();
            GridView1.DataBind();
        }

        protected void Radiobuttonlist(object sender, EventArgs e)
        {
            string message = "Selected Text: " + GENDER.SelectedItem.Text;
            message += "\\nSelected Value: " + GENDER.SelectedItem.Value;
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }

        void ClearAllControls()
        {

            FNAME.Text = "";
            LNAME.Text = " ";
            DOB.Text = " ";
            FATHERNAME.Text = " ";
            MOTHERNAME.Text = " ";
            BRANCH.SelectedValue = "0";
            GENDER.SelectedValue = "0";
            EMAIL.Text = "";
            PHNO.Text = " ";
            lblMsg.Text = " ";
            checkboxlist1.SelectedValue = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string hobbiesList = string.Empty;
                for (int i = 0; i < checkboxlist1.Items.Count; i++)
                {
                    if (checkboxlist1.Items[i].Selected)
                    {
                        hobbiesList += checkboxlist1.Items[i].Text + ", ";
                    }
                }
                Student objStudent = new Student();
                objStudent.FirstName = FNAME.Text;
                objStudent.LastName = LNAME.Text;
                objStudent.DOB = DOB.Text;
                objStudent.Gender = GENDER.SelectedValue;
                objStudent.Branch = BRANCH.SelectedValue;
                objStudent.FatherName = FATHERNAME.Text;
                objStudent.MotherName = MOTHERNAME.Text;
                objStudent.PhoneNumber = PHNO.Text;
                objStudent.EMail = EMAIL.Text;
                objStudent.Hobbies = hobbiesList.ToString();
                string msg = StudentDAL.InsertStudent(objStudent);
                if (msg == null)
                {
                    lblMsg.Text = "Student Details Has Been Added Successfully!";
                    studentGridBind();
                }
                else
                    lblMsg.Text = "Error -> " + msg;
                ClearAllControls();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string hobbiesList = string.Empty;
                for (int i = 0; i < checkboxlist1.Items.Count; i++)
                {
                    if (checkboxlist1.Items[i].Selected)
                    {
                        hobbiesList += checkboxlist1.Items[i].Text + ", ";
                    }
                }
                Student objStudent = new Student();
                objStudent.FirstName = FNAME.Text;
                objStudent.LastName = LNAME.Text;
                objStudent.DOB = DOB.Text;
                objStudent.Gender = GENDER.SelectedValue;
                objStudent.Branch = BRANCH.SelectedValue;
                objStudent.FatherName = FATHERNAME.Text;
                objStudent.MotherName = MOTHERNAME.Text;
                objStudent.PhoneNumber = PHNO.Text;
                objStudent.EMail = EMAIL.Text;
                objStudent.Hobbies = hobbiesList.ToString();
                objStudent.StudentId =Convert.ToInt32(hdnStudentId.Value); 
                string msg = StudentDAL.ModifyStudent(objStudent);
                if (msg == null)
                {
                    lblMsg.Text = "Student Details Has Been Added Successfully!";
                    studentGridBind();
                }
                else
                    lblMsg.Text = "Error -> " + msg;
                ClearAllControls();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Student objStudent = new Student();
                objStudent.StudentId = Convert.ToInt32(hdnStudentId.Value);
                string msg = StudentDAL.RemoveStudent(objStudent.StudentId);
                if (msg == null)
                {
                    lblMsg.Text = "Student Details Has Been Added Successfully!";
                    studentGridBind();
                }
                else
                    lblMsg.Text = "Error -> " + msg;
                ClearAllControls();
            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                FNAME.Text = GridView1.SelectedRow.Cells[2].Text;
                LNAME.Text = GridView1.SelectedRow.Cells[3].Text;
                DOB.Text = GridView1.SelectedRow.Cells[4].Text;
                if (GridView1.SelectedRow.Cells[8].Text == "M")
                    GENDER.SelectedIndex = 0;
                else if (GridView1.SelectedRow.Cells[8].Text == "F")
                    GENDER.SelectedIndex = 1;
                else
                    GENDER.SelectedIndex = 2;
                BRANCH.SelectedValue = GridView1.SelectedRow.Cells[7].Text;
                FATHERNAME.Text = GridView1.SelectedRow.Cells[5].Text;
                MOTHERNAME.Text = GridView1.SelectedRow.Cells[6].Text;
                PHNO.Text = GridView1.SelectedRow.Cells[10].Text;
                EMAIL.Text = GridView1.SelectedRow.Cells[9].Text;
                for (int i = 0; i < checkboxlist1.Items.Count; i++)
                {
                        checkboxlist1.Items[i].Selected = false;
                }
                string hobbyarrayString = GridView1.SelectedRow.Cells[11].Text;
                string[] hobbyArray = hobbyarrayString.Split(',');
                foreach (string hobby in hobbyArray)
                {
                    for (int i = 0; i < checkboxlist1.Items.Count; i++)
                    {
                        if (checkboxlist1.Items[i].Text.Trim() == hobby.Trim())
                        {
                            checkboxlist1.Items[i].Selected = true;
                        }
                    }
                }
                hdnStudentId.Value = GridView1.SelectedRow.Cells[1].Text;
            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
    }
}