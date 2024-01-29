using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{

    //https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionController(NZWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }

        //GET ALL REGIONS
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from database - Domain models
            var regionsDomain = await regionRepository.GetAllAsync();

            //Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto() 
                { 
                    Id = regionDomain.Id, 
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            //Return DTOs
            return Ok(regionsDto);
        }

        //GET SINGLE REGION (Get Region By ID)
        //GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            //Get Region Domain Model From Database
            var regionDomain = await regionRepository.GetByIdAsync(id);
            if(regionDomain == null)
            {
                return NotFound();
            }

            //Map/Convert Region Domain Model to Region DTO
            var regionDto = new RegionDto()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            //Return DTO back to client
            return Ok(regionDto);
        }

        // POST To Create New Region
        // POST: https://localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            //Use Domain Model to create Region
            await regionRepository.CreateAsync(regionDomainModel);

            //Map Domain Model back to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id}, regionDto);
        }

        //Update region
        //PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Check if region exists
            //Map DTO to Domain Modell
            var regionDomainModel = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            };
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            //Convert Domain Model to DTO

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }

        //Delete Region
        //DELETE: https://localhost:portnumber/api/regions/{id}

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            // return deleted Region back
            //map domain model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }
    }
}
