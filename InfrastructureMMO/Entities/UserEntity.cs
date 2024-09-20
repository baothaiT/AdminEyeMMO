﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace InfrastructureMMO.Entities
{
    public class UserEntity
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdatePwd { get; set; }
    }
}
