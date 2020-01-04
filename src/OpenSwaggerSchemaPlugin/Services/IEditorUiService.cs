﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePlug.Services
{
    public interface IEditorUiService
    {
        Task OpenAndReadFile(Action<string> callBack);

        Task LogContent(string content);
    }
}