using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;

namespace UserManager.Services;

public class DataConversionService : IDataConversionService
{
    public CreateUserModel ConvertRequestToUserModel(RequestModel request)
    {
        var newModel = new CreateUserModel
        {
            Name = request.DisplayName
        };
        return newModel;
    }
}