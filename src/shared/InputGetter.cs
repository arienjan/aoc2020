using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Shared
{
    public static partial class InputGetter
    {
        private static readonly HttpClient httpClient;
        
        static InputGetter() {
            var sessionId = session;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Cookie", sessionId);
        }
        
        public static async Task<string> ReadInputAsString(int jaar, int dag) {
            var input = await httpClient.GetAsync($"http://adventofcode.com/{jaar}/day/{dag}/input");
            var bla = await input.Content.ReadAsStringAsync();
            bla = bla.Replace("\r", "");
            bla = bla.Replace("\n", "");
            return bla;
        }
        
        public static async Task<IEnumerable<T>> ReadInputAsLines<T>(int year, int day) {
            var input = await httpClient.GetAsync($"http://adventofcode.com/{year}/day/{day}/input");
            var inputBody = await input.Content.ReadAsStringAsync();
            var inputLines = inputBody.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None);

            var lines = inputLines.Take(inputLines.Count() - 1)
                .Select(l => (T)Convert.ChangeType(l, typeof(T)));

            return lines;
        }
    }
}
