using CaseBasedSchedule.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseBasedSchedule.Application.Contracts
{
    public interface IPractitionerService
    {
        Task<IReadOnlyCollection<PractitionerModel>> GetPractitonerModels();

        Task<Guid> AddPractitionerAsync(PractionerRequest practionerRequest);

        Task UpdatePractitionerAsync(string id, PractionerRequest practionerRequest);

       Task DeletePractitionerAsync(string id);
       
    }
}
