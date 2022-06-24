using GFT.InWallet.Domain.Entity;
using GFT.InWallet.Infra.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GFT.InWallet.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<AssetController> _logger;
        public IBaseRepository<Asset> _repository { get; set; }
        public AssetController(ILogger<AssetController> logger, IBaseRepository<Asset> repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public ActionResult<IEnumerable<object>> GetAsset()
        {
            var AssetView = _repository.ReadAll();
            return Ok(AssetView.ToList());
        }

        // GET: api/Asset/5
        [HttpGet("{Symbol}")]
        public ActionResult<Asset> GetAsset(string Symbol)
        {
            var Asset = _repository
                .ReadSingle(u => u.Symbol == Symbol);

            if (Asset == null)
            {
                return NotFound();
            }
            return Asset;
        }

        // PUT: api/Asset/5
        [HttpPut("{symbol}")]
        public IActionResult PutAsset(string symbol, Asset Asset)
        {
            if (symbol != Asset.Symbol)
            {
                return BadRequest();
            }
            try
            {
                _repository.Update(Asset);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.Exists(symbol))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Asset
        [HttpPost]
        public ActionResult<Asset> PostAsset(Asset Asset)
        {
            if (!Asset.IsValid) return BadRequest(Asset.Notifications);

            _repository.Create(Asset);
            return CreatedAtAction("GetAsset", new { Symbol = Asset.Symbol }, Asset);
        }
        // DELETE: api/Asset/5
        [HttpDelete("{symbol}")]
        public ActionResult<Asset> DeleteAsset(string symbol)
        {
            _repository.Delete(symbol);
            return Ok("Delete with success!");
        }


    }
}