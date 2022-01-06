using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string emails, string ccEmails, string subject, string htmlMessage, CancellationToken cancellationToken);
    }
}
