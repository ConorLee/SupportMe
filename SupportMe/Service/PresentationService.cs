using Newtonsoft.Json;
using SupportMe.Data;
using SupportMe.Data.Model;
using SupportMe.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel = SupportMe.Data.Model;

namespace SupportMe.Service
{
    public class PresentationService: IPresentationService
    {
        #region Constructor 

        /// <summary>
        /// Builds a new Presentation Service
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public PresentationService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");

            this.unitOfWork = unitOfWork;
        }

        #endregion 

        #region Fields 

        private readonly IUnitOfWork unitOfWork; 

        #endregion 

        #region Methods 

        /// <summary>
        /// Fetches an individual Presentation
        /// </summary>
        /// <param name="PresentationId">Presentation ID</param>
        /// <returns></returns>
        public Presentation RetrieveIndividual(Guid PresentationId)
        {
            var dataPresentation = unitOfWork.InitialPresentationRepository.Items.SingleOrDefault(p => p.Id == PresentationId);
            if (dataPresentation == null) throw new ArgumentException("PresentationId");

            return JsonConvert.DeserializeObject<Presentation>(dataPresentation.Payload); 
        }

        /// <summary>
        /// Fetches everyone
        /// </summary>
        /// <returns>All Presentatione</returns>
        public ICollection<Presentation> RetrieveAll()
        {
            var allPresentation = unitOfWork.InitialPresentationRepository.Items.ToList();
            var servicePresentatione = from p in allPresentation
                                select JsonConvert.DeserializeObject<Presentation>(p.Payload); 

            return servicePresentatione.ToList();
        }

        /// <summary>
        /// Removes a Presentation
        /// </summary>
        /// <param name="PresentationId"></param>
        public void RemovePresentation(Guid PresentationId)
        {
            var Presentation = unitOfWork.InitialPresentationRepository.Items.Single(p => p.Id == PresentationId);
            unitOfWork.InitialPresentationRepository.Delete(Presentation);
            unitOfWork.Commit();
        }

        /// <summary>
        /// Inserts a new Presentation
        /// </summary>
        /// <param name="servicePresentation">The Presentation</param>
        /// <returns></returns>
        public Guid InsertPresentation(Presentation servicePresentation)
        {
            var dataPresentation = new InitialPresentation();
            dataPresentation.Payload = JsonConvert.SerializeObject(servicePresentation);

            dataPresentation.Id = servicePresentation.Id;

            unitOfWork.InitialPresentationRepository.Insert(dataPresentation);
            unitOfWork.Commit();

            return dataPresentation.Id;
        }

        /// <summary>
        /// Updates a given presentation
        /// </summary>
        /// <param name="servicePresentation">The service presentation</param>
        void UpdatePresentation(Presentation servicePresentation)
        {
            var existingPresentation = unitOfWork.InitialPresentationRepository.Items.SingleOrDefault(p => p.Id == servicePresentation.Id);

            existingPresentation.Payload = JsonConvert.SerializeObject(servicePresentation);

            unitOfWork.Commit();


        }

        #endregion 

    }
}
