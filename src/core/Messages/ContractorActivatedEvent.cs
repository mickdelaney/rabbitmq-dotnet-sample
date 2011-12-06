using System;

namespace core.Messages
{
    public class ContractorActivatedEvent
    {
        public Guid ContractorId { get; set; }
        public string EmailAddress { get; set; }

        public ContractorActivatedEvent(Guid contractorId, string emailAddress)
        {
            ContractorId = contractorId;
            EmailAddress = emailAddress;
        }
    }
}
