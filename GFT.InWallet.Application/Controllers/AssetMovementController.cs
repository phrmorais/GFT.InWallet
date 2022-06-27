using GFT.InWallet.Business.Core;
using GFT.InWallet.Domain.Entity;
using GFT.InWallet.Infra.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GFT.InWallet.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetMovementController : ControllerBase
    {
        private readonly ILogger<AssetMovementController> _logger;
        public IBaseRepository<AssetMovement> _repository { get; set; }
        public AssetMovementController(ILogger<AssetMovementController> logger, IBaseRepository<AssetMovement> repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<object>> GetAssetMovement()
        {
            var AssetMovementView = _repository.ReadAll();
            return Ok(AssetMovementView.ToList());
        }

        // GET: api/AssetMovement/5
        [HttpGet("{Symbol}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AssetMovement> GetAssetMovement(string Symbol)
        {
            var AssetMovement = _repository
                .ReadSingle(u => u.Symbol == Symbol);

            if (AssetMovement == null)
            {
                return NotFound();
            }
            return AssetMovement;
        }

        // PUT: api/AssetMovement/5
        [HttpPut("{symbol}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAssetMovementAsync(string symbol, AssetMovement AssetMovement)
        {
            if (symbol != AssetMovement.Symbol)
            {
                return BadRequest();
            }
            AssetMovement.Validate();
            await AssetMovement.GetCotation();
            if (!AssetMovement.IsValid) return BadRequest(AssetMovement.Notifications);
            try
            {
                _repository.Update(AssetMovement);
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

        // POST: api/AssetMovement
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AssetMovement>> PostAssetMovementAsync(AssetMovement AssetMovement)
        {
            AssetMovement.Validate();
            await AssetMovement.GetCotation();
            if (!AssetMovement.IsValid) return BadRequest(AssetMovement.Notifications);

            _repository.Create(AssetMovement);
            return Created($"GetAssetMovement/{AssetMovement.Symbol}", AssetMovement);
        }
        // DELETE: api/AssetMovement/5
        [HttpDelete("{symbol}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AssetMovement> DeleteAssetMovement(string symbol)
        {
            _repository.Delete(symbol);
            return Ok("Delete with success!");
        }
    }
}