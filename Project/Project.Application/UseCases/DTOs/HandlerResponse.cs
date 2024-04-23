using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTOs
{
    public class HandlerResponse
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public Response? Data { get; set; }

        public HandlerResponse(string message, int status)
        {
            Message = message;
            Status = status;
        }

        public HandlerResponse(string message, int status, Response? data)
        {
            Message = message;
            Status = status;
            Data = data;
        }
    }
}
