using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Registrar.Objects;

namespace Registrar
{
  [Collection("university_registrar_test")]
  public class RegistrarTest : IDisposable
  {
    public RegistrarTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=university_registrar_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Student.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfStudentsAreTheSame()
    {
      Student firstStudent = new Student("Jim", "10-10-2010");
      Student secondStudent = new Student("Jim", "10-10-2010");
      Assert.Equal(firstStudent, secondStudent);
    }

    [Fact]
    public void Test_Save_ToStudentDatabase()
    {
      Student testStudent = new Student("Jim", "10-10-2010");
      testStudent.Save();

      List<Student> result = Student.GetAll();
      List<Student> testList = new List<Student>{testStudent};
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
     Student testStudent = new Student("Jim", "10-10-2010");
      testStudent.Save();
      int testId = testStudent.GetId();
      int savedStudentId = Student.GetAll()[0].GetId();
      Assert.Equal(testId, savedStudentId);
    }

    [Fact]
    public void Test_Find_FindsStudentInDatabase()
    {
     Student testStudent = new Student("Jim", "10-10-2010");
     testStudent.Save();
     Student foundStudent = Student.Find(testStudent.GetId());
     Assert.Equal(testStudent, foundStudent);
    }




    [Fact]
   public void TestCourse_AddsCourseToStudent_CourseList()
   {
     Student testStudent = new Student("Jim", "10-10-2010");
     testStudent.Save();

     Course testCourse = new Course("Bio 111", "8am", 4);
     testCourse.Save();

     testStudent.AddCourse(testCourse);

     List<Course> result = testStudent.GetCourses();
     List<Course> testList = new List<Course>{testCourse};

     Assert.Equal(testList, result);
   }

   [Fact]
   public void TestCourse_ReturnsAllStudentCourses_CourseList()
   {
     Student testStudent = new Student("Jim", "10-10-2010");
     testStudent.Save();

     Course testCourse1 = new Course("Bio 111", "8am", 4);
     testCourse1.Save();

     Course testCourse2 = new Course("Paper 122", "6am", 1);
     testCourse2.Save();

     testStudent.AddCourse(testCourse1);
     List<Course> result = testStudent.GetCourses();
     List<Course> testList = new List<Course> {testCourse1};

     Assert.Equal(testList, result);
   }
   [Fact]
   public void Delete_DeletesStudentAssociationsFromDataBase_StudentList()
   {
     Course testCourse = new Course("Bio 111", "8am", 4);
     testCourse.Save();

     Student testStudent = new Student("Jim", "10-10-2010");
     testStudent.Save();

     testStudent.AddCourse(testCourse);
     testStudent.Delete();

     List<Student> result = testCourse.GetStudents();
     List<Student> test = new List<Student>{};

     Assert.Equal(test, result);
   }



    public void Dispose()
    {
      Student.DeleteAll();
      Course.DeleteAll();
    }
  }
}
