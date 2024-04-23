using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Repositories;

namespace TechTitansTesting.Services.Stubs
{
    internal class TestArtistSongDashboardRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _data;

        public TestArtistSongDashboardRepository(List<T> data)
        {
            _data = data;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _data;
        }

        public bool Add(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
