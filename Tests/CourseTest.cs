using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Registrar.Objects;

namespace Registrar
{
  [Collection("university_registrar_test")]
  public class CourseTest : IDisposable
  {
    public CourseTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=university_registrar_test;Integrated Security=SSPI;";
    }


    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Course.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfCoursesAreTheSame()
    {
      Course firstCourse = new Course("Bio 111", "8am", 4);
      Course secondCourse = new Course("Bio 111", "8am", 4);
      Assert.Equal(firstCourse, secondCourse);
    }

    [Fact]
    public void Test_Save_ToCourseDatabase()
    {
      Course testCourse = new Course("Bio 111", "8am", 4);
      testCourse.Save();

      List<Course> result = Course.GetAll();
      List<Course> testList = new List<Course>{testCourse};
      Assert.Equal(testList, result);
    }

    [Fact]
     public void Test_Save_AssignsIdToObject()
     {
      Course testCourse = new Course("Bio 111", "8am", 4);
       testCourse.Save();
       int testId = testCourse.GetId();
       int savedCourseId = Course.GetAll()[0].GetId();
       Assert.Equal(testId, savedCourseId);
     }

    [Fact]
    public void Test_Find_FindsCourseInDatabase()
    {
      Course testCourse = new Course("Bio 111", "8am", 4);
      testCourse.Save();
      Course foundCourse = Course.Find(testCourse.GetId());
      Assert.Equal(testCourse, foundCourse);
    }



    [Fact]
   public void TestStudent_AddsStudentToCourse_StudentList()
   {
     Course testCourse = new Course("Bio 111", "8am", 4);
     testCourse.Save();

     Student testStudent = new Student("Jim", "10-10-2010");
     testStudent.Save();

     testCourse.AddStudent(testStudent);

     List<Student> result = testCourse.GetStudents();
     List<Student> testList = new List<Student>{testStudent};

     Assert.Equal(testList, result);
   }

   [Fact]
   public void Test_ReturnsAllCoursesStudents_StudentList()
   {
     Course testCourse = new Course("Bio 111", "8am", 4);
     testCourse.Save();

     Student testStudent1 = new Student("Jim", "10-10-2010");
     testStudent1.Save();

     Student testStudent2 = new Student("Jimmy", "10-11-2011");
     testStudent2.Save();

     testCourse.AddStudent(testStudent1);
     testCourse.AddStudent(testStudent2);
     List<Student> result = testCourse.GetStudents();
     List<Student> testList = new List<Student> {testStudent1, testStudent2};

     Assert.Equal(testList, result);
   }
   [Fact]
   public void Delete_DeletesCourseAssociationsFromDataBase_CourseList()
   {
     Student testStudent = new Student("Jim", "10-10-2010");
     testStudent.Save();

     Course testCourse = new Course("Bio 111", "8am", 4);
     testCourse.Save();

     testCourse.AddStudent(testStudent);
     testCourse.Delete();

     List<Course> result = testStudent.GetCourses();
     List<Course> test = new List<Course>{};

     Assert.Equal(test, result);
   }
   public void Dispose()
   {
     Course.DeleteAll();
     Student.DeleteAll();

   }

  }
}
