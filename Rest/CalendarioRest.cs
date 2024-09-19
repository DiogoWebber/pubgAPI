// using System;
// using System.Collections.Generic;
// using System.Dynamic;
// using System.Linq;
// using System.Net;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using ProjetoIdentity.Data;
// using ScheduleSample.Models;
// using ScheduleSample.Interfaces;
// using ScheduleSample.Dtos;
// using PubgAPI.Dtos;
//
// namespace PubgAPI.Rest
// {
//     public class CalendarioRest : IScheduleService
//     {
//         private readonly ApplicationDbContext _db;
//
//         public CalendarioRest(ApplicationDbContext db)
//         {
//             _db = db;
//         }
//
//         public async Task<ResponseGenerico<IEnumerable<ScheduleEventData>>> GetScheduleEventsAsync(DateTime? startDate, DateTime? endDate)
//         {
//             var response = new ResponseGenerico<IEnumerable<ScheduleEventData>>();
//
//             try
//             {
//                 var eventsQuery = _db.ApplicationDbContext.AsQueryable();
//
//                 if (startDate.HasValue && endDate.HasValue)
//                 {
//                     eventsQuery = eventsQuery.Where(app => app.StartTime >= startDate.Value && app.StartTime <= endDate.Value);
//                 }
//                 else if (startDate.HasValue)
//                 {
//                     eventsQuery = eventsQuery.Where(app => app.StartTime >= startDate.Value);
//                 }
//                 else if (endDate.HasValue)
//                 {
//                     eventsQuery = eventsQuery.Where(app => app.StartTime <= endDate.Value);
//                 }
//
//                 eventsQuery = eventsQuery.Where(app => !string.IsNullOrEmpty(app.RecurrenceRule));
//
//                 var events = await eventsQuery.ToListAsync();
//
//                 response.CodigoHttp = HttpStatusCode.OK;
//                 response.DadosRetorno = events;
//                 response.ErroRetorno = null; // No error
//             }
//             catch (Exception ex)
//             {
//                 dynamic erroRetorno = new ExpandoObject();
//                 erroRetorno.message = ex.Message;
//                 response.CodigoHttp = HttpStatusCode.InternalServerError;
//                 response.ErroRetorno = erroRetorno;
//             }
//
//             return response;
//         }
//
//        public async Task<ResponseGenerico<ApiResponseDto>> UpdateScheduleEventAsync(ScheduleEventRequestDto param)
// {
//     var response = new ResponseGenerico<ApiResponseDto>();
//
//     try
//     {
//         if (param.Action == "insert" || (param.Action == "batch" && param.Added != null))
//         {
//             var appointmentsToAdd = param.Added.Select(value => new ScheduleEventData
//             {
//                 StartTime = value.StartTime,
//                 EndTime = value.EndTime,
//                 Subject = value.Subject,
//                 Location = value.Location,
//                 Description = value.Description,
//                 IsAllDay = value.IsAllDay,
//                 StartTimezone = value.StartTimezone,
//                 EndTimezone = value.EndTimezone,
//                 RecurrenceRule = value.RecurrenceRule,
//                 RecurrenceID = value.RecurrenceID,
//                 RecurrenceException = value.RecurrenceException,
//             }).ToList();
//
//             _db.ApplicationDbContext.AddRange(appointmentsToAdd);
//             await _db.SaveChangesAsync();
//         }
//
//         if (param.Action == "update" || (param.Action == "batch" && param.Changed != null))
//         {
//             foreach (var value in param.Changed)
//             {
//                 var appointment = await _db.ApplicationDbContext.FindAsync(value.Id);
//                 if (appointment != null)
//                 {
//                     appointment.StartTime = value.StartTime;
//                     appointment.EndTime = value.EndTime;
//                     appointment.Subject = value.Subject;
//                     appointment.Location = value.Location;
//                     appointment.Description = value.Description;
//                     appointment.IsAllDay = value.IsAllDay;
//                     appointment.StartTimezone = value.StartTimezone;
//                     appointment.EndTimezone = value.EndTimezone;
//                     appointment.RecurrenceRule = value.RecurrenceRule;
//                     appointment.RecurrenceID = value.RecurrenceID;
//                     appointment.RecurrenceException = value.RecurrenceException;
//                 }
//             }
//
//             await _db.SaveChangesAsync();
//         }
//
//         var apiResponseDto = new ApiResponseDto
//         {
//             CodigoHttp = HttpStatusCode.OK,
//             DadosRetorno = param // Note: This may need to be adjusted based on your needs
//         };
//
//         response.CodigoHttp = HttpStatusCode.OK;
//         response.DadosRetorno = apiResponseDto;
//         response.ErroRetorno = null;
//     }
//     catch (Exception ex)
//     {
//         dynamic erroRetorno = new ExpandoObject();
//         erroRetorno.message = ex.Message;
//         response.CodigoHttp = HttpStatusCode.InternalServerError;
//         response.ErroRetorno = erroRetorno;
//     }
//
//     return response;
// }
//
//     }
// }
