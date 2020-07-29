using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Dominio;
using Agendamento.reposit;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Agendamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly SalaContext _context;
       public SalaController(SalaContext context)
        {
            _context = context;

        }

        
        // GET: api/<SalaController>
        [HttpGet]  // http://localhost:52024/api/Sala
        public ActionResult Get()
        {
            
            try
            {
                SalaContext _context1 = _context;
                return base.Ok(_context1.Salas.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : {ex}");
            }


        }

        // GET api/<SalaController>/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok("Value");
        }

        [HttpGet("Atualizar/{nomeSala}")] //insert
        public ActionResult Get(string nomeSala)
        {
           

            var sala = _context.Salas
                        //.Where(h => h.id == 3)
                        .FirstOrDefault();
            sala.nome = nomeSala;

            _context.SaveChanges();

            return Ok();
        }



        [HttpPost] //http://localhost:52024/api/Sala
        //{ "nome":"sala 3"}
    public ActionResult Post([FromBody]Sala sala)
        {
            try
            {

                if (sala.id > 0) // caso use pode e passe um ID maior que zero ira atualizar
                {
                    _context.Salas.Update(sala);  //update
                    _context.SaveChanges();
                    return Created("api/sala", sala);

                }
                else {
                    _context.Salas.Add(sala);  //insert
                    _context.SaveChanges();
                    return Created("api/sala", sala);
                }

                //return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : {ex}");
            }
        }



        // PUT api/<SalaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPost("Deletar")] //http://localhost:52024/api/Sala/Deletar
        //{id: 1}
        public ActionResult Deletar([FromBody] Sala sala)
        {
            try
            {

                _context.Salas.Remove(sala); 
                _context.SaveChanges();

                SalaContext _context2 = _context;
                return base.Ok(_context2.Salas.ToList());  // RETORNA TODOS MENOS O QUE ACABOU DE DELETAR, PARA VISUALIZAR TESTE


            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : {ex}");
            }
        }


        // DELETE api/<SalaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
