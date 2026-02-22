using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public enum ErrorCodes
    {
        NOT_FOUND = 1,
        COULD_NOT_STORE_DATA = 2,
        INVALID_PERSON_ID = 3,
        INVALID_EMAIL_ADDRESS = 4,
        MISSING_REQUIRED_INFORMATION = 5,
        GUEST_NOT_FOUND = 6,
    }
}
