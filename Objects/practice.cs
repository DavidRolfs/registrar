// public void Delete()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       SqlCommand cmd = new SqlCommand("DELETE FROM courses WHERE id = @CourseId; DELETE FROM student_courses WHERE course_id = @CourseId;", conn);
//       SqlParameter courseIdParameter = new SqlParameter();
//       courseIdParameter.ParameterName = "@CourseId";
//       courseIdParameter.Value = this.GetId();
//
//       cmd.Parameters.Add(courseIdParameter);
//       cmd.ExecuteNonQuery();
//
//       if (conn != null)
//       {
//         conn.Close();
//       }
//     }
//     public void AddStudent(Student newStudent)
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       SqlCommand cmd = new SqlCommand("INSERT INTO student_courses (course_id, student_id) VALUES (@CourseId, @StudentId);", conn);
//       SqlParameter courseIdParameter = new SqlParameter();
//       courseIdParameter.ParameterName = "@CourseId";
//       courseIdParameter.Value = this.GetId();
//       cmd.Parameters.Add(courseIdParameter);
//
//       SqlParameter studentIdParameter = new SqlParameter();
//       studentIdParameter.ParameterName = "@StudentId";
//       studentIdParameter.Value = newStudent.GetId();
//       cmd.Parameters.Add(studentIdParameter);
//
//       cmd.ExecuteNonQuery();
//
//       if (conn != null)
//       {
//         conn.Close();
//       }
//     }
//     public List<Student> GetStudents()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       SqlCommand cmd = new SqlCommand("SELECT student_id FROM student_courses WHERE course_id = @CourseId;", conn);
//       SqlParameter courseIdParameter = new SqlParameter();
//       courseIdParameter.ParameterName = "@CourseId";
//       courseIdParameter.Value = this.GetId();
//       cmd.Parameters.Add(courseIdParameter);
//
//       SqlDataReader rdr = cmd.ExecuteReader();
//
//       List<int> studentIds = new List<int> {};
//       while(rdr.Read())
//       {
//         int studentId = rdr.GetInt32(0);
//         studentIds.Add(studentId);
//       }
//       if (rdr != null)
//       {
//         rdr.Close();
//       }
//
//       List<Student> students = new List<Student> {};
//       foreach (int studentId in studentIds)
//       {
//         SqlCommand studentQuery = new SqlCommand("SELECT * FROM students WHERE id = @StudentId;", conn);
//
//         SqlParameter studentIdParameter = new SqlParameter();
//         studentIdParameter.ParameterName = "@StudentId";
//         studentIdParameter.Value = studentId;
//         studentQuery.Parameters.Add(studentIdParameter);
//
//         SqlDataReader queryReader = studentQuery.ExecuteReader();
//         while(queryReader.Read())
//         {
//               int thisStudentId = queryReader.GetInt32(0);
//               string studentName = queryReader.GetString(1);
//               string studentDoe = queryReader.GetString(2);
//               Student foundStudent = new Student(studentName, studentDoe, thisStudentId);
//               students.Add(foundStudent);
//         }
//         if (queryReader != null)
//         {
//           queryReader.Close();
//         }
//       }
//       if (conn != null)
//       {
//         conn.Close();
//       }
//       return students;
//     }
