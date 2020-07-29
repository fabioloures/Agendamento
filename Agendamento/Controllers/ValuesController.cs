using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Dominio;
using Agendamento.reposit;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly SalaContext _context;
        public ValuesController(SalaContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet("filtro/{nome}")]   //select SALA
        public ActionResult GetFitro(string nome)
        {
            var listSalas =  (from sala in _context.Salas
                              where sala.nome.Contains(nome)
                              select sala).ToList();
            return Ok(listSalas);

            //var listSalas = _context.Salas.ToList();
            //return Ok(listSalas);
        }

        
        // GET api/values/5   
        [HttpGet("Atualizar/{nomeSala}")] //insert
        public ActionResult Get(string nomeSala)
        {
            //var sala = new Sala { nome = nomeSala };
            //_context.Salas.Add(sala);  //insert
            //_context.SaveChanges();
            
            var sala = _context.Salas.
                        Where(h => h.id == 3)
                        .FirstOrDefault();
            sala.nome = nomeSala;

            _context.SaveChanges();

            //var sala = new Sala { nome = nomeSala };
            //_context.SaveChanges();


            return Ok();
         }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var sala = _context.Salas
                .Where(x => x.id == id)
                .Single();
            _context.Salas.Remove(sala);
            _context.SaveChanges();

        }
    }
}
