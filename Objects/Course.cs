using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Registrar.Objects
{
  public class Course
  {
    private string _name;
    private string _time;
    private int _credit;
    private int _id;

    public Course(string Name, string Time, int Credit, int Id = 0)
    {
      _name = Name;
      _time = Time;
      _credit = Credit;
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
    public int GetCredit()
    {
      return _credit;
    }
    public string GetTime()
    {
      return _time;
    }

    public override bool Equals(System.Object otherCourse)
    {
      if (!(otherCourse is Course))
      {
        return false;
      }
      else
      {
        Course newCourse = (Course) otherCourse;
        bool idEquality = (this.GetId() == newCourse.GetId());
        bool nameEquality = (this.GetName() == newCourse.GetName());
        bool timeEquality = (this.GetTime() == newCourse.GetTime());
        bool creditEqulity = (this.GetCredit() == newCourse.GetCredit());
        return (idEquality && nameEquality && timeEquality && creditEqulity);
      }
    }

    public static void DeleteAll()
   {
     SqlConnection conn = DB.Connection();
     conn.Open();
     SqlCommand cmd = new SqlCommand("DELETE FROM courses;", conn);
     cmd.ExecuteNonQuery();
     conn.Close();
   }

   public static List<Course> GetAll()
    {
      List<Course> allCourses = new List<Course>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM courses;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int courseId = rdr.GetInt32(0);
        string courseName = rdr.GetString(1);
        string courseTime = rdr.GetString(2);
        int courseCredit = rdr.GetInt32(3);
        Course newCourse = new Course(courseName, courseTime, courseCredit, courseId);
        allCourses.Add(newCourse);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allCourses;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO courses (name, time, credits) OUTPUT INSERTED.id VALUES (@CourseName, @CourseTime, @CourseCredit)", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@CourseName";
      nameParameter.Value = this.GetName();

      SqlParameter timeParameter = new SqlParameter();
      timeParameter.ParameterName = "@CourseTime";
      timeParameter.Value = this.GetTime();

      SqlParameter creditParameter = new SqlParameter();
      creditParameter.ParameterName = "@CourseCredit";
      creditParameter.Value = this.GetCredit();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(timeParameter);
      cmd.Parameters.Add(creditParameter);
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

    public static Course Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM courses WHERE id = @CourseId", conn);
      SqlParameter courseIdParameter = new SqlParameter();
      courseIdParameter.ParameterName = "@CourseId";
      courseIdParameter.Value = id.ToString();
      cmd.Parameters.Add(courseIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundCourseId = 0;
      string foundCourseName = null;
      string foundCourseTime = null;
      int foundCourseCredit = 0;

      while(rdr.Read())
      {
        foundCourseId = rdr.GetInt32(0);
        foundCourseName = rdr.GetString(1);
        foundCourseTime = rdr.GetString(2);
        foundCourseCredit = rdr.GetInt32(3);
      }
      Course foundCourse = new Course(foundCourseName, foundCourseTime, foundCourseCredit, foundCourseId);

      if (rdr != null)
     {
       rdr.Close();
     }
     if (conn != null)
     {
       conn.Close();
     }

     return foundCourse;
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM courses WHERE id = @CourseId; DELETE FROM student_courses WHERE course_id = @CourseId;", conn);
      SqlParameter courseIdParameter = new SqlParameter();
      courseIdParameter.ParameterName = "@CourseId";
      courseIdParameter.Value = this.GetId();

      cmd.Parameters.Add(courseIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
    public void AddStudent(Student newStudent)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO student_courses (course_id, student_id) VALUES (@CourseId, @StudentId);", conn);
      SqlParameter courseIdParameter = new SqlParameter();
      courseIdParameter.ParameterName = "@CourseId";
      courseIdParameter.Value = this.GetId();
      cmd.Parameters.Add(courseIdParameter);

      SqlParameter studentIdParameter = new SqlParameter();
      studentIdParameter.ParameterName = "@StudentId";
      studentIdParameter.Value = newStudent.GetId();
      cmd.Parameters.Add(studentIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
    public List<Student> GetStudents()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT students.* FROM courses JOIN student_courses ON (course_id = student_courses.course_id) JOIN students ON (student_courses.student_id = students.id) WHERE courses.id = @CourseId;", conn);
      SqlParameter courseIdParameter = new SqlParameter();
      courseIdParameter.ParameterName = "@CourseId";
      courseIdParameter.Value = this.GetId();

      cmd.Parameters.Add(courseIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Student> students = new List<Student> {};

      while(rdr.Read())
        {
          int thisStudentId = rdr.GetInt32(0);
          string studentName = rdr.GetString(1);
          string studentDoe = rdr.GetString(2);
          Student foundStudent = new Student(studentName, studentDoe, thisStudentId);
          students.Add(foundStudent);
        }
        if (rdr != null)
        {
          rdr.Close();
        }

      if (conn != null)
      {
        conn.Close();
      }
      return students;
    }
  }
}
