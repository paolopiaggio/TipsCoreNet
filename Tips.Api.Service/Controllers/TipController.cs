using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tips.Data;
using Tips.Model;

namespace Tips.Api.Service.Controllers
{
    [Route("api/tips")]
    public class TipController : Controller
    {
        private readonly IRepository<Tip> _tipRepository;

        public TipController(IRepository<Tip> tipRepository)
        {
            _tipRepository = tipRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Tip> Get()
        {
            var tips = _tipRepository.GetAll();
            return tips;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
