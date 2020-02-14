using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    readonly DataContext _dataContext;
    public ValuesController(DataContext dataContext)
    {
      _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetValues()
    {
      var values = await _dataContext.Values.ToListAsync();
      return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var value = await _dataContext.Values.FirstOrDefaultAsync(v => v.Id == id);
      return Ok(value);
    }
  }
}
