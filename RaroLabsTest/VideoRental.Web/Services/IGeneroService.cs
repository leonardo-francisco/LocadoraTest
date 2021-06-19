using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Web.Models.DTO;

namespace VideoRental.Web.Services
{
    public interface IGeneroService
    {
        Task<List<GeneroDTO>> GetAll();
    }
}
