using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Home.Dto
{
    /// <summary>
    /// API 回傳結果
    /// </summary>
    public class getDataDto
    {
        public string result { get; set; }

        /// <summary>
        /// 以哪國貨幣為基準
        /// 預設為台灣 TWD
        /// </summary>
        public string base_code { get; set; }

        public Rates rates { get; set; }

        public List<ddlCurrencyDto> ddlCurrencyDtos { get; set; }
    }

    public class Rates
    {
        /// <summary>
        /// 台幣
        /// </summary>
        public double TWD { get; set; }

        /// <summary>
        /// 澳幣
        /// </summary>
        public double AUD { get; set; }

        /// <summary>
        /// 英鎊
        /// </summary>
        public double GBP { get; set; }

        /// <summary>
        /// 美元
        /// </summary>
        public double USD { get; set; }

        /// <summary>
        /// 日圓
        /// </summary>
        public double JPY { get; set; }

        /// <summary>
        /// 港幣
        /// </summary>
        public double HKD { get; set; }
    }

    public class ddlCurrencyDto
    {
        /// <summary>
        /// 貨幣代號
        /// </summary>
        public string currencyCode { get; set; }

        /// <summary>
        /// 貨幣名稱
        /// </summary>
        public string currencyName { get; set; }

        public decimal rate { get; set; }
    }

}
