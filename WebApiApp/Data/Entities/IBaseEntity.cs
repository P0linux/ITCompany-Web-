using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Data.Entities
{
    interface IBaseEntity
    {
        int Id { get; set; }
    }
}
