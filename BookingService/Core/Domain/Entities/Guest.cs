using Domain.Exceptions;
using Domain.Ports;
using Domain.ValueObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public PersonId DocumentId { get; set; }

        private void ValidateState() 
        {
            if(DocumentId == null ||
               string.IsNullOrEmpty(DocumentId.IdNumber) ||
               DocumentId.IdNumber.Length <= 3)
            {
                throw new InvalidPersonDocumentIdException();
            }

            if(string.IsNullOrEmpty(Name) ||
               string.IsNullOrEmpty(Email) ||
               string.IsNullOrEmpty(Surname))
            {
                throw new MissingRequiredInformation();
            }

            if (!Utils.IsValidEmail(Email))
            {
                throw new InvalidEmailException();
            }
        }

        public async Task Save(IGuestRepository repository)
        {
            this.ValidateState();

            if(this.Id == 0)
            {
                this.Id = await repository.Create(this);
            }else
            {
                //TODO ATUALIZAR
            }
        }
    }
}
