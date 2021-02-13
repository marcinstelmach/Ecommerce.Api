namespace Streetwood.Infrastructure.Commands.Models.Slides
{
    using System;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Streetwood.Core.Exceptions;

    public class AddSlideImageCommandModel : IRequest
    {
        public AddSlideImageCommandModel(Guid id, IFormFile file)
        {
            Id = id;
            File = file;
            Validate();
        }

        public Guid Id { get; set; }

        public IFormFile File { get; set; }

        private void Validate()
        {
            if (File == null)
            {
                throw new StreetwoodException(ErrorCode.EmptyImageFile);
            }

            if (Id == Guid.Empty)
            {
                throw new StreetwoodException(ErrorCode.InvalidId);
            }
        }
    }
}