using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Shared.Services.Contracts
{
    public interface ISecurityService
    {
        string GenerateJwtToken(string username, string role = null);
    }
}
