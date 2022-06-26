using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.InWallet.Domain.Entity
{
    public class Attributes
    {
        public string identifier { get; set; }
        public string name { get; set; }
        public double last { get; set; }
        public double change { get; set; }
        public double percentChange { get; set; }
        public double previousClose { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double volume { get; set; }
        public string dateTime { get; set; }
        public string quoteInfo { get; set; }
        public double? close { get; set; }
        public object changeFromPreviousClose { get; set; }
        public object percentChangeFromPreviousClose { get; set; }
        public double? low52Week { get; set; }
        public double? high52Week { get; set; }
        public double? extendedHoursPrice { get; set; }
        public double? extendedHoursChange { get; set; }
        public double? extendedHoursPercentChange { get; set; }
        public string extendedHoursDateTime { get; set; }
        public string extendedHoursType { get; set; }
        public string sourceAPI { get; set; }
        public DateTime updated_at { get; set; }
    }
}
