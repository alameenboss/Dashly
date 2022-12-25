using Alameen.Dashly.API.Models;
using Alameen.Dashly.Common.Helpers;
using Alameen.Dashly.Core;
using Alameen.Dashly.Repository.Contract;
using AutoMapper;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Alameen.Dashly.API.Controllers
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

            return await Task.FromResult(true);
        }

        [HttpGet("parse")]
        public async Task<IEnumerable<BookmarkModel>> ParseBookmarks()
        {
            return await Task.Run(() =>
            {
                var dt = BookmarkParser.ReadBookmark(@"C:/Users/AlameenShaikDawood/Desktop/bookmarks_1_29_22.html");

                var bookmarks = JsonConvert.DeserializeObject<List<BookmarkModel>>(JsonConvert.SerializeObject(dt));

                bookmarks.ForEach(bookmark =>
                {
                    var parent = bookmarks.Find(x => x.Id == bookmark.ParentId);
                    if (parent != null)
                    {
                        parent.Children.Add(bookmark);
                    }
                });
                return bookmarks;
            });
        }
    }
}