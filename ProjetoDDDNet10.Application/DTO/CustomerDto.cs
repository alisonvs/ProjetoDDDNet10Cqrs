using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.DTO
{
    public record CustomerDto(Guid Id, string Name, string Email);
}
