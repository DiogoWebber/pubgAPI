using PubgAPI.Dtos;
using ScheduleSample.Models;
using ScheduleSample.Dtos;

namespace ScheduleSample.Interfaces
{
    public interface IScheduleService
    {
        Task<ResponseGenerico<IEnumerable<ScheduleEventData>>> GetScheduleEventsAsync(DateTime? startDate, DateTime? endDate);
        Task<ResponseGenerico<ApiResponseDto>> UpdateScheduleEventAsync(ScheduleEventRequestDto param);
    }
}