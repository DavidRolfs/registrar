using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Registrar.Objects
{
  public class Student
  {
    private string _name;
    private string _doe;
    private int _id;

    public Student(string Name, string Doe, int Id = 0)
    {
      _name = Name;
      _doe = Doe;
      _id = Id;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetDoe()
    {
      return _doe;
    }

    public override bool Equals(System.Object otherStudent)
    {
      if (!(otherStudent is Student))
      {
        return false;
      }
      else
      {
        Student newStudent = (Student) otherStudent;
        bool idEquality = (this.GetId() == newStudent.GetId());
        bool nameEquality = (this.GetName() == newStudent.GetName());
        bool doeEquality = (this.GetDoe() == newStudent.GetDoe());
        return (idEquality && nameEquality && doeEquality );
      }
    }

    public static void DeleteAll()
   {
     SqlConnection conn = DB.Connection();
     conn.Open();
     SqlCommand cmd = new SqlCommand("DELETE FROM students;", conn);
     cmd.ExecuteNonQuery();
     conn.Close();
   }

   public static List<Student> GetAll()
    {
      List<Student> allStudents = new List<Student>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int studentId = rdr.GetInt32(0);
        string studentName = rdr.GetString(1);
        string studentDoe = rdr.GetString(2);
        Student newStudent = new Student(studentName, studentDoe, studentId);
        allStudents.Add(newStudent);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allStudents;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO students (name, doe) OUTPUT INSERTED.id VALUES (@StudentName, @StudentDoe)", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@StudentName";
      nameParameter.Value = this.GetName();

      SqlParameter doeParameter = new SqlParameter();
      doeParameter.ParameterName = "@Studentdoe";
      doeParameter.Value = this.GetDoe();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(doeParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static Student Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE id = @StudentId", conn);
      SqlParameter airlineIdParameter = new SqlParameter();
      airlineIdParameter.ParameterName = "@StudentId";
      airlineIdParameter.Value = id.ToString();
      cmd.Parameters.Add(airlineIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundStudentId = 0;
      string foundStudentName = null;
      string foundStudentDoe = null;

      while(rdr.Read())
      {
        foundStudentId = rdr.GetInt32(0);
        foundStudentName = rdr.GetString(1);
        foundStudentDoe = rdr.GetString(2);
      }
      Student foundStudent = new Student(foundStudentName, foundStudentDoe, foundStudentId);

      if (rdr != null)
     {
       rdr.Close();
     }
     if (conn != null)
     {
       conn.Close();
     }

     return foundStudent;
    }


  }
}
