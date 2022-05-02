using System.Linq;
using OpenQA.Selenium;

namespace WebDriverHelpers
{
    public static class WebElementTableExtensions
    {
        public static IWebElement GetTableCell(this IWebElement tableElement, int rowIndex, int columnIndex)
        {
            // Example Table XPATH:   //*[@id="customers"]/tbody/tr[2]/td[1]
            var cell = tableElement.FindElement(By.XPath($"//tbody/tr[{rowIndex}]/td[{columnIndex}]"));
            return cell;
        }

        public static IWebElement GetTableCell(this IWebDriver driver, string tableId, int rowIndex, int columnIndex)
        {
            var table = driver.FindElement(By.Id(tableId));
            return GetTableCell(table, rowIndex, columnIndex);
        }

        public static IWebElement[] GetRows(this IWebElement tableElement)
        {
            var rows = tableElement.FindElements(By.XPath("//tbody/tr"));
            return rows?.ToArray();
        }
    }
}