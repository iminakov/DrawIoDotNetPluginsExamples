using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapDiagram.Pages
{
    public class CounterBase :  ComponentBase
    {
        [Parameter]
        public int Increment { get; set; } = 1;

        [Inject]
        protected Services.ICounterService CounterService { get; set; }

        protected void IncrementCount()
        {
            CounterService.Count+=Increment;
        }
    }
}
