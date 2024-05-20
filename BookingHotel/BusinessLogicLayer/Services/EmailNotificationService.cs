using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EmailNotificationService : INotificationService
    {
        public void Send(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
