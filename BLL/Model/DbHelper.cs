using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class DbHelper
    {
        public EF_DataContext _context;
        public DbHelper(EF_DataContext context) {  _context = context; }

        //Get
        public List<StudentModel> GetStudents() 
        {
            List<StudentModel> response = new List<StudentModel>();
            var dataList = _context.Students.ToList();
            dataList.ForEach(row => response.Add(new StudentModel()
            {
                S_Id = row.S_Id,
                First_Name = row.First_Name,
                Last_Name = row.Last_Name,
                Email = row.Email,
                Department = row.Department,
                Gender = row.Gender,
                Phone_number = row.Phone_number,
                Address = row.Address
            }));
            return response;
        }


        public StudentModel GetStudentById(int id)
        {
            StudentModel response = new StudentModel();
            var row = _context.Students.Where(s => s.S_Id.Equals(id)).FirstOrDefault();
            return new StudentModel()
            {
                S_Id = row.S_Id,
                First_Name = row.First_Name,
                Last_Name = row.Last_Name,
                Email = row.Email,
                Department = row.Department,
                Gender = row.Gender,
                Phone_number = row.Phone_number,
                Address = row.Address
            };
        }


        //post,put and patch
        public void SaveStudent(StudentModel studentModel)
        {
            if (studentModel.S_Id > 0)
            {                
                // Post: 
                var newStudent = new Student
                {
                    First_Name = studentModel.First_Name,
                    Last_Name = studentModel.Last_Name,
                    Email = studentModel.Email,
                    Department = studentModel.Department,
                    Gender = studentModel.Gender,
                    Phone_number = studentModel.Phone_number,
                    Address = studentModel.Address
                };

                _context.Students.Add(newStudent);
                _context.SaveChanges();
                studentModel.S_Id = newStudent.S_Id; 
            }

            _context.SaveChanges();
        }

        public void UpdateStudent(int studentId, StudentModel studentModel)
        {
            var existingStudent = _context.Students.Where(s => s.S_Id.Equals(studentId)).FirstOrDefault();
            if (existingStudent != null)
            {
                existingStudent.First_Name = studentModel.First_Name;
                existingStudent.Last_Name = studentModel.Last_Name;
                existingStudent.Email = studentModel.Email;
                existingStudent.Department = studentModel.Department;
                existingStudent.Gender = studentModel.Gender;
                existingStudent.Phone_number = studentModel.Phone_number;
                existingStudent.Address = studentModel.Address;
            }
            studentModel.S_Id = existingStudent.S_Id;
            _context.SaveChanges();

        }


        //Delete
        public void DeleteStudent(int studentId) { 
            var student = _context.Students.Where(s => s.S_Id.Equals(studentId)).FirstOrDefault();
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

        }

    }
}
