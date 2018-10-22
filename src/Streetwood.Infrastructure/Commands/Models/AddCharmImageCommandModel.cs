using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Streetwood.Infrastructure.CustomValidators;

namespace Streetwood.Infrastructure.Commands.Models
{
    public class AddCharmImageCommandModel : IRequest
    {
        [ValidGuid]
        public Guid Id { get; set; }

        public IFormFile File { get; set; }

        public AddCharmImageCommandModel(Guid id, IFormFile file)
        {
            Id = id;
            File = file;
        }
    }
}
