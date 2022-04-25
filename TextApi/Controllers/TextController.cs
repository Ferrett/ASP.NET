using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using Google.Apis;
using Google.Apis.Analytics.v3;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Vision.V1;
using Newtonsoft.Json;
using Google.Apis.Services;
using System.Linq;
using System.Reflection;

namespace TextApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextController : ControllerBase
    {
        private readonly ILogger<TextController> _logger;

        public TextController(ILogger<TextController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string url)
        {


            string _exePath = Assembly.GetEntryAssembly().Location;
            _exePath = _exePath.Remove(_exePath.Length - (System.AppDomain.CurrentDomain.FriendlyName.Length+5));

           
            string credPath = _exePath + @"\info.json";

            var json = System.IO.File.ReadAllText(credPath);
            var cr = JsonConvert.DeserializeObject<PersonalServiceAccountCred>(json); // "personal" service account credential

            // Create an explicit ServiceAccountCredential credential
            var xCred = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(cr.client_email)
            {
                Scopes = new[] {
                    AnalyticsService.Scope.AnalyticsManageUsersReadonly,
                    AnalyticsService.Scope.AnalyticsReadonly
                }
            }.FromPrivateKey(cr.private_key));

            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", $"{_exePath}" + @"\info.json");



            return GetTextFromImage(new Uri(url));

           
        }
        public static string GetTextFromImage(Uri url)
        {
            ImageAnnotatorClient client = ImageAnnotatorClient.Create();

            IReadOnlyList<EntityAnnotation> textAnnotations = client.DetectText(Image.FromUri(url));
            return textAnnotations[0].Description;
        }


    }
}
