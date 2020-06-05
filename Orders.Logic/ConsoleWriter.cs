using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Logic
{
    #region Console Writer...

    /// <summary>
    /// Threading is enabled to allow for both non-blocking fire-and-forget and calling-thread feedback.
    /// </summary>
    public class ConsoleWriter<T> : IWriter<T>
    {
        public async Task<int> Output(IEnumerable<T> items)
        {
            try
            {
                foreach (var i in items)
                {
                    Console.WriteLine(i.ToString());
                }
            }
            catch (Exception ex)
            {
                // TODO: Log the error to the configured output
                return await Task.FromResult(0);
            }

            return await Task.FromResult(items.Count());
        }
    }

    #endregion
}