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


    public void Dispose()
    {
      Student.DeleteAll();
      Course.DeleteAll();
    }
  }
}
