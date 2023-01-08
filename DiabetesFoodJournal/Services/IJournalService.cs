using DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IJournalService
    {
        /// <summary>
        ///  Method to search for journal entries. ICollection allows a collection of Journalentries.
        /// </summary>
        /// <param name="searchValue">String value to be searched partial match.</param>
        /// <returns>A list of journal entries that match the search value.</returns>
        public Task<List<Journalentry>> SearchEntries(string searchValue);

        /// <summary>
        /// Method to search for Journal entries that contain a specific tag.
        /// </summary>
        /// <param name="searchValue">Full or partial string value to be searched. </param>
        /// <returns>A list of journal entries that contain the tag that matches the search value. </returns>
        public Task<List<Journalentry>> SearchTags(string searchValue);
    }
}
