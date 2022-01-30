using Dashly.API.Feature.VideoManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Dashly.API.Feature.VideoManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
       
        [HttpGet("GetDrives")]
        public IEnumerable<string> GetDrives()
        {
            var allDrives = System.Environment.GetLogicalDrives();
            var readyDrive = new List<string>();
            foreach (string drive in allDrives)
            {
                var di = new System.IO.DriveInfo(drive);
                if (di.IsReady)
                {
                    readyDrive.Add(di.Name);
                }
            }

            return readyDrive;
        }

        [HttpGet("GetFiles")]
        public FileFolderModel GetFiles(string path)
        {
            var model = new FileFolderModel();

            model.Folders = System.IO.Directory.GetDirectories(path);

            // First, process all the files directly under this folder
            try
            {
                model.Files = System.IO.Directory.GetFiles(path);
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                //log.Add(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                //log.Add(e.Message);
            }

            return model;
        }

    }
}
