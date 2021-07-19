using ColaboradoresWebApi.DataBaseContext;
using ColaboradoresWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColaboradoresWebApi.Utils;

namespace ColaboradoresWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly AgexportDbContext AgDbContext;
        public ColaboradorController(AgexportDbContext _AgDbContext)
        {
            AgDbContext = _AgDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Colaborador colaborador)
        {

            colaborador.Edad = Funciones.calcularEdad(colaborador.FechaNacimiento);
            AgDbContext.Add(colaborador);
            await AgDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Colaborador>>> Get()
        {
            return await AgDbContext.Colaboradores.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Colaborador>> Get(int id)
        {
            return await AgDbContext.Colaboradores.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Colaborador colaborador)
        {
            colaborador.Edad = Funciones.calcularEdad(colaborador.FechaNacimiento);
            AgDbContext.Update(colaborador);
            await AgDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await AgDbContext.Colaboradores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            AgDbContext.Remove(new Colaborador() { Id = id});
            await AgDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
