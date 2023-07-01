using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Context;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers
{
    public class SearchController : Controller
    {
        private readonly RecordDictionary _Map;
        private readonly DBContext _db;
        public SearchController(DBContext _db)
        {
            this._db = _db;
            this._Map = new RecordDictionary(this._db);
        }
        [HttpGet]
        [Route("/search")]
        public IActionResult Search(string querry = "", int? PageSize = null, int? PageIndex = null)
        {
            //this block is to replace or change the symbols to their word equivalent
            querry = querry.Replace(",", " and ");
            querry = querry.Replace("|", " or ");
            querry = querry.Replace("-", " not ");
            querry = querry.Replace("(", " ( ");
            querry = querry.Replace(")", " ) ");
            string tq = querry;


            List<string> words = new List<string>(){
                "and","or","not","(",")"
            };

            var s = querry.Split(" ");
            string baseFilter = " (Name='{0}' or Company='{0}' or Project='{0}' or Role='{0}' ) "; // filter for all columns and using exact match
            string baseFilterLike = "(Name like'%{0}%' or Company like'%{0}%' or Project like'%{0}%' or Role like'%{0}%' )";// filter for all columns and using like match
            string q = querry;
            string temp = "";
            List<string> filters = new List<string>();
            //looping through the querry string to get all the filter words.
            foreach (var v in s.Where(f => !string.IsNullOrEmpty(f)))
            {

                if (words.Contains(v.ToLower()))
                {
                    filters.Add(temp.Trim());
                    temp = "";
                }
                else
                {
                    temp += v + " ";
                }
            }
            if (!string.IsNullOrEmpty(temp))
            {
                //add the last filter words to the filters 
                filters.Add(temp.Trim());
            }
            //looping through the filters to build the querry filters
            foreach (var f in filters.Where(f => !string.IsNullOrEmpty(f)))
            {
                if (!filters.Contains("\""))
                    q = q.Replace(f, string.Format(baseFilterLike, f.Trim()));
                else
                {
                    string str = f.Replace("\"", "");
                    q = q.Replace(str, String.Format(baseFilter, str));
                }


            }

            IEnumerable<Record> list = new List<Record>();

            if (!string.IsNullOrEmpty(q))
            {
                list = _db.Employees.FromSqlRaw("Select * from Employees where " + q).ToList();
            }
            else
            {
                list = _db.Employees.ToList();
            }
            if (PageSize != null && PageIndex != null)
            {
                int skip = (int)PageSize * ((int)PageIndex - 1);
                return Ok(
                    new
                    {
                        Data = list.Skip(skip).Take((int)PageSize),
                        Total = list.Count(),
                        pageSize = PageSize,
                        currentPage = PageIndex,
                        pages = Math.Ceiling((decimal)((decimal)list.Count() / (decimal)PageSize))

                    }
                );
            }
            return Ok(list);
            //return Ok(new { filters = filters, l = q });

        }
    }
}