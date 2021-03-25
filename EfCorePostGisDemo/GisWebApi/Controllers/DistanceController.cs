using System.Collections;
using System.Linq;
using GisWebApi.Dto;
using GisWebApi.GisModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Geometries;

namespace GisWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DistanceController : ControllerBase
    {
        private readonly DemoGisDbContext _dbContext;
        private readonly ILogger<DistanceController> _logger;

        public DistanceController(DemoGisDbContext dbContext, ILogger<DistanceController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }


        [HttpPost]
        public double CalculateDistance(GetDistanceViewModel model)
        {
            var startPoint = new GeographyPointEntity {Location = new Point(model.From.Lon, model.From.Lat)};
            var endPoint = new GeographyPointEntity {Location = new Point(model.To.Lon, model.To.Lat)};
            var result = startPoint.Location.Distance(endPoint.Location);

            return result;
        }

        [HttpPost("{id:int}")]
        public double CompareDistance(Geography2dPoint from, int id)
        {
            var fromPoint = new GeographyPointEntity {Location = new Point(from.Lon, from.Lat)};
            var comparePoint = _dbContext.Points.FirstOrDefault(x => x.Id == id) ?? new GeographyPointEntity {Location = new Point(0, 0)};

            return comparePoint.Location.Distance(fromPoint.Location);
        }
    }
}