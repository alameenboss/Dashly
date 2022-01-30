using AutoMapper;
using Dashly.API.Feature.Bookmarks.Data;
using Dashly.API.Feature.Bookmarks.Data.Entity;
using Dashly.API.Feature.Contacts;
using Dashly.API.Feature.DataImport;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Bookmarks
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IMapper _mapper;

        public BookmarkController(IBookmarkRepository bookmarkRepository, IMapper mapper)
        {
            _bookmarkRepository = bookmarkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Bookmark>> GetAll()
        {
            return await _bookmarkRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Bookmark> GetById(int id)
        {
            return await _bookmarkRepository.GetById(id);
        }

        [HttpPost]
        public async Task<bool> Save(Bookmark bookmark)
        {
            return await _bookmarkRepository.Save(bookmark);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _bookmarkRepository.Delete(id);
        }

        [HttpDelete]
        public async Task<bool> DeleteAll()
        {
            return await _bookmarkRepository.DeleteAll();
        }

        [HttpPut("import"), DisableRequestSizeLimit]
        public async Task<bool> Import(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string data = Encoding.UTF8.GetString(fileBytes);


                var doc = new HtmlDocument();
                doc.LoadHtml(data);

                var sss = doc.DocumentNode.ChildNodes;
            }

            return true;
        }

        [HttpGet("parse")]
        public async Task<IEnumerable<BookmarkModel>> ParseBookmarks()
        {
            var dt = BookmarkParser.ReadBookmark(@"C:/Users/AlameenShaikDawood/Desktop/bookmarks_1_29_22.html");

            var item =  JsonConvert.DeserializeObject<List<BookmarkModel>>(JsonConvert.SerializeObject(dt));

            foreach(var bk in item)
            {
                var parent = item.Find(x => x.Id == bk.ParentId);
                if (parent != null)
                {
                    parent.Children.Add(bk);
                }
            }
            return item;
        }
    }

    public class BookmarkModel
    {
        public BookmarkModel()
        {
            Children = new List<BookmarkModel>();
        }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int Hierarchy { get; set; }

        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public List<BookmarkModel> Children { get; set; }
    }
}