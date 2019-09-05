using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public interface IDialer
    {
        Task<bool> DialAsync(string number);
    }
}
