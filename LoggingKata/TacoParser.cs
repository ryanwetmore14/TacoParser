using System.Reflection.Metadata;

namespace LoggingKata
{

    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Now parsing line: {line}");


            var cells = line.Split(',');


            if (cells.Length < 3)
            {

                logger.LogError("There should atleast be 3 lines");
                return null;
            }


            var lat = double.Parse(cells[0]);



            var lon = double.Parse(cells[1]);



            var storeName = cells[2];


            var location = new Point(lat, lon);
            var tacoBell = new TacoBell(storeName, location);

            return tacoBell;
        }
    }
}
