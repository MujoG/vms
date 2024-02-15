using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static SimpleUserDto ToSimpleUserDTO(this AppUser appUser)
        {
            return new SimpleUserDto
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                Email = appUser.Email
            };
        }
    }
}