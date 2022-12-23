using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileApp
{

    public class SqlData
    {
        HttpClient client;

        JsonSerializerOptions options = new JsonSerializerOptions() {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        public SqlData()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client = new HttpClient(clientHandler);
        }
        

        public async Task CreateProvider(ProviderModel provider)
        {
            string jsonString = JsonSerializer.Serialize(provider, options);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://10.0.2.2:5276/api/provider/", httpContent);
            
        }

        public async Task<List<ProviderModel>> ReadProviders()
        {
            
                var response = await client.GetAsync("http://10.0.2.2:5276/api/provider/");
                string res = await response.Content.ReadAsStringAsync();
            

            List<ProviderModel> list = JsonSerializer.Deserialize<List<ProviderModel>>(res, options);

            return list;
            
        }

        public async Task UpdateProvider(ProviderModel provider)
        {
            string jsonString = JsonSerializer.Serialize(provider, options);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"http://10.0.2.2:5276/api/provider/{provider.ProviderId}", httpContent);
            
        }

        public async Task DeleteProvider(ProviderModel provider)
        {
            var response = await client.DeleteAsync($"http://10.0.2.2:5276/api/provider/{provider.ProviderId}");
            
        }
        //-----------------------------------
        public async Task CreateRegion(RegionModel reg)
        {
            string jsonString = JsonSerializer.Serialize(reg, options);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            await client.PostAsync("http://10.0.2.2:5276/api/region/", httpContent);
        }

        public async Task<List<RegionModel>> ReadRegions()
        {
            var response = await client.GetAsync("http://10.0.2.2:5276/api/region/");
            string res = await response.Content.ReadAsStringAsync();
            List<RegionModel> list = JsonSerializer.Deserialize<IEnumerable<RegionModel>>(res, options).ToList();

            return list;
        }

        public async Task UpdateRegion(RegionModel reg)
        {

            string jsonString = JsonSerializer.Serialize(reg, options);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"http://10.0.2.2:5276/api/region/{reg.RegionId}", httpContent);
        }

        public async Task DeleteRegion(RegionModel reg)
        {
            var response = await client.DeleteAsync($"http://10.0.2.2:5276/api/region/{reg.RegionId}");
        }
        //---------------
        public async Task CreateTariff(TariffModel tariff)
        {
            string jsonString = JsonSerializer.Serialize(tariff, options);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            await client.PostAsync("http://10.0.2.2:5276/api/tariff/", httpContent);
        }

        public async Task<List<TariffModel>> ReadTariffs()
        {
            var response = await client.GetAsync("http://10.0.2.2:5276/api/tariff/");
            string res = await response.Content.ReadAsStringAsync();
            List<TariffModel> list = JsonSerializer.Deserialize<IEnumerable<TariffModel>>(res, options).ToList();

            return list;
        }

        public async Task UpdateTariff(TariffModel tariff)
        {

            string jsonString = JsonSerializer.Serialize(tariff, options);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"http://10.0.2.2:5276/api/tariff/{tariff.TariffId}", httpContent);
        }

        public async Task DeleteTariff(TariffModel tariff)
        {
            var response = await client.DeleteAsync($"http://10.0.2.2:5276/api/tariff/{tariff.TariffId}");
        }
    }

}
