using GFT.InWallet.Business.Core;
using GFT.InWallet.Domain.Entity;
using GFT.InWallet.Infra.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GFT.InWallet.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly ILogger<MovementController> _logger;
        public IBaseRepository<Asset> _repositoryAsset { get; set; }
        public IBaseRepository<AssetMovement> _repositoryAssetMovement { get; set; }
        public MovementController(ILogger<MovementController> logger,
            IBaseRepository<Asset> repositoryAsset,
            IBaseRepository<AssetMovement> repositoryAssetMovement
            )
        {
            _logger = logger;
            _repositoryAsset = repositoryAsset;
            _repositoryAssetMovement = repositoryAssetMovement;
        }
        [HttpGet("{symbol}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Asset> GetMovement(string symbol)
        {
            var asset = _repositoryAsset.ReadSingle(u => u.Symbol == symbol);
            if (asset is null) return BadRequest();
            var moviments = _repositoryAssetMovement.ReadAll().Where(c => c.Symbol == symbol).Select(c=>new {c.OperationType, c.OperationDate,c.Volume, c.PriceAsset, c.Total});

            return Ok(new { asset, moviments});
        }
    }
}