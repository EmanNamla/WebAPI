﻿using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.ChangePassword
{
    public class ChangePasswordCommand :IRequest<Result<UserDto>>
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }
    }
}
