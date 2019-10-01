using PetshopCompulsory.Core.DomainService;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetshopCompulsory.Core.DomainService.Filtering;
using System.Linq;

namespace Petshop.Infrastructure.SQL.Repositories
{
    public class ColorRepository : IColorRepository
    {
        PetShopContext _ctx;
        public Color Create(Color color)
        {
            _ctx.Colors.Attach(color).State = EntityState.Added;
            _ctx.SaveChanges();
            return color;
        }

        public FilteredList<Color> ReadAllColors(Filter filter)
        {
            if(filter == null)
            {
                return new FilteredList<Color>() { List = _ctx.Colors.ToList(), Count = _ctx.Colors.Count() };
            }

            var items = _ctx.Colors
                .Include(c => c.Pets)
                .ThenInclude(pc => pc.Pet)
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
            return new FilteredList<Color>() { List = items, Count = _ctx.Colors.Count() };
        }

        public Color ReadById(int id)
        {
            return _ctx.Colors
                .Include(c => c.Pets)
                .ThenInclude(pc => pc.Pet)
                .FirstOrDefault(c => c.ColorId == id);
        }

        public Color Update(int id)
        {
            throw new NotImplementedException();
        }
        public Color Delete(int id)
        {
            var removeColor = _ctx.Remove(new Color {ColorId = id }).Entity;
            _ctx.SaveChanges();
            return removeColor;
        }
    }
}
