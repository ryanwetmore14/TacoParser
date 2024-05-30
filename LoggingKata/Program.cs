using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Net.WebSockets;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {


            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");


            var parser = new TacoParser();


            var locations = lines.Select(parser.Parse).ToArray();


            ITrackable tacoBellOne = null;
            ITrackable tacoBellTwo = null;


            double distance = 0;


            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var cordA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                for (int x = 0; x < locations.Length; x++)
                {
                    var locB = locations[x];
                    var cordB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    var distanceBetween = cordA.GetDistanceTo(cordB);

                    if (distanceBetween > distance)
                    {
                        distance = distanceBetween;
                        tacoBellOne = locA;
                        tacoBellTwo = locB;
                    }
                }
            }


            logger.LogInfo($"{tacoBellOne.Name} and {tacoBellTwo.Name} have the greatest distance apart that amounts to {distance} meters, which is roughly {Math.Round(distance * 0.00062)} miles in between");



        }
    }
}
