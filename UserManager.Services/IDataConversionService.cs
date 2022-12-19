using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;

namespace UserManager.Services
{
    public interface IDataConversionService
    {
        CreateUserModel ConvertRequestToUserModel(RequestModel request);
    }
}
