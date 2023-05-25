using Echo.Models;

namespace Echo.Interfaces
{
    public interface IExhibitRepository
    {
        Dictionary<int, Exhibit> AllExhibits();
        Dictionary<int, Exhibit> FilterExhibits(string criteria);
        void DeleteExhibit(int id);
        void AddExhibit(Exhibit exhibit);
        void UpdateExhibit(Exhibit exhibit);
        Exhibit GetExhibit(string id);

        bool ExhibitExists(string id);

        void SortBy();

    }
}
