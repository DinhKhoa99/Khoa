using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto.courseId)
        {
            int CourseId = adto.CourseId;
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendences.Any(a => a.AttendeeId == userId && a.CourseId == CourseId))
                return BadRequest("The Attendances are already exists");
            var attendence = new Attendance
            {
                CourseId = attendanceDto.courseId,
                AttendeeId = User.Identity.GetUserId()
            };
            _dbContext.Attendences.Add(attendence);
            _dbContext.SaveChanges();
            return Ok(); 
        }
    }
}
