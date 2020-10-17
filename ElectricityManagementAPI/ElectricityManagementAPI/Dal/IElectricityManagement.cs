using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectricityManagementAPI.Models;

namespace ElectricityManagementAPI.Dal
{
     public interface IElectricityManagement
    {
        Task< List<inquire>> GetShowAsync();
    }
}
