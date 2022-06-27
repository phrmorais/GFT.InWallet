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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<object>> GetAsset()
        {
            var AssetView = _repository.ReadAll();
            return Ok(AssetView.ToList());
        }

        // GET: api/Asset/5
        [HttpGet("{Symbol}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Asset> PostAsset(Asset Asset)
        {
            Asset.Validate();
            if (!string.IsNullOrEmpty(Asset.Symbol) && _repository.Exists(Asset.Symbol))
                Asset.AddNotification("Symbol", "This symbol already exists in the database");
            if (!Asset.IsValid) return BadRequest(Asset.Notifications);

            _repository.Create(Asset);
            return Created($"GetAsset/{Asset.Symbol}", Asset);
        }
        // DELETE: api/Asset/5
        [HttpDelete("{symbol}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Asset> DeleteAsset(string symbol)
        {
            _repository.Delete(symbol);
            return Ok("Delete with success!");
        }


    }
}