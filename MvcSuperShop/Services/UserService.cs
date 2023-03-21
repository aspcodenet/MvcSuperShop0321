using Newtonsoft.Json;

namespace MvcSuperShop.Services
{
    public class FakePerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string Username { get; set; }
    }

    public class UserService
    {
        public FakePerson Generate()
        {
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync("https://randomuser.me/api/").Result;
                dynamic r = JsonConvert.DeserializeObject<dynamic>(json);

                var result = new FakePerson();
                result.City = r.results[0].location.city;
                result.Country = r.results[0].location.country;
                result.FirstName = r.results[0].name.first;
                result.LastName = r.results[0].name.last;
                result.Username = r.results[0].login.username;
                return result;
            }
        }
    }
}
