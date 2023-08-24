using Microsoft.AspNetCore.Mvc;
using Olimpo.Controllers;
using Olimpo.Model;
using Olimpo.Web.Model;

namespace Olimpo.Web
{
    [ApiController]
    [Route("/")]
    public class Api : ControllerBase
    {
        #region Login
        [HttpPost]
        [Route("api/login")]
        public IActionResult LoginParticipante([FromBody] LoginRequest loginRequest)
        {
            return Ok();
        }
        #endregion

        #region Participante
        [HttpGet]
        [Route("api/participante")]
        public IActionResult GetParticipanteList()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/participante/{id}")]
        public IActionResult GetParticipanteById(int Id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api/participante")]
        public IActionResult CreateParticipante([FromBody] Participante participante)
        {
            if (participante == null)
            {
                return BadRequest("Invalid data.");
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/participante/{id}")]
        public IActionResult DeleteParticipanteById(int id)
        {
            Console.WriteLine(id);
            return NoContent();
        }
        #endregion

        #region Equipe
        [HttpGet]
        [Route("api/equipe")]
        public IActionResult GetEquipeList()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/equipe/{id}")]
        public IActionResult GetEquipeById(int id)
        {   
            Console.WriteLine(id);
            return Ok();
        }

        [HttpPost]
        [Route("api/equipe")]
        public IActionResult CreateEquipe([FromBody] Equipe equipe)
        {
            if (equipe == null)
            {
                return BadRequest("Invalid data.");
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/equipe/{id}")]
        public IActionResult DeleteEquipeById(int id)
        {

            Console.WriteLine(id);
            return NoContent();
        }

        [HttpPatch]
        [Route("api/equipe")]
        public IActionResult AddParticipanteToEquipe([FromBody] ParticipanteEquipeRequest participanteEquipeRequest)
        {

            return NoContent();
        }
        #endregion

        #region Evento
        [HttpGet]
        [Route("api/evento")]
        public IActionResult GetEventosList()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/evento/{id}")]
        public ActionResult<Evento> GetEventoById(int id)
        {
            Console.WriteLine(id);

            return Ok();
        }

        [HttpPost]
        [Route("api/evento")]
        public IActionResult CreateEvento([FromBody] Evento evento)
        {
            if (evento == null)
            {
                return BadRequest("Invalid data.");
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/evento/{id}")]
        public IActionResult DeleteEventoById(int id)
        {
            Console.WriteLine(id);

            return NoContent();
        }

        [HttpPatch]
        [Route("api/evento")]
        public IActionResult AddEquipeToEvento([FromBody] InscricaoEquipeRequest equipeData)
        {

            return Ok();
        }
        #endregion

        #region TDP
        [HttpGet]
        [Route("api/tdp")]
        public IActionResult GetTDPList()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/tdp/{equipeId}")]
        public IActionResult GetTDPByEquipe(int equipeId)
        {
            Console.WriteLine(equipeId);

            return Ok();
        }

        [HttpGet]
        [Route("api/tdp/{equipeId}/{categoria}")]
        public IActionResult GetTDPByEquipeCategoria(int equipeId, CategoriasType categoria)
        {
            Console.WriteLine("equipeId: {0}\ncategoria: {1}", equipeId, categoria);
            return Ok();
        }

        //todo(fnap): fix route
        [HttpPost]
        [Route("api/tdp")]
        public IActionResult CreateTdp([FromBody] TDP tdp)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("api/tdp/{equipeId}/{categoria}")]
        public IActionResult DeleteTdpById(int equipeId, CategoriasType categoria)
        {
            Console.WriteLine("equipeId: {0}\ncategoria: {1}", equipeId, categoria);
            return NoContent();
        }
        #endregion
    }
}