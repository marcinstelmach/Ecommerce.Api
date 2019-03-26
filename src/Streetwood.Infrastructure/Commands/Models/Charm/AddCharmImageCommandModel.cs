using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.CustomValidators;

namespace Streetwood.Infrastructure.Commands.Models.Charm
{
    public class AddCharmImageCommandModel : IRequest
    {
        [ValidGuid]
        public Guid Id { get; protected set; }

        public IFormFile File { get; protected set; }

        public AddCharmImageCommandModel(Guid id, IFormFile file)
        {
            Id = id;
            File = file;

            Validate();
        }

        private void Validate()
        {
            if (File == null)
            {
                throw new StreetwoodException(ErrorCode.EmptyImageFile);
            }
        }
    }
}
