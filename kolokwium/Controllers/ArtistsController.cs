using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {

        private readonly ArtistsDbContext _context;

        public ArtistsController(ArtistsDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetArtist(int id)
        {
            try
            {
                var artistById = _context.Artists
                                                .Where(artist => artist.IdArtist.Equals(id))
                                                .Select(artist => new {
                                                                        artist.IdArtist,
                                                                        artist.Nickname,
                                                                        events = artist.ArtistEvent
                                                .OrderByDescending(artistEvent => artistEvent.Event.StartDate.Year)
                                                .Select(artistEvent => new {
                                                                        artistEvent.Event.IdEvent,
                                                                        artistEvent.Event.Name,
                                                                        artistEvent.Event.StartDate,
                                                                        artistEvent.Event.EndDate })
                }).FirstOrDefault();

                return Ok(artistById);
            }
            catch (Exception)
            {
                return NotFound("Artist with given Id was not found");
            }



        }

    }
}