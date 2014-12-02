using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportMe.Service.Model;
using DataModel = SupportMe.Data.Model;

namespace SupportMe.Service
{
    interface IPresentationService
    {
        /// <summary>
        /// Fetches an individual Presentation from the data store
        /// </summary>
        /// <param name="PresentationId">The Presentation ID</param>
        /// <returns>A Presentation</returns>
        Presentation RetrieveIndividual(Guid PresentationId);

        /// <summary>
        /// Fetches everyone
        /// </summary>
        /// <returns></returns>
        ICollection<Presentation> RetrieveAll();

        /// <summary>
        /// Removes a Presentation
        /// </summary>
        /// <param name="PresentationId">Their ID</param>
        void RemovePresentation(Guid PresentationId);

        /// <summary>
        /// Inserts a new Presentation
        /// </summary>
        /// <param name="servicePresentation"></param>
        /// <returns></returns>
        Guid InsertPresentation(Presentation servicePresentation);

        /// <summary>
        /// Updates an existing presentation. 
        /// </summary>
        /// <param name="servicePresentation">Thr service presentation</param>
        void UpdatePresentation(Presentation servicePresentation); 
    }
}
