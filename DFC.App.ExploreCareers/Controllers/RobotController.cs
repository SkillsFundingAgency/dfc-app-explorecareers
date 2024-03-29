﻿using System.Net.Mime;

using DFC.App.ExploreCareers.Models.Robots;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Controllers
{
    public class RobotController : Controller
    {
        public const string RobotsViewCanonicalName = "robots";

        private readonly ILogger<RobotController> logger;
        private readonly IWebHostEnvironment hostingEnvironment;

        public RobotController(ILogger<RobotController> logger, IWebHostEnvironment hostingEnvironment)
        {
            this.logger = logger;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("/robots")]
        [Route("robots.txt")]
        public ContentResult Robot()
        {
            logger.LogInformation("Generating Robots.txt");

            var robot = GenerateThisSiteRobot();

            // add any dynamic robots data from the Shell app
            logger.LogInformation("Generated Robots.txt");

            return Content(robot.Data, MediaTypeNames.Text.Plain);
        }

        private Robot GenerateThisSiteRobot()
        {
            var robot = new Robot();
            string robotsFilePath = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "StaticRobots.txt");

            if (System.IO.File.Exists(robotsFilePath))
            {
                // output the composite UI default (static) robots data from the StaticRobots.txt file
                string staticRobotsText = System.IO.File.ReadAllText(robotsFilePath);

                if (!string.IsNullOrWhiteSpace(staticRobotsText))
                {
                    robot.Add(staticRobotsText);
                }
            }

            // add any dynamic robots data form the Shell app
            return robot;
        }
    }
}
