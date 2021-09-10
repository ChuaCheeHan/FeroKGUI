using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics; // This is needed for command line
using System.IO; // This is needed for requests
using System.Net; // This is needed for requests
using System.Net.Http; // This is needed for requests
using System.Net.Http.Headers; // This is needed for requests
using Newtonsoft.Json; //for parasing http requests
using Newtonsoft.Json.Serialization; //for parasing http requests
using BingMapsRESTToolkit;
using Microsoft.Maps.MapControl.WPF; //For Bing Maps

namespace FeroKGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Company
    {
        public int closingtime { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int openingtime { get; set; }
        public string trashtype { get; set; }
        public int zipcode { get; set; }
    }

    public class Aeaconverter
    {
        public string data { get; set; }
    }

    public class Aeavalues
    {
        public string created_at { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
    public class PublicWebsite
    {
        public string amount { get; set; }
        public int closingtime { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public bool notification { get; set; }
        public int openingtime { get; set; }
        public string trashtype { get; set; }
        public int zipcode { get; set; }
    }

    public class Point
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Address
    {
        public string countryRegion { get; set; }
        public string formattedAddress { get; set; }
        public string locality { get; set; }
        public string postalCode { get; set; }
    }

    public class GeocodePoint
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
        public string calculationMethod { get; set; }
        public List<string> usageTypes { get; set; }
    }

    public class Resource
    {
        public string __type { get; set; }
        public List<double> bbox { get; set; }
        public string name { get; set; }
        public Point point { get; set; }
        public Address address { get; set; }
        public string confidence { get; set; }
        public string entityType { get; set; }
        public List<GeocodePoint> geocodePoints { get; set; }
        public List<string> matchCodes { get; set; }
    }

    public class ResourceSet
    {
        public int estimatedTotal { get; set; }
        public List<Resource> resources { get; set; }
    }

    public class Bingmapsjson
    {
        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public List<ResourceSet> resourceSets { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string traceId { get; set; }
    }

    public class StartLocation
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class EndLocation
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Break
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string duration { get; set; }
    }

    public class Shift
    {
        public DateTime startTime { get; set; }
        public StartLocation startLocation { get; set; }
        public DateTime endTime { get; set; }
        public EndLocation endLocation { get; set; }
        public List<Break> breaks { get; set; }
    }

    public class Price
    {
        public double fixedPrice { get; set; }
        public double pricePerKM { get; set; }
        public double pricePerHour { get; set; }
    }

    public class Agent
    {
        public string name { get; set; }
        public List<Shift> shifts { get; set; }
        public Price price { get; set; }
        public List<int> capacity { get; set; }
    }

    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class ItineraryItem
    {
        public string name { get; set; }
        public DateTime openingTime { get; set; }
        public DateTime closingTime { get; set; }
        public string dwellTime { get; set; }
        public int priority { get; set; }
        public List<int> quantity { get; set; }
        public Location location { get; set; }
        public List<string> dropOffFrom { get; set; }
    }

    public class BingMapsOptimization
    {
        public List<Agent> agents { get; set; }
        public List<ItineraryItem> itineraryItems { get; set; }
    }


    public class Instruction
    {
        public string duration { get; set; }
        public DateTime endTime { get; set; }
        public string instructionType { get; set; }
        public ItineraryItem itineraryItem { get; set; }
        public DateTime startTime { get; set; }
        public int? distance { get; set; }
    }

    public class WayPoint
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Route
    {
        public EndLocation endLocation { get; set; }
        public DateTime endTime { get; set; }
        public StartLocation startLocation { get; set; }
        public DateTime startTime { get; set; }
        public int totalTravelDistance { get; set; }
        public string totalTravelTime { get; set; }
        public List<Location> wayPoints { get; set; }
    }

    public class AgentItinerary
    {
        public Agent agent { get; set; }
        public List<Instruction> instructions { get; set; }
        public Route route { get; set; }
    }

    public class Resource_2
    {
        public string __type { get; set; }
        public List<AgentItinerary> agentItineraries { get; set; }
        public bool isAccepted { get; set; }
        public bool isCompleted { get; set; }
        public List<object> unscheduledItems { get; set; }
        public List<object> unusedAgents { get; set; }
    }

    public class ResourceSet_2
    {
        public int estimatedTotal { get; set; }
        public List<Resource_2> resources { get; set; }
    }

    public class BingMapsOptimizationResult
    {
        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public List<ResourceSet_2> resourceSets { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string traceId { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Location_2
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class EntitiesAlongRoute
    {
        public Location_2 location { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class ActualEnd
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class ActualStart
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }


    public class EndLocation_2
    {
        public List<double> bbox { get; set; }
        public string name { get; set; }
        public Point point { get; set; }
        public Address address { get; set; }
        public string confidence { get; set; }
        public string entityType { get; set; }
        public List<GeocodePoint> geocodePoints { get; set; }
        public List<string> matchCodes { get; set; }
    }

    public class EndWaypoint
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
        public string description { get; set; }
        public bool isVia { get; set; }
        public string locationIdentifier { get; set; }
        public int routePathIndex { get; set; }
    }

    public class StartWaypoint
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
        public string description { get; set; }
        public bool isVia { get; set; }
        public string locationIdentifier { get; set; }
        public int routePathIndex { get; set; }
    }

    public class RouteSubLeg
    {
        public EndWaypoint endWaypoint { get; set; }
        public StartWaypoint startWaypoint { get; set; }
        public double travelDistance { get; set; }
        public int travelDuration { get; set; }
    }

    public class StartLocation_2
    {
        public List<double> bbox { get; set; }
        public string name { get; set; }
        public Point point { get; set; }
        public Address address { get; set; }
        public string confidence { get; set; }
        public string entityType { get; set; }
        public List<GeocodePoint> geocodePoints { get; set; }
        public List<string> matchCodes { get; set; }
    }

    public class RouteLeg
    {
        public ActualEnd actualEnd { get; set; }
        public ActualStart actualStart { get; set; }
        public List<object> alternateVias { get; set; }
        public int cost { get; set; }
        public string description { get; set; }
        public EndLocation_2 endLocation { get; set; }
        public string routeRegion { get; set; }
        public List<RouteSubLeg> routeSubLegs { get; set; }
        public StartLocation_2 startLocation { get; set; }
        public double travelDistance { get; set; }
        public int travelDuration { get; set; }
        public string travelMode { get; set; }
    }

    public class Resource_3
    {
        public string __type { get; set; }
        public List<double> bbox { get; set; }
        public string id { get; set; }
        public string distanceUnit { get; set; }
        public string durationUnit { get; set; }
        public List<EntitiesAlongRoute> entitiesAlongRoute { get; set; }
        public int price { get; set; }
        public List<RouteLeg> routeLegs { get; set; }
        public string trafficCongestion { get; set; }
        public string trafficDataUsed { get; set; }
        public double travelDistance { get; set; }
        public int travelDuration { get; set; }
        public int travelDurationTraffic { get; set; }
        public string travelMode { get; set; }
    }

    public class ResourceSet_3
    {
        public int estimatedTotal { get; set; }
        public List<Resource_3> resources { get; set; }
    }

    public class MapRoute //Route optimization from calculating optimzed itineary routes
    {
        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public List<ResourceSet_3> resourceSets { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string traceId { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    public class Shield
    {
        public List<string> labels { get; set; }
        public int roadShieldType { get; set; }
    }

    public class RoadShieldRequestParameters
    {
        public int bucket { get; set; }
        public List<Shield> shields { get; set; }
    }

    public class Detail
    {
        public int compassDegrees { get; set; }
        public List<int> endPathIndices { get; set; }
        public string maneuverType { get; set; }
        public string mode { get; set; }
        public List<string> names { get; set; }
        public string roadType { get; set; }
        public List<int> startPathIndices { get; set; }
        public List<string> locationCodes { get; set; }
        public RoadShieldRequestParameters roadShieldRequestParameters { get; set; }
    }

    public class Instruction_2
    {
        public object formattedText { get; set; }
        public string maneuverType { get; set; }
        public string text { get; set; }
    }

    public class ManeuverPoint
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Warning
    {
        public string severity { get; set; }
        public string text { get; set; }
        public string warningType { get; set; }
        public string origin { get; set; }
        public string to { get; set; }
    }

    public class Hint
    {
        public string hintType { get; set; }
        public string text { get; set; }
    }

    public class ItineraryItem_3
    {
        public string compassDirection { get; set; }
        public List<Detail> details { get; set; }
        public string exit { get; set; }
        public string iconType { get; set; }
        public Instruction_2 instruction { get; set; }
        public bool isRealTimeTransit { get; set; }
        public ManeuverPoint maneuverPoint { get; set; }
        public int realTimeTransitDelay { get; set; }
        public string sideOfStreet { get; set; }
        public string tollZone { get; set; }
        public string transitTerminus { get; set; }
        public double travelDistance { get; set; }
        public int travelDuration { get; set; }
        public string travelMode { get; set; }
        public List<Warning> warnings { get; set; }
        public List<string> signs { get; set; }
        public List<Hint> hints { get; set; }
    }

    public class RouteLeg_2
    {
        public ActualEnd actualEnd { get; set; }
        public ActualStart actualStart { get; set; }
        public List<object> alternateVias { get; set; }
        public int cost { get; set; }
        public string description { get; set; }
        public EndLocation_2 endLocation { get; set; }
        public List<ItineraryItem_3> itineraryItems { get; set; }
        public string routeRegion { get; set; }
        public List<RouteSubLeg> routeSubLegs { get; set; }
        public StartLocation_2 startLocation { get; set; }
        public double travelDistance { get; set; }
        public int travelDuration { get; set; }
        public string travelMode { get; set; }
    }

    public class Line
    {
        public string type { get; set; }
        public List<List<double>> coordinates { get; set; }
    }

    public class RoutePath
    {
        public List<object> generalizations { get; set; }
        public Line line { get; set; }
    }

    public class Resource_4
    {
        public string __type { get; set; }
        public List<double> bbox { get; set; }
        public string id { get; set; }
        public string distanceUnit { get; set; }
        public string durationUnit { get; set; }
        public int price { get; set; }
        public List<RouteLeg_2> routeLegs { get; set; }
        public RoutePath routePath { get; set; }
        public string trafficCongestion { get; set; }
        public string trafficDataUsed { get; set; }
        public double travelDistance { get; set; }
        public int travelDuration { get; set; }
        public int travelDurationTraffic { get; set; }
        public string travelMode { get; set; }
    }

    public class ResourceSet_4
    {
        public int estimatedTotal { get; set; }
        public List<Resource_4> resources { get; set; }
    }

    public class Bingroute //Waypoint optimized from get request
    {
        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public List<ResourceSet_4> resourceSets { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string traceId { get; set; }
    }




    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //string[] args = Environment.GetCommandLineArgs();
        }


        private void Public_Click(object sender, RoutedEventArgs e)
        {
            Process publicSearch = new Process();
            publicSearch.StartInfo.FileName = "cmd";
            publicSearch.StartInfo.WorkingDirectory = "C:\\Users\\kevan\\FETCH\\my_aea_projects\\publicsearch";
            publicSearch.StartInfo.Arguments = "/c aea run";
            publicSearch.Start();
            var aeafilereader = new StreamReader("C:\\Users\\kevan\\FETCH\\my_aea_projects\\publicsearch\\outputfile.txt");
            var aeatext = aeafilereader.ReadToEnd();
            Console.WriteLine("AEATEXT");
            Console.WriteLine(aeatext);
            //aeatext = aeatext.Replace(@"\", string.Empty);
            Aeaconverter convertedaeatext = JsonConvert.DeserializeObject<Aeaconverter>(aeatext);
            Console.WriteLine("convertedaeatext");
            Console.WriteLine(convertedaeatext.data);
            Aeavalues aeatabledata = JsonConvert.DeserializeObject<Aeavalues>(convertedaeatext.data);
            List<Aeavalues> list2 = new List<Aeavalues>();
            list2.Add(aeatabledata);
            RCGrid.ItemsSource = list2;
        }

        private void RC_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient(); //should not be here, should only be called ONCE
            client.BaseAddress = new Uri("https://ferorc.herokuapp.com/");
            var responseTask = client.GetAsync("/?trashtype=metal");
            responseTask.Wait();
            var companies = responseTask.Result;
            Console.WriteLine(companies.Content.ReadAsStringAsync());
            Company companylist = JsonConvert.DeserializeObject<Company>(companies.Content.ReadAsStringAsync().Result);
            List<Company> list = new List<Company>();
            list.Add(companylist);


            responseTask = client.GetAsync("/?trashtype=paper");
            responseTask.Wait();
            companies = responseTask.Result;
            Console.WriteLine(companies.Content.ReadAsStringAsync());
            companylist = JsonConvert.DeserializeObject<Company>(companies.Content.ReadAsStringAsync().Result);
            list.Add(companylist);


            RCGrid.ItemsSource = list;
        }

        public void Website_Click(object sender, RoutedEventArgs e)
        {
            HttpClient public_client = new HttpClient();
            HttpClient map_client = new HttpClient();
            public_client.BaseAddress = new Uri("https://feropublic.herokuapp.com/");
            map_client.BaseAddress = new Uri("https://dev.virtualearth.net/");
            var publicClientTask = public_client.GetAsync("/numberofusers");
            publicClientTask.Wait();
            var publicClientResult = publicClientTask.Result;
            int numberofusers = int.Parse(publicClientResult.Content.ReadAsStringAsync().Result);
            //Console.WriteLine(numberofusers);
            List<PublicWebsite> publicList = new List<PublicWebsite>();

            for (int i = 1; i <= numberofusers; i++)
            {
                publicClientTask = public_client.GetAsync("/?id=" + i);
                publicClientTask.Wait();
                publicClientResult = publicClientTask.Result;
                PublicWebsite public_obj = JsonConvert.DeserializeObject<PublicWebsite>(publicClientResult.Content.ReadAsStringAsync().Result);
                publicList.Add(public_obj);

                publicClientTask = public_client.GetAsync("/notifytrue/" + i);
                publicClientTask.Wait();
                publicClientResult = publicClientTask.Result;

                
                var BingMapsKey = "fRPFc4ZzXV5MsgrJO2UC~zR1H67pRE89hOyB3g1603w~Ag9s_g6NU_mZFYV76RGpS2tl4_1vmZgnjjkjGz4q6PkOuZshl496bxlUWqDVuImO";
                publicClientTask = map_client.GetAsync("/REST/v1/Locations?countryRegion=Singapore&postalCode=" + public_obj.zipcode.ToString() + "&key=" + BingMapsKey);
                publicClientTask.Wait();
                publicClientResult = publicClientTask.Result;
                Bingmapsjson bingmapsinfo = JsonConvert.DeserializeObject<Bingmapsjson>(publicClientResult.Content.ReadAsStringAsync().Result);
                var longitude = bingmapsinfo.resourceSets.First().resources.First().point.coordinates[0];
                var latitude = bingmapsinfo.resourceSets.First().resources.First().point.coordinates[1];
                var mapLocation = new Microsoft.Maps.MapControl.WPF.Location(longitude, latitude);
                var p = new Pushpin() {Location = mapLocation, ToolTip = public_obj.name};
                BingMaps.Children.Add(p);
            }
            RCGrid.ItemsSource = publicList;

        }

        private void OptimizeRoute_Click(object sender, RoutedEventArgs e)
        {
            //var mapLocation = new Microsoft.Maps.MapControl.WPF.Location(1.373806031, 103.8739802);
            //var p = new Pushpin() { Location = mapLocation, ToolTip = "CurrentUser" };
            //BingMaps.Children.Add(p);

            //mapLocation = new Microsoft.Maps.MapControl.WPF.Location(1.473806031, 103.8739802);
            //p = new Pushpin() { Location = mapLocation, ToolTip = "NextUser" };
            //BingMaps.Children.Add(p);

            if (BingMaps.Children.Count == 0)
            {
                MessageBox.Show("No points on map.");
            }

            else if (KG_Zipcode.Text.Length < 5)
            {
                MessageBox.Show("Please Enter Zipcode.");
            }
            else
            {

                //HttpClient post_client = new HttpClient();
                //post_client.BaseAddress = new Uri("https://dev.virtualearth.net/REST/V1/Routes/OptimizeItinerary?key=fRPFc4ZzXV5MsgrJO2UC~zR1H67pRE89hOyB3g1603w~Ag9s_g6NU_mZFYV76RGpS2tl4_1vmZgnjjkjGz4q6PkOuZshl496bxlUWqDVuImO");
                //post_client.DefaultRequestHeaders
                //    .Accept
                //    .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                //var values = new Dictionary<string, string>
                //{
                //    { "agents", "name" },
                //    { "thing2", "world" }
                //   };

                //var content = new FormUrlEncodedContent(values);

                //Agent current_user = new Agent() {shifts = new List<Shift>() };
                //current_user.name = "agentName";
                //Shift user_shift = new Shift();
                //user_shift.startTime = new DateTime(2019, 11, 9, 08, 00, 00); //"2019 - 11 - 09T08: 00:00"
                //user_shift.startLocation = new StartLocation() {latitude = 1.3738, longitude = 103.87453 };
                //user_shift.endTime = new DateTime(2019, 11, 9, 18, 00, 00); //"2019 - 11 - 09T18: 00:00"
                //user_shift.endLocation = new EndLocation() { latitude = 1.3738, longitude = 103.87453 };
                //current_user.shifts.Add(user_shift);

                //ItineraryItem firstLoc = new ItineraryItem();
                //firstLoc.name = "loc1";
                //firstLoc.openingTime = new DateTime(2019, 11, 9, 09, 00, 00);
                //firstLoc.closingTime = new DateTime(2019, 11, 9, 18, 00, 00);
                //firstLoc.dwellTime = "00:31:08.3850000";
                //firstLoc.priority = 5;
                //firstLoc.location = new Location() {latitude = 1.3978, longitude = 103.7447 };

                //ItineraryItem secondLoc = new ItineraryItem();
                //secondLoc.name = "loc2";
                //secondLoc.openingTime = new DateTime(2019, 11, 9, 09, 00, 00);
                //secondLoc.closingTime = new DateTime(2019, 11, 9, 18, 00, 00);
                //secondLoc.dwellTime = "00:31:08.3850000";
                //secondLoc.priority = 5;
                //secondLoc.location = new Location() { latitude = 1.3720, longitude = 103.8373 };


                //BingMapsOptimization optimizationrequest = new BingMapsOptimization() {agents = new List<Agent>(), itineraryItems = new List<ItineraryItem>() };
                //optimizationrequest.agents.Add(current_user);
                //optimizationrequest.itineraryItems.Add(firstLoc);
                //optimizationrequest.itineraryItems.Add(secondLoc);


                //string output = JsonConvert.SerializeObject(optimizationrequest);
                //Console.WriteLine(output);

                //var response = post_client.PostAsync("https://dev.virtualearth.net/REST/V1/Routes/OptimizeItinerary?key=fRPFc4ZzXV5MsgrJO2UC~zR1H67pRE89hOyB3g1603w~Ag9s_g6NU_mZFYV76RGpS2tl4_1vmZgnjjkjGz4q6PkOuZshl496bxlUWqDVuImO", new StringContent(output, Encoding.UTF8, "application/json"));
                //response.Wait();
                //var responseString = response.Result.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(responseString);
                //BingMapsOptimizationResult bingResult = JsonConvert.DeserializeObject<BingMapsOptimizationResult>(responseString);
                //Console.WriteLine(bingResult.resourceSets.First().resources.First().agentItineraries.First().agent.name);
                //Console.WriteLine(JsonConvert.SerializeObject(bingResult));
                //var orderoftravel = bingResult.resourceSets.First().resources.First().agentItineraries.First().instructions.FindAll(value => value.instructionType == "VisitLocation");
                //Console.WriteLine("Hello");
                //foreach (var obj in orderoftravel)
                //{
                //    Console.WriteLine(obj);
                //}

                HttpClient map_route = new HttpClient();
                map_route.BaseAddress = new Uri("https://dev.virtualearth.net/");
                string get_param = "/REST/V1/Routes/Driving?wp.0=" + KG_Zipcode + "&";
                int waypointnumber = 1;
                List<Pushpin> list_of_pins = new List<Pushpin>(); 
                foreach (Pushpin pin in BingMaps.Children)
                {
                    get_param = get_param + "wp." + waypointnumber + "=" + pin.Location.Latitude + "," + pin.Location.Longitude + "&";
                    waypointnumber++;
                    list_of_pins.Add(pin);
                }
                get_param = get_param + "wp." + waypointnumber + "=" + KG_Zipcode + "&optmz=distance&routeAttributes=routepath&optimizeWaypoints=true&key=fRPFc4ZzXV5MsgrJO2UC~zR1H67pRE89hOyB3g1603w~Ag9s_g6NU_mZFYV76RGpS2tl4_1vmZgnjjkjGz4q6PkOuZshl496bxlUWqDVuImO";
                Console.WriteLine("get_param");
                Console.WriteLine(get_param);
                //var map_route_task = map_route.GetAsync("/REST/V1/Routes/Driving?wp.0=550535&wp.1=680603&wp.2=757488&wp.3=550535&optmz=distance&routeAttributes=routepath&optimizeWaypoints=true&key=fRPFc4ZzXV5MsgrJO2UC~zR1H67pRE89hOyB3g1603w~Ag9s_g6NU_mZFYV76RGpS2tl4_1vmZgnjjkjGz4q6PkOuZshl496bxlUWqDVuImO");
                var map_route_task = map_route.GetAsync(get_param);
                map_route_task.Wait();
                var map_route_result = map_route_task.Result;
                Bingroute route = JsonConvert.DeserializeObject<Bingroute>(map_route_result.Content.ReadAsStringAsync().Result);

                List<System.Windows.Media.SolidColorBrush> strokeList = new List<System.Windows.Media.SolidColorBrush>();
                strokeList.Add(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red));
                strokeList.Add(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Orange));
                strokeList.Add(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Yellow));
                strokeList.Add(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green));
                strokeList.Add(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue));
                strokeList.Add(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Indigo));
                strokeList.Add(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Violet));
                int counter = 0;

                
                for (int i = 0; i < route.resourceSets.First().resources.First().routeLegs.Count; i++ )
                {
                    int waypoint_check = 0;
                    var polyline = new MapPolyline();
                    polyline.Stroke = strokeList[counter];
                    polyline.StrokeThickness = 5;
                    polyline.Opacity = 0.7;
                    polyline.Locations = new LocationCollection();
                    counter++;
                    if (counter > strokeList.Count - 1)
                    {
                        counter = 0;
                    };

                    foreach (var obj in route.resourceSets.First().resources.First().routePath.line.coordinates)
                    {
                        if (i > 0 && waypoint_check == 0)
                        {
                            if (obj[0] == route.resourceSets.First().resources.First().routeLegs[i-1].routeSubLegs[0].endWaypoint.coordinates[0])
                            {
                                waypoint_check++;
                            };
                            continue;
                        };
                        var bingpoint = new Microsoft.Maps.MapControl.WPF.Location(obj[0], obj[1]);
                        polyline.Locations.Add(bingpoint);
                        if (obj[0] == route.resourceSets.First().resources.First().routeLegs[i].routeSubLegs[0].endWaypoint.coordinates[0])
                        {
                            break;
                        };
                    }
                    BingMaps.Children.Add(polyline);
                };
                

                BingMaps.Children.Add(new Pushpin() { Location = new Microsoft.Maps.MapControl.WPF.Location(route.resourceSets.First().resources.First().routePath.line.coordinates.First()[0], route.resourceSets.First().resources.First().routePath.line.coordinates.First()[1]), ToolTip = "Start Here" });

                
            }
        }

        private void Chat_Click(object sender, RoutedEventArgs e)
        {
            ChatWindow chatWindow = new ChatWindow();
            chatWindow.Show();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
    
}
