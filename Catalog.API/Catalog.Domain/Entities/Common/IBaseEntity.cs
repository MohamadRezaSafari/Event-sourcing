using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities.Common
{
    public interface IBaseEntity<out TKey>
    {
        TKey Id { get; }
    }
}
