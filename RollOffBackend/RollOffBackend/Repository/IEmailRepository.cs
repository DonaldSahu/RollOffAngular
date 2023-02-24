using RollOffBackend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public interface IEmailRepository
    {
        void SendEmail(EmailDTO email);
    }
}
