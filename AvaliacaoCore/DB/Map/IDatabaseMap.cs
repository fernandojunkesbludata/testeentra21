using Microsoft.EntityFrameworkCore;

namespace AvaliacaoCore.DB.Map
{
    public interface IDatabaseMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}