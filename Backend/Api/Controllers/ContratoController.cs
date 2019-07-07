using System;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private IContratoService conSer;
        public ContratoController(IContratoService conSer)
        {
            this.conSer=conSer;
        }

        [HttpGet]
        public ActionResult GetAll(){
            return Ok(
                conSer.GetAll()
            );
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id){
            return Ok(
                conSer.Get(id)
            );
        }

        [HttpPut]
        public ActionResult Update([FromBody] Contrato cl){
            return Ok(
                conSer.Update(cl)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            return Ok(
                conSer.Delete(id)
            );
        }

        [HttpGet]
        public ActionResult fetchContratoByExpirar(){
            return Ok(
                conSer.fetchByExpirar()
            );
        }

        [HttpGet("{inicio},{fin}")]
        public ActionResult fetchContratoByFecha([FromRoute] DateTime inicio, [FromRoute] DateTime fin){
            return Ok(
                conSer.fetchByDate(inicio, fin)
            );
        }

        [HttpPost]
        public ActionResult Crear([FromBody] Contrato cl){
            return Ok(
                conSer.Save(cl)
            );
        }
    }
}