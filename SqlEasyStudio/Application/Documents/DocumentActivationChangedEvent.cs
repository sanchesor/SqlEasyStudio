﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Documents
{
    public class DocumentActivationChangedEvent
    {
        public IDocument Document;
        public bool IsActive;
    }
}
