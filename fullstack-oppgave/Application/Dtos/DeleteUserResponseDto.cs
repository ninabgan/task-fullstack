using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class DeleteUserResponseDto
    {
        public int Status { get; set; }
        public string? StatusMessage { get; set; }
        public bool Succeeded { get; set; }
    }
}
