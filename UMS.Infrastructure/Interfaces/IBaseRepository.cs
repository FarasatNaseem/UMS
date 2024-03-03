using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Infrastructure.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T model, CancellationToken cancellationToken);
    }
}
