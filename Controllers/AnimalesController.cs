using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
using VetS.Data;
using VetS.Core.Models;

namespace VetS.Controllers
{
    public class AnimalesController : Controller
    {
        private readonly VetSDbContext context;
        private readonly IMapper mapper;

        public AnimalesController(VetSDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public VetSDbContext Context { get; }

        [HttpGet("/api/animales")]
        public async Task<IEnumerable<AnimalResource>> GetAnimales()
        {
            var animales = await context.Animales.Include(a => a.Razas).ToListAsync();
            return mapper.Map<List<Animal>, List<AnimalResource>>(animales);
        }
    }
}
