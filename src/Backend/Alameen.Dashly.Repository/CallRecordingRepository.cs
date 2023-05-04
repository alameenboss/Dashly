using Alameen.Dashly.Common.Helpers;
using Alameen.Dashly.Core;
using Alameen.Dashly.Repository.Contract;
using Alameen.Dashly.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository
{
    public class CallRecordingRepository : ICallRecordingRepository
    {
        private readonly DashlyContext _dbContext;

        public CallRecordingRepository(DashlyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CallRecording>> GetAll()
        {
            return await _dbContext
                .CallRecordings
                .ToListAsync();
        }

        public async Task<CallRecording> GetById(int id)
        {
            return await _dbContext
                .CallRecordings
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Insert(CallRecording entity)
        {
            await _dbContext.CallRecordings.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Update(CallRecording model, int id)
        {
            var oldCallRecording = _dbContext.CallRecordings
                    .Where(p => p.Id == model.Id)
                    .SingleOrDefault();

            if (oldCallRecording != null)
            {
                _dbContext.Entry(oldCallRecording).CurrentValues.SetValues(model);
                _dbContext.SaveChanges();
            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var callRecording = await _dbContext.CallRecordings.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.CallRecordings.Remove(callRecording);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAll()
        {
            var callRecordings = _dbContext.CallRecordings;
            _dbContext.CallRecordings.RemoveRange(callRecordings);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task Import(IEnumerable<CallRecording> entities)
        {
            //await _dbContext.AddRangeAsync(entities);
            try
            {

                var existingEntities = _dbContext.CallRecordings.ToList();
                var filteredList = entities.Where(p2 => !existingEntities.Any(p1 => p1.HashValue == p2.HashValue)).ToList();
                await _dbContext.CallRecordings.AddRangeAsync(filteredList);
                await _dbContext.SaveChangesAsync();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
    }

}