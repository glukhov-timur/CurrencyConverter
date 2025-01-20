namespace CurrencyConverter.Models
{
    public class Currency
    {
        public DateTime Date { get; set; }
        public DateTime PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, CurrencyItem> Valute { get; set; }
    }
}
