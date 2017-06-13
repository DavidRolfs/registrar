using System;
using System.Collections.Generic;
using Registrar.Objects;
using System.Data;
using System.Data.SqlClient;
using Nancy;

namespace Registrar
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/student/add"] = _ => {
        return View["student_form.cshtml"];
      };

      Get["/course/add"] = _ => {
        return View["course_form.cshtml"];
      };

      Post["/student/add"] = _ => {
        Student newStudent = new Student(Request.Form["name"], Request.Form["doe"]);
        newStudent.Save();
        return View["success.cshtml"];
      };

      Post["/course/add"] = _ => {
        Course newCourse = new Course(Request.Form["name"], Request.Form["time"], Request.Form["credits"]);
        newCourse.Save();
        return View["success.cshtml"];
      };
      Get["/student/all"] = _ => {
        List<Student> AllStudents = Student.GetAll();
        return View["student_all.cshtml", AllStudents];
      };
      Get["/course/all"] = _ => {
        List<Course> AllCourses = Course.GetAll();
        return View["course_all.cshtml", AllCourses];
      };
      Get["student/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Student SelectedStudent = Student.Find(parameters.id);
        List<Course> StudentCourse = SelectedStudent.GetCourses();
        List<Course> AllCourses = Course.GetAll();
        model.Add("student", SelectedStudent);
        model.Add("studentCourse", StudentCourse);
        model.Add("allCourses", AllCourses);
        return View["student.cshtml", model];
      };
      Get["course/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Course SelectedCourse = Course.Find(parameters.id);
        List<Student> CourseStudent = SelectedCourse.GetStudents();
        List<Student> AllStudents = Student.GetAll();
        model.Add("course", SelectedCourse);
        model.Add("courseStudent", CourseStudent);
        model.Add("allStudents", AllStudents);
        return View["course.cshtml", model];
      };
      Post["students/add_course"] = _ => {
        Course course = Course.Find(Request.Form["course-id"]);
        Student student = Student.Find(Request.Form["student-id"]);
        student.AddCourse(course);
        return View["success.cshtml"];
      };
      Post["courses/add_student"]= _ => {
        Course course = Course.Find(Request.Form["course-id"]);
        Student student = Student.Find(Request.Form["student-id"]);
        course.AddStudent(student);
        return View["success.cshtml"];
      };


    }
  }
}
