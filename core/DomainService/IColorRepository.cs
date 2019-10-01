using PetshopCompulsory.Core.DomainService.Filtering;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.DomainService
{
    public interface IColorRepository
    {
        Color Create(Color color);
        FilteredList<Color> ReadAllColors(Filter filter);
        Color ReadById(int id);
        Color Update(int id);
        Color Delete(int id);
    }
}
