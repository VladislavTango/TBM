using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuarterService.Domain.Enums;
using QuarterService.Infrastructure.Interfaces;
using QuarterService.Infrastructure.Static;
using System.Globalization;

namespace QuarterService.Infrastructure.Service
{
    public class BinanceClient : IBinanceClient
    {
        private readonly HttpClient _httpClient;

        private const int InvalidInterval = -1120;
        private const int InvalidSymbol = -1121;

        public BinanceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Decimal> GetCandlestickHighPrice(string symbol, TimeFrameEnum timeFrame)
        {
            string timeFrameStr = timeFrame.GetEnumDescription();

            string url = $"https://fapi.binance.com/fapi/v1/klines?symbol={symbol}&interval={timeFrameStr}&limit=500";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody.Contains("\"code\""))
            {
                JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(responseBody);
                int errorCode = jsonResponse["code"].ToObject<int>();

                if (errorCode == InvalidInterval)
                {
                     if(timeFrameStr == "1M")
                        return await GetCandlestickHighPrice(symbol, 0);
                     else
                        return await GetCandlestickHighPrice(symbol, timeFrame+1);

                }
                if (errorCode == InvalidSymbol) 
                {
                    if (symbol.Split("_").Length < 2) throw new Exception("нет такой валюты");

                    string correctSymbol = await FindNearestContract(symbol);
                    return await GetCandlestickHighPrice(correctSymbol, timeFrame);
                }
                throw new Exception($"неизвестаня ошибка API {errorCode}");
            }

            var HighPrice = JsonConvert.DeserializeObject<List<object[]>>(responseBody);

            return Convert.ToDecimal(HighPrice.Last()[2].ToString().Replace(".",",")); 
        }
        private async Task<string> FindNearestContract(string targetSymbol)
        {
            string url = "https://fapi.binance.com/fapi/v1/exchangeInfo";

            if (!targetSymbol.Contains("_"))
                throw new Exception("Некорректный формат символа");

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Ошибка запроса: {response.StatusCode}");

            string json = await response.Content.ReadAsStringAsync();
            JObject data = JsonConvert.DeserializeObject<JObject>(json);

            JArray symbolsArray = (JArray)data["symbols"];
            List<string> allSymbols = symbolsArray.Select(s => s["symbol"].ToString()).ToList();

            string baseSymbol = targetSymbol.Split('_')[0];
            string targetDateStr = targetSymbol.Split('_')[1];

            if (!DateTime.TryParseExact(targetDateStr, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime targetDate))
                throw new Exception("Неверный формат даты в symbol");

            var contracts = allSymbols
                .Where(s => s.StartsWith(baseSymbol + "_") && s.Length == baseSymbol.Length + 7)
                .Select(s => new
                {
                    Symbol = s,
                    Date = DateTime.TryParseExact(s.Split('_')[1], "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt) ? dt : (DateTime?)null
                })
                .Where(x => x.Date.HasValue)
                .OrderBy(x => Math.Abs((x.Date.Value - targetDate).Ticks))
                .FirstOrDefault();

            return contracts?.Symbol ?? "Не найдено";
        }
    }
}

