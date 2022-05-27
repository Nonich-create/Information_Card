using Information_Card.Core.Entities;
using Information_Card.Core.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace Information_Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : WebApiBase<Employee, EmployeeAPIController>
    {
        public EmployeeAPIController(IRepository<Employee> repository) : base(repository)
        {

        }
    }
}
 