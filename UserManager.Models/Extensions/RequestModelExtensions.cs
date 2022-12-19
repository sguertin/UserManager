using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Models.Extensions
{
    public static class RequestModelExtensions
    {
        public static CreateUserModel Map(this RequestModel request)
        {
            var newModel = new CreateUserModel
            {
                Name = request.DisplayName
            };
            return newModel;
        }
    }
}
