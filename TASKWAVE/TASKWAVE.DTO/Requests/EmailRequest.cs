using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.API.Requests
{
    public record EmailRequest(string mailTO, string mailSubject, string mailBody);
}
