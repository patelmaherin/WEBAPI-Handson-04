using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIHandson04.Models;

namespace WebAPIHandson04.Controllers
{
    public class BrandsController : ApiController
    {
        List<Brand> brands;
        public BrandsController()
        {
            brands = new List<Brand>
            {
                new Brand(){BrandId="B001",Name="Haro"},
                new Brand(){BrandId="B002",Name="Electra"},
                new Brand(){BrandId="B003",Name="Heller"},
                new Brand(){BrandId="B004",Name="Trek"},
            };
        }

        public HttpResponseMessage Post([FromUri] Brand brand)
        {

            brands.Add(brand);
            return Request.CreateResponse(HttpStatusCode.Created, brand);

        }
    }
}
