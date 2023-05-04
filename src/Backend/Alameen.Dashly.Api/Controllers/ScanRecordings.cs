using Alameen.Dashly.Core;
using Alameen.Dashly.Repository.Contract;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Alameen.Dashly.API.Controllers
{
    public class ScanRecordings
    {
        private readonly ICallRecordingRepository _callRecordingRepository;
        public ScanRecordings(ICallRecordingRepository callRecordingRepository)
        {
            _callRecordingRepository = callRecordingRepository;
        }
        public async Task ScanCallRecordingAsync()
        {
            var path = "D:\\Alameen\\Call_Logs\\call_rec";
            var files = new List<string>();

            try
            {
                files = Directory.GetFiles(path)?.ToList();
            }

            catch (UnauthorizedAccessException e)
            {

            }
            catch (DirectoryNotFoundException e)
            {

            }

            
           

            var calls = new List<CallRecording>();
            foreach (var filePath in files)
            {
                if (IsAudioFile(filePath))
                {
                    var fileInfo = new FileInfo(filePath);
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    var call = new CallRecording()
                    {
                        Path = fileInfo.FullName,
                        Name = fileInfo.Name,
                        CreatedTime = fileInfo.CreationTimeUtc,
                        ModifiedTime = fileInfo.LastWriteTimeUtc,
                        TotalSeconds = GetDuration(filePath).TotalSeconds,
                    };
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] hashBytes = sha256.ComputeHash(fileBytes);
                        call.HashValue = BitConverter.ToString(hashBytes).Replace("-", "");
                    }

                    calls.Add(call);
                }
            }

            await _callRecordingRepository.Import(calls);


            //Notify the scan completion to frontend 
        }


        private TimeSpan GetDuration(string filePath)
        {
            using (var audioFile = new AudioFileReader(filePath))
            {
                return audioFile.TotalTime;
            }
        }

        private bool IsAudioFile(string filePath)
        {
            try
            {
                using (var reader = new MediaFoundationReader(filePath))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
