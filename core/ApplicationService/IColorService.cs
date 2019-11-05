using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using PetshopCompulsory.Core.DomainService.Filtering;

namespace PetshopCompulsory.Core.ApplicationService
{
    public interface IColorService
    {
        void Create(Color color);
        Color ReadById(int id);
        FilteredList<Color> ReadAll(Filter filter);
        Color Update(Color color);
        void Delete(int id);
    }
}
