using System.Collections.Generic;
using Domain.Model;

namespace Common.Services
{
    public interface IIndividualRegistration
    {
        /// <summary>
        /// Get all individuals 
        /// </summary>
        /// <returns>list of Individual </returns>
        IEnumerable<Individual> GetAllIndividuals();

        /// <summary>
        /// Get individual by reference
        /// </summary>
        /// <param name="individualRef"></param>
        /// <returns>individual</returns>
        Individual GetIndividualByReference(string individualRef);

        bool SaveIndividual(Individual model);
    }
}
