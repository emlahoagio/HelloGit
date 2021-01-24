using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo3_Tier.Data;
using Model.Entities;

namespace Demo3_Tier.Controllers
{
    [Route("api/quan")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Demo3_TierContext _context;

        public StudentsController(Demo3_TierContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            return await _context.Student.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{StudentId}")]
        public async Task<ActionResult<Student>> GetStudent(int StudentId)
        {
            var student = await _context.Student.FindAsync(StudentId);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkStudentId=2123754
        [HttpPut("{StudentId}")]
        public async Task<IActionResult> PutStudent(int StudentId, Student student)
        {
            if (StudentId != student.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(StudentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkStudentId=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { StudentId = student.StudentId }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{StudentId}")]
        public async Task<IActionResult> DeleteStudent(int StudentId)
        {
            var student = await _context.Student.FindAsync(StudentId);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int StudentId)
        {
            return _context.Student.Any(e => e.StudentId == StudentId);
        }
    }
}
