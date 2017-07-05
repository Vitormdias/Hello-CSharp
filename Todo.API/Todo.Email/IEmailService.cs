using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Email
{
    public interface IEmailService
    {
        bool Send(Email email);
    }
}
