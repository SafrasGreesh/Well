using GazpromTest.Models;

namespace GazpromTest.Repo
{
    public interface IWellRepository
    {
        Well GetById(long id);
        List<Well> GetAll();
        void Add(Well well);
        void Update(Well well);
        void Delete(long id);
    }

}
