using FFMpegCore;
using LiveStreamCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RtmpSharp;
using RtmpSharp.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace LiveStreamCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiveStreamController : ControllerBase
    {
        private static readonly int _frameRate = 15;
        private static readonly string _outputName = "testOutput2.mkv";
        private readonly ILogger<LiveStreamController> _logger;
        private static List<LivestreamMetadata> metadataListSeeded = new List<LivestreamMetadata>() {
            new LivestreamMetadata() {
                id = 1,
                name = "My Desktop (HLS)",
                description = "Welcome to my Desktop stream!",
                username = "EmirUnluturk",
                src = "http://localhost:8080/hls/room.m3u8",
                thumbnail = "http://localhost:8080/room.jpg"
            },
            new LivestreamMetadata() {
                id = 2,
                name = "My Webcam (HLS)",
                description = "Welcome to my Webcam stream!",
                username = "EmirUnluturk",
                src = "http://localhost:8080/hls/webcam.m3u8",
                thumbnail = "http://localhost:8080/webcam.jpg"
            },
            new LivestreamMetadata() {
                id = 3,
                name = "My Desktop (DASH)",
                description = "Welcome to my Desktop stream!",
                username = "EmirUnluturk",
                src = "http://localhost:8080/dash/room_src.mpd",
                thumbnail = "http://localhost:8080/room.jpg"
            },
            new LivestreamMetadata() {
                id = 4,
                name = "My Webcam (DASH)",
                description = "Welcome to my Webcam stream!",
                username = "EmirUnluturk",
                src = "http://localhost:8080/dash/webcam_hd720.mpd",
                thumbnail = "http://localhost:8080/webcam.jpg"
            }
        };

        public LiveStreamController(ILogger<LiveStreamController> logger)
        {
            _logger = logger;
        }

        
            
        [Route("GetStream/{id}")]
        public string GetStream(int id)
        {
            /*var filePath = $"C:/ffmpeg/{_outputName}";
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/octet-stream", Path.GetFileName(filePath), true);*/
            return metadataListSeeded.First(x => x.id == id).src;
        }

        [Route("GetMetadata")]
        public List<LivestreamMetadata> GetMetadata()
        {
            return metadataListSeeded;
        }



        [Route("GetMetadata/{id}")]  
        public LivestreamMetadata GetMetadata(int id)
        {
            return metadataListSeeded.First(x => x.id == id);
        }
    }
}
