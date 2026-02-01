using Entities = Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Guest.DTOs
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public int IdTypeCode { get; set; }

        public static Entities.Guest MapToEntity(GuestDTO dto)
        {
            return new Entities.Guest
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                DocumentId = new Domain.ValueObjects.PersonId
                {
                    IdNumber = dto.IdNumber,
                    DocumentType = (DocumentType)dto.IdTypeCode,
                }
            };
        }
    }
}
