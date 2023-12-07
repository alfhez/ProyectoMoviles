using ProyectoMoviles.API.Data;
using ProyectoMoviles.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoMoviles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EventosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EventosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] // 1. Agregamos el atributo [Authorize] para que solo los usuarios autenticados puedan acceder a los metodos de este controlador
        [HttpGet("ObtenerEventos")]
        public async Task<ActionResult<List<Evento>>> GetEventos()
        {
            return await context.Eventos.ToListAsync();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("AgregarEvento")]
        public async Task<ActionResult> PostEvento(Evento evento)
        {
            context.Add(evento);
            await context.SaveChangesAsync();
            return Ok();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("Evento/{id}")]
        //public async Task<ActionResult<Evento>> GetEvento(int id)
        //{
        //    var lugar = await context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
        //    if (lugar == null)
        //    {
        //        return NotFound();
        //    }
        //    return lugar;
        //}
    }
}
