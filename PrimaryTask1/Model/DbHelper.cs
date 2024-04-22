using Microsoft.EntityFrameworkCore;
using PrimaryTask1.EF;


namespace PrimaryTask1.Model
{
    public class DbHelper
    {
        
            private readonly EF_DataContext _context;

            public DbHelper(EF_DataContext context)
            {
                _context = context;
            }

            public void SaveStudent(StudentModel studentModel)
            {
                _context.InsertStudent(studentModel.First_Name, studentModel.Last_Name, studentModel.Email, studentModel.Department, studentModel.Gender, studentModel.Phone_number, studentModel.Address);
            }

            public void UpdateStudent(int studentId, StudentModel studentModel)
            {
                _context.UpdateStudent(studentId, studentModel.First_Name, studentModel.Last_Name, studentModel.Email, studentModel.Department, studentModel.Gender, studentModel.Phone_number, studentModel.Address);
            }

            public void DeleteStudent(int studentId)
            {
                _context.DeleteStudent(studentId);
            }
        
        

            // Retrieve all students
            public List<StudentModel> GetStudents()
            {
                try
                {
                    var students = _context.Students.FromSqlRaw("EXECUTE get_students").ToList();
                    
                    List<StudentModel> studentModels = new List<StudentModel>();
                    foreach (var student in students)
                    {
                        studentModels.Add(new StudentModel
                        {
                            S_Id = student.S_Id,
                            First_Name = student.First_Name,
                            Last_Name = student.Last_Name,
                            Email = student.Email,
                            Department = student.Department,
                            Gender = student.Gender,
                            Phone_number = student.Phone_number,
                            Address = student.Address
                        });
                    }
                    return studentModels;
                }
                catch (Exception ex)
                {
                    
                    string errorMessage = ex.Message;
                    throw new Exception("Error executing stored procedure: get_students " + errorMessage, ex);
                }
            }



            // Retrieve student by ID
            public StudentModel GetStudentById(int id)
                {
                    var student = _context.GetStudentById(id);
                    if (student == null)
                        return null;

                    return new StudentModel
                    {
                        S_Id = student.S_Id,
                        First_Name = student.First_Name,
                        Last_Name = student.Last_Name,
                        Email = student.Email,
                        Department = student.Department,
                        Gender = student.Gender,
                        Phone_number = student.Phone_number,
                        Address = student.Address
                    };
                }


    }
}
