using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ChinookSystem.DAL;
using ChinookSystem.Entities;
using ChinookSystem.ViewModels;
#endregion

namespace ChinookSystem.BLL
{
    public class GenreServices
    {
        #region Constructor and Context Dependency
        private readonly ChinookContext _context;

        // Obtain the context link from IServiceCollection when this set of services is injected
        // into the "outside user"
        internal GenreServices(ChinookContext context)
        {
            _context = context;
        }
        #endregion

        #region Services : Queries
        // Obtain a list of genres to be used in a select list

        public List<SelectionList> GetAllGenres()
        {
            IEnumerable<SelectionList> info = _context.Genres
                                                .Select(g => new SelectionList
                                                {
                                                    ValueId = g.GenreId,
                                                    DisplayText = g.Name,
                                                });
                                           // .OrderBy(g => g.DisplayText); This sort is done in SQL           
           
            // return info.OrderBy(g => g.DisplayText).ToList(); This sort is done in RAM
            return info.ToList();
        }
        #endregion
    }
}
