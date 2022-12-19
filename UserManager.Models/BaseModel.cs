using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public abstract class BaseModel
    {
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
