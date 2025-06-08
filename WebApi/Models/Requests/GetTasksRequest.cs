using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;

namespace WebApi.Models.Requests
{
    public class GetTasksRequest : AAuthKeyRequestBase<TaskFilter>
    {
    }
}