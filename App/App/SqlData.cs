using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App
{
    public class SqlData
    {
        private readonly SQLiteAsyncConnection db;

        public SqlData(string Path)
        {
            db = new SQLiteAsyncConnection(Path);
            db.CreateTableAsync<ProviderModel>();
            db.CreateTableAsync<RegionModel>();
            db.CreateTableAsync<TariffModel>();
        }
        public Task<int> CreateProvider(ProviderModel provider)
        {
            return db.InsertAsync(provider);
        }

        public Task<List<ProviderModel>> ReadProviders()
        {
            return db.Table<ProviderModel>().ToListAsync();
        }

        public Task<int> UpdateProvider(ProviderModel provider)
        {

            return db.UpdateAsync(provider);
        }

        public Task<int> DeleteProvider(ProviderModel provider)
        {
            return db.DeleteAsync(provider);
        }
        //-----------------------------------
        public Task<int> CreateRegion(RegionModel reg)
        {
            return db.InsertAsync(reg);
        }

        public Task<List<RegionModel>> ReadRegions()
        {
            return db.Table<RegionModel>().ToListAsync();
        }

        public Task<int> UpdateRegion(RegionModel reg)
        {

            return db.UpdateAsync(reg);
        }

        public Task<int> DeleteRegion(RegionModel reg)
        {
            return db.DeleteAsync(reg);
        }
        //---------------
        public Task<int> CreateTariff(TariffModel tariff)
        {
            return db.InsertAsync(tariff);
        }

        public Task<List<TariffModel>> ReadTariffs()
        {
            return db.Table<TariffModel>().ToListAsync();
        }

        public Task<int> UpdateTariff(TariffModel tariff)
        {

            return db.UpdateAsync(tariff);
        }

        public Task<int> DeleteTariff(TariffModel tariff)
        {
            return db.DeleteAsync(tariff);
        }
    }
}

