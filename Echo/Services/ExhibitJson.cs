using Echo.Interfaces;
using Echo.Models;
using Echo.Helpers;

namespace Echo.Services
{
    public class ExhibitJson : IExhibitRepository
    {
        const string JsonFileName = @"Data\Exhibits.json";
        public void AddExhibit(Exhibit exhibit)
        {
            Dictionary<int, Exhibit> exhibits = AllExhibits();
            exhibits.Add(Int32.Parse(exhibit.ID), exhibit);
            JsonFileWriter.WriteToJson(exhibits, JsonFileName);
        }
        public Dictionary<int,Exhibit> AllExhibits()
        {
            return JsonFileReader.ReadJson(JsonFileName);
        }
        public Dictionary<int,Exhibit> FilterExhibits(string criteria)
        {
            Dictionary<int, Exhibit> exhibits = AllExhibits();
            Dictionary<int, Exhibit> filteredExhibits = new Dictionary<int, Exhibit>();
            foreach (var e in exhibits.Values) 
            {
                if (e.ID.ToString().StartsWith(criteria))
                {
                    filteredExhibits.Add(Int32.Parse(e.ID), e);
                }
            }
            return filteredExhibits;
        }
        public Exhibit GetExhibit(string id)
        {

            Dictionary<int, Exhibit> exhibits = AllExhibits();
            Exhibit foundExhibit;
            foreach (var e in exhibits.Values)
            {
                if (e.ID.Equals(id))
                {
                    foundExhibit = e;
                    return foundExhibit;
                }
            }
            
            return null;
        }

        public bool ExhibitExists(string id)
        {
            Dictionary<int, Exhibit> exhibits = AllExhibits();
            if (exhibits.ContainsKey(Int32.Parse(id)))
            {
                return true;
            }
            return false;

        }

        public void UpdateExhibit(Exhibit exhibit)
        {
            Dictionary<int, Exhibit> exhibits = AllExhibits();
            Exhibit foundExhibit = exhibits[int.Parse(exhibit.ID)];
            Console.WriteLine(exhibit.ID);
            foundExhibit.ID = exhibit.ID;
            foundExhibit.Name = exhibit.Name;
            foundExhibit.Videourl = exhibit.Videourl;
            foundExhibit.Videourlen = exhibit.Videourlen;
            foundExhibit.Nameen = exhibit.Nameen;
            JsonFileWriter.WriteToJson(exhibits, JsonFileName);
        }

        public void DeleteExhibit(int id)
        {
            Dictionary<int, Exhibit> exhibits = AllExhibits();
            exhibits.Remove(id);
            JsonFileWriter.WriteToJson(exhibits, JsonFileName);
        }

        public void SortBy()
        {
            Dictionary<int, Exhibit> exhibits = AllExhibits();
            var sortedArticles = exhibits.OrderBy(x => x.Key);
            JsonFileWriter.WriteToJson(exhibits, JsonFileName);
        }
    }
}
