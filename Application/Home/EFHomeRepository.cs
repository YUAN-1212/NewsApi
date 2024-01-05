using Application.Home.Dto;
using System;
using System.Configuration;
using System.Net; //訪問網路
using System.IO; //接收數據
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Application.Home
{
    public class EFHomeRepository
    {
        private static string key = ConfigurationManager.AppSettings["KEY"].ToString();

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <param name="currency">以哪國貨幣為基準，初始或是空值時以台灣TWD為準</param>
        /// <returns></returns>
        public static getDataDto getData(string currency)
        {
            var data = new getDataDto();

            try
            {
                if (string.IsNullOrEmpty(currency))
                {
                    currency = "TWD";
                }

                var url = "https://open.er-api.com/v6/latest/" + currency + "?apikey=" + key;
                
                WebRequest request = WebRequest.Create(url);

                // 接收
                WebResponse response = request.GetResponse();

                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                string json = streamReader.ReadToEnd();

                // 將 json 轉成 class
                data = JsonConvert.DeserializeObject<getDataDto>(json);

                #region 將幣值轉換成我要的格式
                var obj = JObject.Parse(json);

                // 提取
                var rates = obj.GetValue("rates");

                var jTokenProperties = rates.Children().OfType<JProperty>();
                var list = new List<ddlCurrencyDto>();

                foreach (JProperty property in jTokenProperties)
                {
                    var aa = new ddlCurrencyDto();
                    aa.currencyName = property.Name;
                    aa.rate = Convert.ToDecimal(property.Value);
                    list.Add(aa);
                }

                data.ddlCurrencyDtos = list;
                #endregion

                return data;
            }
            catch(Exception ex)
            {
                throw new Exception("查詢資料時發生錯誤!!" + ex.Message);
            }            
        }

        /// <summary>
        /// 貨幣
        /// </summary>
        public static List<ddlCurrencyDto> getCurrencyDto()
        {
            List<ddlCurrencyDto> dataList = new List<ddlCurrencyDto>();

            dataList.Add(new ddlCurrencyDto() { currencyCode = "TWD", currencyName = "台幣" });
            dataList.Add(new ddlCurrencyDto() { currencyCode = "AUD", currencyName = "澳幣" });
            dataList.Add(new ddlCurrencyDto() { currencyCode = "GBP", currencyName = "英鎊" });
            dataList.Add(new ddlCurrencyDto() { currencyCode = "USD", currencyName = "美元" });
            dataList.Add(new ddlCurrencyDto() { currencyCode = "JPY", currencyName = "日圓" });
            dataList.Add(new ddlCurrencyDto() { currencyCode = "HKD", currencyName = "港幣" });

            return dataList;
        }
    }
}
