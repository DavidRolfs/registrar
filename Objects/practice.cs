// "SELECT students.* FROM courses JOIN student_courses ON (courseid = student_courses.course_id) JOIN students ON (student_courses.student_id = students.id) WHERE courses.id = @CourseId;"
//
// "SELECT courses.* FROM students JOIN student_courses ON (student_id = student_courses.student_id) JOIN courses ON (student_courses.course_id = courses.id) WHERE students.id = @studentId;"
//
// "SELECT tasks.* FROM categories JOIN categories_tasks ON (categories.id = categories_tasks.category_id) JOIN tasks ON (categories_tasks.task_id = tasks.id) WHERE categories.id = @CategoryId;"
