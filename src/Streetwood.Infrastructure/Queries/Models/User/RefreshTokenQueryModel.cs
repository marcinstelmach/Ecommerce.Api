using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.User
{
    public class RefreshTokenQueryModel : IRequest<TokenModel>
    {
        [Required]
        public string JwtToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
