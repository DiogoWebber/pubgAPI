using System;
using System.Collections.Generic;

namespace ScheduleSample.Dtos
{
    public class ScheduleEventRequestDto
    {
        // Parâmetros de Data para Filtragem
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Detalhes da Operação
        public string Action { get; set; }
        public string Key { get; set; }

        // Dados do Evento para Inserção, Atualização, ou Deleção
        public List<ScheduleEventDto> Added { get; set; }
        public List<ScheduleEventDto> Changed { get; set; }
        public List<ScheduleEventDto> Deleted { get; set; }
        public ScheduleEventDto Value { get; set; }
    }

    public class ScheduleEventDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public string RecurrenceRule { get; set; }
        public int? RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
    }

    public class ApiResponseDto
    {
        public System.Net.HttpStatusCode CodigoHttp { get; set; }
        public object DadosRetorno { get; set; }
        public string ErroRetorno { get; set; }
    }
}