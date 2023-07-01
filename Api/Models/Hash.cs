using System.Reflection;
using Api.Context;
namespace Api.Models
{
    public class RecordDictionary
    {
        private readonly DBContext _db;

        public Dictionary<string, List<Record>> Map;
        public RecordDictionary(DBContext _db)
        {
            this._db = _db;
            this.Map = new Dictionary<string, List<Record>>();

            foreach (var r in _db.Employees.ToList())
            {
                foreach (PropertyInfo prop in r.GetType().GetProperties())
                {


                    if (prop.PropertyType != typeof(Int32))
                    {
                        string key = prop.GetValue(r, null).ToString();
                        if (this.Map.ContainsKey(key))
                        {
                            List<Record> rs = this.Map[key];
                            if (!rs.Contains(r))
                                rs.Append(r);
                            this.Map[key] = rs;

                        }
                        else
                        {
                            this.Map.Add(key, new List<Record>() { r });
                        }
                    }

                }
            }
        }
    }

}