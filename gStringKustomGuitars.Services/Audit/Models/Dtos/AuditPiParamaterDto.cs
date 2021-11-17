namespace gStringKustomGuitars.Services.Domain.Audit.Models.Dtos
{
    public class AuditPiParamaterDto
    {
        public string eventName { get; set; }

        public string eventAction { get; set; }

        public int userId { get; set; }
    }
}
