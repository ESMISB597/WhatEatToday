using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatEatToday.Models;

namespace WhatEatToday.Controllers
{
    public class CheckInAPIController : ApiController
    {
        private WhatEatToday_Entities db = new WhatEatToday_Entities();

        // GET: api/CheckInAPI
        public IQueryable<CheckIn> Get()
        {
            var shr = from str in db.CheckIns
                  select str;
            return shr;
        }

        // GET: api/CheckInAPI/5
        public IHttpActionResult Get(int id)
        {
            CheckIn cr = db.CheckIns.Find(id);
            return Ok(cr);
        }

        // POST: api/CheckInAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CheckInAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CheckInAPI/5
        public void Delete(int id)
        {
        }
    }
}
