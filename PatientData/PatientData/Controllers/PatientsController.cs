using MongoDB.Bson;
using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PatientData.Controllers
{
    [EnableCors("*","*","GET")]
    [Authorize]
    public class PatientsController : ApiController
    {
        MongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }

        public IEnumerable<Patient> Get()
        {
            return _patients.FindAll();
        }

        //public HttpResponseMessage Get(string id)
        //{
        //    var patient = _patients.FindOneById(ObjectId.Parse(id));
        //    if (patient == null)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found.");
        //    }
        //    return Request.CreateResponse(patient);
        //}

        public IHttpActionResult Get(string id)
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [Route("api/patients/{id}/medications")]
        //public HttpResponseMessage GetMedications(string id)
        //{
        //    var patient = _patients.FindOneById(ObjectId.Parse(id));
        //    if (patient == null)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found.");
        //    }
        //    return Request.CreateResponse(patient.Medications);
        //}
        public IHttpActionResult GetMedications(string id)
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient.Medications);
        }
    }
}
