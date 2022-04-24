using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core;
using PhoneBook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private IPhoneBookRepository _phoneBookRepository;
 public PhoneBookController(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        /// <summary>
        /// Gets all Entries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public List<Entry> GetMovies(int entryId)
        {
            return _phoneBookRepository.GetEntries();
        }
        /// <summary>
        /// Gets all Entries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Find")]
        public Entry FindEntry(string entry)
        {
            return _phoneBookRepository.FindEntry(entry);
        }
        /// <summary>
        /// Returns a specific entry using an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id}")]
        public Entry GetEntry(int id)
        {
            return _phoneBookRepository.GetEntry(id);
        }
        /// <summary>
        /// Saves a new entry
        /// </summary>
        /// <param name="entry"></param>

        [HttpPost]
        [Route("Add")]
        public void AddEntry([FromBody] Entry entry)
        {
            _phoneBookRepository.AddEntry(entry);
        }
        /// <summary>
        /// Updates a specific movie        
        /// </summary>
        /// <param name="entry"></param>
        [HttpPut]
        [Route("Update")]
        public void UpdateMovie([FromBody] Entry entry)
        {
            _phoneBookRepository.UpdateEntry(entry);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteEntry(int id)
        {
            _phoneBookRepository.DeleteEntry(id);
        }


    }
}
