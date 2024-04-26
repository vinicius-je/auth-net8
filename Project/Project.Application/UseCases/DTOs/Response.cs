using Project.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UseCases.DTOs
{
    public class Response
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public UserDTO? Data { get; set; }

        public Response(string message, int status)
        {
            Message = message;
            Status = status;
        }

        public Response(string message, int status, UserDTO? data)
        {
            Message = message;
            Status = status;
            Data = data;
        }
    }
}
