using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CERPAlsaceTandem.Models;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Helpers
{
    public static class FileCopyHelper
    {
        public static async Task<bool> Copy<T>(FileCollection<T> files, PassengerViewModel passenger) where T : FileViewModel
        {
            return await Task.Run(() =>
            {
                return true;
            });
        } 
    }
}
