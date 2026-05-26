using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12.Services
{
    public interface INavigationAware
    {
        void OnNavigatedTo(object? parameter);
    }
}