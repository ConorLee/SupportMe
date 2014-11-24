using SupportMe.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Data
{
    public interface IUnitOfWork
    {
        
        /// <summary>
        /// Gets or sets the IP repository
        /// </summary>
        IRepository<InitialPresentation> InitialPresentationRepository { get; }

        /// <summary>
        /// Gets or sets the Individual repository
        /// </summary>
        IRepository<Individual> IndividualRepository { get; }

        /// <summary>
        /// Commits any outstanding changes carried out through this unit of work to the underlaying data store.  
        /// </summary>
        void Commit(); 
    }
}
