using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIHandson04.Models;

namespace WebAPIHandson04.Controllers
{
    public class CoursesController : ApiController
    {
        List<Course> course;
        public CoursesController()
        {
            course = new List<Course>
            {
                new Course { CourseId= 1, CourseName = "Android", Trainer = "devi", Fees = 20000, CourseDescription="Android is a mobile operating system development" },
                new Course(){CourseId =2, CourseName="ASP.Net" ,Trainer="Kevin", Fees=10000, CourseDescription = "ASP.NET is a open source web development framework"},
                new Course(){CourseId =3, CourseName="JSP" ,Trainer="Debaratha", Fees=10000, CourseDescription = "Java server pages is a technology used for web page creations"},
                new Course(){CourseId =4, CourseName="Xamarin.forms" ,Trainer="Mark John", Fees=15000, CourseDescription = "Xamarin forms are cross platform UI tools"},
            };
        }
        public HttpResponseMessage Get(string coursename)
        {

            try
            {

                if (!course.Any(x => x.CourseName == coursename))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course Name " + coursename.ToString() + " not found");
                }
                else
                {
                    var list = course.Where(x => x.CourseName == coursename).Single();

                    return Request.CreateResponse(HttpStatusCode.OK, list);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage post([FromBody] Course list)
        {

            course.Add(list);
            return Request.CreateResponse(HttpStatusCode.Created, list);

        }

    }
}
