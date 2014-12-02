using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Service.Model
{
    public class Presentation
    {
        //Properties here

        /// <summary>
        /// The ID used for the presentation
        /// </summary>
        public Guid Id { get; set; }

        #region Constructor 

        /// <summary>
        /// Constructs a new Initial Presentation.
        /// </summary>
        public Presentation()
        {
            Id = Guid.NewGuid();
        }

        #endregion 


    }
}
