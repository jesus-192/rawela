using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rawela.ViewModels.MailViewModel
{
    public class SendMailViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}