using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Tips.Data;
using Tips.Model;

namespace Tips.Api.Service.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/tips")]
    public class TipController : Controller
    {
        private readonly IRepository<Tip> _tipRepository;

        public TipController(IRepository<Tip> tipRepository)
        {
            _tipRepository = tipRepository;
        }

        // GET api/tips
        [HttpGet(Name = "GetAllTips")]
        public IActionResult Get()
        {
            var tips = _tipRepository.GetAll();
            return Ok(tips);
        }

        // GET api/tips/5
        [HttpGet("{id}", Name="GetTip")]
        public IActionResult Get(long id)
        {
            var tip = _tipRepository.Get(id);
            if (tip == null)
            {
                return NotFound();
            }
            return Ok(tip);
        }

        // POST api/tips
        [HttpPost(Name="CreateTip")]
        public IActionResult Post([FromBody]Tip tip)
        {
            if(tip.Id!=0)
            {
                throw new InvalidOperationException("id > 0");
            }
            tip.Id = _tipRepository.GetMaxId()+1;
            _tipRepository.Insert(tip);
            return this.CreatedAtRoute("GetTip", new { controller = "Tip", id = tip.Id }, tip);
        }

        // PUT api/tips/5
        [HttpPut("{id}", Name="UpdateTip")]
        public IActionResult Put(long id, [FromBody]Tip tip)
        {
            if (tip.Id != id)
            {
                return BadRequest();
            }
            if (_tipRepository.Get(id) == null)
            {
                return NotFound();
            }

            _tipRepository.Update(tip);
            return new NoContentResult();
        }

        // DELETE api/tips/5
        [HttpDelete("{id}", Name="DeleteTip")]
        public IActionResult Delete(long id)
        {
            var tipToDelete = _tipRepository.Get(id);
            if(tipToDelete == null)
            {
                return NotFound();
            }
            _tipRepository.Delete(tipToDelete);
            return Ok();
        }
    }
}
