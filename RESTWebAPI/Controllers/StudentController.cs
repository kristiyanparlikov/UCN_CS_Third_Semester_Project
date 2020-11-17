using DocuSign.eSign.Model;
using RESTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTWebAPI.Controllers
{
    public class StudentController : ApiController
    {

        List<Student> students = new List<Student>();
    public StudentController()
        {
            
            students.Add(new Student( "Alanis",  "Mirko",  "123",  "sjsjjs@nhh", 1, "12", "123",  "jjj" ));
            students.Add(new Student("Olivia", "denmark", "123", "sjsjjs@nhh", 2, "12", "123", "jjj"));
            students.Add(new Student("Sandija", "Lapina", "123", "sjsjjs@nhh", 3, "12", "123", "jjj"));
        }

        // GET: api/Student
        public List<Student> Get()
        {
            return students;
        }

       

        // GET: api/Student/5

        public Student Get(int id)
        {
            return students.Where(x=> x.Id==id).FirstOrDefault();
        }

        // POST: api/Student
        public void Post(Student val)
        {
            students.Add(val);
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
            students.RemoveAll(x => x.Id == id);
        }
    }
}
