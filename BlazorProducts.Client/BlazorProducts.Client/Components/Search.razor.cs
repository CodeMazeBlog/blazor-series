using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorProducts.Client.Components
{
    public partial class Search
    {
        private Timer _timer;

        public string SearchTerm { get; set; }

        [Parameter]
        public EventCallback<string> OnSearchChanged { get; set; }

        private void SearchChanged()
        {
            if (_timer != null)
                _timer.Dispose();

            _timer = new Timer(OnTimerElapsed, null, 500, 0);
        }

        private void OnTimerElapsed(object sender)
        {
            OnSearchChanged.InvokeAsync(SearchTerm);
            _timer.Dispose();
        }
    }
}
