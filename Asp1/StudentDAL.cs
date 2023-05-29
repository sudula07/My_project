using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Antlr.Runtime.Misc;
using System.Xml.Linq;
using System.Diagnostics;
using System.Security.Policy;
using System.EnterpriseServices.Internal;

public class StudentDAL
{
    public static DataSet GetStudents()
    {
        SqlConnection con = new SqlConnection(Database.ConnectionString);
        SqlDataAdapter sda = new SqlDataAdapter("USP_STUDENT_REGISTRATION", con);
        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        sda.SelectCommand.Parameters.AddWithValue("@MODE", "ALL");
        DataSet ds = new DataSet();
        sda.Fill(ds, "students");
        return ds;
    }

    public static Student GetStudent(int _studentId)
    {
        SqlConnection con = new SqlConnection(Database.ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_STUDENT_REGISTRATION", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STUDENTID", _studentId);
            cmd.Parameters.AddWithValue("@MODE", "SINGLE");
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Student objstudent = new Student();
                objstudent.FirstName = dr["FirstName"].ToString();
                objstudent.LastName = dr["LastName"].ToString();
                objstudent.DOB = dr["DOB"].ToString();
                objstudent.FatherName = dr["FatherName"].ToString();
                objstudent.MotherName = dr["MotherName"].ToString();
                objstudent.Branch = dr["Branch"].ToString();
                objstudent.Gender = dr["Gender"].ToString();
                objstudent.EMail = dr["EMail"].ToString();
                objstudent.PhoneNumber = dr["PhoneNumber"].ToString();
                objstudent.Hobbies = dr["Hobbies"].ToString();
                return objstudent;
            }
            else
                return null;
        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
            con.Close();
        }
    }
    public static string InsertStudent(Student objstudent)
    {
        SqlConnection con = new SqlConnection(Database.ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_STUDENT_REGISTRATION", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FNAME", objstudent.FirstName);
            cmd.Parameters.AddWithValue("@LNAME", objstudent.LastName);
            cmd.Parameters.AddWithValue("@DOB", objstudent.DOB);
            cmd.Parameters.AddWithValue("@FATHERNAME", objstudent.FatherName);
            cmd.Parameters.AddWithValue("@MOTHERNAME", objstudent.MotherName);
            cmd.Parameters.AddWithValue("@BRANCH", objstudent.Branch);
            cmd.Parameters.AddWithValue("@GENDER", objstudent.Gender);
            cmd.Parameters.AddWithValue("@EMAIL", objstudent.EMail);
            cmd.Parameters.AddWithValue("@PHNO", objstudent.PhoneNumber);
            cmd.Parameters.AddWithValue("@HOBBIES", objstudent.Hobbies);
            cmd.Parameters.AddWithValue("@MODE", "INSERT");
            cmd.ExecuteNonQuery();
            return null; // success 
        }
        catch (Exception ex)
        {
            return ex.Message;  // return error message
        }
        finally
        {
            con.Close();
        }
    }
    public static string ModifyStudent(Student objstudent)
    {
        SqlConnection con = new SqlConnection(Database.ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_STUDENT_REGISTRATION", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FNAME", objstudent.FirstName);
            cmd.Parameters.AddWithValue("@LNAME", objstudent.LastName);
            cmd.Parameters.AddWithValue("@DOB", objstudent.DOB);
            cmd.Parameters.AddWithValue("@FATHERNAME", objstudent.FatherName);
            cmd.Parameters.AddWithValue("@MOTHERNAME", objstudent.MotherName);
            cmd.Parameters.AddWithValue("@BRANCH", objstudent.Branch);
            cmd.Parameters.AddWithValue("@GENDER", objstudent.Gender);
            cmd.Parameters.AddWithValue("@EMAIL", objstudent.EMail);
            cmd.Parameters.AddWithValue("@PHNO", objstudent.PhoneNumber);
            cmd.Parameters.AddWithValue("@HOBBIES", objstudent.Hobbies);
            cmd.Parameters.AddWithValue("@MODE", "UPDATE");
            cmd.Parameters.AddWithValue("@STUDENTID", objstudent.StudentId);
            cmd.ExecuteNonQuery();
            return null; // success 
        }
        catch (Exception ex)
        {
            return ex.Message;  // return error message
        }
        finally
        {
            con.Close();
        }
    }
    public static string RemoveStudent(int studentId)
    {
        SqlConnection con = new SqlConnection(Database.ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_STUDENT_REGISTRATION", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STUDENTID", studentId);
            cmd.Parameters.AddWithValue("@MODE", "DELETE");
            cmd.ExecuteNonQuery();
            return null; // success 
        }
        catch (Exception ex)
        {
            return ex.Message;  // return error message
        }
        finally
        {
            con.Close();
        }
    }
}