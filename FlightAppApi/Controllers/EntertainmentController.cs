using FlightAppApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class EntertainmentController : ControllerBase
    {
        #region Init
        private readonly IEntertainmentRepository _entertainmentRepository;

        public EntertainmentController(IEntertainmentRepository entertainmentRepository)
        {
            _entertainmentRepository = entertainmentRepository;
        }
        #endregion

        // GET: api/Entertainment/get_movies
        /// <summary>
        /// Get the movies
        /// </summary>
        /// <returns>200: the movies</returns>
        [HttpGet("get_movies")]
        public ActionResult GetMovies()
        {
            try
            {
                IList<Movie> movies = _entertainmentRepository.GetMovies();
                if (movies is null)
                {
                    return NotFound();
                }

                return Ok(movies);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET: api/Entertainment/get_music
        /// <summary>
        /// Get the music
        /// </summary>
        /// <returns>200: the music</returns>
        [HttpGet("get_music")]
        public ActionResult GetMusic()
        {
            try
            {
                IList<Music> music = _entertainmentRepository.GetMusic();
                if (music is null)
                {
                    return NotFound();
                }

                return Ok(music);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}