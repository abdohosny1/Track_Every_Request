using Microsoft.AspNetCore.Mvc;

namespace Track_Every_Request.Model
{
    public class ReferenceDto
    {
        [FromHeader(Name = "X-Correlation-ID")]
        public string CorrelationID { get; set; }

        [FromHeader(Name = "X-Trace-ID")]
         public string TraceId { get; set; }
    }
}
