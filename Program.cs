using System.Configuration;
using CurrencyConverter.Models;
using CurrencyConverter.Service;

Console.WriteLine(@"
█──█─████─█──█─████──███─████─███─███─████────████──████───██─█──██──███
█─█──█──█─█──█─█──██─█───█──█──█──█───█──█────█──██─█──█──█─█─█─█──█──█─
██───█──█─████─████──███─████──█──███─████────████──████─█──█─████─█──█─
█─█──█──█─█──█─█──██─█───█─────█──█───█───────█──██─█──█─█──█─█─█──█──█─
█──█─████─█──█─████──███─█─────█──███─█───────████──█──█─█──█─█──██───█─"
);

var apiService = new APIService();
while (true)
{
    Console.WriteLine("\nВыберите количество рублей");
    Console.WriteLine("Введите число и нажмите ENTER");
    var inputValue = Console.ReadLine();
    if (!long.TryParse(inputValue, out long inputNum))
    {
        Console.WriteLine("Ошибка ввода. Введите число.");
        continue;
    }

    Console.WriteLine("Выберите конечную валюту");
    #region CurrencyCodes
    Console.WriteLine(@"
AUD: Австралийский доллар
AZN: Азербайджанский манат
GBP: Фунт стерлингов
AMD: Армянских драмов
BYN: Белорусский рубль
BGN: Болгарский лев
BRL: Бразильский реал
HUF: Форинтов
VND: Донгов
HKD: Гонконгский доллар
GEL: Лари
DKK: Датская крона
AED: Дирхам ОАЭ
USD: Доллар США
EUR: Евро
EGP: Египетских фунтов
INR: Индийских рупий
IDR: Рупий
KZT: Тенге
CAD: Канадский доллар
QAR: Катарский риал
KGS: Сомов
CNY: Юань
MDL: Молдавских леев
NZD: Новозеландский доллар
NOK: Норвежских крон
PLN: Злотый
RON: Румынский лей
XDR: СДР (специальные права заимствования)
SGD: Сингапурский доллар
TJS: Сомони
THB: Батов
TRY: Турецких лир
TMT: Новый туркменский манат
UZS: Узбекских сумов
UAH: Гривен
CZK: Чешских крон
SEK: Шведских крон
CHF: Швейцарский франк
RSD: Сербских динаров
ZAR: Рэндов
KRW: Вон
JPY: Иен
");
    #endregion
    Console.WriteLine("Введите код валюты и нажмите ENTER");
    var code = Console.ReadLine();
    string apiUrl = ConfigurationManager.AppSettings["ApiUrl"]!;
    var currency = await apiService.GetCurrencyAsync(apiUrl);
    if (!ResultCurrency(inputNum, currency, code!))
        continue;

    Console.WriteLine("\nЕще раз? Нажмите ENTER.");
    Console.ReadLine();
}

bool ResultCurrency(long input, Currency currency, string code)
{
    try
    {
        var result = input / currency.Valute[code.ToUpper()].Value;
        Console.WriteLine($"Итог: {result} ({code})");
        return true;
    }
    catch (Exception)
    {
        Console.WriteLine("Ошибка ввода кода валюты попробуйте еще раз.");
        return false;
    }
}
