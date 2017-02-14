using System.Collections.Generic;
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
        [HttpGet]
        public IEnumerable<Tip> Get()
        {
            var tips = _tipRepository.GetAll();
            return tips;
        }

        // GET api/tips/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/tips
        [HttpPost]
        public void Post([FromBody]Tip tip)
        {
            _tipRepository.Insert(tip);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
