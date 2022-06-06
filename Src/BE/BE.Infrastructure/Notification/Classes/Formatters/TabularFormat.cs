using BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BE.Infrastructure.Notification.Classes.Formatters
{
    public class TabularFormat
    {
        public static string Display(List<CartItem>items)
        {
            var tbl = new StringBuilder();
            tbl.AppendLine($"<div>Name: {items[0].User.Name} {items[0].User.Surname}</div>");
            tbl.AppendLine($"<div>Date: {DateTime.Now.Date.ToString("dd-MM-yyyy")}</div>");
            tbl.AppendLine("</div>---------------------------------------------------</div>");
            tbl.AppendLine("<table style='border:1px solid tomato; width:80%'>");
            tbl.AppendLine("<thead>");
            
            tbl.AppendLine($"<td>Name</td>");
            tbl.AppendLine($"<td>Price</td>");
            tbl.AppendLine($"<td>Quantity</td>");
            tbl.AppendLine($"<td>Order Number</td>");

            tbl.AppendLine("</thead>");
            tbl.AppendLine("<tbody>");

            foreach(var item in items)
            {
                tbl.AppendLine("<tr>");
                tbl.AppendLine($"<td style='width: 20%; margin-left: 20px;'>{item.Product.Name}</td>");
                tbl.AppendLine($"<td style='width: 20%; margin-left: 20px;'>{item.Price}</td>");
                tbl.AppendLine($"<td style='width: 20%; margin-left: 20px;'>{item.Qty}</td>");
                tbl.AppendLine($"<td style='width: 20%; margin-left: 20px;'>{item.OrderNr}</td>");
                tbl.AppendLine("</tr>");
            }

            tbl.AppendLine("</tbody>");
            tbl.AppendLine("</table>");

            return tbl.ToString();
        }
    }
}
