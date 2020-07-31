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
    public class EventoController : ControllerBase
    {

        private readonly SalaContext _context;

        public EventoController(SalaContext context)
        {
             _context = context;
        }



        // GET: api/<EventoController>
        [HttpGet]  // http://localhost:52024/api/Evento
        public ActionResult Get()
        {
           try
            {
                SalaContext _context1 = _context;
                return base.Ok(_context1.Eventos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : {ex}");
            }


        }

        // GET api/<EventoController>/5
        /*[HttpGet("{id}")]
        public string Gettid(int id)
        {
            var evento = _context.Eventos
               .Where(x => x.id == id)
                .ToList();

        }*/

        //http://localhost:52024/api/evento/filtro/10
        [HttpGet("filtro/{id}")]
        public async Task<ActionResult<Evento>> GetEventos(int id)
        {
            var eventos = await _context.Eventos.FindAsync(id);

            if (eventos == null)
            {
                return NotFound();
            }

            return eventos;
        }


        // atualizar e inserir no mesmo metodo post
        [HttpPost] //http://localhost:52024/api/Evento
                   //{ "nome":"sala 3"}
        public ActionResult Post([FromBody] Evento evento)
        {
            try
            {

                if (evento.id > 0) // caso use pode e passe um ID maior que zero ira atualizar
                {
                    _context.Eventos.Update(evento);  //update
                    _context.SaveChanges();
                    return Created("api/sala", evento);

                }
                else
                {
                    _context.Eventos.Add(evento);  //insert
                    _context.SaveChanges();
                    return Created("api/sala", evento);
                }

                //return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : {ex}");
            }
        }



        // PUT api/<EventoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }



        [HttpPost("Deletar")] //http://localhost:52024/api/evento/Deletar
        //{id: 1}
        public ActionResult Deletar([FromBody] Evento evento)
        {
            try
            {

                _context.Eventos.Remove(evento);
                _context.SaveChanges();

                SalaContext _context2 = _context;
                return base.Ok(_context2.Eventos.ToList());  // RETORNA TODOS MENOS O QUE ACABOU DE DELETAR, PARA VISUALIZAR TESTE
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : {ex}");
            }
        }


        //http://localhost:52024/api/evento/delete/10
        [HttpGet("delete/{id}")]
        public async Task<ActionResult<Evento>> GetDelete(int id)
        {
            var eventos = await _context.Eventos.FindAsync(id);

            if (eventos == null)
            {
                return NotFound();
            }
            else
            {
                var sala = _context.Eventos
                        .Where(h => h.id == id)
                        .FirstOrDefault();
                
                _context.Eventos.Remove(sala);
                _context.SaveChanges();
                
            }

            return eventos;
        }



        // DELETE api/<EventoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // teste validação de data ja existe -> //  http://localhost:52024/api/evento/filtrodata/2020-03-01
        //A única regra de negócio é validar se já existe um evento para a
        //data selecionada e neste caso, não permitir o cadastro.
        [HttpGet("filtrodata/{data}")]
        public async Task<ActionResult<Evento>> GetData(DateTime data)
        {
            var eventos = _context.Eventos
                       .Where(h => h.data_inicial == data)
                       .FirstOrDefault();

            if (eventos == null)
            {
                return NotFound();
            }

            return eventos;
        }


    }
}
