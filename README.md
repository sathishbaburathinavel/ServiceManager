# ServiceManager
Addon Technologies API to push the dashboard report to server.

This is service to sync the Daily summay (report) to server.

Sample Code to access the API.

```C#
private  async void InsertRecordToDB()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://addonservicemanager.azurewebsites.net/");
            //httpClient.BaseAddress = new Uri("http://localhost:50665/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Report[] reports = new Report[]
            {
                new Report{Id = 4,
                Date = new DateTime(2017, 1, 1),
                TotalAmount = 3302,
                BusinessId = 1,
                SystemId = 1
                }
            };
            var response = await httpClient.PostAsJsonAsync("api/Reports", reports[0]);
            response.EnsureSuccessStatusCode();

            txtMessage.Text = await response.Content.ReadAsStringAsync();
        }
 ```
