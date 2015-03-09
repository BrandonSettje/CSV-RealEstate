using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CSV_RealEstate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RealEstateSale> realEstateSaleList = GetRealEstateSaleList();
            
            
            //Display the average square footage of a Condo sold in the city of Sacramento, use the GetAverageSquareFootageByRealEstateTypeAndCity() function.
            Console.WriteLine(GetAverageSquareFootageByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Residential, "sacramento"));
            Console.ReadKey();
            //Display the total sales of all residential homes in Elk Grove.  Use the GetTotalSalesByRealEstateTypeAndCity() function for testing.
            Console.WriteLine(GetTotalSalesByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Residential, "Elk Grove"));
            Console.ReadKey();
            //Display the total number of residential homes sold in the zip code 95842.  Use the GetNumberOfSalesByRealEstateTypeAndZip() function for testing.
            Console.WriteLine(GetNumberOfSalesByRealEstateTypeAndZip(realEstateSaleList, RealEstateType.Residential, "95842"));
            Console.ReadKey();
            //Display the average sale price of a lot in Sacramento.  Use the GetAverageSalePriceByRealEstateTypeAndCity() function for testing.
           // Console.WriteLine(realEstateSaleList.Where(x => x.City.ToLower() =="Sacramento" && x.ResidenceType == RealEstateType.Lot).Average(x => x.SalePrice));
            Console.WriteLine(GetAverageSalePriceByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Lot, "Sacramento"));
            Console.ReadKey();
            //Display the average price per square foot for a condo in Sacramento. Round to 2 decimal places. Use the GetAveragePricePerSquareFootByRealEstateTypeAndCity() function for testing.
            Console.WriteLine(GetAveragePricePerSquareFootByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Condo, "Sacramento"));
            Console.ReadKey();
            //Display the number of all sales that were completed on a Wednesday.  Use the GetNumberOfSalesByDayOfWeek() function for testing.
           // Console.WriteLine(realEstateSaleList.Count(x => x.SaleDate.DayOfWeek == DayOfWeek.Wednesday));
            Console.WriteLine(GetNumberOfSalesByDayOfWeek(realEstateSaleList, DayOfWeek.Wednesday));
            Console.ReadKey();
            //Display the average number of bedrooms for a residential home in Sacramento when the 
            // price is greater than 300000.  Round to 2 decimal places.  Use the GetAverageBedsByRealEstateTypeAndCityHigherThanPrice() function for testing.
            Console.WriteLine(GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(realEstateSaleList, RealEstateType.Residential, "Sacramento", 300000));
            Console.ReadKey();
            //Extra Credit:
            //Display top 5 cities by the number of homes sold (using the GroupBy extension)
            // Use the GetTop5CitiesByNumberOfHomesSold() function for testing.
            //Console.WriteLine(GetTop5CitiesByNumberOfHomesSold());
        }
        /// <summary>
        /// Reads through the csv file, line by line
        /// </summary>
        /// <returns> returns the data to be sifted through</returns>
        public static List<RealEstateSale> GetRealEstateSaleList()
        {
            //the list thatll hold the info after being read in.
            List<RealEstateSale> RealEstateReading = new List<RealEstateSale>();
            //the streamreader
            using (StreamReader reader = new StreamReader("realestatedata.csv"))
            {
                //reads the line
                string readerLine = reader.ReadLine();
                //wont stop until the end
                while (!reader.EndOfStream)
                {
                   {
                       //adds the line to the list
                       RealEstateReading.Add(new RealEstateSale(reader.ReadLine()));
                   }
                }
                //returns the whole list after the streamreader
                return RealEstateReading;
            }
        }
        /// <summary>
        /// find average square foot by city and type
        /// </summary>
        /// <param name="realEstateDataList">gets the list to be sifted through</param>
        /// <param name="realEstateType">user input of type</param>
        /// <param name="city"user input of city</param>
        /// <returns></returns>
        public static double GetAverageSquareFootageByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city) 
        {
            return realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.ResidenceType == realEstateType).Average(x => x.Sqfoot);
        }
        /// <summary>
        /// finds total sales by city and type
        /// </summary>
        /// <param name="realEstateDataList">gets the list to be sifted through</param>
        /// <param name="realEstateType">user input of type</param>
        /// <param name="city">user input of city</param>
        /// <returns></returns>
        public static decimal GetTotalSalesByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.ResidenceType == realEstateType).Sum(x => x.SalePrice);
        }
        /// <summary>
        /// finds the number of sales by the zipcode
        /// </summary>
        /// <param name="realEstateDataList">gets the list to be sifted through</param>
        /// <param name="realEstateType">user input of type</param>
        /// <param name="zipcode">user input of zipcode</param>
        /// <returns></returns>
        public static int GetNumberOfSalesByRealEstateTypeAndZip(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string zipcode)
        {
            return realEstateDataList.Where(x => x.ZipCode == zipcode && x.ResidenceType == realEstateType).Count();
        }
        /// <summary>
        /// finds average sale price by type and city
        /// </summary>
        /// <param name="realEstateDataList">gets the list to be sifted through</param>
        /// <param name="realEstateType">user input of type</param>
        /// <param name="city">user input of city</param>
        /// <returns></returns>
        public static decimal GetAverageSalePriceByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return Math.Round(realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.ResidenceType == realEstateType).Average(x => x.SalePrice), 2);
        }
        /// <summary>
        /// finds the average price per square foot by city and type
        /// </summary>
        /// <param name="realEstateDataList">gets the list to be sifted through</param>
        /// <param name="realEstateType">user input of type</param>
        /// <param name="city">user input of city</param>
        /// <returns></returns>
        public static decimal GetAveragePricePerSquareFootByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return Math.Round(realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.ResidenceType == realEstateType).Average(x => x.SalePrice / x.Sqfoot), 2);
        }
        /// <summary>
        /// finds the number of sales with a selected day
        /// </summary>
        /// <param name="realEstateDataList">gets the list to be sifted through</param>
        /// <param name="dayOfWeek">select a day of week</param>
        /// <returns></returns>
        public static int GetNumberOfSalesByDayOfWeek(List<RealEstateSale> realEstateDataList, DayOfWeek dayOfWeek)
        {
            return realEstateDataList.Count(x => x.SaleDate.DayOfWeek == dayOfWeek);
        }
        /// <summary>
        /// finds the average amount of bedrooms by type and city that is higher than an amount
        /// </summary>
        /// <param name="realEstateDataList">gets the list to be sifted through</param>
        /// <param name="realEstateType">user input of type</param>
        /// <param name="city">user input of city</param>
        /// <param name="price">the user input of price</param>
        /// <returns></returns>
        public static double GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city, decimal price)
        {
            return Math.Round(realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.ResidenceType == realEstateType && x.SalePrice > price).Average(x => x.Beds), 2);
        }
        /// <summary>
        /// finds the cities with most homes sold and lists the top 5
        /// </summary>
        /// <param name="realEstateDataList"></param>
        /// <returns></returns>
        public static List<string> GetTop5CitiesByNumberOfHomesSold(List<RealEstateSale> realEstateDataList)
        {
            return realEstateDataList.GroupBy(x => x.City).OrderByDescending(x => x.Count()).Select(x => x.Key).Take(5).ToList();
        }
    }
    /// <summary>
    /// enums for real estate type
    /// </summary>
    public enum RealEstateType
    {
        Residential, 
        MultiFamily, 
        Condo, 
        Lot
    }
    /// <summary>
    /// builds the sifter info for the real estate text from csv
    /// </summary>
    class RealEstateSale
    {

        public string Street {get; set;}

        public string City {get; set;}
         
        public string ZipCode {get; set;}
       
        public string State {get; set;}

        public int Beds { get; set; }

        public int Baths { get; set; }

        public int Sqfoot {get; set;}

        public RealEstateType ResidenceType { get; set; }

        public DateTime SaleDate {get; set;}

        public decimal SalePrice {get; set;}

        public string Lat { get; set; }

        public string Long { get; set; }
        /// <summary>
        /// the sifter to go through the real estate info
        /// </summary>
        /// <param name="dataLine"></param>
        public RealEstateSale(string dataLine)
        {
            //splits the data by the comma
            var estateDataSplit = dataLine.Split(',');
            //assigns the enums to the column index
            this.Street = estateDataSplit[0];
            this.City = estateDataSplit[1];
            this.ZipCode = estateDataSplit[2];
            this.State = estateDataSplit[3];
            this.Beds = Int32.Parse(estateDataSplit[4]);
            this.Baths = Int32.Parse(estateDataSplit[5]);
            this.Sqfoot = Int32.Parse(estateDataSplit[6]);
            //if the sq footage is 0 it has to be an empty lot
            if (this.Sqfoot == 0)
            {
                this.ResidenceType = RealEstateType.Lot;
            }
            else if (estateDataSplit[7] == "Residential")
            {
                this.ResidenceType = RealEstateType.Residential;
            }
            else if (estateDataSplit[7] == "Multi-Family")
            {
                this.ResidenceType = RealEstateType.MultiFamily;
            }
            else if (estateDataSplit[7] == "Condo")
            {
                this.ResidenceType = RealEstateType.Condo;
            }
            this.SaleDate = Convert.ToDateTime(estateDataSplit[8]);
            this.SalePrice = Int32.Parse(estateDataSplit[9]);
            this.Lat = estateDataSplit[10];
            this.Long = estateDataSplit[11];
        }
    }
}
