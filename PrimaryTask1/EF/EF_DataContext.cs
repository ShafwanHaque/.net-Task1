using Microsoft.EntityFrameworkCore;
using PrimaryTask1.Model;
using System.Collections.Generic;
using System.Linq;

namespace PrimaryTask1.EF
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        // Map stored procedures to methods
        public virtual DbSet<Student> Students { get; set; }

        // Stored procedures
        public virtual void InsertStudent(string firstName, string lastName, string email, string department, string gender, string phoneNumber, string address)
        {
            try
            {
                this.Database.ExecuteSqlRaw("CALL insert_student({0}, {1}, {2}, {3}, {4}, {5}, {6})", firstName, lastName, email, department, gender, phoneNumber, address);
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Error executing stored procedure: insert_student", ex);
            }
        }

        public virtual void UpdateStudent(int id, string firstName, string lastName, string email, string department, string gender, string phoneNumber, string address)
        {
            try
            {
                this.Database.ExecuteSqlRaw("CALL update_student({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", id, firstName, lastName, email, department, gender, phoneNumber, address);
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Error executing stored procedure: update_student", ex);
            }
        }

        public virtual void DeleteStudent(int id)
        {
            try
            {
                this.Database.ExecuteSqlRaw("CALL delete_student({0})", id);
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Error executing stored procedure: delete_student", ex);
            }
        }

        public virtual IEnumerable<Student> GetStudents()
        {
            try
            {
                return this.Students.FromSqlRaw("SELECT * FROM get_students()").ToList();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Error executing stored procedure: get_students", ex);
            }
        }

        public virtual Student GetStudentById(int id)
        {
            try
            {
                return this.Students.FromSqlRaw("SELECT * FROM get_student_by_id({0})", id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Error executing stored procedure: get_student_by_id", ex);
            }
        }
    }
}