using NCPHARMACY.Models.Auth;
using NCPHARMACY.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NCPHARMACY.ServiceUser
{
    interface IUserServices
    {
        public UserResponse Auth(AuthRequest model);
    }
}
