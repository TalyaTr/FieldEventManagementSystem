using System.Diagnostics;
using BL.Shared;
using DAL;
using DAL.DataObjects;
using Twilio;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;

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
                fieldEvent.StatusId = (int)Enums.FieldEventStatus.New; 
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
            string accountSid = "YOUR_ACCOUNT_SID";
            string authToken = "YOUR_AUTH_TOKEN";
            try
            {
                Employee dispatcher = _dbContext.Employees.FirstOrDefault(e => e.EmployeeCategoryId == (int)Enums.EmployeeCategory.Dispatcher);
              
                TwilioClient.Init(accountSid, authToken);
                var message = MessageResource.Create(
                body: $"A new event has been received. Event number: {id.ToString()}",
                from: new Twilio.Types.PhoneNumber("0528979117"),
                to: new Twilio.Types.PhoneNumber(dispatcher.PhoneNumber)
            );
            }
            catch (Exception ex)
            {

                await Log(ex.Message, (int)id);
            }
          
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
