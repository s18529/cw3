using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zad3.DAL;
using Zad3.Models;

namespace Zad3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IDbService db;
        public StudentController(IDbService service)
        {
            db = service;
        }

        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            return Ok(db.GetStudents());
        }
        [HttpGet("{id}")]
        public IActionResult GetSudents(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            } else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie Znaleziono studenta");
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //... add to database
            //... generatig index number
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Usuwanie Zakończone");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id)
        {
            return Ok("Aktualizowanie Zakończone");
        }
    }
}
