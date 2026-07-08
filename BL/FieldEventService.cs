using System.Diagnostics;
using DAL;
using DAL.DataObjects;

namespace BL
{
    public interface IFieldEventService
    {
        
        public Task<long> SaveFieldEvent(FieldEventDetails details);
        public Task SendAlertToDispatcher(long id);
        public Task Log(string message);
        public Task Log(string message, int userId);
    }
    public class FieldEventService: IFieldEventService
    {
        private readonly FieldEventContext _dbContext;
        public FieldEventService(FieldEventContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public async Task<long> SaveFieldEvent(FieldEventDetails details)
        {
            FieldEvent fieldEvent = new FieldEvent();
            try
            {
                fieldEvent.Title = details.Title;
                fieldEvent.Desc = details.Description;
                fieldEvent.UserId = details.UserId;
                fieldEvent.SourseId = details.SourceId;
                fieldEvent.StatusId = 1;
                fieldEvent.StartDate = DateTime.Now;

                _dbContext.Add(fieldEvent);

                _dbContext.SaveChanges();

                FieldEvent currentSavedTrans = _dbContext.FieldEvents.OrderByDescending(f => f.Id).FirstOrDefault();
                if (currentSavedTrans != null) 
                {
                    await SendAlertToDispatcher(currentSavedTrans.Id); 
                    return currentSavedTrans.Id;
                }
                else {return 0; }  

            }
            catch (Exception ex)
            {

                return 0;
                
            }
        }

        public async Task SendAlertToDispatcher(long id)
        {

        }
        public async Task Log(string message)
        {
            await Log(message, 0);
            
        }

        public async Task Log(string message, int userId)
        {
            
            //await _dbContext.Database.ExecuteSqlRawAsync(
            //    "INSERT INTO BackendLogs (PlayerId, Timestamp, Log) VALUES ({0}, {1}, {2})",
            //    userId,
            //    DateTime.UtcNow,
            //    message
            //);
            Trace.WriteLine(message);
        }

    }
}
